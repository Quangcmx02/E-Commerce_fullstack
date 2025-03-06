<template>
  <label class="relative inline-flex cursor-pointer items-center">
    <input
      type="checkbox"
      :checked="modelValue"
      class="peer sr-only"
      v-bind="$attrs"
      @change="$emit('update:modelValue', $event.target.checked)"
    />
    <div
      :class="[
        'peer h-6 w-11 rounded-full bg-zinc-700 after:absolute after:left-[2px] after:top-[2px]',
        'after:h-5 after:w-5 after:rounded-full after:bg-white after:transition-all after:content-[\'\']',
        'peer-checked:bg-primary peer-checked:after:translate-x-full peer-checked:after:border-white',
        'peer-focus:outline-none peer-focus:ring-4 peer-focus:ring-primary/20',
        'peer-disabled:cursor-not-allowed peer-disabled:opacity-50',
        size === 'sm' && 'h-5 w-9 after:h-4 after:w-4',
        size === 'lg' && 'h-7 w-14 after:h-6 after:w-6',
      ]"
    ></div>
    <span v-if="label" class="ml-3 text-sm font-medium text-zinc-300">{{ label }}</span>
  </label>
</template>

<script setup lang="ts">
defineProps({
  modelValue: {
    type: Boolean,
    required: true,
  },
  label: {
    type: String,
    default: '',
  },
  size: {
    type: String,
    default: 'md',
    validator: (value: string) => ['sm', 'md', 'lg'].includes(value),
  },
});

defineEmits(['update:modelValue']);
</script> 