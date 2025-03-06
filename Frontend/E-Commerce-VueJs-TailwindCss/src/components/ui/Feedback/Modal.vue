<template>
  <Teleport to="body">
    <Transition
      enter-active-class="transition duration-200 ease-out"
      enter-from-class="opacity-0 scale-95"
      enter-to-class="opacity-100 scale-100"
      leave-active-class="transition duration-150 ease-in"
      leave-from-class="opacity-100 scale-100"
      leave-to-class="opacity-0 scale-95"
    >
      <div
        v-if="modelValue"
        class="fixed inset-0 z-50 overflow-y-auto"
        @click="handleBackdropClick"
      >
        <!-- Backdrop -->
        <div
          class="fixed inset-0 bg-black/50 transition-opacity"
          aria-hidden="true"
        ></div>

        <!-- Modal Panel -->
        <div class="flex min-h-full items-center justify-center p-4">
          <div
            class="relative w-full max-w-lg rounded-lg bg-white p-6 shadow-xl dark:bg-zinc-800"
            :class="[className, { 'sm:max-w-sm': size === 'sm', 'sm:max-w-xl': size === 'lg' }]"
            role="dialog"
            aria-modal="true"
            @click.stop
          >
            <!-- Başlık -->
            <div v-if="title || $slots.header" class="mb-4">
              <slot name="header">
                <div class="flex items-center justify-between">
                  <h3
                    class="text-lg font-semibold text-gray-900 dark:text-white"
                    v-if="title"
                  >
                    {{ title }}
                  </h3>
                  <button
                    v-if="!hideCloseButton"
                    type="button"
                    class="rounded-lg p-1 text-gray-400 hover:text-gray-500 dark:text-zinc-400 dark:hover:text-zinc-300"
                    @click="$emit('update:modelValue', false)"
                  >
                    <span class="sr-only">Kapat</span>
                    <svg
                      class="h-5 w-5"
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
                  </button>
                </div>
              </slot>
            </div>

            <!-- İçerik -->
            <div class="relative">
              <slot></slot>
            </div>

            <!-- Alt Butonlar -->
            <div
              v-if="$slots.footer"
              class="mt-6 flex items-center justify-end gap-3"
            >
              <slot name="footer"></slot>
            </div>
          </div>
        </div>
      </div>
    </Transition>
  </Teleport>
</template>

<script setup lang="ts">
import { onMounted, onUnmounted } from 'vue';

interface Props {
  modelValue: boolean;
  title?: string;
  size?: 'sm' | 'md' | 'lg';
  hideCloseButton?: boolean;
  closeOnBackdrop?: boolean;
  className?: string;
}

const props = withDefaults(defineProps<Props>(), {
  size: 'md',
  hideCloseButton: false,
  closeOnBackdrop: true,
  className: '',
});

const emit = defineEmits(['update:modelValue']);

const handleBackdropClick = () => {
  if (props.closeOnBackdrop) {
    emit('update:modelValue', false);
  }
};

const handleEscape = (e: KeyboardEvent) => {
  if (e.key === 'Escape' && props.modelValue) {
    emit('update:modelValue', false);
  }
};

onMounted(() => {
  document.addEventListener('keydown', handleEscape);
});

onUnmounted(() => {
  document.removeEventListener('keydown', handleEscape);
});
</script> 