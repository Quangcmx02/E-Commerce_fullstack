<template>
  <Modal
    :model-value="modelValue"
    @update:model-value="$emit('update:modelValue', $event)"
    :title="title"
    size="sm"
    :close-on-backdrop="false"
    :hide-close-button="!showCloseButton"
    class="text-center"
  >
    <!-- İkon -->
    <div
      class="mx-auto mb-4 flex h-12 w-12 items-center justify-center rounded-full"
      :class="{
        'bg-green-100 text-green-600 dark:bg-green-900/30 dark:text-green-400':
          type === 'success',
        'bg-red-100 text-red-600 dark:bg-red-900/30 dark:text-red-400':
          type === 'error',
        'bg-yellow-100 text-yellow-600 dark:bg-yellow-900/30 dark:text-yellow-400':
          type === 'warning',
        'bg-blue-100 text-blue-600 dark:bg-blue-900/30 dark:text-blue-400':
          type === 'info',
      }"
    >
      <svg
        v-if="type === 'success'"
        class="h-6 w-6"
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M5 13l4 4L19 7"
        />
      </svg>
      <svg
        v-else-if="type === 'error'"
        class="h-6 w-6"
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M6 18L18 6M6 6l12 12"
        />
      </svg>
      <svg
        v-else-if="type === 'warning'"
        class="h-6 w-6"
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
      <svg
        v-else
        class="h-6 w-6"
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
        />
      </svg>
    </div>

    <!-- Mesaj -->
    <div class="space-y-2">
      <p class="text-sm text-gray-600 dark:text-zinc-300">{{ message }}</p>
      <p
        v-if="description"
        class="text-xs text-gray-500 dark:text-zinc-400"
        v-html="description"
      ></p>
    </div>

    <!-- Butonlar -->
    <template #footer>
      <button
        type="button"
        class="rounded-lg px-4 py-2 text-sm font-medium text-white shadow-sm"
        :class="{
          'bg-green-600 hover:bg-green-700 dark:bg-green-600 dark:hover:bg-green-700':
            type === 'success',
          'bg-red-600 hover:bg-red-700 dark:bg-red-600 dark:hover:bg-red-700':
            type === 'error',
          'bg-yellow-600 hover:bg-yellow-700 dark:bg-yellow-600 dark:hover:bg-yellow-700':
            type === 'warning',
          'bg-blue-600 hover:bg-blue-700 dark:bg-blue-600 dark:hover:bg-blue-700':
            type === 'info',
        }"
        @click="handleAction"
      >
        {{ buttonText }}
      </button>
    </template>
  </Modal>
</template>

<script setup lang="ts">
import Modal from './Modal.vue';

interface Props {
  modelValue: boolean;
  title: string;
  message: string;
  description?: string;
  type?: 'success' | 'error' | 'warning' | 'info';
  buttonText?: string;
  showCloseButton?: boolean;
  autoClose?: boolean;
  autoCloseDelay?: number;
}

const props = withDefaults(defineProps<Props>(), {
  type: 'info',
  buttonText: 'Tamam',
  showCloseButton: true,
  autoClose: false,
  autoCloseDelay: 3000,
});

const emit = defineEmits(['update:modelValue', 'action']);

const handleAction = () => {
  emit('update:modelValue', false);
  emit('action');
};

// Otomatik kapanma
if (props.autoClose && props.modelValue) {
  setTimeout(() => {
    emit('update:modelValue', false);
  }, props.autoCloseDelay);
}
</script> 