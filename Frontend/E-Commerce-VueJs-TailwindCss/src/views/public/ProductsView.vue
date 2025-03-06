<template>
    <div class="container py-8">
        <!-- Başlık -->
        <div class="mb-8">
            <h1 class="text-3xl font-bold tracking-tight">Tüm Ürünler</h1>
            <p class="text-muted-foreground">En yeni ve popüler ürünlerimizi keşfedin</p>
        </div>

        <!-- Filtreler -->
        <div class="mb-8 grid gap-6 lg:grid-cols-[250px_1fr]">
            <!-- Sol Taraf - Filtreler -->
            <div class="space-y-6">
                <!-- Kategoriler -->
                <div>
                    <h3 class="mb-4 text-lg font-semibold">Kategoriler</h3>
                    <div class="space-y-2">
                        <label v-for="category in categories" :key="category.id" class="flex cursor-pointer items-center space-x-2">
                            <input type="checkbox" :value="category.id" v-model="selectedCategories" class="h-4 w-4 rounded border-input bg-background text-primary" />
                            <span class="text-sm">{{ category.name }}</span>
                            <span class="text-xs text-muted-foreground">({{ category.count }})</span>
                        </label>
                    </div>
                </div>

                <!-- Fiyat Aralığı -->
                <div>
                    <h3 class="mb-4 text-lg font-semibold">Fiyat Aralığı</h3>
                    <div class="space-y-4">
                        <div class="grid grid-cols-2 gap-4">
                            <div>
                                <label for="minPrice" class="text-sm">Min</label>
                                <Input id="minPrice" v-model="priceRange.min" type="number" placeholder="0" class="mt-1" />
                            </div>
                            <div>
                                <label for="maxPrice" class="text-sm">Max</label>
                                <Input id="maxPrice" v-model="priceRange.max" type="number" placeholder="1000" class="mt-1" />
                            </div>
                        </div>
                        <Button variant="outline" class="w-full" @click="applyPriceFilter">Uygula</Button>
                    </div>
                </div>

                <!-- İndirimli Ürünler -->
                <div>
                    <label class="flex cursor-pointer items-center space-x-2">
                        <input type="checkbox" v-model="onlyDiscounted" class="h-4 w-4 rounded border-input bg-background text-primary" />
                        <span class="text-sm">Sadece İndirimli Ürünler</span>
                    </label>
                </div>

                <!-- Marka Filtresi -->
                <div>
                    <h3 class="mb-4 text-lg font-semibold">Markalar</h3>
                    <div class="space-y-2 max-h-40 overflow-y-auto">
                        <label v-for="brand in brands" :key="brand.id" class="flex cursor-pointer items-center space-x-2">
                            <input type="checkbox" :value="brand.id" v-model="selectedBrands" class="h-4 w-4 rounded border-input bg-background text-primary" />
                            <span class="text-sm">{{ brand.name }}</span>
                            <span class="text-xs text-muted-foreground">({{ brand.count }})</span>
                        </label>
                    </div>
                </div>

                <!-- Değerlendirme Puanı -->
                <div>
                    <h3 class="mb-4 text-lg font-semibold">Değerlendirme</h3>
                    <div class="space-y-2">
                        <label v-for="rating in [5,4,3,2,1]" :key="rating" class="flex cursor-pointer items-center space-x-2">
                            <input type="checkbox" :value="rating" v-model="selectedRatings" class="h-4 w-4 rounded border-input bg-background text-primary" />
                            <div class="flex items-center">
                                <span v-for="star in rating" :key="star" class="text-yellow-400">★</span>
                                <span v-for="star in 5-rating" :key="star" class="text-gray-300">★</span>
                                <span class="ml-1 text-sm text-muted-foreground">ve üzeri</span>
                            </div>
                        </label>
                    </div>
                </div>

                <!-- Stok Durumu -->
                <div>
                    <h3 class="mb-4 text-lg font-semibold">Stok Durumu</h3>
                    <label class="flex cursor-pointer items-center space-x-2">
                        <input type="checkbox" v-model="onlyInStock" class="h-4 w-4 rounded border-input bg-background text-primary" />
                        <span class="text-sm">Sadece Stokta Olanlar</span>
                    </label>
                </div>

                <!-- Renk Seçenekleri -->
                <div>
                    <h3 class="mb-4 text-lg font-semibold">Renkler</h3>
                    <div class="flex flex-wrap gap-2">
                        <button
                            v-for="color in colors"
                            :key="color.id"
                            @click="toggleColor(color.id)"
                            class="h-8 w-8 rounded-full border-2 transition-all"
                            :class="{
                                'border-primary': selectedColors.includes(color.id),
                                'border-transparent': !selectedColors.includes(color.id)
                            }"
                            :style="{ backgroundColor: color.value }"
                            :title="color.name"
                        ></button>
                    </div>
                </div>

                <!-- Özellik Filtreleri -->
                <div v-if="categorySpecificFilters.length > 0">
                    <h3 class="mb-4 text-lg font-semibold">Özellikler</h3>
                    <div v-for="filter in categorySpecificFilters" :key="filter.id" class="mb-4">
                        <h4 class="mb-2 text-sm font-medium">{{ filter.name }}</h4>
                        <Select v-model="selectedSpecifications[filter.id]" class="w-full">
                            <option value="">Tümü</option>
                            <option v-for="option in filter.options" :key="option.id" :value="option.id">
                                {{ option.name }}
                            </option>
                        </Select>
                    </div>
                </div>

                <!-- Filtreleri Temizle -->
                <Button variant="outline" class="w-full" @click="clearFilters">Filtreleri Temizle</Button>
            </div>

            <!-- Sağ Taraf - Ürünler -->
            <div class="space-y-6">
                <!-- Arama ve Sıralama -->
                <div class="flex flex-col space-y-4 md:flex-row md:items-center md:justify-between md:space-y-0">
                    <!-- Arama -->
                    <div class="relative w-full md:w-[250px]">
                        <Input v-model="searchQuery" type="search" placeholder="Ürün ara..." class="pr-8" />
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute right-2 top-1/2 -translate-y-1/2 text-muted-foreground">
                            <circle cx="11" cy="11" r="8" />
                            <path d="m21 21-4.3-4.3" />
                        </svg>
                    </div>

                    <!-- Sıralama -->
                    <Select v-model="sortBy" class="w-full md:w-[200px]">
                        <option value="newest">En Yeniler</option>
                        <option value="price-asc">Fiyat (Düşükten Yükseğe)</option>
                        <option value="price-desc">Fiyat (Yüksekten Düşüğe)</option>
                        <option value="name-asc">İsim (A-Z)</option>
                        <option value="name-desc">İsim (Z-A)</option>
                    </Select>
                </div>

                <!-- Yükleniyor -->
                <div v-if="loading" class="flex items-center justify-center py-12">
                    <div class="h-8 w-8 animate-spin rounded-full border-4 border-primary border-t-transparent"></div>
                </div>

                <!-- Ürün Bulunamadı -->
                <div v-else-if="filteredProducts.length === 0" class="rounded-lg border bg-card p-8 text-center">
                    <div class="mx-auto mb-4 flex h-12 w-12 items-center justify-center rounded-full bg-muted">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-muted-foreground">
                            <circle cx="11" cy="11" r="8" />
                            <path d="m21 21-4.3-4.3" />
                        </svg>
                    </div>
                    <p class="text-lg font-semibold">Ürün Bulunamadı</p>
                    <p class="text-sm text-muted-foreground">Arama kriterlerinize uygun ürün bulunamadı. Lütfen farklı filtreler deneyin.</p>
                </div>

                <!-- Ürün Listesi -->
                <div v-else class="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-3">
                    <div v-for="product in paginatedProducts" :key="product.id" class="group relative overflow-hidden rounded-lg border bg-background">
                        <div class="aspect-[4/3] overflow-hidden">
                            <img :src="product.image" :alt="product.name" class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105" />
                            <div v-if="product.discount" class="absolute right-2 top-2 rounded-full bg-destructive px-2 py-1 text-xs font-medium text-destructive-foreground">%{{ product.discount }} İndirim</div>
                        </div>
                        <div class="p-4">
                            <h3 class="font-semibold">{{ product.name }}</h3>
                            <p class="mt-1 text-sm text-muted-foreground line-clamp-2">
                                {{ product.description }}
                            </p>
                            <div class="mt-2 flex items-center justify-between">
                                <div class="flex items-baseline space-x-2">
                                    <span class="text-lg font-bold">{{ product.price }} TL</span>
                                    <span v-if="product.oldPrice" class="text-sm text-muted-foreground line-through">{{ product.oldPrice }} TL</span>
                                </div>
                                <Button size="sm" variant="secondary" @click="addToCart(product)">Sepete Ekle</Button>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Sayfalama -->
                <div v-if="filteredProducts.length > 0" class="mt-8 flex justify-center">
                    <div class="flex space-x-2">
                        <Button variant="outline" size="sm" :disabled="currentPage === 1" @click="currentPage--">Önceki</Button>
                        <Button v-for="page in totalPages" :key="page" variant="outline" size="sm" :class="{ 'bg-primary text-primary-foreground': currentPage === page }" @click="currentPage = page">
                            {{ page }}
                        </Button>
                        <Button variant="outline" size="sm" :disabled="currentPage === totalPages" @click="currentPage++">Sonraki</Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted } from "vue";
import Button from "@/components/ui/Form/Button.vue";
import Input from "@/components/ui/Form/Input.vue";
import Select from "@/components/ui/Form/Select.vue";

const loading = ref(true);
const searchQuery = ref("");
const sortBy = ref("newest");
const currentPage = ref(1);
const itemsPerPage = 9;

// Filtreler
const selectedCategories = ref([]);
const priceRange = ref({ min: null, max: null });
const onlyDiscounted = ref(false);
const selectedBrands = ref([]);
const selectedRatings = ref([]);
const onlyInStock = ref(false);
const selectedColors = ref([]);
const selectedSpecifications = ref({});

// Örnek kategori verileri
const categories = ref([
    { id: 1, name: "Elektronik", count: 150 },
    { id: 2, name: "Giyim", count: 120 },
    { id: 3, name: "Kitap", count: 80 },
    { id: 4, name: "Spor", count: 60 },
    { id: 5, name: "Ev & Yaşam", count: 90 },
    { id: 6, name: "Kozmetik", count: 70 },
]);

// Örnek ürün verileri
const products = ref([
    {
        id: 1,
        name: "Kablosuz Kulaklık",
        description: "Aktif gürültü önleme özellikli premium kablosuz kulaklık",
        price: 199.99,
        oldPrice: 299.99,
        discount: 33,
        categoryId: 1,
        brandId: 3, // Sony
        rating: 4.5,
        inStock: true,
        colors: [1, 2], // Siyah, Beyaz
        specifications: {
            1: 2, // 128 GB
            2: 2  // 6.1 inç
        },
        image: "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500&h=400&fit=crop",
    },
    {
        id: 2,
        name: "Akıllı Saat",
        description: "Fitness takibi ve bildirimler için akıllı saat",
        price: 149.99,
        categoryId: 1,
        brandId: 1, // Samsung
        rating: 4.2,
        inStock: true,
        colors: [1, 4], // Siyah, Mavi
        specifications: {
            1: 1, // 64 GB
            2: 1  // 5.5 inç
        },
        image: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500&h=400&fit=crop",
    },
    {
        id: 3,
        name: "Tablet",
        description: "10.5 inç ekranlı, güçlü işlemcili tablet",
        price: 299.99,
        oldPrice: 399.99,
        discount: 25,
        categoryId: 1,
        brandId: 2, // Apple
        rating: 4.8,
        inStock: true,
        colors: [1, 2, 3], // Siyah, Beyaz, Gri
        specifications: {
            1: 3, // 256 GB
            2: 4  // 6.7 inç
        },
        image: "https://images.unsplash.com/photo-1572635196237-14b3f281503f?w=500&h=400&fit=crop",
    },
    {
        id: 4,
        name: "Bluetooth Hoparlör",
        description: "Taşınabilir kablosuz hoparlör",
        price: 79.99,
        categoryId: 1,
        brandId: 3, // Sony
        rating: 4.0,
        inStock: false,
        colors: [1, 5], // Siyah, Kırmızı
        specifications: {
            1: 1, // 64 GB
            2: 1  // 5.5 inç
        },
        image: "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?w=500&h=400&fit=crop",
    },
    {
        id: 5,
        name: "Akıllı Telefon",
        description: "Yüksek performanslı akıllı telefon",
        price: 999.99,
        oldPrice: 1299.99,
        discount: 23,
        categoryId: 1,
        brandId: 1, // Samsung
        rating: 4.7,
        inStock: true,
        colors: [1, 2, 4], // Siyah, Beyaz, Mavi
        specifications: {
            1: 4, // 512 GB
            2: 3  // 6.5 inç
        },
        image: "https://images.unsplash.com/photo-1592899677977-9c10ca588bbd?w=500&h=400&fit=crop",
    },
    // Daha fazla ürün eklenebilir
]);

// Örnek marka verileri
const brands = ref([
    { id: 1, name: "Samsung", count: 45 },
    { id: 2, name: "Apple", count: 32 },
    { id: 3, name: "Sony", count: 28 },
    { id: 4, name: "LG", count: 25 },
    { id: 5, name: "Xiaomi", count: 20 },
]);

// Örnek renk verileri
const colors = ref([
    { id: 1, name: "Siyah", value: "#000000" },
    { id: 2, name: "Beyaz", value: "#FFFFFF" },
    { id: 3, name: "Gri", value: "#808080" },
    { id: 4, name: "Mavi", value: "#0000FF" },
    { id: 5, name: "Kırmızı", value: "#FF0000" },
    { id: 6, name: "Yeşil", value: "#008000" },
]);

// Örnek kategoriye özel filtreler
const categorySpecificFilters = ref([
    {
        id: 1,
        name: "Bellek Kapasitesi",
        options: [
            { id: 1, name: "64 GB" },
            { id: 2, name: "128 GB" },
            { id: 3, name: "256 GB" },
            { id: 4, name: "512 GB" },
        ],
    },
    {
        id: 2,
        name: "Ekran Boyutu",
        options: [
            { id: 1, name: "5.5 inç" },
            { id: 2, name: "6.1 inç" },
            { id: 3, name: "6.5 inç" },
            { id: 4, name: "6.7 inç" },
        ],
    },
]);

// Hesaplanan özellikler
const filteredProducts = computed(() => {
    let result = [...products.value];

    // Kategori filtresi
    if (selectedCategories.value.length > 0) {
        result = result.filter((product) => selectedCategories.value.includes(product.categoryId));
    }

    // Fiyat aralığı filtresi
    if (priceRange.value.min !== null) {
        result = result.filter((product) => product.price >= priceRange.value.min);
    }
    if (priceRange.value.max !== null) {
        result = result.filter((product) => product.price <= priceRange.value.max);
    }

    // İndirimli ürünler filtresi
    if (onlyDiscounted.value) {
        result = result.filter((product) => product.discount);
    }

    // Arama filtresi
    if (searchQuery.value) {
        const query = searchQuery.value.toLowerCase();
        result = result.filter((product) => product.name.toLowerCase().includes(query) || product.description.toLowerCase().includes(query));
    }

    // Marka filtresi
    if (selectedBrands.value.length > 0) {
        result = result.filter((product) => selectedBrands.value.includes(product.brandId));
    }

    // Değerlendirme filtresi
    if (selectedRatings.value.length > 0) {
        result = result.filter((product) => 
            selectedRatings.value.some(rating => product.rating >= rating)
        );
    }

    // Stok durumu filtresi
    if (onlyInStock.value) {
        result = result.filter((product) => product.inStock);
    }

    // Renk filtresi
    if (selectedColors.value.length > 0) {
        result = result.filter((product) => 
            product.colors?.some(color => selectedColors.value.includes(color))
        );
    }

    // Özellik filtreleri
    for (const [filterId, value] of Object.entries(selectedSpecifications.value)) {
        if (value) {
            result = result.filter((product) => 
                product.specifications?.[filterId] === value
            );
        }
    }

    // Sıralama
    switch (sortBy.value) {
        case "price-asc":
            result.sort((a, b) => a.price - b.price);
            break;
        case "price-desc":
            result.sort((a, b) => b.price - a.price);
            break;
        case "name-asc":
            result.sort((a, b) => a.name.localeCompare(b.name));
            break;
        case "name-desc":
            result.sort((a, b) => b.name.localeCompare(a.name));
            break;
        default:
            // En yeniler (varsayılan olarak id'ye göre ters sıralama)
            result.sort((a, b) => b.id - a.id);
    }

    return result;
});

const paginatedProducts = computed(() => {
    const start = (currentPage.value - 1) * itemsPerPage;
    const end = start + itemsPerPage;
    return filteredProducts.value.slice(start, end);
});

const totalPages = computed(() => Math.ceil(filteredProducts.value.length / itemsPerPage));

// Metodlar
const addToCart = (product) => {
    // Sepete ekleme işlemi (Pinia store'da yapılacak)
    console.log("Ürün sepete eklendi:", product);
};

const applyPriceFilter = () => {
    // Fiyat filtresini uygula
    currentPage.value = 1;
};

const clearFilters = () => {
    selectedCategories.value = [];
    priceRange.value = { min: null, max: null };
    onlyDiscounted.value = false;
    selectedBrands.value = [];
    selectedRatings.value = [];
    onlyInStock.value = false;
    selectedColors.value = [];
    selectedSpecifications.value = {};
    searchQuery.value = "";
    sortBy.value = "newest";
    currentPage.value = 1;
};

// Renk seçimi için metod
const toggleColor = (colorId) => {
    const index = selectedColors.value.indexOf(colorId);
    if (index === -1) {
        selectedColors.value.push(colorId);
    } else {
        selectedColors.value.splice(index, 1);
    }
};

// Sayfa yüklendiğinde
onMounted(() => {
    // Burada API'den ürün verileri çekilecek
    setTimeout(() => {
        loading.value = false;
    }, 1000);
});
</script>
