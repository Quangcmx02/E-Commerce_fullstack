<template>
  <label
    :class="[
      'relative flex items-start',
      inline ? 'inline-flex' : 'flex',
      disabled ? 'cursor-not-allowed opacity-50' : 'cursor-pointer'
    ]"
  >
    <div class="flex items-center h-5">
      <input
        type="checkbox"
        :checked="modelValue"
        :disabled="disabled"
        class="hidden"
        @change="$emit('update:modelValue', $event.target.checked)"
      />
      <div
        :class="[
          'flex items-center justify-center w-5 h-5 border-2 rounded transition-colors',
          modelValue
            ? 'bg-zinc-900 border-zinc-900'
            : 'bg-transparent border-zinc-600 hover:border-zinc-500',
          disabled ? 'cursor-not-allowed' : 'cursor-pointer'
        ]"
      >
        <svg
          v-if="modelValue"
          class="w-3.5 h-3.5 text-white"
          viewBox="0 0 24 24"
          fill="none"
          stroke="currentColor"
          stroke-width="3"
          stroke-linecap="round"
          stroke-linejoin="round"
        >
          <polyline points="20 6 9 17 4 12" />
        </svg>
      </div>
    </div>
    <div class="ml-3 text-sm">
      <span :class="[disabled ? 'text-zinc-500' : 'text-zinc-200']">
        <slot />
      </span>
      <p
        v-if="helperText"
        :class="[disabled ? 'text-zinc-600' : 'text-zinc-400']"
        class="mt-1"
      >
        {{ helperText }}
      </p>
    </div>
  </label>
</template>

<script setup lang="ts">
defineProps<{
  modelValue: boolean
  disabled?: boolean
  inline?: boolean
  helperText?: string
}>()

defineEmits<{
  (e: 'update:modelValue', value: boolean): void
}>()
</script> 