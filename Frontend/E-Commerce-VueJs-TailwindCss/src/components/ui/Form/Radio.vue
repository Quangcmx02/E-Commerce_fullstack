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
        type="radio"
        :name="name"
        :value="value"
        :checked="modelValue === value"
        :disabled="disabled"
        class="hidden"
        @change="$emit('update:modelValue', value)"
      />
      <div
        :class="[
          'flex items-center justify-center w-5 h-5 border-2 rounded-full transition-colors',
          modelValue === value
            ? 'bg-zinc-900 border-zinc-900'
            : 'bg-transparent border-zinc-600 hover:border-zinc-500',
          disabled ? 'cursor-not-allowed' : 'cursor-pointer'
        ]"
      >
        <div
          v-if="modelValue === value"
          class="w-2.5 h-2.5 rounded-full bg-white"
        />
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
  modelValue: string | number
  value: string | number
  name: string
  disabled?: boolean
  inline?: boolean
  helperText?: string
}>()

defineEmits<{
  (e: 'update:modelValue', value: string | number): void
}>()
</script> 