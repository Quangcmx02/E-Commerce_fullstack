<template>
    <div :class="[className, orientation === 'horizontal' ? 'flex' : 'space-y-4']">
        <div v-for="(item, index) in items" :key="index" :class="[orientation === 'horizontal' ? 'flex-1' : '', { 'ml-4': orientation === 'horizontal' && index > 0 }]">
            <!-- Yatay Düzen -->
            <div v-if="orientation === 'horizontal'" class="relative pb-8">
                <!-- Çizgi -->
                <div v-if="index < items.length - 1" class="absolute left-4 top-4 -ml-px h-0.5 w-full bg-zinc-800" aria-hidden="true" />

                <div class="relative flex items-start">
                    <!-- İkon -->
                    <div class="relative z-10 flex h-8 w-8 items-center justify-center rounded-full" :class="[item.iconBackground || 'bg-zinc-800']">
                        <component :is="item.icon" class="h-5 w-5" :class="[item.iconForeground || 'text-zinc-400']" aria-hidden="true" />
                    </div>

                    <!-- İçerik -->
                    <div class="ml-4 min-w-0 flex-1">
                        <div class="text-sm font-medium text-white">{{ item.title }}</div>
                        <div class="mt-1 text-sm text-zinc-400">{{ item.content }}</div>
                        <div v-if="item.date" class="mt-1 text-xs text-zinc-500">{{ item.date }}</div>
                    </div>
                </div>
            </div>

            <!-- Dikey Düzen -->
            <div v-else class="relative">
                <!-- Çizgi -->
                <div v-if="index < items.length - 1" class="absolute left-4 top-4 -ml-px h-full w-0.5 bg-zinc-800" aria-hidden="true" />

                <div class="relative flex items-start">
                    <!-- İkon -->
                    <div class="relative z-10 flex h-8 w-8 items-center justify-center rounded-full" :class="[item.iconBackground || 'bg-zinc-800']">
                        <component :is="item.icon" class="h-5 w-5" :class="[item.iconForeground || 'text-zinc-400']" aria-hidden="true" />
                    </div>

                    <!-- İçerik -->
                    <div class="ml-4 min-w-0 flex-1">
                        <div class="text-sm font-medium text-white">{{ item.title }}</div>
                        <div class="mt-1 text-sm text-zinc-400">{{ item.content }}</div>
                        <div v-if="item.date" class="mt-1 text-xs text-zinc-500">{{ item.date }}</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import type { Component } from "vue";

interface TimelineItem {
    title: string;
    content: string;
    date?: string;
    icon: Component;
    iconBackground?: string;
    iconForeground?: string;
}

interface Props {
    className?: string;
    items: TimelineItem[];
    orientation?: "vertical" | "horizontal";
}

const props = withDefaults(defineProps<Props>(), {
    className: "",
    orientation: "vertical",
});
</script>
