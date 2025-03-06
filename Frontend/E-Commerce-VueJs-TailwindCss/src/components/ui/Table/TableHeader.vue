<template>
    <thead class="bg-zinc-900 text-zinc-400">
        <tr>
            <slot></slot>
        </tr>
    </thead>
</template>

<script setup lang="ts">
defineProps<{
    className?: string
}>()
</script> 