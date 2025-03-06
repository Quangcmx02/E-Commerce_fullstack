<template>
    <td :class="[
        'px-4 py-2',
        className
    ]">
        <slot></slot>
    </td>
</template>

<script setup lang="ts">
interface Props {
    className?: string;
}

defineProps<Props>();
</script> 