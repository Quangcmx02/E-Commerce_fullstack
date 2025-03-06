<template>
    <aside :class="['fixed inset-y-0 left-0 z-50 w-64 bg-zinc-900 border-r border-zinc-800 transition-transform duration-300 ease-in-out transform', collapsed ? '-translate-x-full md:translate-x-0 md:w-16' : 'translate-x-0', className]">
        <!-- Header -->
        <div class="h-16 flex items-center justify-between px-4 border-b border-zinc-800">
            <div :class="['transition-opacity duration-300', collapsed ? 'md:opacity-0' : 'opacity-100']">
                <slot name="header">
                    <span class="text-white font-bold">Sidebar</span>
                </slot>
            </div>
            <button
                class="p-1 text-zinc-400 hover:text-white focus:outline-none"
                @click="toggleCollapse"
            >
                <svg
                    class="w-6 h-6"
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                >
                    <path
                        v-if="!collapsed"
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="2"
                        d="M11 19l-7-7 7-7m8 14l-7-7 7-7"
                    />
                    <path
                        v-else
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="2"
                        d="M13 5l7 7-7 7M5 5l7 7-7 7"
                    />
                </svg>
            </button>
        </div>

        <!-- Content -->
        <div class="h-[calc(100vh-4rem)] overflow-y-auto">
            <slot />
        </div>

        <!-- Footer -->
        <div v-if="$slots.footer" class="absolute bottom-0 w-full border-t border-zinc-800">
            <slot name="footer" />
        </div>

        <!-- Overlay (Mobile) -->
        <div
            v-if="!collapsed"
            class="fixed inset-0 bg-black bg-opacity-50 md:hidden"
            @click="toggleCollapse"
        />
    </aside>
</template>

<script setup lang="ts">
import { ref } from 'vue'

defineProps<{
    className?: string
}>()

const collapsed = ref(false)

const toggleCollapse = () => {
    collapsed.value = !collapsed.value
}
</script> 