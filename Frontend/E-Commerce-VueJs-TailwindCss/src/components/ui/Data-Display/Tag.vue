<template>
    <div :class="['inline-flex items-center px-2.5 py-1 rounded-full text-sm font-medium', variantClasses[variant], sizeClasses[size], className]">
        <slot name="icon" />
        <span :class="{ 'ml-1.5': $slots.icon }">
            <slot>{{ text }}</slot>
        </span>
        <button v-if="dismissible" @click="$emit('dismiss')" class="ml-1.5 hover:opacity-75 focus:outline-none" type="button">
            <svg class="w-3.5 h-3.5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
            </svg>
        </button>
    </div>
</template>

<script setup lang="ts">
interface Props {
    text?: string;
    variant?: "primary" | "secondary" | "success" | "warning" | "danger" | "info";
    size?: "sm" | "md" | "lg";
    dismissible?: boolean;
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    variant: "primary",
    size: "md",
    dismissible: false,
    className: "",
});

defineEmits<{
    (e: "dismiss"): void;
}>();

const variantClasses = {
    primary: "bg-primary/10 text-primary border border-primary/20",
    secondary: "bg-zinc-700/10 text-zinc-300 border border-zinc-700/20",
    success: "bg-green-500/10 text-green-500 border border-green-500/20",
    warning: "bg-yellow-500/10 text-yellow-500 border border-yellow-500/20",
    danger: "bg-red-500/10 text-red-500 border border-red-500/20",
    info: "bg-blue-500/10 text-blue-500 border border-blue-500/20",
};

const sizeClasses = {
    sm: "text-xs px-2 py-0.5",
    md: "text-sm px-2.5 py-1",
    lg: "text-base px-3 py-1.5",
};
</script>
