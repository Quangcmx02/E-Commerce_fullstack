<template>
    <div class="container py-8">
        <!-- Başlık -->
        <div class="mb-8">
            <h1 class="text-3xl font-bold tracking-tight">Kategoriler</h1>
            <p class="text-muted-foreground">Tüm kategorileri keşfedin</p>
        </div>

        <!-- Kategoriler Grid -->
        <div class="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-3">
            <router-link
                v-for="category in categories"
                :key="category.id"
                :to="'/categories/' + category.slug"
                class="group relative overflow-hidden rounded-lg border bg-background"
            >
                <div class="aspect-[4/3] overflow-hidden">
                    <img
                        :src="category.image"
                        :alt="category.name"
                        class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105"
                    />
                </div>
                <div class="p-4">
                    <h3 class="text-lg font-semibold">{{ category.name }}</h3>
                    <p class="mt-1 text-sm text-muted-foreground">{{ category.description }}</p>
                    <div class="mt-2 flex items-center justify-between">
                        <span class="text-sm text-muted-foreground"
                            >{{ category.productCount }} Ürün</span
                        >
                        <span
                            class="inline-flex items-center text-sm font-medium text-primary hover:underline"
                        >
                            Ürünleri Gör
                            <svg
                                xmlns="http://www.w3.org/2000/svg"
                                width="24"
                                height="24"
                                viewBox="0 0 24 24"
                                fill="none"
                                stroke="currentColor"
                                stroke-width="2"
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                class="ml-1 h-4 w-4"
                            >
                                <path d="m9 18 6-6-6-6" />
                            </svg>
                        </span>
                    </div>
                </div>
            </router-link>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

// Örnek kategori verileri
const categories = ref([
    {
        id: 1,
        name: 'Elektronik',
        slug: 'elektronik',
        description: 'Telefon, bilgisayar, tablet ve daha fazlası',
        image: 'https://images.unsplash.com/photo-1498049794561-7780e7231661?w=500&h=400&fit=crop',
        productCount: 1250,
    },
    {
        id: 2,
        name: 'Giyim',
        slug: 'giyim',
        description: 'Erkek, kadın ve çocuk giyim ürünleri',
        image: 'https://images.unsplash.com/photo-1445205170230-053b83016050?w=500&h=400&fit=crop',
        productCount: 850,
    },
    {
        id: 3,
        name: 'Kitap',
        slug: 'kitap',
        description: 'Roman, bilim, tarih ve daha fazla kitap',
        image: 'https://images.unsplash.com/photo-1495446815901-a7297e633e8d?w=500&h=400&fit=crop',
        productCount: 650,
    },
    {
        id: 4,
        name: 'Spor',
        slug: 'spor',
        description: 'Spor giyim ve ekipmanları',
        image: 'https://images.unsplash.com/photo-1517836357463-d25dfeac3438?w=500&h=400&fit=crop',
        productCount: 450,
    },
    {
        id: 5,
        name: 'Ev & Yaşam',
        slug: 'ev-yasam',
        description: 'Ev dekorasyon ve yaşam ürünleri',
        image: 'https://images.unsplash.com/photo-1484101403633-562f891dc89a?w=500&h=400&fit=crop',
        productCount: 750,
    },
    {
        id: 6,
        name: 'Kozmetik',
        slug: 'kozmetik',
        description: 'Makyaj, cilt bakımı ve parfüm',
        image: 'https://images.unsplash.com/photo-1612817288484-6f916006741a?w=500&h=400&fit=crop',
        productCount: 550,
    },
])
</script>
