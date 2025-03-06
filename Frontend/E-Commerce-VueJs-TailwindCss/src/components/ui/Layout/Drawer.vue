<template>
    <Teleport to="body">
        <!-- Arka Plan Overlay -->
        <div
            v-if="modelValue"
            class="fixed inset-0 z-40 bg-black/50 backdrop-blur-sm transition-opacity"
            :class="{ 'opacity-100': modelValue, 'opacity-0': !modelValue }"
            @click="$emit('update:modelValue', false)"
        />

        <!-- Drawer Panel -->
        <div
            class="fixed inset-y-0 z-50 w-full max-w-xs transform bg-zinc-900 shadow-xl transition duration-300 ease-in-out"
            :class="[
                position === 'left' ? 'left-0' : 'right-0',
                modelValue ? 'translate-x-0' : position === 'left' ? '-translate-x-full' : 'translate-x-full'
            ]"
        >
            <!-- Header -->
            <div class="flex items-center justify-between border-b border-zinc-800 px-4 py-3">
                <h2 class="text-lg font-medium text-white">{{ title }}</h2>
                <button
                    class="rounded-lg p-2 text-zinc-400 hover:bg-zinc-800 hover:text-white"
                    @click="$emit('update:modelValue', false)"
                >
                    <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
                        <path
                            fill-rule="evenodd"
                            d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                            clip-rule="evenodd"
                        />
                    </svg>
                </button>
            </div>

            <!-- Content -->
            <div class="p-4">
                <slot />
            </div>
        </div>
    </Teleport>
</template>

<script setup lang="ts">
defineProps<{
    modelValue: boolean;
    title: string;
    position?: 'left' | 'right';
}>();

defineEmits<{
    (e: 'update:modelValue', value: boolean): void;
}>();
</script> 