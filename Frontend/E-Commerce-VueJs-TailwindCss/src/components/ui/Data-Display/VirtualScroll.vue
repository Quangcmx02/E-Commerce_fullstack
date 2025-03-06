<template>
    <div
        ref="containerRef"
        :class="['relative overflow-auto', className]"
        :style="{ height: height + 'px' }"
        @scroll="handleScroll"
    >
        <div :style="{ height: totalHeight + 'px', position: 'relative' }">
            <div
                :style="{
                    transform: `translateY(${startOffset}px)`,
                    position: 'absolute',
                    width: '100%',
                }"
            >
                <template v-for="(item, index) in visibleItems" :key="getKey(item, startIndex + index)">
                    <slot :item="item" :index="startIndex + index" />
                </template>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, onUnmounted } from 'vue';

interface Props {
    className?: string;
    items: any[];
    height: number;
    itemHeight: number;
    buffer?: number;
    keyField?: string;
}

const props = withDefaults(defineProps<Props>(), {
    className: '',
    buffer: 5,
    keyField: 'id',
});

const containerRef = ref<HTMLElement | null>(null);
const scrollTop = ref(0);

// Toplam yükseklik
const totalHeight = computed(() => props.items.length * props.itemHeight);

// Görünür öğelerin başlangıç indeksi
const startIndex = computed(() => {
    const index = Math.floor(scrollTop.value / props.itemHeight);
    return Math.max(0, index - props.buffer);
});

// Görünür öğelerin bitiş indeksi
const endIndex = computed(() => {
    const visibleCount = Math.ceil(props.height / props.itemHeight);
    const index = startIndex.value + visibleCount + props.buffer * 2;
    return Math.min(props.items.length, index);
});

// Görünür öğeler
const visibleItems = computed(() => {
    return props.items.slice(startIndex.value, endIndex.value);
});

// Başlangıç offseti
const startOffset = computed(() => startIndex.value * props.itemHeight);

// Scroll işleyicisi
const handleScroll = (event: Event) => {
    const target = event.target as HTMLElement;
    scrollTop.value = target.scrollTop;
};

// Öğe anahtarı alma
const getKey = (item: any, index: number) => {
    return props.keyField ? item[props.keyField] : index;
};

// Yaşam döngüsü kancaları
onMounted(() => {
    if (containerRef.value) {
        containerRef.value.addEventListener('scroll', handleScroll);
    }
});

onUnmounted(() => {
    if (containerRef.value) {
        containerRef.value.removeEventListener('scroll', handleScroll);
    }
});
</script> 