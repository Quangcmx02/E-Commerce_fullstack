<template>
    <li :class="['relative flex items-center gap-4 py-4 px-4 transition-colors', clickable && 'cursor-pointer hover:bg-zinc-800/50', active && 'bg-zinc-800', disabled && 'opacity-50 cursor-not-allowed', className]" @click="handleClick">
        <!-- Sol İkon -->
        <div v-if="$slots.icon || icon" class="flex-shrink-0">
            <slot name="icon">
                <component :is="icon" class="w-5 h-5 text-zinc-400" />
            </slot>
        </div>

        <!-- Ana İçerik -->
        <div class="flex-grow min-w-0">
            <div v-if="title || $slots.title" class="text-sm font-medium text-white truncate">
                <slot name="title">{{ title }}</slot>
            </div>
            <div v-if="description || $slots.description" class="text-sm text-zinc-400 truncate">
                <slot name="description">{{ description }}</slot>
            </div>
            <slot />
        </div>

        <!-- Sağ İkon veya İçerik -->
        <div v-if="$slots.suffix" class="flex-shrink-0">
            <slot name="suffix" />
        </div>

        <!-- Chevron İkonu (clickable ise) -->
        <div v-if="clickable && !$slots.suffix" class="flex-shrink-0">
            <svg class="w-5 h-5 text-zinc-400" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" />
            </svg>
        </div>
    </li>
</template>

<script setup lang="ts">
import type { Component } from "vue";

interface Props {
    title?: string;
    description?: string;
    icon?: Component;
    clickable?: boolean;
    active?: boolean;
    disabled?: boolean;
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    clickable: false,
    active: false,
    disabled: false,
});

const emit = defineEmits<{
    (e: "click", event: MouseEvent): void;
}>();

const handleClick = (event: MouseEvent) => {
    if (!props.disabled && props.clickable) {
        emit("click", event);
    }
};
</script>