<template>
  <div v-show="modelValue === value" role="tabpanel">
    <slot />
  </div>
</template>

<script setup lang="ts">
defineProps<{
  modelValue: string
  value: string
}>()
</script> 