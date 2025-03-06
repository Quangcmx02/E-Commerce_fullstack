<template>
    <div class="w-full overflow-x-auto">
        <table class="w-full border-collapse text-sm">
            <slot></slot>
        </table>
    </div>
</template>

<script setup lang="ts">
defineProps<{
    className?: string
}>()
</script> 