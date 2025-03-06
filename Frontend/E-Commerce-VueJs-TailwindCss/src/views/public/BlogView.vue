<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Başlık Bölümü -->
            <div class="text-center mb-12">
                <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl mb-4">
                    Blog
                </h1>
                <p class="text-muted-foreground">
                    En son haberler, güncellemeler ve teknoloji yazıları
                </p>
            </div>

            <!-- Kategori Filtreleri -->
            <div class="mb-8">
                <div class="flex flex-wrap gap-2">
                    <button
                        v-for="category in categories"
                        :key="category.id"
                        @click="selectedCategory = category.id"
                        :class="[
                            'px-4 py-2 rounded-md text-sm font-medium transition-colors duration-200',
                            selectedCategory === category.id
                                ? 'bg-primary text-primary-foreground'
                                : 'bg-background border hover:bg-muted',
                        ]"
                    >
                        {{ category.name }}
                    </button>
                </div>
            </div>

            <!-- Blog Yazıları Grid -->
            <div class="grid gap-8 md:grid-cols-2">
                <div
                    v-for="post in filteredPosts"
                    :key="post.id"
                    class="group rounded-lg border bg-background overflow-hidden transition-all duration-200 hover:border-primary"
                >
                    <!-- Blog Görseli -->
                    <div class="aspect-video overflow-hidden">
                        <img
                            :src="post.image"
                            :alt="post.title"
                            class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105"
                        />
                    </div>

                    <!-- Blog İçeriği -->
                    <div class="p-6">
                        <!-- Kategori ve Tarih -->
                        <div class="flex items-center gap-4 text-sm text-muted-foreground mb-3">
                            <span
                                class="inline-flex items-center rounded-full bg-muted px-2.5 py-0.5 text-xs font-medium"
                            >
                                {{ post.category }}
                            </span>
                            <span>{{ post.date }}</span>
                        </div>

                        <!-- Başlık -->
                        <h2 class="text-xl font-semibold group-hover:text-primary mb-2">
                            {{ post.title }}
                        </h2>

                        <!-- Özet -->
                        <p class="text-muted-foreground mb-4">
                            {{ post.excerpt }}
                        </p>

                        <!-- Alt Bilgiler -->
                        <div class="flex items-center justify-between">
                            <div class="flex items-center space-x-4">
                                <img
                                    :src="post.author.avatar"
                                    :alt="post.author.name"
                                    class="h-8 w-8 rounded-full"
                                />
                                <span class="text-sm font-medium">{{ post.author.name }}</span>
                            </div>

                            <router-link
                                :to="{ name: 'blog-detail', params: { slug: post.slug } }"
                                class="inline-flex items-center text-sm font-medium text-primary hover:underline"
                            >
                                Devamını Oku
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    class="h-4 w-4 ml-1"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                >
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="2"
                                        d="M9 5l7 7-7 7"
                                    />
                                </svg>
                            </router-link>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Boş Durum -->
            <div
                v-if="filteredPosts.length === 0"
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
                            d="M19 20H5a2 2 0 01-2-2V6a2 2 0 012-2h10a2 2 0 012 2v1m2 13a2 2 0 01-2-2V7m2 13a2 2 0 002-2V9.5a2.5 2.5 0 00-2.5-2.5H14"
                        />
                    </svg>
                </div>
                <h3 class="mt-4 text-lg font-medium">Blog Yazısı Bulunamadı</h3>
                <p class="mt-2 text-sm text-muted-foreground">
                    Seçili kategoride henüz blog yazısı bulunmuyor.
                </p>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

// Örnek kategori verileri
const categories = [
    { id: 'all', name: 'Tüm Yazılar' },
    { id: 'technology', name: 'Teknoloji' },
    { id: 'ecommerce', name: 'E-Ticaret' },
    { id: 'design', name: 'Tasarım' },
    { id: 'development', name: 'Yazılım Geliştirme' },
]

// Örnek blog yazıları
const posts = [
    {
        id: 1,
        title: 'E-Ticaret Sitenizi Optimize Etmenin 10 Yolu',
        slug: 'e-ticaret-sitenizi-optimize-etmenin-10-yolu',
        excerpt:
            'E-ticaret sitenizin performansını artırmak ve dönüşüm oranlarını yükseltmek için uygulayabileceğiniz en etkili yöntemler.',
        image: 'https://images.unsplash.com/photo-1661956602116-aa6865609028?w=800&h=400&fit=crop',
        category: 'E-Ticaret',
        categoryId: 'ecommerce',
        date: '15 Mayıs 2024',
        author: {
            name: 'Ahmet Yılmaz',
            avatar: 'https://i.pravatar.cc/150?u=ahmet',
        },
    },
    {
        id: 2,
        title: 'Modern Web Tasarım Trendleri 2024',
        slug: 'modern-web-tasarim-trendleri-2024',
        excerpt:
            '2024 yılında öne çıkan web tasarım trendleri ve kullanıcı deneyimini artıran modern tasarım yaklaşımları.',
        image: 'https://images.unsplash.com/photo-1659276998725-61ca1ad6d773?w=800&h=400&fit=crop',
        category: 'Tasarım',
        categoryId: 'design',
        date: '12 Mayıs 2024',
        author: {
            name: 'Zeynep Kaya',
            avatar: 'https://i.pravatar.cc/150?u=zeynep',
        },
    },
    {
        id: 3,
        title: 'Vue.js ile Performanslı Uygulamalar Geliştirme',
        slug: 'vue-js-ile-performansli-uygulamalar-gelistirme',
        excerpt:
            'Vue.js kullanarak yüksek performanslı web uygulamaları geliştirmenin püf noktaları ve best practice örnekleri.',
        image: 'https://images.unsplash.com/photo-1661956602868-6ae368943878?w=800&h=400&fit=crop',
        category: 'Yazılım Geliştirme',
        categoryId: 'development',
        date: '10 Mayıs 2024',
        author: {
            name: 'Mehmet Demir',
            avatar: 'https://i.pravatar.cc/150?u=mehmet',
        },
    },
    {
        id: 4,
        title: 'Yapay Zeka ve E-Ticaretin Geleceği',
        slug: 'yapay-zeka-ve-e-ticaretin-gelecegi',
        excerpt:
            'Yapay zeka teknolojilerinin e-ticaret sektörüne etkileri ve gelecekte bizi bekleyen yenilikler.',
        image: 'https://images.unsplash.com/photo-1661956601349-f61c959a8fd4?w=800&h=400&fit=crop',
        category: 'Teknoloji',
        categoryId: 'technology',
        date: '8 Mayıs 2024',
        author: {
            name: 'Ayşe Yıldız',
            avatar: 'https://i.pravatar.cc/150?u=ayse',
        },
    },
]

const selectedCategory = ref('all')

// Filtrelenmiş blog yazıları
const filteredPosts = computed(() => {
    if (selectedCategory.value === 'all') {
        return posts
    }
    return posts.filter((post) => post.categoryId === selectedCategory.value)
})
</script>
