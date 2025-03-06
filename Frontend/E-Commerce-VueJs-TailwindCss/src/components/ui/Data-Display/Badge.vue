<template>
    <span
        :class="[
            'inline-flex items-center justify-center font-medium rounded-full',
            sizeClasses[size],
            variantClasses[variant],
            className
        ]"
    >
        <slot>{{ text }}</slot>
        <button
            v-if="dismissible"
            @click="$emit('dismiss')"
            class="ml-1 hover:opacity-75 focus:outline-none"
            :class="[dismissibleClasses[size]]"
        >
            <svg class="w-full h-full" viewBox="0 0 20 20" fill="currentColor">
                <path
                    fill-rule="evenodd"
                    d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                    clip-rule="evenodd"
                />
            </svg>
        </button>
    </span>
</template>

<script setup lang="ts">
type SizeType = "sm" | "md" | "lg";
type VariantType = "primary" | "secondary" | "success" | "warning" | "danger" | "info";

const props = defineProps({
    variant: {
        type: String as () => VariantType,
        default: "primary",
        validator: (value: string) =>
            ["primary", "secondary", "success", "warning", "danger", "info"].includes(value),
    },
    size: {
        type: String as () => SizeType,
        default: "md",
        validator: (value: string) => ["sm", "md", "lg"].includes(value),
    },
    text: {
        type: String,
        default: "",
    },
    dismissible: {
        type: Boolean,
        default: false,
    },
    className: {
        type: String,
        default: "",
    },
});

defineEmits(["dismiss"]);

const sizeClasses: Record<SizeType, string> = {
    sm: "px-2 py-0.5 text-xs",
    md: "px-2.5 py-0.5 text-sm",
    lg: "px-3 py-1 text-base",
};

const dismissibleClasses: Record<SizeType, string> = {
    sm: "w-3 h-3",
    md: "w-3.5 h-3.5",
    lg: "w-4 h-4",
};

const variantClasses: Record<VariantType, string> = {
    primary: "bg-blue-100 text-blue-800 dark:bg-blue-900/30 dark:text-blue-300",
    secondary: "bg-gray-100 text-gray-800 dark:bg-gray-900/30 dark:text-gray-300",
    success: "bg-green-100 text-green-800 dark:bg-green-900/30 dark:text-green-300",
    warning: "bg-yellow-100 text-yellow-800 dark:bg-yellow-900/30 dark:text-yellow-300",
    danger: "bg-red-100 text-red-800 dark:bg-red-900/30 dark:text-red-300",
    info: "bg-cyan-100 text-cyan-800 dark:bg-cyan-900/30 dark:text-cyan-300",
};
</script> 