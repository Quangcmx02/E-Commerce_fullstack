<template>
    <ul :class="['w-full', bordered && 'divide-y divide-zinc-800', className]">
        <slot />
    </ul>
</template>

<script setup lang="ts">
const props = defineProps({
    bordered: {
        type: Boolean,
        default: false,
    },
    className: {
        type: String,
        default: "",
    },
});
</script>
