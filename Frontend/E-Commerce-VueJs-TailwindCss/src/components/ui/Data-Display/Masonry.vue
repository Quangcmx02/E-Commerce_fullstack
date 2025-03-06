<template>
    <div :class="className">
        <div class="grid gap-4" :style="gridStyle">
            <slot />
        </div>
    </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';

interface Props {
    className?: string;
    columns?: number;
    gap?: number;
    breakpoints?: {
        sm?: number;
        md?: number;
        lg?: number;
        xl?: number;
        '2xl'?: number;
    };
}

const props = withDefaults(defineProps<Props>(), {
    className: '',
    columns: 3,
    gap: 16,
    breakpoints: () => ({
        sm: 1,
        md: 2,
        lg: 3,
        xl: 4,
        '2xl': 5,
    }),
});

const gridStyle = computed(() => {
    return {
        'grid-template-columns': `repeat(${props.columns}, minmax(0, 1fr))`,
        gap: `${props.gap}px`,
    };
});
</script>

<style scoped>
@media (max-width: 640px) {
    .grid {
        grid-template-columns: repeat(v-bind(breakpoints.sm), minmax(0, 1fr)) !important;
    }
}

@media (min-width: 641px) and (max-width: 768px) {
    .grid {
        grid-template-columns: repeat(v-bind(breakpoints.md), minmax(0, 1fr)) !important;
    }
}

@media (min-width: 769px) and (max-width: 1024px) {
    .grid {
        grid-template-columns: repeat(v-bind(breakpoints.lg), minmax(0, 1fr)) !important;
    }
}

@media (min-width: 1025px) and (max-width: 1280px) {
    .grid {
        grid-template-columns: repeat(v-bind(breakpoints.xl), minmax(0, 1fr)) !important;
    }
}

@media (min-width: 1281px) {
    .grid {
        grid-template-columns: repeat(v-bind('breakpoints["2xl"]'), minmax(0, 1fr)) !important;
    }
}
</style> 