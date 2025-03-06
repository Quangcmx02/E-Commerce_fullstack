<template>
    <div class="container py-8">
        <!-- Breadcrumb -->
        <nav class="mb-8 flex" aria-label="Breadcrumb">
            <ol class="inline-flex items-center space-x-1 text-sm text-muted-foreground md:space-x-2">
                <li>
                    <router-link to="/" class="hover:text-foreground">Ana Sayfa</router-link>
                </li>
                <li>
                    <span class="mx-2">/</span>
                </li>
                <li>
                    <router-link to="/brands" class="hover:text-foreground">Markalar</router-link>
                </li>
                <li>
                    <span class="mx-2">/</span>
                </li>
                <li class="text-foreground">{{ brand.name }}</li>
            </ol>
        </nav>

        <!-- Marka Başlık Bölümü -->
        <div class="mb-8 rounded-lg bg-card p-6 shadow-lg">
            <div class="flex flex-col items-center gap-6 md:flex-row md:justify-between">
                <!-- Logo ve İsim -->
                <div class="flex items-center gap-6">
                    <img :src="brand.logo" :alt="brand.name" class="h-24 w-24 object-contain" />
                    <div>
                        <h1 class="text-3xl font-bold tracking-tight">{{ brand.name }}</h1>
                        <p class="mt-2 text-muted-foreground">{{ brand.description }}</p>
                    </div>
                </div>

                <!-- İstatistikler -->
                <div class="flex flex-wrap items-center gap-6">
                    <div class="text-center">
                        <span class="text-2xl font-bold">{{ brand.productCount }}</span>
                        <p class="text-sm text-muted-foreground">Ürün</p>
                    </div>
                    <div class="text-center">
                        <div class="flex items-center gap-1">
                            <span class="text-2xl font-bold">{{ brand.rating }}</span>
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="currentColor" class="text-yellow-400">
                                <path d="M12 2l2.4 7.4H22l-6 4.4 2.3 7.2-6.3-4.6-6.3 4.6L8 13.8l-6-4.4h7.6L12 2z" />
                            </svg>
                        </div>
                        <p class="text-sm text-muted-foreground">{{ brand.reviewCount }} Değerlendirme</p>
                    </div>
                    <div class="text-center">
                        <span class="text-2xl font-bold">{{ brand.followerCount }}</span>
                        <p class="text-sm text-muted-foreground">Takipçi</p>
                    </div>
                </div>
            </div>

            <!-- Marka Hakkında -->
            <div class="mt-6 border-t pt-6">
                <h2 class="text-xl font-semibold">Marka Hakkında</h2>
                <div class="mt-4 grid gap-6 md:grid-cols-2">
                    <div class="space-y-4">
                        <p class="text-muted-foreground">{{ brand.about }}</p>
                        <div class="flex flex-wrap gap-2">
                            <span v-for="tag in brand.tags" :key="tag" class="rounded-full bg-accent px-3 py-1 text-sm">
                                {{ tag }}
                            </span>
                        </div>
                    </div>
                    <div class="space-y-4">
                        <div class="flex items-center gap-2">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M20 10c0 6-8 12-8 12s-8-6-8-12a8 8 0 0 1 16 0Z" />
                                <circle cx="12" cy="10" r="3" />
                            </svg>
                            <span>{{ brand.location }}</span>
                        </div>
                        <div class="flex items-center gap-2">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <rect width="20" height="16" x="2" y="4" rx="2" />
                                <path d="m22 7-8.97 5.7a1.94 1.94 0 0 1-2.06 0L2 7" />
                            </svg>
                            <a href="#" class="hover:text-primary">{{ brand.email }}</a>
                        </div>
                        <div class="flex items-center gap-2">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z" />
                            </svg>
                            <span>{{ brand.phone }}</span>
                        </div>
                        <div class="flex gap-4">
                            <a v-for="social in brand.socialMedia" :key="social.name" :href="social.url" target="_blank" class="text-muted-foreground hover:text-foreground">
                                <component :is="social.icon" class="h-5 w-5" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Filtreler ve Sıralama -->
        <div class="mb-8 grid gap-4 md:grid-cols-3">
            <!-- Kategori Filtresi -->
            <Select v-model="selectedCategory" :options="categories" placeholder="Kategori seçin" />

            <!-- Fiyat Aralığı -->
            <Select v-model="priceRange" :options="priceRanges" placeholder="Fiyat aralığı" />

            <!-- Sıralama -->
            <Select v-model="sortBy" :options="sortOptions" placeholder="Sıralama" />
        </div>

        <!-- Ürünler Grid -->
        <div class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
            <div v-for="product in filteredProducts" :key="product.id" class="group rounded-lg border bg-card p-4 transition-all hover:shadow-lg">
                <!-- Ürün Görseli -->
                <div class="relative mb-4 aspect-square overflow-hidden rounded-md">
                    <img :src="product.image" :alt="product.name" class="h-full w-full object-cover transition-transform group-hover:scale-105" />
                    <div class="absolute right-2 top-2">
                        <button class="rounded-full bg-background/80 p-2 text-muted-foreground backdrop-blur-sm hover:text-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z" />
                            </svg>
                        </button>
                    </div>
                    <div v-if="product.discount" class="absolute left-2 top-2">
                        <span class="rounded-full bg-primary px-2 py-1 text-xs font-semibold text-primary-foreground">%{{ product.discount }}</span>
                    </div>
                </div>

                <!-- Ürün Bilgileri -->
                <div class="space-y-2">
                    <h3 class="font-semibold group-hover:text-primary">
                        {{ product.name }}
                    </h3>
                    <div class="flex items-center gap-2">
                        <div class="flex items-center">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="currentColor" class="text-yellow-400">
                                <path d="M12 2l2.4 7.4H22l-6 4.4 2.3 7.2-6.3-4.6-6.3 4.6L8 13.8l-6-4.4h7.6L12 2z" />
                            </svg>
                            <span class="ml-1 text-sm">{{ product.rating }}</span>
                        </div>
                        <span class="text-sm text-muted-foreground">({{ product.reviewCount }})</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <div>
                            <span class="text-lg font-bold">{{ product.price }} ₺</span>
                            <span v-if="product.oldPrice" class="ml-2 text-sm text-muted-foreground line-through">{{ product.oldPrice }} ₺</span>
                        </div>
                        <button class="rounded-full bg-primary/10 p-2 text-primary hover:bg-primary/20">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M6 2 3 6v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V6l-3-4Z" />
                                <path d="M3 6h18" />
                                <path d="M16 10a4 4 0 0 1-8 0" />
                            </svg>
                        </button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Sayfalama -->
        <div class="mt-8 flex items-center justify-between border-t pt-4">
            <button class="rounded-md px-3 py-2 text-sm font-semibold hover:bg-accent disabled:opacity-50" :disabled="currentPage === 1" @click="currentPage--">Önceki</button>
            <span class="text-sm text-muted-foreground">Sayfa {{ currentPage }} / {{ totalPages }}</span>
            <button class="rounded-md px-3 py-2 text-sm font-semibold hover:bg-accent disabled:opacity-50" :disabled="currentPage === totalPages" @click="currentPage++">Sonraki</button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import { useRoute } from "vue-router";
import Select from "@/components/ui/Form/Select.vue";

const route = useRoute();

// Durum değişkenleri
const selectedCategory = ref("");
const priceRange = ref("");
const sortBy = ref("");
const currentPage = ref(1);

// Sabit veriler
const categories = [
    { value: "all", label: "Tüm Kategoriler" },
    { value: "phones", label: "Telefonlar" },
    { value: "laptops", label: "Laptoplar" },
    { value: "tablets", label: "Tabletler" },
    { value: "accessories", label: "Aksesuarlar" },
];

const priceRanges = [
    { value: "all", label: "Tüm Fiyatlar" },
    { value: "0-1000", label: "0 - 1.000 ₺" },
    { value: "1000-5000", label: "1.000 - 5.000 ₺" },
    { value: "5000-10000", label: "5.000 - 10.000 ₺" },
    { value: "10000+", label: "10.000 ₺ ve üzeri" },
];

const sortOptions = [
    { value: "popular", label: "En Popüler" },
    { value: "newest", label: "En Yeni" },
    { value: "price-asc", label: "Fiyat (Düşükten Yükseğe)" },
    { value: "price-desc", label: "Fiyat (Yüksekten Düşüğe)" },
    { value: "rating", label: "En Çok Değerlendirilenler" },
];

// Örnek marka verisi
const brand = {
    id: 1,
    name: "Apple",
    logo: "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png",
    description: "Think Different",
    about: "Apple Inc. teknoloji dünyasının öncü markalarından biridir. iPhone, iPad, Mac ve daha birçok yenilikçi ürünle kullanıcılarına en iyi deneyimi sunmayı hedefler.",
    productCount: 156,
    rating: 4.8,
    reviewCount: 1250,
    followerCount: "2.5M",
    location: "Cupertino, California",
    email: "contact@apple.com",
    phone: "+1 800-692-7753",
    tags: ["Teknoloji", "İnovasyon", "Tasarım", "Premium"],
    socialMedia: [
        {
            name: "Twitter",
            url: "https://twitter.com/apple",
            icon: "TwitterIcon",
        },
        {
            name: "Facebook",
            url: "https://facebook.com/apple",
            icon: "FacebookIcon",
        },
        {
            name: "Instagram",
            url: "https://instagram.com/apple",
            icon: "InstagramIcon",
        },
        {
            name: "YouTube",
            url: "https://youtube.com/apple",
            icon: "YoutubeIcon",
        },
    ],
};

// Örnek ürün verileri
const products = [
    {
        id: 1,
        name: "iPhone 14 Pro",
        image: "https://example.com/iphone14pro.jpg",
        price: 64999,
        oldPrice: 69999,
        discount: 7,
        rating: 4.9,
        reviewCount: 856,
        category: "phones",
    },
    // Diğer ürünler buraya eklenebilir
];

// Hesaplanan özellikler
const filteredProducts = computed(() => {
    let result = [...products];

    // Kategori filtresi
    if (selectedCategory.value && selectedCategory.value !== "all") {
        result = result.filter((product) => product.category === selectedCategory.value);
    }

    // Fiyat aralığı filtresi
    if (priceRange.value && priceRange.value !== "all") {
        const [min, max] = priceRange.value.split("-").map(Number);
        result = result.filter((product) => {
            if (max) {
                return product.price >= min && product.price <= max;
            }
            return product.price >= min;
        });
    }

    // Sıralama
    if (sortBy.value) {
        switch (sortBy.value) {
            case "price-asc":
                result.sort((a, b) => a.price - b.price);
                break;
            case "price-desc":
                result.sort((a, b) => b.price - a.price);
                break;
            case "rating":
                result.sort((a, b) => b.rating - a.rating);
                break;
            // Diğer sıralama seçenekleri buraya eklenebilir
        }
    }

    return result;
});

const totalPages = computed(() => Math.ceil(filteredProducts.value.length / 12));
</script>
