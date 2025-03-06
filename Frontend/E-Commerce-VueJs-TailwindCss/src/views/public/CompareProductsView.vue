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
                <li class="text-foreground">Ürün Karşılaştırma</li>
            </ol>
        </nav>

        <!-- Başlık ve Açıklama -->
        <div class="mb-8">
            <h1 class="text-3xl font-bold tracking-tight">Ürün Karşılaştırma</h1>
            <p class="mt-2 text-muted-foreground">Seçtiğiniz ürünleri detaylı olarak karşılaştırın ve en doğru seçimi yapın</p>
        </div>

        <!-- Ürün Seçim Alanı -->
        <div v-if="selectedProducts.length < 4" class="mb-8">
            <button @click="openProductSelector" class="inline-flex items-center justify-center rounded-md bg-primary px-6 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                    <path d="M5 12h14" />
                    <path d="M12 5v14" />
                </svg>
                Ürün Ekle ({{ selectedProducts.length }}/4)
            </button>
        </div>

        <!-- Karşılaştırma Tablosu -->
        <div v-if="selectedProducts.length > 0" class="space-y-8">
            <!-- Ürün Kartları Grid -->
            <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-6">
                <div v-for="product in selectedProducts" :key="product.id" class="rounded-lg border bg-card">
                    <!-- Ürün Başlığı ve Kaldır Butonu -->
                    <div class="p-4 border-b">
                        <div class="flex justify-between items-start">
                            <h3 class="text-lg font-semibold">{{ product.name }}</h3>
                            <button @click="removeProduct(product.id)" class="text-muted-foreground hover:text-destructive transition-colors">
                                <span class="sr-only">Kaldır</span>
                                <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                                </svg>
                            </button>
                        </div>
                    </div>

                    <!-- Ürün Görseli -->
                    <div class="aspect-square relative overflow-hidden border-b">
                        <img :src="product.image" :alt="product.name" class="absolute inset-0 w-full h-full object-cover" />
                    </div>

                    <!-- Fiyat ve Stok Bilgisi -->
                    <div class="p-4 border-b space-y-4">
                        <div class="flex items-baseline space-x-2">
                            <span class="text-2xl font-bold">{{ formatPrice(product.price) }} TL</span>
                        </div>

                        <div class="flex items-center space-x-2">
                            <div class="h-2.5 w-2.5 rounded-full" :class="{ 'bg-green-500': product.stock > 0, 'bg-destructive': product.stock === 0 }"></div>
                            <span class="text-sm">
                                {{ product.stock > 0 ? "Stokta" : "Stokta Yok" }}
                                <span v-if="product.stock > 0" class="text-muted-foreground">({{ product.stock }} adet)</span>
                            </span>
                        </div>

                        <!-- Değerlendirme -->
                        <div class="flex items-center space-x-2">
                            <div class="flex">
                                <template v-for="n in 5" :key="n">
                                    <svg :class="[n <= Math.floor(product.rating) ? 'text-yellow-400' : 'text-gray-300']" class="w-4 h-4" fill="currentColor" viewBox="0 0 20 20">
                                        <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                                    </svg>
                                </template>
                            </div>
                            <span class="text-sm text-muted-foreground">{{ product.rating }}/5</span>
                        </div>
                    </div>

                    <!-- Özellikler -->
                    <div class="p-4 border-b">
                        <h4 class="font-semibold mb-3">Özellikler</h4>
                        <div class="space-y-2">
                            <div v-for="(value, key) in product.specifications" :key="key" class="grid grid-cols-2 gap-2 py-1 border-b last:border-0">
                                <span class="text-sm text-muted-foreground">{{ key }}:</span>
                                <span class="text-sm font-medium">{{ value }}</span>
                            </div>
                        </div>
                    </div>

                    <!-- Sepete Ekle -->
                    <div class="p-4">
                        <button @click="addToCart(product.id)" class="w-full inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                                <circle cx="8" cy="21" r="1" />
                                <circle cx="19" cy="21" r="1" />
                                <path d="M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12" />
                            </svg>
                            Sepete Ekle
                        </button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Boş Durum -->
        <div v-else class="text-center py-12 border rounded-lg bg-card">
            <div class="flex flex-col items-center space-y-4">
                <svg class="w-12 h-12 text-muted-foreground" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 12h6m-6 4h6m2 5H7a2 2 0 01-2-2V5a2 2 0 012-2h5.586a1 1 0 01.707.293l5.414 5.414a1 1 0 01.293.707V19a2 2 0 01-2 2z" />
                </svg>
                <div>
                    <h3 class="text-lg font-semibold">Karşılaştırılacak Ürün Yok</h3>
                    <p class="text-muted-foreground mt-1">Karşılaştırma yapmak için ürün ekleyin</p>
                </div>
                <button @click="openProductSelector" class="inline-flex items-center justify-center rounded-md bg-primary px-6 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                        <path d="M5 12h14" />
                        <path d="M12 5v14" />
                    </svg>
                    Ürün Ekle
                </button>
            </div>
        </div>

        <!-- Ürün Seçim Modalı -->
        <div v-if="showProductSelector" class="fixed inset-0 bg-background/80 backdrop-blur-sm z-50">
            <div class="fixed inset-0 flex items-center justify-center p-4">
                <div class="relative bg-card rounded-lg shadow-lg w-full max-w-2xl">
                    <!-- Modal Başlık -->
                    <div class="flex items-center justify-between p-4 border-b">
                        <h2 class="text-lg font-semibold">Ürün Seç</h2>
                        <button @click="showProductSelector = false" class="text-muted-foreground hover:text-foreground">
                            <svg class="w-6 h-6" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                            </svg>
                        </button>
                    </div>

                    <!-- Arama -->
                    <div class="p-4 border-b">
                        <div class="relative">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute left-3 top-1/2 -translate-y-1/2 text-muted-foreground">
                                <circle cx="11" cy="11" r="8" />
                                <path d="m21 21-4.3-4.3" />
                            </svg>
                            <input type="text" v-model="searchQuery" placeholder="Ürün ara..." class="w-full pl-10 pr-4 py-2 border rounded-md bg-background focus:outline-none focus:ring-2 focus:ring-primary/50" />
                        </div>
                    </div>

                    <!-- Ürün Listesi -->
                    <div class="p-4 max-h-[400px] overflow-y-auto">
                        <div v-for="product in filteredProducts" :key="product.id" class="flex items-center justify-between p-3 rounded-lg hover:bg-accent cursor-pointer" @click="selectProduct(product)">
                            <div class="flex items-center space-x-4">
                                <img :src="product.image" :alt="product.name" class="w-16 h-16 object-cover rounded-md" />
                                <div>
                                    <h3 class="font-medium">{{ product.name }}</h3>
                                    <p class="text-sm text-muted-foreground">{{ formatPrice(product.price) }} TL</p>
                                </div>
                            </div>
                            <button class="text-primary hover:text-primary/90">Ekle</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, computed } from "vue";
import { useToast } from "vue-toastification";

// Toast bildirimleri için
const toast = useToast();

// Durum yönetimi
const selectedProducts = ref([]);
const showProductSelector = ref(false);
const searchQuery = ref("");

// Örnek ürün verileri (gerçek uygulamada API'den gelecek)
const allProducts = ref([
    {
        id: 1,
        name: "iPhone 14 Pro",
        price: 54999,
        stock: 10,
        rating: 4.5,
        image: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-14-pro-finish-select-202209-6-1inch-deeppurple?wid=2560&hei=1440&fmt=p-jpg&qlt=80&.v=1663703840578",
        specifications: {
            Ekran: "6.1 inç OLED",
            RAM: "6 GB",
            Depolama: "256 GB",
            İşlemci: "A16 Bionic",
            Kamera: "48 MP + 12 MP + 12 MP",
            Batarya: "3200 mAh",
        },
    },
    {
        id: 2,
        name: "Samsung Galaxy S23 Ultra",
        price: 49999,
        stock: 15,
        rating: 4.7,
        image: "https://images.samsung.com/is/image/samsung/p6pim/tr/2302/gallery/tr-galaxy-s23-s918-sm-s918bzgctur-thumb-534863401",
        specifications: {
            Ekran: "6.8 inç AMOLED",
            RAM: "12 GB",
            Depolama: "512 GB",
            İşlemci: "Snapdragon 8 Gen 2",
            Kamera: "200 MP + 12 MP + 10 MP + 10 MP",
            Batarya: "5000 mAh",
        },
    },
    {
        id: 3,
        name: 'MacBook Pro 14"',
        price: 72999,
        stock: 5,
        rating: 4.9,
        image: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mbp14-spacegray-select-202301?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1671304673229",
        specifications: {
            Ekran: "14.2 inç Liquid Retina XDR",
            RAM: "16 GB",
            Depolama: "512 GB SSD",
            İşlemci: "M2 Pro",
            GPU: "16 çekirdekli",
            "İşletim Sistemi": "macOS",
        },
    },
    {
        id: 4,
        name: "iPad Air",
        price: 24999,
        stock: 20,
        rating: 4.6,
        image: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/ipad-air-select-wifi-blue-202203?wid=940&hei=1112&fmt=png-alpha&.v=1645065732688",
        specifications: {
            Ekran: "10.9 inç Liquid Retina",
            RAM: "8 GB",
            Depolama: "256 GB",
            İşlemci: "M1",
            Kamera: "12 MP",
            Bağlantı: "Wi-Fi + 5G",
        },
    },
    {
        id: 5,
        name: "Dell XPS 15",
        price: 64999,
        stock: 8,
        rating: 4.8,
        image: "https://i.dell.com/is/image/DellContent/content/dam/ss2/product-images/dell-client-products/notebooks/xps-notebooks/xps-15-9520/media-gallery/black/laptop-xps-9520-t-black-gallery-4.psd?fmt=png-alpha&pscan=auto&scl=1&hei=402&wid=402&qlt=100,1&resMode=sharp2&size=402,402&chrss=full",
        specifications: {
            Ekran: "15.6 inç 4K OLED",
            RAM: "32 GB",
            Depolama: "1 TB SSD",
            İşlemci: "Intel i9-12900HK",
            GPU: "RTX 3050 Ti",
            "İşletim Sistemi": "Windows 11",
        },
    },
]);

// Hesaplanan özellikler
const filteredProducts = computed(() => {
    if (!searchQuery.value) return allProducts.value;
    const query = searchQuery.value.toLowerCase();
    return allProducts.value.filter((product) => product.name.toLowerCase().includes(query));
});

// Metodlar
const formatPrice = (price) => {
    return new Intl.NumberFormat("tr-TR").format(price);
};

const openProductSelector = () => {
    if (selectedProducts.value.length >= 4) {
        toast.warning("En fazla 4 ürün karşılaştırabilirsiniz");
        return;
    }
    showProductSelector.value = true;
};

const selectProduct = (product) => {
    if (selectedProducts.value.some((p) => p.id === product.id)) {
        toast.info("Bu ürün zaten karşılaştırma listesinde");
        return;
    }

    if (selectedProducts.value.length >= 4) {
        toast.warning("En fazla 4 ürün karşılaştırabilirsiniz");
        return;
    }

    selectedProducts.value.push(product);
    showProductSelector.value = false;
    toast.success("Ürün karşılaştırma listesine eklendi");
};

const removeProduct = (productId) => {
    selectedProducts.value = selectedProducts.value.filter((p) => p.id !== productId);
    toast.success("Ürün karşılaştırma listesinden kaldırıldı");
};

const addToCart = (productId) => {
    // Sepete ekleme işlemi burada yapılacak
    toast.success("Ürün sepete eklendi");
};
</script>
