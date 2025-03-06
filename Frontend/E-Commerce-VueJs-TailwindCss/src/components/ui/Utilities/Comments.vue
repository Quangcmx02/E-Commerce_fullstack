<template>
    <div class="space-y-4">
        <!-- Yorum Formu -->
        <div class="space-y-2">
            <textarea
                v-model="newComment"
                rows="3"
                class="w-full rounded-lg border border-zinc-700 bg-zinc-800 p-3 text-sm text-white placeholder-zinc-400 focus:border-primary focus:outline-none focus:ring-2 focus:ring-primary/20"
                placeholder="Yorumunuzu yazın..."
            ></textarea>
            <div class="flex justify-end">
                <button
                    @click="addComment"
                    class="rounded-lg bg-primary px-4 py-2 text-sm font-medium text-white hover:bg-primary/90"
                    :disabled="!newComment.trim()"
                >
                    Yorum Yap
                </button>
            </div>
        </div>

        <!-- Yorumlar Listesi -->
        <div class="space-y-4">
            <div v-for="comment in comments" :key="comment.id" class="space-y-2">
                <div class="flex items-start space-x-3">
                    <!-- Kullanıcı Avatarı -->
                    <img
                        :src="comment.user.avatar"
                        :alt="comment.user.name"
                        class="h-8 w-8 rounded-full object-cover"
                    />
                    <!-- Yorum İçeriği -->
                    <div class="flex-1 space-y-1">
                        <div class="flex items-center justify-between">
                            <div class="flex items-center space-x-2">
                                <span class="text-sm font-medium text-white">{{ comment.user.name }}</span>
                                <span class="text-xs text-zinc-400">{{ formatDate(comment.date) }}</span>
                            </div>
                            <!-- Yorum Aksiyonları -->
                            <div class="flex items-center space-x-2">
                                <button
                                    @click="toggleLike(comment)"
                                    class="flex items-center space-x-1 text-xs text-zinc-400 hover:text-primary"
                                >
                                    <svg
                                        :class="{ 'text-primary fill-primary': comment.isLiked }"
                                        class="h-4 w-4"
                                        xmlns="http://www.w3.org/2000/svg"
                                        fill="none"
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
                                    <span>{{ comment.likes }}</span>
                                </button>
                                <button
                                    @click="replyTo(comment)"
                                    class="text-xs text-zinc-400 hover:text-primary"
                                >
                                    Yanıtla
                                </button>
                            </div>
                        </div>
                        <p class="text-sm text-zinc-300">{{ comment.content }}</p>

                        <!-- Yanıtlar -->
                        <div v-if="comment.replies?.length" class="mt-3 space-y-3 pl-4">
                            <div
                                v-for="reply in comment.replies"
                                :key="reply.id"
                                class="flex items-start space-x-3"
                            >
                                <img
                                    :src="reply.user.avatar"
                                    :alt="reply.user.name"
                                    class="h-6 w-6 rounded-full object-cover"
                                />
                                <div class="flex-1 space-y-1">
                                    <div class="flex items-center space-x-2">
                                        <span class="text-sm font-medium text-white">{{ reply.user.name }}</span>
                                        <span class="text-xs text-zinc-400">{{ formatDate(reply.date) }}</span>
                                    </div>
                                    <p class="text-sm text-zinc-300">{{ reply.content }}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';

interface User {
    id: number;
    name: string;
    avatar: string;
}

interface Reply {
    id: number;
    user: User;
    content: string;
    date: Date;
}

interface Comment {
    id: number;
    user: User;
    content: string;
    date: Date;
    likes: number;
    isLiked: boolean;
    replies?: Reply[];
}

interface Props {
    initialComments?: Comment[];
}

const props = withDefaults(defineProps<Props>(), {
    initialComments: () => [],
});

const emit = defineEmits(['add', 'like', 'reply']);

const comments = ref<Comment[]>(props.initialComments);
const newComment = ref('');

const addComment = () => {
    if (!newComment.value.trim()) return;

    const comment: Comment = {
        id: Date.now(),
        user: {
            id: 1,
            name: 'Kullanıcı',
            avatar: 'https://i.pravatar.cc/150?img=1',
        },
        content: newComment.value,
        date: new Date(),
        likes: 0,
        isLiked: false,
    };

    comments.value.unshift(comment);
    newComment.value = '';
    emit('add', comment);
};

const toggleLike = (comment: Comment) => {
    comment.isLiked = !comment.isLiked;
    comment.likes += comment.isLiked ? 1 : -1;
    emit('like', comment);
};

const replyTo = (comment: Comment) => {
    emit('reply', comment);
};

const formatDate = (date: Date) => {
    return new Intl.DateTimeFormat('tr-TR', {
        day: 'numeric',
        month: 'long',
        hour: 'numeric',
        minute: 'numeric',
    }).format(date);
};
</script> 