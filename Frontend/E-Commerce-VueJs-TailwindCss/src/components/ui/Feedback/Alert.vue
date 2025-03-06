<template>
    <div
        v-if="isVisible"
        :class="[
            'flex items-center p-4 rounded-lg',
            variantClasses[variant],
            className
        ]"
        role="alert"
    >
        <!-- Icon -->
        <div v-if="icon" class="flex-shrink-0 mr-3">
            <component :is="icons[variant]" class="w-5 h-5" />
        </div>

        <!-- Content -->
        <div class="flex-1">
            <h3 v-if="title" class="font-medium" :class="titleClasses[variant]">
                {{ title }}
            </h3>
            <div :class="[title ? 'mt-1' : '', messageClasses[variant]]">
                <slot>{{ message }}</slot>
            </div>
        </div>

        <!-- Close Button -->
        <button
            v-if="dismissible"
            @click="close"
            class="flex-shrink-0 ml-3 hover:opacity-75 focus:outline-none"
            :class="closeButtonClasses[variant]"
        >
            <svg class="w-5 h-5" viewBox="0 0 20 20" fill="currentColor">
                <path
                    fill-rule="evenodd"
                    d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                    clip-rule="evenodd"
                />
            </svg>
        </button>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';

type VariantType = "info" | "success" | "warning" | "danger";

const props = defineProps({
    variant: {
        type: String as () => VariantType,
        default: "info",
        validator: (value: string) => ["info", "success", "warning", "danger"].includes(value),
    },
    title: {
        type: String,
        default: "",
    },
    message: {
        type: String,
        default: "",
    },
    icon: {
        type: Boolean,
        default: true,
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

const emit = defineEmits(["close"]);

const isVisible = ref(true);

const close = () => {
    isVisible.value = false;
    emit("close");
};

const variantClasses: Record<VariantType, string> = {
    info: "bg-blue-50 dark:bg-blue-900/20 border border-blue-200 dark:border-blue-800",
    success: "bg-green-50 dark:bg-green-900/20 border border-green-200 dark:border-green-800",
    warning: "bg-yellow-50 dark:bg-yellow-900/20 border border-yellow-200 dark:border-yellow-800",
    danger: "bg-red-50 dark:bg-red-900/20 border border-red-200 dark:border-red-800",
};

const titleClasses: Record<VariantType, string> = {
    info: "text-blue-800 dark:text-blue-200",
    success: "text-green-800 dark:text-green-200",
    warning: "text-yellow-800 dark:text-yellow-200",
    danger: "text-red-800 dark:text-red-200",
};

const messageClasses: Record<VariantType, string> = {
    info: "text-blue-700 dark:text-blue-300",
    success: "text-green-700 dark:text-green-300",
    warning: "text-yellow-700 dark:text-yellow-300",
    danger: "text-red-700 dark:text-red-300",
};

const closeButtonClasses: Record<VariantType, string> = {
    info: "text-blue-500 dark:text-blue-400",
    success: "text-green-500 dark:text-green-400",
    warning: "text-yellow-500 dark:text-yellow-400",
    danger: "text-red-500 dark:text-red-400",
};

const icons = {
    info: computed(() => ({
        template: `
            <svg xmlns="http://www.w3.org/2000/svg" class="w-5 h-5 text-blue-500 dark:text-blue-400" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z" clip-rule="evenodd" />
            </svg>
        `
    })),
    success: computed(() => ({
        template: `
            <svg xmlns="http://www.w3.org/2000/svg" class="w-5 h-5 text-green-500 dark:text-green-400" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.707-9.293a1 1 0 00-1.414-1.414L9 10.586 7.707 9.293a1 1 0 00-1.414 1.414l2 2a1 1 0 001.414 0l4-4z" clip-rule="evenodd" />
            </svg>
        `
    })),
    warning: computed(() => ({
        template: `
            <svg xmlns="http://www.w3.org/2000/svg" class="w-5 h-5 text-yellow-500 dark:text-yellow-400" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M8.257 3.099c.765-1.36 2.722-1.36 3.486 0l5.58 9.92c.75 1.334-.213 2.98-1.742 2.98H4.42c-1.53 0-2.493-1.646-1.743-2.98l5.58-9.92zM11 13a1 1 0 11-2 0 1 1 0 012 0zm-1-8a1 1 0 00-1 1v3a1 1 0 002 0V6a1 1 0 00-1-1z" clip-rule="evenodd" />
            </svg>
        `
    })),
    danger: computed(() => ({
        template: `
            <svg xmlns="http://www.w3.org/2000/svg" class="w-5 h-5 text-red-500 dark:text-red-400" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zM8.707 7.293a1 1 0 00-1.414 1.414L8.586 10l-1.293 1.293a1 1 0 101.414 1.414L10 11.414l1.293 1.293a1 1 0 001.414-1.414L11.414 10l1.293-1.293a1 1 0 00-1.414-1.414L10 8.586 8.707 7.293z" clip-rule="evenodd" />
            </svg>
        `
    })),
};
</script> 