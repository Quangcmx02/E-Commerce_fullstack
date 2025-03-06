<template>
  <div
    class="flex items-center justify-center space-x-2"
    :class="[className, { 'flex-col space-y-2 space-x-0': vertical }]"
  >
    <!-- Spinner -->
    <div
      class="inline-block animate-spin rounded-full border-2 border-solid border-current border-r-transparent"
      :class="[
        sizeClasses[size],
        variantClasses[variant],
      ]"
      role="status"
    >
      <span class="sr-only">Yükleniyor...</span>
    </div>

    <!-- Text -->
    <span
      v-if="text"
      class="text-sm"
      :class="[variantClasses[variant]]"
    >
      {{ text }}
    </span>
  </div>
</template>

<script setup lang="ts">
interface Props {
  variant?: 'primary' | 'secondary' | 'success' | 'warning' | 'danger' | 'info';
  size?: 'sm' | 'md' | 'lg';
  text?: string;
  vertical?: boolean;
  className?: string;
}

const props = withDefaults(defineProps<Props>(), {
  variant: 'primary',
  size: 'md',
  text: undefined,
  vertical: false,
  className: '',
});

const sizeClasses = {
  sm: 'h-4 w-4',
  md: 'h-6 w-6',
  lg: 'h-8 w-8',
};

const variantClasses = {
  primary: 'text-blue-600 dark:text-blue-500',
  secondary: 'text-gray-600 dark:text-gray-400',
  success: 'text-green-600 dark:text-green-500',
  warning: 'text-yellow-600 dark:text-yellow-500',
  danger: 'text-red-600 dark:text-red-500',
  info: 'text-sky-600 dark:text-sky-500',
};
</script> 