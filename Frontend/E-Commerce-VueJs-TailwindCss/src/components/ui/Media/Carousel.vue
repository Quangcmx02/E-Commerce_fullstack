<template>
    <div class="relative" :class="className">
        <!-- Slides Container -->
        <div class="relative overflow-hidden rounded-lg">
            <div
                class="flex transition-transform duration-500 ease-in-out"
                :style="{
                    transform: `translateX(-${currentIndex * 100}%)`,
                    width: `${slides.length * 100}%`,
                }"
            >
                <div v-for="(slide, index) in slides" :key="index" class="relative w-full flex-shrink-0" :style="{ width: `${100 / slides.length}%` }">
                    <img :src="slide.image" :alt="slide.alt" class="w-full object-cover" :class="aspectRatioClasses[aspectRatio]" @load="handleImageLoad" />
                    <div v-if="slide.caption" class="absolute bottom-0 left-0 right-0 bg-gradient-to-t from-black/75 to-transparent p-4">
                        <p class="text-white">{{ slide.caption }}</p>
                    </div>
                </div>
            </div>

            <!-- Loading Spinner -->
            <div v-if="loading" class="absolute inset-0 flex items-center justify-center bg-zinc-900/50">
                <div class="h-12 w-12 animate-spin rounded-full border-4 border-zinc-500 border-t-white" />
            </div>

            <!-- Navigation Arrows -->
            <button v-if="showArrows && slides.length > 1" class="absolute left-4 top-1/2 -translate-y-1/2 rounded-full bg-black/50 p-2 text-white backdrop-blur-sm transition-all hover:bg-black/75" @click="prev">
                <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
                </svg>
            </button>
            <button v-if="showArrows && slides.length > 1" class="absolute right-4 top-1/2 -translate-y-1/2 rounded-full bg-black/50 p-2 text-white backdrop-blur-sm transition-all hover:bg-black/75" @click="next">
                <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
                </svg>
            </button>
        </div>

        <!-- Indicators -->
        <div v-if="showIndicators && slides.length > 1" class="mt-4 flex items-center justify-center gap-2">
            <button v-for="(_, index) in slides" :key="index" class="h-2 w-2 rounded-full transition-all" :class="[currentIndex === index ? 'bg-white w-4' : 'bg-zinc-600 hover:bg-zinc-500']" @click="goToSlide(index)" />
        </div>

        <!-- Thumbnails -->
        <div v-if="showThumbnails && slides.length > 1" class="mt-4 flex gap-2 overflow-x-auto">
            <button v-for="(slide, index) in slides" :key="index" class="relative flex-shrink-0 overflow-hidden rounded-lg focus:outline-none" :class="{ 'ring-2 ring-white': currentIndex === index }" @click="goToSlide(index)">
                <img :src="slide.image" :alt="slide.alt" class="h-16 w-24 object-cover" />
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from "vue";

interface Slide {
    image: string;
    alt?: string;
    caption?: string;
}

interface Props {
    slides: Slide[];
    autoplay?: boolean;
    interval?: number;
    aspectRatio?: "1:1" | "4:3" | "16:9" | "21:9";
    showArrows?: boolean;
    showIndicators?: boolean;
    showThumbnails?: boolean;
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    autoplay: false,
    interval: 5000,
    aspectRatio: "16:9",
    showArrows: true,
    showIndicators: true,
    showThumbnails: false,
    className: "",
});

const emit = defineEmits(["change"]);

const currentIndex = ref(0);
const loading = ref(true);
let autoplayInterval: number | null = null;

const aspectRatioClasses = {
    "1:1": "aspect-square",
    "4:3": "aspect-[4/3]",
    "16:9": "aspect-video",
    "21:9": "aspect-[21/9]",
};

const next = () => {
    currentIndex.value = (currentIndex.value + 1) % props.slides.length;
    emit("change", currentIndex.value);
};

const prev = () => {
    currentIndex.value = (currentIndex.value - 1 + props.slides.length) % props.slides.length;
    emit("change", currentIndex.value);
};

const goToSlide = (index: number) => {
    currentIndex.value = index;
    emit("change", currentIndex.value);
};

const handleImageLoad = () => {
    loading.value = false;
};

const startAutoplay = () => {
    if (props.autoplay && props.slides.length > 1) {
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

onUnmounted(() => {
    stopAutoplay();
});
</script>
