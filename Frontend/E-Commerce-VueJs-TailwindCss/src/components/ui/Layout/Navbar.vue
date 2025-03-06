<template>
    <nav :class="['relative bg-zinc-900 border-b border-zinc-800', className]">
        <div class="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
            <div class="flex items-center justify-between h-16">
                <!-- Logo/Brand -->
                <div class="flex-shrink-0">
                    <slot name="brand">
                        <a href="#" class="text-white font-bold">Logo</a>
                    </slot>
                </div>

                <!-- Desktop Menu -->
                <div class="hidden md:flex md:items-center md:space-x-4">
                    <slot name="menu" />
                </div>

                <!-- Right Content -->
                <div class="hidden md:flex md:items-center md:space-x-4">
                    <slot name="right" />
                </div>

                <!-- Mobile Menu Button -->
                <div class="flex md:hidden">
                    <button
                        type="button"
                        class="inline-flex items-center justify-center p-2 rounded-md text-zinc-400 hover:text-white hover:bg-zinc-800 focus:outline-none"
                        @click="isOpen = !isOpen"
                    >
                        <span class="sr-only">Ana menüyü aç</span>
                        <svg
                            v-if="!isOpen"
                            class="h-6 w-6"
                            xmlns="http://www.w3.org/2000/svg"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                        </svg>
                        <svg
                            v-else
                            class="h-6 w-6"
                            xmlns="http://www.w3.org/2000/svg"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                        </svg>
                    </button>
                </div>
            </div>
        </div>

        <!-- Mobile Menu -->
        <div
            v-show="isOpen"
            class="md:hidden"
        >
            <div class="px-2 pt-2 pb-3 space-y-1">
                <slot name="mobile-menu">
                    <slot name="menu" />
                </slot>
            </div>
            <div class="pt-4 pb-3 border-t border-zinc-800">
                <div class="px-2 space-y-1">
                    <slot name="mobile-right">
                        <slot name="right" />
                    </slot>
                </div>
            </div>
        </div>
    </nav>
</template>

<script setup lang="ts">
import { ref } from 'vue'

defineProps<{
    className?: string
}>()

const isOpen = ref(false)
</script> 