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

    <!-- Date Picker Container -->
    <div class="relative">
      <input
        :id="id"
        type="date"
        v-model="inputValue"
        :class="[
          'w-full rounded-md bg-zinc-900 border border-zinc-800 text-white placeholder:text-zinc-400',
          'focus:outline-none focus:ring-2 focus:ring-zinc-700 focus:ring-offset-2 focus:ring-offset-zinc-900',
          'disabled:cursor-not-allowed disabled:opacity-50',
          error ? 'border-red-500 focus:ring-red-500' : 'hover:border-zinc-700',
          sizeClasses[size],
          variantClasses[variant],
          className
        ]"
        :min="min"
        :max="max"
        :disabled="disabled"
        :required="required"
        @input="handleInput"
        @blur="$emit('blur', $event)"
        @focus="$emit('focus', $event)"
      />

      <!-- Calendar Icon -->
      <div class="absolute inset-y-0 right-0 flex items-center pr-3 pointer-events-none">
        <svg
          class="w-5 h-5 text-zinc-400"
          xmlns="http://www.w3.org/2000/svg"
          viewBox="0 0 20 20"
          fill="currentColor"
        >
          <path
            fill-rule="evenodd"
            d="M6 2a1 1 0 00-1 1v1H4a2 2 0 00-2 2v10a2 2 0 002 2h12a2 2 0 002-2V6a2 2 0 00-2-2h-1V3a1 1 0 10-2 0v1H7V3a1 1 0 00-1-1zm0 5a1 1 0 000 2h8a1 1 0 100-2H6z"
            clip-rule="evenodd"
          />
        </svg>
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
import { computed } from 'vue'

type SizeType = 'sm' | 'md' | 'lg'
type VariantType = 'default' | 'filled' | 'outline' | 'ghost'

interface Props {
  modelValue?: string
  id?: string
  label?: string
  min?: string
  max?: string
  variant?: VariantType
  size?: SizeType
  disabled?: boolean
  required?: boolean
  error?: string
  helperText?: string
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  modelValue: '',
  id: () => 'datepicker-' + Math.random().toString(36).slice(2, 11),
  variant: 'default',
  size: 'md'
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: string): void
  (e: 'blur', event: FocusEvent): void
  (e: 'focus', event: FocusEvent): void
}>()

const inputValue = computed({
  get: () => props.modelValue,
  set: (value) => emit('update:modelValue', value)
})

const handleInput = (event: Event) => {
  const target = event.target as HTMLInputElement
  emit('update:modelValue', target.value)
}

const sizeClasses: Record<SizeType, string> = {
  sm: 'px-3 py-2 text-sm',
  md: 'px-4 py-3 text-base',
  lg: 'px-4 py-4 text-lg'
}

const variantClasses: Record<VariantType, string> = {
  default: 'bg-zinc-900 border-zinc-800',
  filled: 'bg-zinc-800 border-transparent',
  outline: 'bg-transparent border-zinc-700',
  ghost: 'bg-transparent border-transparent hover:bg-zinc-800'
}
</script>

<style>
/* Özel takvim görünümü için CSS */
input[type="date"]::-webkit-calendar-picker-indicator {
  filter: invert(1);
  opacity: 0.5;
  cursor: pointer;
}

input[type="date"]::-webkit-calendar-picker-indicator:hover {
  opacity: 0.8;
}
</style> 