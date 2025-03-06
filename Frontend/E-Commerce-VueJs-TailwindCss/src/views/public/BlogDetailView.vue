<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Geri Dönüş Linki -->
            <router-link
                to="/blog"
                class="inline-flex items-center text-sm text-muted-foreground hover:text-primary mb-8"
            >
                <svg
                    xmlns="http://www.w3.org/2000/svg"
                    class="h-4 w-4 mr-1"
                    fill="none"
                    viewBox="0 0 24 24"
                    stroke="currentColor"
                >
                    <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        stroke-width="2"
                        d="M10 19l-7-7m0 0l7-7m-7 7h18"
                    />
                </svg>
                Blog'a Dön
            </router-link>

            <!-- Blog Başlığı ve Meta Bilgileri -->
            <div class="mb-8">
                <div class="flex items-center gap-4 text-sm text-muted-foreground mb-4">
                    <span
                        class="inline-flex items-center rounded-full bg-muted px-2.5 py-0.5 text-xs font-medium"
                    >
                        {{ post.category }}
                    </span>
                    <span>{{ post.date }}</span>
                </div>

                <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl mb-6">
                    {{ post.title }}
                </h1>

                <div class="flex items-center space-x-4">
                    <img
                        :src="post.author.avatar"
                        :alt="post.author.name"
                        class="h-10 w-10 rounded-full"
                    />
                    <div>
                        <div class="font-medium">{{ post.author.name }}</div>
                        <div class="text-sm text-muted-foreground">{{ post.author.title }}</div>
                    </div>
                </div>
            </div>

            <!-- Blog Görseli -->
            <div class="rounded-lg overflow-hidden mb-8">
                <img :src="post.image" :alt="post.title" class="w-full h-auto" />
            </div>

            <!-- Blog İçeriği -->
            <div class="prose prose-muted max-w-none mb-12">
                <div v-html="post.content"></div>
            </div>

            <!-- Yorumlar Bölümü -->
            <div class="border-t pt-8">
                <h2 class="text-2xl font-bold tracking-tight mb-6">
                    Yorumlar ({{ comments.length }})
                </h2>

                <!-- Yorum Formu -->
                <div class="rounded-lg border bg-background p-6 mb-8">
                    <h3 class="text-lg font-semibold mb-4">Yorum Yap</h3>
                    <form @submit.prevent="handleCommentSubmit" class="space-y-4">
                        <div>
                            <label for="name" class="block text-sm font-medium mb-1"
                                >Ad Soyad</label
                            >
                            <input
                                type="text"
                                id="name"
                                v-model="commentForm.name"
                                class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                required
                            />
                        </div>

                        <div>
                            <label for="email" class="block text-sm font-medium mb-1"
                                >E-posta</label
                            >
                            <input
                                type="email"
                                id="email"
                                v-model="commentForm.email"
                                class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                required
                            />
                        </div>

                        <div>
                            <label for="comment" class="block text-sm font-medium mb-1"
                                >Yorum</label
                            >
                            <textarea
                                id="comment"
                                v-model="commentForm.comment"
                                rows="4"
                                class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                required
                            ></textarea>
                        </div>

                        <button
                            type="submit"
                            class="inline-flex items-center justify-center rounded-md bg-primary px-6 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
                        >
                            Yorum Gönder
                        </button>
                    </form>
                </div>

                <!-- Yorumlar Listesi -->
                <div class="space-y-6">
                    <div
                        v-for="comment in comments"
                        :key="comment.id"
                        class="rounded-lg border bg-background p-6"
                    >
                        <div class="flex items-start justify-between">
                            <div class="flex items-center space-x-4">
                                <img
                                    :src="comment.avatar"
                                    :alt="comment.name"
                                    class="h-10 w-10 rounded-full"
                                />
                                <div>
                                    <div class="font-medium">{{ comment.name }}</div>
                                    <div class="text-sm text-muted-foreground">
                                        {{ comment.date }}
                                    </div>
                                </div>
                            </div>
                        </div>
                        <p class="mt-4 text-muted-foreground">{{ comment.comment }}</p>
                    </div>
                </div>

                <!-- Boş Durum -->
                <div
                    v-if="comments.length === 0"
                    class="flex flex-col items-center justify-center rounded-lg border bg-background p-12 text-center"
                >
                    <div class="text-muted-foreground">
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            class="mx-auto h-12 w-12"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M8 12h.01M12 12h.01M16 12h.01M21 12c0 4.418-4.03 8-9 8a9.863 9.863 0 01-4.255-.949L3 20l1.395-3.72C3.512 15.042 3 13.574 3 12c0-4.418 4.03-8 9-8s9 3.582 9 8z"
                            />
                        </svg>
                    </div>
                    <h3 class="mt-4 text-lg font-medium">Henüz Yorum Yapılmamış</h3>
                    <p class="mt-2 text-sm text-muted-foreground">
                        İlk yorumu siz yapın ve tartışmayı başlatın.
                    </p>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()

// Örnek blog yazısı verisi
const post = ref({
    id: 1,
    title: 'E-Ticaret Sitenizi Optimize Etmenin 10 Yolu',
    slug: 'e-ticaret-sitenizi-optimize-etmenin-10-yolu',
    category: 'E-Ticaret',
    date: '15 Mayıs 2024',
    image: 'https://images.unsplash.com/photo-1661956602116-aa6865609028?w=1200&h=600&fit=crop',
    author: {
        name: 'Ahmet Yılmaz',
        title: 'Senior Frontend Developer',
        avatar: 'https://i.pravatar.cc/150?u=ahmet',
    },
    content: `
        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.</p>

        <h2>1. Site Hızını Optimize Edin</h2>
        <p>Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p>

        <h2>2. Mobil Uyumluluğu Sağlayın</h2>
        <p>Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.</p>

        <h2>3. SEO Optimizasyonu Yapın</h2>
        <p>Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.</p>
    `,
})

// Örnek yorumlar
const comments = ref([
    {
        id: 1,
        name: 'Mehmet Demir',
        avatar: 'https://i.pravatar.cc/150?u=mehmet2',
        date: '16 Mayıs 2024',
        comment:
            'Harika bir yazı olmuş! Özellikle site hızı optimizasyonu konusundaki öneriler çok faydalı.',
    },
    {
        id: 2,
        name: 'Ayşe Yıldız',
        avatar: 'https://i.pravatar.cc/150?u=ayse2',
        date: '16 Mayıs 2024',
        comment: 'SEO optimizasyonu konusundaki önerileri hemen uygulamaya başladım. Teşekkürler!',
    },
])

// Yorum formu
const commentForm = ref({
    name: '',
    email: '',
    comment: '',
})

const handleCommentSubmit = () => {
    // Yeni yorum ekleme
    const newComment = {
        id: comments.value.length + 1,
        name: commentForm.value.name,
        avatar: `https://i.pravatar.cc/150?u=${commentForm.value.name.toLowerCase().replace(' ', '')}`,
        date: new Date().toLocaleDateString('tr-TR', {
            year: 'numeric',
            month: 'long',
            day: 'numeric',
        }),
        comment: commentForm.value.comment,
    }

    comments.value.unshift(newComment)

    // Form temizleme
    commentForm.value = {
        name: '',
        email: '',
        comment: '',
    }
}

onMounted(() => {
    // Gerçek uygulamada burada API'den blog yazısı detayları çekilecek
    console.log('Blog slug:', route.params.slug)
})
</script>
