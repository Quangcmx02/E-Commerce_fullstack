<template>
  <div class="relative overflow-hidden rounded-lg bg-zinc-900" :class="className">
    <!-- Video Container -->
    <div class="relative aspect-video">
      <video
        ref="videoRef"
        :src="src"
        :poster="poster"
        :autoplay="autoplay"
        :loop="loop"
        :muted="muted"
        :playsinline="playsinline"
        class="h-full w-full"
        @timeupdate="handleTimeUpdate"
        @loadedmetadata="handleLoadedMetadata"
        @ended="handleEnded"
      />

      <!-- Loading Spinner -->
      <div v-if="loading" class="absolute inset-0 flex items-center justify-center">
        <div class="h-12 w-12 animate-spin rounded-full border-4 border-zinc-500 border-t-white" />
      </div>

      <!-- Play/Pause Overlay -->
      <div
        v-if="!hideControls"
        class="absolute inset-0 flex items-center justify-center bg-black/50 opacity-0 transition-opacity hover:opacity-100"
        @click="togglePlay"
      >
        <button
          type="button"
          class="rounded-full bg-white/25 p-4 text-white backdrop-blur-sm transition-transform hover:scale-110"
        >
          <svg
            v-if="!isPlaying"
            class="h-8 w-8"
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
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
            />
          </svg>
          <svg
            v-else
            class="h-8 w-8"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M10 9v6m4-6v6m7-3a9 9 0 11-18 0 9 9 0 0118 0z"
            />
          </svg>
        </button>
      </div>

      <!-- Controls -->
      <div
        v-if="!hideControls"
        class="absolute bottom-0 left-0 right-0 bg-gradient-to-t from-black/75 to-transparent p-4 opacity-0 transition-opacity hover:opacity-100"
      >
        <!-- Progress Bar -->
        <div class="mb-4">
          <input
            type="range"
            :value="progress"
            min="0"
            max="100"
            step="0.1"
            class="h-1 w-full cursor-pointer appearance-none rounded-full bg-zinc-600"
            @input="handleSeek"
          />
        </div>

        <!-- Controls Bar -->
        <div class="flex items-center justify-between">
          <div class="flex items-center gap-4">
            <!-- Play/Pause Button -->
            <button
              type="button"
              class="text-white hover:text-zinc-300"
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
                class="text-white hover:text-zinc-300"
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
                class="h-1 w-20 cursor-pointer appearance-none rounded-full bg-zinc-600"
              />
            </div>

            <!-- Time Display -->
            <div class="text-sm text-white">
              {{ formatTime(currentTime) }} / {{ formatTime(duration) }}
            </div>
          </div>

          <div class="flex items-center gap-4">
            <!-- Playback Speed -->
            <select
              v-model="playbackRate"
              class="rounded bg-transparent text-sm text-white hover:text-zinc-300 focus:outline-none"
            >
              <option value="0.5">0.5x</option>
              <option value="1">1x</option>
              <option value="1.5">1.5x</option>
              <option value="2">2x</option>
            </select>

            <!-- Full Screen Button -->
            <button
              type="button"
              class="text-white hover:text-zinc-300"
              @click="toggleFullscreen"
            >
              <svg
                class="h-6 w-6"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M4 8V4m0 0h4M4 4l5 5m11-1V4m0 0h-4m4 0l-5 5M4 16v4m0 0h4m-4 0l5-5m11 5l-5-5m5 5v-4m0 4h-4"
                />
              </svg>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch, onMounted, onUnmounted } from 'vue'

interface Props {
  src: string
  poster?: string
  autoplay?: boolean
  loop?: boolean
  muted?: boolean
  playsinline?: boolean
  hideControls?: boolean
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  autoplay: false,
  loop: false,
  muted: false,
  playsinline: true,
  hideControls: false,
  className: ''
})

const emit = defineEmits(['play', 'pause', 'ended', 'timeupdate', 'volumechange'])

const videoRef = ref<HTMLVideoElement | null>(null)
const isPlaying = ref(false)
const loading = ref(true)
const currentTime = ref(0)
const duration = ref(0)
const progress = ref(0)
const volume = ref(1)
const playbackRate = ref(1)

// Video kontrolleri
const togglePlay = () => {
  if (!videoRef.value) return
  if (isPlaying.value) {
    videoRef.value.pause()
    isPlaying.value = false
    emit('pause')
  } else {
    videoRef.value.play()
    isPlaying.value = true
    emit('play')
  }
}

const toggleMute = () => {
  if (!videoRef.value) return
  videoRef.value.muted = !videoRef.value.muted
}

const handleTimeUpdate = () => {
  if (!videoRef.value) return
  currentTime.value = videoRef.value.currentTime
  progress.value = (currentTime.value / duration.value) * 100
  emit('timeupdate', currentTime.value)
}

const handleLoadedMetadata = () => {
  if (!videoRef.value) return
  duration.value = videoRef.value.duration
  loading.value = false
}

const handleSeek = (event: Event) => {
  if (!videoRef.value) return
  const target = event.target as HTMLInputElement
  const time = (parseFloat(target.value) / 100) * duration.value
  videoRef.value.currentTime = time
}

const handleEnded = () => {
  isPlaying.value = false
  emit('ended')
}

const toggleFullscreen = () => {
  if (!videoRef.value) return
  if (document.fullscreenElement) {
    document.exitFullscreen()
  } else {
    videoRef.value.requestFullscreen()
  }
}

// Zaman formatı
const formatTime = (time: number) => {
  const minutes = Math.floor(time / 60)
  const seconds = Math.floor(time % 60)
  return `${minutes}:${seconds.toString().padStart(2, '0')}`
}

// Volume ve playback rate izleme
watch(volume, (newValue) => {
  if (!videoRef.value) return
  videoRef.value.volume = newValue
  emit('volumechange', newValue)
})

watch(playbackRate, (newValue) => {
  if (!videoRef.value) return
  videoRef.value.playbackRate = Number(newValue)
})

// Temizlik
onUnmounted(() => {
  if (videoRef.value) {
    videoRef.value.pause()
  }
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