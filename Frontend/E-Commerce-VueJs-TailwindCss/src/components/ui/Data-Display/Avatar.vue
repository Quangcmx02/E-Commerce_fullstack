<template>
    <div :class="['inline-flex items-center justify-center rounded-full overflow-hidden', sizeClasses[size], className]">
        <template v-if="src">
            <img :src="src" :alt="alt" class="w-full h-full object-cover" @error="handleImageError" />
        </template>
        <template v-else>
            <div :class="['flex items-center justify-center w-full h-full font-medium', variantClasses[variant]]">
                {{ initials }}
            </div>
        </template>
        <div v-if="status" :class="['absolute bottom-0 right-0 rounded-full border-2 border-background', statusClasses[status], statusSizeClasses[size]]" />
    </div>
</template>

<script setup lang="ts">
import { computed, ref } from "vue";

interface Props {
    src?: string;
    alt?: string;
    initials?: string;
    size?: "sm" | "md" | "lg" | "xl";
    variant?: "primary" | "secondary" | "success" | "warning" | "danger" | "info";
    status?: "online" | "offline" | "busy" | "away";
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    size: "md",
    variant: "primary",
    className: "",
});

const showFallback = ref(false);

const handleImageError = () => {
    showFallback.value = true;
};

const sizeClasses = {
    sm: "w-8 h-8 text-xs",
    md: "w-10 h-10 text-sm",
    lg: "w-12 h-12 text-base",
    xl: "w-14 h-14 text-lg",
};

const variantClasses = {
    primary: "bg-primary/10 text-primary",
    secondary: "bg-zinc-700/10 text-zinc-300",
    success: "bg-green-500/10 text-green-500",
    warning: "bg-yellow-500/10 text-yellow-500",
    danger: "bg-red-500/10 text-red-500",
    info: "bg-blue-500/10 text-blue-500",
};

const statusClasses = {
    online: "bg-green-500",
    offline: "bg-zinc-500",
    busy: "bg-red-500",
    away: "bg-yellow-500",
};

const statusSizeClasses = {
    sm: "w-2 h-2",
    md: "w-2.5 h-2.5",
    lg: "w-3 h-3",
    xl: "w-3.5 h-3.5",
};
</script>
