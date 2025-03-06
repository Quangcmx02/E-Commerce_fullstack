<template>
    <div class="space-y-6">
        <!-- Başlık ve Filtreler -->
        <div class="flex items-center justify-between">
            <div class="space-y-1">
                <h2 class="text-2xl font-semibold tracking-tight">Favori Ürünlerim</h2>
                <p class="text-sm text-muted-foreground">Beğendiğiniz ve takip ettiğiniz ürünler</p>
            </div>
            <div class="flex items-center space-x-2">
                <Input v-model="search" placeholder="Ürün ara..." class="w-[250px]">
                    <template #prefix>
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-4 h-4 text-muted-foreground">
                            <circle cx="11" cy="11" r="8" />
                            <path d="m21 21-4.3-4.3" />
                        </svg>
                    </template>
                </Input>
                <Select v-model="sortBy" class="w-[200px]">
                    <option value="date-desc">En Yeni Eklenen</option>
                    <option value="date-asc">En Eski Eklenen</option>
                    <option value="price-desc">En Yüksek Fiyat</option>
                    <option value="price-asc">En Düşük Fiyat</option>
                    <option value="name-asc">A-Z</option>
                    <option value="name-desc">Z-A</option>
                </Select>
            </div>
        </div>

        <!-- Ürün Listesi -->
        <div v-if="favorites.length > 0" class="grid gap-6 sm:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
            <div v-for="product in filteredProducts" :key="product.id" class="group relative">
                <!-- Favori Butonu -->
                <button class="absolute right-4 top-4 z-10 rounded-full bg-background/90 p-2 text-muted-foreground/90 backdrop-blur-lg transition-colors hover:bg-background hover:text-foreground" @click="removeFromFavorites(product.id)">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="currentColor" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-5 h-5">
                        <path d="M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z" />
                    </svg>
                </button>

                <!-- Ürün Kartı -->
                <router-link :to="{ name: 'product-detail', params: { id: product.id } }" class="block">
                    <div class="overflow-hidden rounded-lg border bg-card">
                        <img :src="product.image" :alt="product.name" class="h-[200px] w-full object-cover transition-transform group-hover:scale-105" />
                        <div class="p-4">
                            <h3 class="font-semibold">{{ product.name }}</h3>
                            <p class="mt-1 text-sm text-muted-foreground line-clamp-2">
                                {{ product.description }}
                            </p>
                            <div class="mt-3 flex items-center justify-between">
                                <div class="space-y-1">
                                    <div class="font-semibold">{{ formatPrice(product.price) }}</div>
                                    <div v-if="product.oldPrice" class="text-sm text-muted-foreground line-through">
                                        {{ formatPrice(product.oldPrice) }}
                                    </div>
                                </div>
                                <Button size="sm" @click.prevent="addToCart(product.id)">Sepete Ekle</Button>
                            </div>
                        </div>
                    </div>
                </router-link>
            </div>
        </div>

        <!-- Boş Durum -->
        <div v-else class="flex flex-col items-center justify-center py-12 text-center">
            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-12 h-12 text-muted-foreground/50">
                <path d="M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z" />
            </svg>
            <h3 class="mt-4 text-lg font-semibold">Henüz Favori Ürününüz Yok</h3>
            <p class="mt-2 text-sm text-muted-foreground">Beğendiğiniz ürünleri favorilerinize ekleyerek daha sonra kolayca ulaşabilirsiniz.</p>
            <Button class="mt-4" asChild>
                <router-link :to="{ name: 'home' }">Alışverişe Başla</router-link>
            </Button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import Input from "@/components/ui/Form/Input.vue";
import Button from "@/components/ui/Form/Button.vue";
import Select from "@/components/ui/Form/Select.vue";

// Arama ve filtreleme
const search = ref("");
const sortBy = ref("date-desc");

// Örnek veri
const favorites = ref([
    {
        id: 1,
        name: "Nike Air Max 270",
        description: "Nike Air Max 270, maksimum konfor ve şık tasarımı bir arada sunan bir spor ayakkabıdır.",
        price: 4299.99,
        oldPrice: 4999.99,
        image: "https://static.nike.com/a/images/t_PDP_1280_v1/f_auto,q_auto:eco/skwgyqrbfzhu6uyeh0gg/air-max-270-ayakkab%C4%B1s%C4%B1-VW5Qpz.png",
    },
    {
        id: 2,
        name: 'Apple MacBook Pro 14"',
        description: "M3 Pro çip, 18GB RAM, 512GB SSD, Uzay Grisi",
        price: 89999.99,
        image: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mbp14-spacegray-select-202310?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1697311054290",
    },
    {
        id: 3,
        name: "Samsung QLED 4K TV",
        description: '65" Smart TV, Quantum HDR, Dolby Atmos',
        price: 39999.99,
        oldPrice: 44999.99,
        image: "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/samsung/thumb/147731-1-1_large.jpg",
    },
    {
        id: 4,
        name: "Sony WH-1000XM5",
        description: "Kablosuz Gürültü Engelleyici Kulaklık, Siyah",
        price: 14999.99,
        image: "https://www.sony.com.tr/image/5d02da5df552836db894cead8a68f5f3?fmt=pjpeg&wid=330&bgcolor=FFFFFF&bgc=FFFFFF",
    },
]);

// Filtrelenmiş ürünler
const filteredProducts = computed(() => {
    let filtered = [...favorites.value];

    // Arama filtresi
    if (search.value) {
        const searchLower = search.value.toLowerCase();
        filtered = filtered.filter((product) => product.name.toLowerCase().includes(searchLower) || product.description.toLowerCase().includes(searchLower));
    }

    // Sıralama
    switch (sortBy.value) {
        case "date-desc":
            // En yeni eklenenler (id'ye göre tersine sıralama)
            filtered.sort((a, b) => b.id - a.id);
            break;
        case "date-asc":
            // En eski eklenenler (id'ye göre sıralama)
            filtered.sort((a, b) => a.id - b.id);
            break;
        case "price-desc":
            // En yüksek fiyat
            filtered.sort((a, b) => b.price - a.price);
            break;
        case "price-asc":
            // En düşük fiyat
            filtered.sort((a, b) => a.price - b.price);
            break;
        case "name-asc":
            // A-Z
            filtered.sort((a, b) => a.name.localeCompare(b.name));
            break;
        case "name-desc":
            // Z-A
            filtered.sort((a, b) => b.name.localeCompare(a.name));
            break;
    }

    return filtered;
});

// Fiyat formatlama
const formatPrice = (price: number): string => {
    return new Intl.NumberFormat("tr-TR", {
        style: "currency",
        currency: "TRY",
    }).format(price);
};

// Favorilerden kaldır
const removeFromFavorites = (productId: number) => {
    const index = favorites.value.findIndex((p) => p.id === productId);
    if (index !== -1) {
        favorites.value.splice(index, 1);
    }
};

// Sepete ekle
const addToCart = (productId: number) => {
    console.log("Ürün sepete eklendi:", productId);
    // TODO: Sepete ekleme işlemi
};
</script>
