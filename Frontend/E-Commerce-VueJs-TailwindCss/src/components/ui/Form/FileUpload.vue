<template>
  <div class="w-full">
    <!-- Label -->
    <label
      v-if="label"
      :for="id"
      class="block mb-2 text-sm font-medium text-white"
    >
      {{ label }}
    </label>

    <!-- File Upload Container -->
    <div class="relative">
      <!-- Hidden File Input -->
      <input
        :id="id"
        ref="fileInput"
        type="file"
        :accept="accept"
        :multiple="multiple"
        :disabled="disabled"
        :required="required"
        class="hidden"
        @change="handleFileChange"
      />

      <!-- Upload Zone -->
      <div
        :class="[
          'relative flex flex-col items-center justify-center w-full rounded-md border-2 border-dashed transition-colors',
          'focus-within:outline-none focus-within:ring-2 focus-within:ring-zinc-700 focus-within:ring-offset-2 focus-within:ring-offset-zinc-900',
          'disabled:cursor-not-allowed disabled:opacity-50',
          isDragging ? 'border-zinc-500 bg-zinc-800/50' : 'border-zinc-700 hover:border-zinc-500',
          error ? 'border-red-500' : '',
          sizeClasses[size],
          variantClasses[variant],
          className
        ]"
        @dragenter.prevent="isDragging = true"
        @dragleave.prevent="isDragging = false"
        @dragover.prevent
        @drop.prevent="handleDrop"
        @click="handleZoneClick"
      >
        <!-- Upload Icon -->
        <div class="mb-4">
          <svg
            class="w-10 h-10 text-zinc-400"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M7 16a4 4 0 01-.88-7.903A5 5 0 1115.9 6L16 6a5 5 0 011 9.9M15 13l-3-3m0 0l-3 3m3-3v12"
            />
          </svg>
        </div>

        <!-- Upload Text -->
        <div class="text-center">
          <p class="mb-2 text-sm text-zinc-400">
            <span class="font-semibold">Dosya yüklemek için tıklayın</span> veya sürükleyip bırakın
          </p>
          <p class="text-xs text-zinc-500">
            {{ acceptText }}
          </p>
        </div>

        <!-- Selected Files -->
        <div v-if="selectedFiles.length > 0" class="w-full mt-4 space-y-2">
          <div
            v-for="(file, index) in selectedFiles"
            :key="index"
            class="flex items-center justify-between p-2 bg-zinc-800 rounded"
          >
            <div class="flex items-center space-x-2">
              <svg
                class="w-4 h-4 text-zinc-400"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M4 4a2 2 0 012-2h4.586A2 2 0 0112 2.586L15.414 6A2 2 0 0116 7.414V16a2 2 0 01-2 2H6a2 2 0 01-2-2V4z"
                  clip-rule="evenodd"
                />
              </svg>
              <span class="text-sm text-zinc-300">{{ file.name }}</span>
            </div>
            <button
              type="button"
              class="p-1 text-zinc-400 hover:text-zinc-300"
              @click="removeFile(index)"
            >
              <svg
                class="w-4 h-4"
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 20 20"
                fill="currentColor"
              >
                <path
                  fill-rule="evenodd"
                  d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                  clip-rule="evenodd"
                />
              </svg>
            </button>
          </div>
        </div>

        <!-- Progress Bar -->
        <div
          v-if="progress > 0"
          class="w-full h-1 mt-4 bg-zinc-700 rounded-full overflow-hidden"
        >
          <div
            class="h-full bg-zinc-500 transition-all duration-300"
            :style="{ width: `${progress}%` }"
          />
        </div>
      </div>
    </div>

    <!-- Error Text -->
    <div
      v-if="error"
      class="mt-2 text-sm text-red-500"
    >
      {{ error }}
    </div>

    <!-- Helper Text -->
    <div
      v-else-if="helperText"
      class="mt-2 text-sm text-zinc-400"
    >
      {{ helperText }}
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

type SizeType = 'sm' | 'md' | 'lg'
type VariantType = 'default' | 'filled' | 'outline' | 'ghost'

interface Props {
  modelValue?: File[]
  id?: string
  label?: string
  accept?: string
  multiple?: boolean
  maxSize?: number // MB cinsinden
  variant?: VariantType
  size?: SizeType
  disabled?: boolean
  required?: boolean
  error?: string
  helperText?: string
  className?: string
  progress?: number
}

const props = withDefaults(defineProps<Props>(), {
  modelValue: () => [],
  id: () => 'fileupload-' + Math.random().toString(36).slice(2, 11),
  accept: '*/*',
  multiple: false,
  maxSize: 5,
  variant: 'default',
  size: 'md',
  progress: 0
})

const emit = defineEmits<{
  (e: 'update:modelValue', files: File[]): void
  (e: 'error', message: string): void
}>()

const fileInput = ref<HTMLInputElement | null>(null)
const isDragging = ref(false)
const selectedFiles = ref<File[]>(props.modelValue || [])
const progress = ref(props.progress)

// Kabul edilen dosya tiplerini insan tarafından okunabilir formata çevirme
const acceptText = computed(() => {
  if (props.accept === '*/*') return 'Tüm dosya tipleri kabul edilir'
  
  const types = props.accept.split(',').map(type => {
    return type
      .trim()
      .replace('image/*', 'Resim dosyaları')
      .replace('video/*', 'Video dosyaları')
      .replace('audio/*', 'Ses dosyaları')
      .replace('application/pdf', 'PDF dosyaları')
      .replace('.doc,.docx', 'Word dosyaları')
      .replace('.xls,.xlsx', 'Excel dosyaları')
  })
  
  return `Kabul edilen dosya tipleri: ${types.join(', ')}`
})

// Dosya seçildiğinde
const handleFileChange = (event: Event) => {
  const input = event.target as HTMLInputElement
  if (!input.files?.length) return
  
  const files = Array.from(input.files)
  validateAndAddFiles(files)
}

// Dosya sürüklenip bırakıldığında
const handleDrop = (event: DragEvent) => {
  isDragging.value = false
  if (!event.dataTransfer?.files.length) return
  
  const files = Array.from(event.dataTransfer.files)
  validateAndAddFiles(files)
}

// Upload zone'a tıklandığında
const handleZoneClick = () => {
  if (!props.disabled && fileInput.value) {
    fileInput.value.click()
  }
}

// Dosyaları doğrulama ve ekleme
const validateAndAddFiles = (files: File[]) => {
  const validFiles = files.filter(file => {
    // Dosya tipi kontrolü
    if (props.accept !== '*/*') {
      const acceptedTypes = props.accept.split(',').map(type => type.trim())
      const isValidType = acceptedTypes.some(type => {
        if (type.includes('/*')) {
          const [mainType] = type.split('/')
          return file.type.startsWith(mainType)
        }
        return file.type === type || type.includes(file.name.split('.').pop() || '')
      })
      
      if (!isValidType) {
        emit('error', `"${file.name}" desteklenmeyen bir dosya tipi`)
        return false
      }
    }
    
    // Dosya boyutu kontrolü
    const maxSizeInBytes = props.maxSize * 1024 * 1024
    if (file.size > maxSizeInBytes) {
      emit('error', `"${file.name}" dosyası çok büyük. Maksimum ${props.maxSize}MB olmalı`)
      return false
    }
    
    return true
  })
  
  if (!props.multiple) {
    selectedFiles.value = validFiles.slice(-1)
  } else {
    selectedFiles.value = [...selectedFiles.value, ...validFiles]
  }
  
  emit('update:modelValue', selectedFiles.value)
}

// Dosya silme
const removeFile = (index: number) => {
  selectedFiles.value.splice(index, 1)
  emit('update:modelValue', selectedFiles.value)
}

const sizeClasses: Record<SizeType, string> = {
  sm: 'p-4',
  md: 'p-6',
  lg: 'p-8'
}

const variantClasses: Record<VariantType, string> = {
  default: 'bg-zinc-900',
  filled: 'bg-zinc-800',
  outline: 'bg-transparent',
  ghost: 'bg-transparent border-none hover:bg-zinc-800/50'
}
</script>

<style scoped>
.file-upload-zone {
  transition: all 0.2s ease;
}

.file-upload-zone:hover {
  transform: translateY(-1px);
}

.file-upload-zone:active {
  transform: translateY(0);
}
</style> 