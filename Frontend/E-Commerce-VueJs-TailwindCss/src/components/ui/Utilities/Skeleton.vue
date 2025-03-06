<template>
  <div
    class="animate-pulse rounded-md bg-gray-200 dark:bg-zinc-700"
    :class="[
      className,
      {
        'h-4': variant === 'text',
        'h-12 w-12': variant === 'avatar',
        'aspect-video': variant === 'image',
      },
      variantClasses[size],
    ]"
  >
    <span class="sr-only">Yükleniyor...</span>
  </div>
</template>

<script setup lang="ts">
interface Props {
  variant?: 'text' | 'avatar' | 'image';
  size?: 'sm' | 'md' | 'lg' | 'full';
  className?: string;
}

const props = withDefaults(defineProps<Props>(), {
  variant: 'text',
  size: 'full',
  className: '',
});

const variantClasses = {
  sm: 'w-16',
  md: 'w-32',
  lg: 'w-48',
  full: 'w-full',
};
</script> 