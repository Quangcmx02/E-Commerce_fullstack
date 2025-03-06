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
                <li class="text-foreground">Markalar</li>
            </ol>
        </nav>

        <!-- Başlık ve Açıklama -->
        <div class="mb-8">
            <h1 class="text-3xl font-bold tracking-tight">Markalar</h1>
            <p class="mt-2 text-muted-foreground">Platformumuzda yer alan tüm markaları keşfedin</p>
        </div>

        <!-- Arama ve Filtreleme -->
        <div class="mb-8 grid gap-4 md:grid-cols-2 lg:grid-cols-4">
            <!-- Arama -->
            <div class="relative">
                <Input v-model="searchQuery" placeholder="Marka ara..." class="pl-10" />
                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute left-3 top-1/2 -translate-y-1/2 text-muted-foreground">
                    <circle cx="11" cy="11" r="8" />
                    <path d="m21 21-4.3-4.3" />
                </svg>
            </div>

            <!-- Kategori Filtresi -->
            <Select v-model="selectedCategory" :options="categories" placeholder="Kategori seçin" />

            <!-- Sıralama -->
            <Select v-model="sortBy" :options="sortOptions" placeholder="Sıralama" />

            <!-- Görünüm Değiştirme -->
            <div class="flex items-center justify-end space-x-2">
                <button class="rounded-md p-2 hover:bg-accent" :class="{ 'bg-accent': viewMode === 'grid' }" @click="viewMode = 'grid'">
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                        <rect width="7" height="7" x="3" y="3" rx="1" />
                        <rect width="7" height="7" x="14" y="3" rx="1" />
                        <rect width="7" height="7" x="14" y="14" rx="1" />
                        <rect width="7" height="7" x="3" y="14" rx="1" />
                    </svg>
                </button>
                <button class="rounded-md p-2 hover:bg-accent" :class="{ 'bg-accent': viewMode === 'list' }" @click="viewMode = 'list'">
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                        <line x1="3" x2="21" y1="6" y2="6" />
                        <line x1="3" x2="21" y1="12" y2="12" />
                        <line x1="3" x2="21" y1="18" y2="18" />
                    </svg>
                </button>
            </div>
        </div>

        <!-- Alfabetik İndeks -->
        <div class="mb-8 flex flex-wrap gap-2">
            <button v-for="letter in alphabet" :key="letter" class="min-w-[32px] rounded-md px-2 py-1 text-sm font-medium hover:bg-accent" :class="{ 'bg-primary text-primary-foreground': selectedLetter === letter }" @click="selectedLetter = letter">
                {{ letter }}
            </button>
        </div>

        <!-- Markalar Listesi -->
        <div :class="viewMode === 'grid' ? 'grid gap-6 sm:grid-cols-2 lg:grid-cols-4' : 'space-y-4'">
            <div v-for="brand in filteredBrands" :key="brand.id" :class="['group rounded-lg border bg-card p-4 transition-all hover:shadow-lg', viewMode === 'list' ? 'flex items-center space-x-4' : '']">
                <!-- Logo -->
                <div :class="viewMode === 'list' ? 'w-24 flex-shrink-0' : 'mb-4'">
                    <img :src="brand.logo" :alt="brand.name" class="h-16 w-full object-contain" />
                </div>

                <!-- Detaylar -->
                <div class="flex-1">
                    <h3 class="font-semibold group-hover:text-primary">
                        {{ brand.name }}
                    </h3>
                    <p class="mt-1 text-sm text-muted-foreground">{{ brand.productCount }} Ürün</p>
                    <div class="mt-2 flex items-center space-x-2 text-sm">
                        <span class="flex items-center space-x-1">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M12 2l2.4 7.4H22l-6 4.4 2.3 7.2-6.3-4.6-6.3 4.6L8 13.8l-6-4.4h7.6L12 2z" />
                            </svg>
                            <span>{{ brand.rating }}/5</span>
                        </span>
                        <span class="text-muted-foreground">({{ brand.reviewCount }} Değerlendirme)</span>
                    </div>
                </div>

                <!-- Aksiyon Butonları -->
                <div :class="viewMode === 'list' ? 'flex-shrink-0' : 'mt-4'">
                    <router-link :to="{ name: 'brand-detail' }" class="flex w-full items-center justify-center rounded-md bg-primary px-3 py-2 text-sm font-semibold text-primary-foreground shadow-sm hover:bg-primary/90">Ürünleri Gör</router-link>
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
import Input from "@/components/ui/Form/Input.vue";
import Select from "@/components/ui/Form/Select.vue";

// Durum değişkenleri
const searchQuery = ref("");
const selectedCategory = ref("");
const sortBy = ref("");
const viewMode = ref("grid");
const selectedLetter = ref("");
const currentPage = ref(1);

// Sabit veriler
const alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".split("");
const categories = [
    { value: "electronics", label: "Elektronik" },
    { value: "fashion", label: "Moda" },
    { value: "home", label: "Ev & Yaşam" },
    { value: "sports", label: "Spor" },
];
const sortOptions = [
    { value: "name-asc", label: "İsme Göre (A-Z)" },
    { value: "name-desc", label: "İsme Göre (Z-A)" },
    { value: "popular", label: "Popülerliğe Göre" },
    { value: "rating", label: "Değerlendirmeye Göre" },
];

// Örnek marka verileri
const brands = [
    {
        id: 1,
        name: "Apple",
        logo: "https://www.apple.com/ac/structured-data/images/knowledge_graph_logo.png",
        productCount: 156,
        rating: 4.8,
        reviewCount: 1250,
        category: "electronics",
    },
    {
        id: 2,
        name: "Samsung",
        logo: "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Samsung_Logo.svg/2560px-Samsung_Logo.svg.png",
        productCount: 243,
        rating: 4.6,
        reviewCount: 980,
        category: "electronics",
    },
    {
        id: 3,
        name: "Nike",
        logo: "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Logo_NIKE.svg/1200px-Logo_NIKE.svg.png",
        productCount: 312,
        rating: 4.7,
        reviewCount: 1540,
        category: "sports",
    },
    // Diğer markalar buraya eklenebilir
];

// Hesaplanan özellikler
const filteredBrands = computed(() => {
    let result = [...brands];

    // Arama filtresi
    if (searchQuery.value) {
        result = result.filter((brand) => brand.name.toLowerCase().includes(searchQuery.value.toLowerCase()));
    }

    // Kategori filtresi
    if (selectedCategory.value) {
        result = result.filter((brand) => brand.category === selectedCategory.value);
    }

    // Harf filtresi
    if (selectedLetter.value) {
        result = result.filter((brand) => brand.name.startsWith(selectedLetter.value));
    }

    // Sıralama
    if (sortBy.value) {
        switch (sortBy.value) {
            case "name-asc":
                result.sort((a, b) => a.name.localeCompare(b.name));
                break;
            case "name-desc":
                result.sort((a, b) => b.name.localeCompare(a.name));
                break;
            case "popular":
                result.sort((a, b) => b.productCount - a.productCount);
                break;
            case "rating":
                result.sort((a, b) => b.rating - a.rating);
                break;
        }
    }

    return result;
});

const totalPages = computed(() => Math.ceil(filteredBrands.value.length / 12));
</script>
