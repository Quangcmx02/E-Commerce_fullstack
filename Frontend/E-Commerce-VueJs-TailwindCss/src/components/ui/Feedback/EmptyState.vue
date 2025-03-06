<template>
  <div class="flex flex-col items-center justify-center space-y-4 p-8 text-center" :class="className">
    <!-- İkon -->
    <div v-if="$slots.icon" class="text-gray-400 dark:text-zinc-500">
      <slot name="icon">
        <svg
          class="mx-auto h-12 w-12"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M20 13V6a2 2 0 00-2-2H6a2 2 0 00-2 2v7m16 0v5a2 2 0 01-2 2H6a2 2 0 01-2-2v-5m16 0h-2.586a1 1 0 00-.707.293l-2.414 2.414a1 1 0 01-.707.293h-3.172a1 1 0 01-.707-.293l-2.414-2.414A1 1 0 006.586 13H4"
          />
        </svg>
      </slot>
    </div>

    <!-- Başlık -->
    <h3 class="text-lg font-medium text-gray-900 dark:text-white">
      {{ title }}
    </h3>

    <!-- Açıklama -->
    <p class="max-w-sm text-sm text-gray-500 dark:text-zinc-400">
      {{ description }}
    </p>

    <!-- Aksiyon -->
    <div v-if="$slots.action" class="mt-2">
      <slot name="action"></slot>
    </div>
  </div>
</template>

<script setup lang="ts">
interface Props {
  title: string;
  description: string;
  className?: string;
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
});
</script> 