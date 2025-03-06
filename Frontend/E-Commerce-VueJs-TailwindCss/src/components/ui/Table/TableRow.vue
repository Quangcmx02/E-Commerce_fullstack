export interface User {
  id: number | string;
  name: string;
  email: string;
  role: string;
  status: string;
}

<template>
    <tr
        :class="[
            'transition-colors hover:bg-zinc-800',
            selected && 'bg-zinc-800',
            clickable && 'cursor-pointer',
            className
        ]"
        @click="clickable && $emit('click')"
    >
        <slot></slot>
    </tr>
</template>

<script setup lang="ts">
export interface User {
  id: number | string;
  name: string;
  email: string;
  role: string;
  status: string;
}

interface Props {
  selected?: boolean;
  clickable?: boolean;
  className?: string;
  item?: any
}

defineProps<Props>();

defineEmits<{
  (e: 'click'): void;
}>();
</script> 