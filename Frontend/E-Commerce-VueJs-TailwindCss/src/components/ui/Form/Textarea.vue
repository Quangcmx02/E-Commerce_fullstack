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

    <!-- Textarea Container -->
    <div class="relative">
      <textarea
        :id="id"
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
        :placeholder="placeholder"
        :rows="rows"
        :disabled="disabled"
        :required="required"
        @input="$emit('update:modelValue', ($event.target as HTMLTextAreaElement).value)"
        @blur="$emit('blur', $event)"
        @focus="$emit('focus', $event)"
      />
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
  placeholder?: string
  variant?: VariantType
  size?: SizeType
  rows?: number
  disabled?: boolean
  required?: boolean
  error?: string
  helperText?: string
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  modelValue: '',
  id: () => 'textarea-' + Math.random().toString(36).slice(2, 11),
  variant: 'default',
  size: 'md',
  rows: 4
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