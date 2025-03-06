<template>
    <div>
        <!-- Thumbnail Grid -->
        <div class="grid grid-cols-2 gap-4 sm:grid-cols-3 md:grid-cols-4" :class="className">
            <div v-for="(image, index) in images" :key="index" class="group relative aspect-square cursor-pointer overflow-hidden rounded-lg" @click="openLightbox(index)">
                <img :src="image.thumbnail || image.src" :alt="image.alt" class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-110" />
                <div class="absolute inset-0 bg-black/25 opacity-0 transition-opacity group-hover:opacity-100" />
            </div>
        </div>

        <!-- Lightbox Modal -->
        <Teleport to="body">
            <Transition enter-active-class="transition duration-300 ease-out" enter-from-class="opacity-0 scale-95" enter-to-class="opacity-100 scale-100" leave-active-class="transition duration-200 ease-in" leave-from-class="opacity-100 scale-100" leave-to-class="opacity-0 scale-95">
                <div v-if="isOpen" class="fixed inset-0 z-50 flex items-center justify-center bg-black/90" @click="closeLightbox">
                    <!-- Close Button -->
                    <button class="absolute right-4 top-4 rounded-full bg-black/50 p-2 text-white backdrop-blur-sm transition-all hover:bg-black/75" @click="closeLightbox">
                        <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                        </svg>
                    </button>

                    <!-- Navigation Arrows -->
                    <button v-if="images.length > 1" class="absolute left-4 top-1/2 -translate-y-1/2 rounded-full bg-black/50 p-2 text-white backdrop-blur-sm transition-all hover:bg-black/75" @click.stop="prev">
                        <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
                        </svg>
                    </button>
                    <button v-if="images.length > 1" class="absolute right-4 top-1/2 -translate-y-1/2 rounded-full bg-black/50 p-2 text-white backdrop-blur-sm transition-all hover:bg-black/75" @click.stop="next">
                        <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
                        </svg>
                    </button>

                    <!-- Image Container -->
                    <div class="relative max-h-[90vh] max-w-[90vw]" @click.stop>
                        <img :src="currentImage.src" :alt="currentImage.alt" class="h-full w-full object-contain" @load="handleImageLoad" />

                        <!-- Loading Spinner -->
                        <div v-if="loading" class="absolute inset-0 flex items-center justify-center">
                            <div class="h-12 w-12 animate-spin rounded-full border-4 border-zinc-500 border-t-white" />
                        </div>

                        <!-- Caption -->
                        <div v-if="currentImage.caption" class="absolute bottom-0 left-0 right-0 bg-gradient-to-t from-black/75 to-transparent p-4">
                            <p class="text-center text-white">{{ currentImage.caption }}</p>
                        </div>
                    </div>

                    <!-- Thumbnails -->
                    <div v-if="showThumbnails && images.length > 1" class="absolute bottom-4 left-1/2 flex -translate-x-1/2 gap-2 overflow-x-auto">
                        <button v-for="(image, index) in images" :key="index" class="relative h-16 w-24 flex-shrink-0 overflow-hidden rounded-lg focus:outline-none" :class="{ 'ring-2 ring-white': currentIndex === index }" @click.stop="goToImage(index)">
                            <img :src="image.thumbnail || image.src" :alt="image.alt" class="h-full w-full object-cover" />
                        </button>
                    </div>
                </div>
            </Transition>
        </Teleport>
    </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, onUnmounted } from "vue";

interface Image {
    src: string;
    thumbnail?: string;
    alt?: string;
    caption?: string;
}

interface Props {
    images: Image[];
    showThumbnails?: boolean;
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    showThumbnails: true,
    className: "",
});

const emit = defineEmits(["open", "close", "change"]);

const isOpen = ref(false);
const currentIndex = ref(0);
const loading = ref(true);

const currentImage = computed(() => props.images[currentIndex.value]);

const openLightbox = (index: number) => {
    currentIndex.value = index;
    isOpen.value = true;
    loading.value = true;
    emit("open", index);
};

const closeLightbox = () => {
    isOpen.value = false;
    emit("close");
};

const next = () => {
    loading.value = true;
    currentIndex.value = (currentIndex.value + 1) % props.images.length;
    emit("change", currentIndex.value);
};

const prev = () => {
    loading.value = true;
    currentIndex.value = (currentIndex.value - 1 + props.images.length) % props.images.length;
    emit("change", currentIndex.value);
};

const goToImage = (index: number) => {
    loading.value = true;
    currentIndex.value = index;
    emit("change", index);
};

const handleImageLoad = () => {
    loading.value = false;
};

// Klavye kontrolü
const handleKeydown = (event: KeyboardEvent) => {
    if (!isOpen.value) return;

    switch (event.key) {
        case "ArrowLeft":
            prev();
            break;
        case "ArrowRight":
            next();
            break;
        case "Escape":
            closeLightbox();
            break;
    }
};

// Klavye event listener'larını ekle/kaldır
onMounted(() => {
    document.addEventListener("keydown", handleKeydown);
});

onUnmounted(() => {
    document.removeEventListener("keydown", handleKeydown);
});
</script>
