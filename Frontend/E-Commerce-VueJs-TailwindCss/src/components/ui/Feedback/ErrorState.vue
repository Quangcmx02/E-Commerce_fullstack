<template>
  <div class="flex flex-col items-center justify-center space-y-4 p-8 text-center" :class="className">
    <!-- İkon -->
    <div v-if="$slots.icon" class="text-red-500 dark:text-red-400">
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
            d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"
          />
        </svg>
      </slot>
    </div>

    <!-- Başlık -->
    <h3 class="text-lg font-medium text-gray-900 dark:text-white">
      {{ title }}
    </h3>

    <!-- Hata Mesajı -->
    <p class="max-w-sm text-sm text-gray-500 dark:text-zinc-400">
      {{ message }}
    </p>

    <!-- Detaylar -->
    <div v-if="details" class="mt-2 w-full max-w-sm">
      <pre class="rounded-md bg-gray-100 p-4 text-left text-xs text-gray-900 dark:bg-zinc-800 dark:text-zinc-300">{{ details }}</pre>
    </div>

    <!-- Aksiyon -->
    <div v-if="$slots.action" class="mt-4">
      <slot name="action">
        <button
          type="button"
          class="inline-flex items-center rounded-md bg-red-600 px-4 py-2 text-sm font-medium text-white hover:bg-red-700 dark:bg-red-600 dark:hover:bg-red-700"
          @click="$emit('retry')"
        >
          <svg
            class="-ml-1 mr-2 h-4 w-4"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15"
            />
          </svg>
          {{ retryButtonText }}
        </button>
      </slot>
    </div>
  </div>
</template>

<script setup lang="ts">
interface Props {
  title: string;
  message: string;
  details?: string;
  retryButtonText?: string;
  className?: string;
}

const props = withDefaults(defineProps<Props>(), {
  retryButtonText: 'Tekrar Dene',
  className: '',
});

defineEmits(['retry']);
</script> 