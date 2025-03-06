<template>
  <div class="rounded-lg bg-zinc-900 p-4" :class="className">
    <audio
      ref="audioRef"
      :src="src"
      :autoplay="autoplay"
      :loop="loop"
      :muted="muted"
      @timeupdate="handleTimeUpdate"
      @loadedmetadata="handleLoadedMetadata"
      @ended="handleEnded"
      class="hidden"
    />

    <!-- Audio Info -->
    <div class="mb-4 flex items-center gap-4">
      <!-- Cover Image -->
      <div v-if="cover" class="h-16 w-16 flex-shrink-0 overflow-hidden rounded-md">
        <img :src="cover" :alt="title" class="h-full w-full object-cover" />
      </div>

      <!-- Title & Artist -->
      <div class="flex-1 min-w-0">
        <h3 class="truncate text-lg font-medium text-white">{{ title }}</h3>
        <p class="truncate text-sm text-zinc-400">{{ artist }}</p>
      </div>
    </div>

    <!-- Progress Bar -->
    <div class="mb-4">
      <div class="flex items-center gap-2">
        <span class="text-sm text-zinc-400">{{ formatTime(currentTime) }}</span>
        <div class="flex-1">
          <input
            type="range"
            :value="progress"
            min="0"
            max="100"
            step="0.1"
            class="h-1 w-full cursor-pointer appearance-none rounded-full bg-zinc-700"
            @input="handleSeek"
          />
        </div>
        <span class="text-sm text-zinc-400">{{ formatTime(duration) }}</span>
      </div>
    </div>

    <!-- Controls -->
    <div class="flex items-center justify-between">
      <div class="flex items-center gap-4">
        <!-- Play/Pause Button -->
        <button
          type="button"
          class="rounded-full bg-white p-3 text-black hover:bg-zinc-200"
          @click="togglePlay"
        >
          <svg
            v-if="!isPlaying"
            class="h-6 w-6"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M14.752 11.168l-3.197-2.132A1 1 0 0010 9.87v4.263a1 1 0 001.555.832l3.197-2.132a1 1 0 000-1.664z"
            />
          </svg>
          <svg
            v-else
            class="h-6 w-6"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M10 9v6m4-6v6"
            />
          </svg>
        </button>

        <!-- Volume Control -->
        <div class="flex items-center gap-2">
          <button
            type="button"
            class="text-zinc-400 hover:text-white"
            @click="toggleMute"
          >
            <svg
              v-if="muted || volume === 0"
              class="h-6 w-6"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M5.586 15H4a1 1 0 01-1-1v-4a1 1 0 011-1h1.586l4.707-4.707C10.923 3.663 12 4.109 12 5v14c0 .891-1.077 1.337-1.707.707L5.586 15z"
              />
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M17 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2"
              />
            </svg>
            <svg
              v-else
              class="h-6 w-6"
              fill="none"
              viewBox="0 0 24 24"
              stroke="currentColor"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="M15.536 8.464a5 5 0 010 7.072m2.828-9.9a9 9 0 010 12.728M5.586 15H4a1 1 0 01-1-1v-4a1 1 0 011-1h1.586l4.707-4.707C10.923 3.663 12 4.109 12 5v14c0 .891-1.077 1.337-1.707.707L5.586 15z"
              />
            </svg>
          </button>
          <input
            type="range"
            v-model="volume"
            min="0"
            max="1"
            step="0.1"
            class="h-1 w-20 cursor-pointer appearance-none rounded-full bg-zinc-700"
          />
        </div>
      </div>

      <div class="flex items-center gap-4">
        <!-- Loop Button -->
        <button
          type="button"
          class="text-zinc-400 hover:text-white"
          :class="{ 'text-white': loop }"
          @click="toggleLoop"
        >
          <svg
            class="h-5 w-5"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15"
            />
          </svg>
        </button>

        <!-- Playback Speed -->
        <select
          v-model="playbackRate"
          class="rounded bg-transparent text-sm text-zinc-400 hover:text-white focus:outline-none"
        >
          <option value="0.5">0.5x</option>
          <option value="1">1x</option>
          <option value="1.5">1.5x</option>
          <option value="2">2x</option>
        </select>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'

interface Props {
  src: string
  title?: string
  artist?: string
  cover?: string
  autoplay?: boolean
  loop?: boolean
  muted?: boolean
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  title: '',
  artist: '',
  autoplay: false,
  loop: false,
  muted: false,
  className: ''
})

const emit = defineEmits(['play', 'pause', 'ended', 'timeupdate', 'volumechange'])

const audioRef = ref<HTMLAudioElement | null>(null)
const isPlaying = ref(false)
const currentTime = ref(0)
const duration = ref(0)
const progress = ref(0)
const volume = ref(1)
const playbackRate = ref(1)

// Audio kontrolleri
const togglePlay = () => {
  if (!audioRef.value) return
  if (isPlaying.value) {
    audioRef.value.pause()
    isPlaying.value = false
    emit('pause')
  } else {
    audioRef.value.play()
    isPlaying.value = true
    emit('play')
  }
}

const toggleMute = () => {
  if (!audioRef.value) return
  audioRef.value.muted = !audioRef.value.muted
}

const toggleLoop = () => {
  if (!audioRef.value) return
  audioRef.value.loop = !audioRef.value.loop
}

const handleTimeUpdate = () => {
  if (!audioRef.value) return
  currentTime.value = audioRef.value.currentTime
  progress.value = (currentTime.value / duration.value) * 100
  emit('timeupdate', currentTime.value)
}

const handleLoadedMetadata = () => {
  if (!audioRef.value) return
  duration.value = audioRef.value.duration
}

const handleSeek = (event: Event) => {
  if (!audioRef.value) return
  const target = event.target as HTMLInputElement
  const time = (parseFloat(target.value) / 100) * duration.value
  audioRef.value.currentTime = time
}

const handleEnded = () => {
  isPlaying.value = false
  emit('ended')
}

// Zaman formatı
const formatTime = (time: number) => {
  const minutes = Math.floor(time / 60)
  const seconds = Math.floor(time % 60)
  return `${minutes}:${seconds.toString().padStart(2, '0')}`
}

// Volume ve playback rate izleme
watch(volume, (newValue) => {
  if (!audioRef.value) return
  audioRef.value.volume = newValue
  emit('volumechange', newValue)
})

watch(playbackRate, (newValue) => {
  if (!audioRef.value) return
  audioRef.value.playbackRate = Number(newValue)
})
</script>

<style scoped>
input[type='range'] {
  @apply accent-white;
}

input[type='range']::-webkit-slider-thumb {
  @apply h-3 w-3 cursor-pointer appearance-none rounded-full bg-white;
}

select option {
  @apply bg-zinc-800;
}
</style> 