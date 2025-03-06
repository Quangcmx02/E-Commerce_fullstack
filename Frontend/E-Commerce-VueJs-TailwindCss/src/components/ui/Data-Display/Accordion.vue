<template>
    <div :class="className">
        <div v-for="(item, index) in items" :key="index" class="border-b border-zinc-800">
            <button
                class="flex w-full items-center justify-between py-4 text-left"
                @click="toggleItem(index)"
            >
                <span class="text-sm font-medium text-white">{{ item.title }}</span>
                <svg
                    class="h-5 w-5 transform text-zinc-400 transition-transform duration-200"
                    :class="{ 'rotate-180': expandedItems.includes(index) }"
                    viewBox="0 0 20 20"
                    fill="currentColor"
                >
                    <path
                        fill-rule="evenodd"
                        d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z"
                        clip-rule="evenodd"
                    />
                </svg>
            </button>
            <div
                v-show="expandedItems.includes(index)"
                class="pb-4 text-sm text-zinc-400"
            >
                {{ item.content }}
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';

interface AccordionItem {
    title: string;
    content: string;
}

interface Props {
    className?: string;
    items: AccordionItem[];
    multiple?: boolean;
}

const props = withDefaults(defineProps<Props>(), {
    className: '',
    multiple: false,
});

const expandedItems = ref<number[]>([]);

const toggleItem = (index: number) => {
    if (props.multiple) {
        const itemIndex = expandedItems.value.indexOf(index);
        if (itemIndex === -1) {
            expandedItems.value.push(index);
        } else {
            expandedItems.value.splice(itemIndex, 1);
        }
    } else {
        if (expandedItems.value.includes(index)) {
            expandedItems.value = [];
        } else {
            expandedItems.value = [index];
        }
    }
};
</script> 