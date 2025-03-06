<template>
    <div class="inline-flex items-center space-x-1">
        <button
            v-for="star in maxStars"
            :key="star"
            @click="!disabled && updateRating(star)"
            @mouseenter="!disabled && (hoveredStar = star)"
            @mouseleave="!disabled && (hoveredStar = 0)"
            :class="[
                'focus:outline-none transition-colors duration-200',
                sizeClasses[size],
                {
                    'cursor-default': readonly || disabled,
                    'cursor-pointer': !readonly && !disabled,
                },
            ]"
            :disabled="readonly || disabled"
            type="button"
        >
            <svg :class="[getStarColor(star), 'fill-current transition-colors duration-200']" viewBox="0 0 24 24">
                <path d="M12 17.27L18.18 21L16.54 13.97L22 9.24L14.81 8.63L12 2L9.19 8.63L2 9.24L7.46 13.97L5.82 21L12 17.27Z" />
            </svg>
        </button>
        <span v-if="showValue" class="text-sm text-zinc-400 ml-2">{{ currentValue }} / {{ maxStars }}</span>
    </div>
</template>

<script setup lang="ts">
import { computed, ref } from "vue";

interface Props {
    modelValue?: number;
    maxStars?: number;
    size?: "sm" | "md" | "lg";
    readonly?: boolean;
    disabled?: boolean;
    showValue?: boolean;
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    modelValue: 0,
    maxStars: 5,
    size: "md",
    readonly: false,
    disabled: false,
    showValue: false,
    className: "",
});

const emit = defineEmits<{
    (e: "update:modelValue", value: number): void;
}>();

const hoveredStar = ref(0);

const currentValue = computed(() => props.modelValue || 0);

const sizeClasses = {
    sm: "w-4 h-4",
    md: "w-5 h-5",
    lg: "w-6 h-6",
};

const getStarColor = (star: number) => {
    if (props.disabled || props.readonly) {
        return star <= currentValue.value ? "text-yellow-400" : "text-zinc-600";
    }
    const rating = hoveredStar.value || currentValue.value;
    return star <= rating ? "text-yellow-400" : "text-zinc-600";
};

const updateRating = (rating: number) => {
    if (!props.readonly && !props.disabled) {
        emit("update:modelValue", rating);
    }
};
</script>
