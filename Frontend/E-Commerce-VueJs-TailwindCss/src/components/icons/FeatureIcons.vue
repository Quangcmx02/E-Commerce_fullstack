<template>
    <svg v-if="name === 'bluetooth'" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
        <path d="m6 7 12 10-6 5V2l6 5L6 17" />
    </svg>

    <svg v-else-if="name === 'battery'" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
        <rect width="16" height="10" x="2" y="7" rx="2" ry="2" />
        <line x1="22" x2="22" y1="11" y2="13" />
        <line x1="6" x2="6" y1="11" y2="13" />
        <line x1="10" x2="10" y1="11" y2="13" />
        <line x1="14" x2="14" y1="11" y2="13" />
    </svg>

    <svg v-else-if="name === 'water'" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
        <path d="M12 2.69l5.66 5.66a8 8 0 1 1-11.31 0z" />
    </svg>

    <svg v-else-if="name === 'noise'" xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
        <path d="M2 10c.6.5 1.2 1 1.8 1.5C7 14 7 14 12 16c5-2 5-2 8.2-4.5.6-.5 1.2-1 1.8-1.5" />
        <path d="M5 18c.6.5 1.2 1 1.8 1.5C10 22 10 22 12 22c2 0 2 0 5.2-2.5.6-.5 1.2-1 1.8-1.5" />
        <path d="M5 6c.6.5 1.2 1 1.8 1.5C10 10 10 10 12 10c2 0 2 0 5.2-2.5.6-.5 1.2-1 1.8-1.5" />
    </svg>
</template>

<script setup lang="ts">
defineProps<{
    name: "bluetooth" | "battery" | "water" | "noise";
}>();
</script>
