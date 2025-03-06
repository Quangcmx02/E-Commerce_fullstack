<template>
    <div class="relative" :class="className">
        <!-- Main Image -->
        <div class="relative overflow-hidden rounded-lg">
            <div class="flex transition-transform duration-300 ease-in-out" :style="{ transform: `translateX(-${currentIndex * 100}%)` }">
                <div v-for="(image, index) in images" :key="index" class="w-full flex-shrink-0">
                    <img :src="image.src" :alt="image.alt" class="w-full h-full object-cover" :class="aspectRatioClasses[aspectRatio]" />
                </div>
            </div>

            <!-- Navigation Arrows -->
            <button v-if="showArrows && images.length > 1" @click="prev" class="absolute left-2 top-1/2 -translate-y-1/2 p-1.5 rounded-full bg-black/50 text-white hover:bg-black/70 focus:outline-none">
                <svg class="w-6 h-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
                </svg>
            </button>
            <button v-if="showArrows && images.length > 1" @click="next" class="absolute right-2 top-1/2 -translate-y-1/2 p-1.5 rounded-full bg-black/50 text-white hover:bg-black/70 focus:outline-none">
                <svg class="w-6 h-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
                </svg>
            </button>
        </div>

        <!-- Thumbnails -->
        <div v-if="showThumbnails && images.length > 1" class="flex space-x-2 mt-4 overflow-x-auto">
            <button v-for="(image, index) in images" :key="index" @click="currentIndex = index" class="relative flex-shrink-0 focus:outline-none">
                <img :src="image.src" :alt="image.alt" class="w-16 h-16 object-cover rounded-lg" :class="{ 'ring-2 ring-primary': currentIndex === index }" />
            </button>
        </div>

        <!-- Dots -->
        <div v-if="showDots && images.length > 1" class="absolute bottom-4 left-1/2 -translate-x-1/2 flex space-x-2">
            <button v-for="(_, index) in images" :key="index" @click="currentIndex = index" class="w-2 h-2 rounded-full focus:outline-none transition-colors duration-200" :class="currentIndex === index ? 'bg-white' : 'bg-white/50'" />
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onBeforeUnmount } from "vue";

interface Image {
    src: string;
    alt?: string;
}

interface Props {
    images: Image[];
    autoplay?: boolean;
    interval?: number;
    aspectRatio?: "1:1" | "4:3" | "16:9" | "21:9";
    showArrows?: boolean;
    showDots?: boolean;
    showThumbnails?: boolean;
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    autoplay: false,
    interval: 5000,
    aspectRatio: "16:9",
    showArrows: true,
    showDots: true,
    showThumbnails: false,
    className: "",
});

const currentIndex = ref(0);
let autoplayInterval: number | null = null;

const aspectRatioClasses = {
    "1:1": "aspect-square",
    "4:3": "aspect-[4/3]",
    "16:9": "aspect-video",
    "21:9": "aspect-[21/9]",
};

const next = () => {
    currentIndex.value = (currentIndex.value + 1) % props.images.length;
};

const prev = () => {
    currentIndex.value = (currentIndex.value - 1 + props.images.length) % props.images.length;
};

const startAutoplay = () => {
    if (props.autoplay && props.images.length > 1) {
        autoplayInterval = window.setInterval(next, props.interval);
    }
};

const stopAutoplay = () => {
    if (autoplayInterval) {
        clearInterval(autoplayInterval);
        autoplayInterval = null;
    }
};

onMounted(() => {
    startAutoplay();
});

onBeforeUnmount(() => {
    stopAutoplay();
});
</script>
