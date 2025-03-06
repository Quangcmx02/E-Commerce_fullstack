<template>
    <div class="inline-flex items-center space-x-2">
        <!-- Beğeni Butonu -->
        <button
            @click="toggleLike"
            class="group relative inline-flex items-center space-x-2 rounded-lg px-4 py-2 text-sm font-medium transition-colors"
            :class="[
                isLiked
                    ? 'bg-red-500/10 text-red-500'
                    : 'bg-zinc-800 text-white hover:bg-zinc-700'
            ]"
        >
            <!-- Kalp İkonu -->
            <svg
                class="h-5 w-5 transition-all duration-300"
                :class="{ 'scale-125 animate-bounce': isAnimating }"
                xmlns="http://www.w3.org/2000/svg"
                :fill="isLiked ? 'currentColor' : 'none'"
                viewBox="0 0 24 24"
                stroke="currentColor"
            >
                <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"
                />
            </svg>
            <span>{{ count }}</span>

            <!-- Tepki Menüsü -->
            <div
                v-if="showReactions"
                class="absolute bottom-full left-0 mb-2 flex -space-x-1 rounded-full bg-white p-1 shadow-lg dark:bg-zinc-800"
            >
                <button
                    v-for="reaction in reactions"
                    :key="reaction.type"
                    @click.stop="selectReaction(reaction.type)"
                    class="group relative rounded-full p-1.5 hover:bg-zinc-100 dark:hover:bg-zinc-700"
                    :class="{ 'scale-125': selectedReaction === reaction.type }"
                >
                    <span class="text-xl">{{ reaction.emoji }}</span>
                    <span
                        class="absolute -bottom-8 left-1/2 hidden -translate-x-1/2 rounded-md bg-zinc-800 px-2 py-1 text-xs text-white group-hover:block"
                    >
                        {{ reaction.label }}
                    </span>
                </button>
            </div>
        </button>

        <!-- Beğenenler Listesi -->
        <div v-if="showLikesList && likesList.length > 0" class="relative">
            <div class="flex -space-x-2">
                <img
                    v-for="(user, index) in visibleLikesList"
                    :key="index"
                    :src="user.avatar"
                    :alt="user.name"
                    class="h-6 w-6 rounded-full border-2 border-white dark:border-zinc-800"
                />
            </div>
            <span v-if="likesList.length > maxVisibleLikes" class="ml-2 text-sm text-zinc-400">
                +{{ likesList.length - maxVisibleLikes }}
            </span>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';

interface User {
    id: number;
    name: string;
    avatar: string;
}

interface Props {
    modelValue?: boolean;
    count?: number;
    showReactions?: boolean;
    showLikesList?: boolean;
    likesList?: User[];
    maxVisibleLikes?: number;
}

const props = withDefaults(defineProps<Props>(), {
    modelValue: false,
    count: 0,
    showReactions: false,
    showLikesList: false,
    likesList: () => [],
    maxVisibleLikes: 3,
});

const emit = defineEmits(['update:modelValue', 'reaction']);

const isLiked = ref(props.modelValue);
const isAnimating = ref(false);
const selectedReaction = ref<string | null>(null);

const reactions = [
    { type: 'like', emoji: '👍', label: 'Beğen' },
    { type: 'love', emoji: '❤️', label: 'Çok Beğen' },
    { type: 'haha', emoji: '😄', label: 'Güldüm' },
    { type: 'wow', emoji: '😮', label: 'Şaşırdım' },
    { type: 'sad', emoji: '😢', label: 'Üzüldüm' },
    { type: 'angry', emoji: '😠', label: 'Kızdım' },
];

const visibleLikesList = computed(() => {
    return props.likesList.slice(0, props.maxVisibleLikes);
});

const toggleLike = () => {
    isLiked.value = !isLiked.value;
    isAnimating.value = true;
    emit('update:modelValue', isLiked.value);

    setTimeout(() => {
        isAnimating.value = false;
    }, 1000);
};

const selectReaction = (type: string) => {
    selectedReaction.value = type;
    isLiked.value = true;
    emit('reaction', type);
};
</script> 