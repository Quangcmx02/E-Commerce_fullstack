<template>
  <button
    :class="[
      'flex w-full items-center px-4 py-2 text-sm transition-colors',
      disabled
        ? 'cursor-not-allowed text-zinc-500'
        : 'text-zinc-200 hover:bg-zinc-800 hover:text-white',
      className
    ]"
    :disabled="disabled"
    role="menuitem"
    @click="$emit('click')"
  >
    <slot name="icon" />
    <slot />
  </button>
</template>

<script setup lang="ts">
defineProps<{
  disabled?: boolean
  className?: string
}>()

defineEmits<{
  (e: 'click'): void
}>()
</script> 