<template>
    <button :class="['inline-flex items-center justify-center rounded-md font-medium transition-all duration-200 focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50 select-none', sizeClasses[size], variantClasses[variant], className, { 'opacity-90 scale-[0.98] transform': active }]" :disabled="disabled || loading" @click="$emit('click')" @mousedown="active = true" @mouseup="active = false" @mouseleave="active = false">
        <span v-if="loading" class="mr-2">
            <svg class="animate-spin h-4 w-4" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
            </svg>
        </span>
        <span v-if="$slots.leftIcon && !loading" class="mr-2">
            <slot name="leftIcon" />
        </span>
        <slot />
        <span v-if="$slots.rightIcon && !loading" class="ml-2">
            <slot name="rightIcon" />
        </span>
    </button>
</template>

<script setup lang="ts">
import { ref } from "vue";

const active = ref(false);

const props = defineProps({
    variant: {
        type: String,
        default: "primary",
        validator: (value) => ["primary", "secondary", "outline", "ghost", "danger", "success"].includes(value),
    },
    size: {
        type: String,
        default: "md",
        validator: (value) => ["sm", "md", "lg"].includes(value),
    },
    loading: {
        type: Boolean,
        default: false,
    },
    disabled: {
        type: Boolean,
        default: false,
    },
    className: {
        type: String,
        default: "",
    },
});

const sizeClasses = {
    sm: "h-8 px-3 text-sm",
    md: "h-10 px-4 py-2 text-base",
    lg: "h-12 px-6 py-3 text-lg",
};

const variantClasses = {
    primary: "bg-white text-black hover:bg-zinc-100 focus-visible:ring-zinc-500 ring-offset-zinc-900 shadow-sm",
    secondary: "bg-gray-700 text-gray-100 hover:bg-gray-600 focus-visible:ring-gray-400 ring-offset-gray-900 shadow-sm",
    outline: "border border-gray-600 bg-transparent hover:bg-gray-800 text-gray-100 focus-visible:ring-gray-400 ring-offset-gray-900",
    ghost: "text-gray-100 hover:bg-gray-800 focus-visible:ring-gray-400 ring-offset-gray-900",
    danger: "bg-red-500 text-white hover:bg-red-600 focus-visible:ring-red-400 ring-offset-gray-900 shadow-sm",
    success: "bg-green-500 text-white hover:bg-green-600 focus-visible:ring-green-400 ring-offset-gray-900 shadow-sm",
};

defineEmits(["click"]);
</script>
