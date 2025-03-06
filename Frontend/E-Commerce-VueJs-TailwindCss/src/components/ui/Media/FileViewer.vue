<template>
  <div class="rounded-lg border border-zinc-800 bg-zinc-900" :class="className">
    <!-- Header -->
    <div class="flex items-center justify-between border-b border-zinc-800 p-4">
      <div class="flex items-center gap-3">
        <!-- File Icon -->
        <div class="rounded-lg bg-zinc-800 p-2">
          <component :is="fileIcon" class="h-6 w-6 text-zinc-400" />
        </div>

        <!-- File Info -->
        <div class="min-w-0">
          <h3 class="truncate text-sm font-medium text-white">
            {{ fileName }}
          </h3>
          <p class="text-xs text-zinc-400">
            {{ fileType }} · {{ formatFileSize(fileSize) }}
          </p>
        </div>
      </div>

      <!-- Actions -->
      <div class="flex items-center gap-2">
        <button
          v-if="downloadable"
          type="button"
          class="rounded-lg bg-zinc-800 p-2 text-zinc-400 hover:text-white"
          @click="handleDownload"
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
              d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-4l-4 4m0 0l-4-4m4 4V4"
            />
          </svg>
        </button>
        <button
          v-if="closable"
          type="button"
          class="rounded-lg bg-zinc-800 p-2 text-zinc-400 hover:text-white"
          @click="$emit('close')"
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
              d="M6 18L18 6M6 6l12 12"
            />
          </svg>
        </button>
      </div>
    </div>

    <!-- Content -->
    <div class="relative">
      <!-- Image Preview -->
      <template v-if="isImage">
        <img
          :src="src"
          :alt="fileName"
          class="w-full"
          :class="aspectRatioClasses[aspectRatio]"
          @load="handleLoad"
        />
      </template>

      <!-- PDF Preview -->
      <template v-else-if="isPDF">
        <iframe
          :src="src"
          class="w-full"
          :class="aspectRatioClasses[aspectRatio]"
          @load="handleLoad"
        />
      </template>

      <!-- Video Preview -->
      <template v-else-if="isVideo">
        <video
          :src="src"
          controls
          class="w-full"
          :class="aspectRatioClasses[aspectRatio]"
          @loadeddata="handleLoad"
        />
      </template>

      <!-- Audio Preview -->
      <template v-else-if="isAudio">
        <audio
          :src="src"
          controls
          class="mt-4 w-full"
          @loadeddata="handleLoad"
        />
      </template>

      <!-- Text Preview -->
      <template v-else-if="isText">
        <pre
          class="max-h-96 overflow-auto p-4 text-sm text-zinc-300"
          v-html="content"
        />
      </template>

      <!-- Unsupported Format -->
      <template v-else>
        <div class="flex items-center justify-center p-8">
          <p class="text-sm text-zinc-400">
            Bu dosya formatı önizleme için desteklenmiyor.
          </p>
        </div>
      </template>

      <!-- Loading Overlay -->
      <div
        v-if="loading"
        class="absolute inset-0 flex items-center justify-center bg-zinc-900/75"
      >
        <div class="h-12 w-12 animate-spin rounded-full border-4 border-zinc-700 border-t-white" />
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

interface Props {
  src: string
  fileName: string
  fileSize: number
  fileType?: string
  content?: string
  aspectRatio?: '1:1' | '4:3' | '16:9' | '21:9'
  downloadable?: boolean
  closable?: boolean
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  fileType: '',
  aspectRatio: '16:9',
  downloadable: true,
  closable: true,
  className: ''
})

const emit = defineEmits(['close', 'load', 'error'])

const loading = ref(true)

// Dosya türü kontrolü
const isImage = computed(() =>
  /\.(jpg|jpeg|png|gif|webp)$/i.test(props.fileName)
)
const isPDF = computed(() => /\.pdf$/i.test(props.fileName))
const isVideo = computed(() =>
  /\.(mp4|webm|ogg)$/i.test(props.fileName)
)
const isAudio = computed(() =>
  /\.(mp3|wav|ogg)$/i.test(props.fileName)
)
const isText = computed(() =>
  /\.(txt|md|json|xml|html|css|js|ts)$/i.test(props.fileName)
)

// Dosya ikonu
const fileIcon = computed(() => ({
  template: `
    <svg v-if="${isImage.value}" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 16l4.586-4.586a2 2 0 012.828 0L16 16m-2-2l1.586-1.586a2 2 0 012.828 0L20 14m-6-6h.01M6 20h12a2 2 0 002-2V6a2 2 0 00-2-2H6a2 2 0 00-2 2v12a2 2 0 002 2z" />
    </svg>
    <svg v-else-if="${isPDF.value}" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M7 21h10a2 2 0 002-2V9.414a1 1 0 00-.293-.707l-5.414-5.414A1 1 0 0012.586 3H7a2 2 0 00-2 2v14a2 2 0 002 2z" />
    </svg>
    <svg v-else-if="${isVideo.value}" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 10l4.553-2.276A1 1 0 0121 8.618v6.764a1 1 0 01-1.447.894L15 14M5 18h8a2 2 0 002-2V8a2 2 0 00-2-2H5a2 2 0 00-2 2v8a2 2 0 002 2z" />
    </svg>
    <svg v-else-if="${isAudio.value}" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 19V6l12-3v13M9 19c0 1.105-1.343 2-3 2s-3-.895-3-2 1.343-2 3-2 3 .895 3 2zm12-3c0 1.105-1.343 2-3 2s-3-.895-3-2 1.343-2 3-2 3 .895 3 2zM9 10l12-3" />
    </svg>
    <svg v-else-if="${isText.value}" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
    </svg>
    <svg v-else class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
      <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M7 21h10a2 2 0 002-2V9.414a1 1 0 00-.293-.707l-5.414-5.414A1 1 0 0012.586 3H7a2 2 0 00-2 2v14a2 2 0 002 2z" />
    </svg>
  `
}))

const aspectRatioClasses = {
  '1:1': 'aspect-square',
  '4:3': 'aspect-[4/3]',
  '16:9': 'aspect-video',
  '21:9': 'aspect-[21/9]'
}

// Dosya boyutu formatı
const formatFileSize = (bytes: number) => {
  if (bytes === 0) return '0 B'
  const k = 1024
  const sizes = ['B', 'KB', 'MB', 'GB', 'TB']
  const i = Math.floor(Math.log(bytes) / Math.log(k))
  return `${parseFloat((bytes / Math.pow(k, i)).toFixed(2))} ${sizes[i]}`
}

const handleLoad = () => {
  loading.value = false
  emit('load')
}

const handleError = () => {
  loading.value = false
  emit('error')
}

const handleDownload = () => {
  const link = document.createElement('a')
  link.href = props.src
  link.download = props.fileName
  document.body.appendChild(link)
  link.click()
  document.body.removeChild(link)
}
</script> 