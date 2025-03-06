<template>
    <div class="space-y-6">
        <!-- Başlık ve Açıklama -->
        <div class="flex items-center justify-between">
            <div>
                <h1 class="text-3xl font-bold tracking-tight">Ürün Yönetimi</h1>
                <p class="text-muted-foreground">Platformdaki tüm ürünleri buradan yönetebilirsiniz.</p>
            </div>
            <button class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                    <path d="M11 21H4a2 2 0 0 1-2-2V5c0-1.1.9-2 2-2h5l2 3h9a2 2 0 0 1 2 2v2M19 15v6M16 18h6"/>
                </svg>
                Yeni Ürün Ekle
            </button>
        </div>

        <!-- İstatistik Kartları -->
        <div class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
            <!-- Toplam Ürün -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Ürün</p>
                        <h2 class="mt-2 text-3xl font-bold">2.5K</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            12% artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="m7.5 4.27 9 5.15" />
                            <path d="M21 8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16Z" />
                            <path d="m3.3 7 8.7 5 8.7-5" />
                            <path d="M12 22V12" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Toplam Satış -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Satış</p>
                        <h2 class="mt-2 text-3xl font-bold">₺3.2M</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            8% artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M20.91 8.84 8.56 2.23a1.93 1.93 0 0 0-1.81 0L3.1 4.13a2.12 2.12 0 0 0-.05 3.69l12.22 6.93a2 2 0 0 0 1.94 0L21 12.51a2.12 2.12 0 0 0-.09-3.67Z" />
                            <path d="m3.09 8.84 12.35-6.61a1.93 1.93 0 0 1 1.81 0l3.65 1.9a2.12 2.12 0 0 1 .1 3.69L8.73 14.75a2 2 0 0 1-1.94 0L3 12.51a2.12 2.12 0 0 1 .09-3.67Z" />
                            <line x1="12" y1="22" x2="12" y2="13" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Stok Durumu -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Stok Durumu</p>
                        <h2 class="mt-2 text-3xl font-bold">15.8K</h2>
                        <p class="mt-1 flex items-center text-red-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 17 13.5 8.5 8.5 13.5 2 7" />
                                <polyline points="16 17 22 17 22 11" />
                            </svg>
                            3% azalış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M20 12V8H6a2 2 0 0 1-2-2c0-1.1.9-2 2-2h12v4" />
                            <path d="M4 6v12c0 1.1.9 2 2 2h14v-4" />
                            <path d="M18 12a2 2 0 0 0-2 2c0 1.1.9 2 2 2h4v-4h-4z" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Ortalama Değerlendirme -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Ortalama Değerlendirme</p>
                        <h2 class="mt-2 text-3xl font-bold">4.6</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            0.3 artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <polygon points="12 2 15.09 8.26 22 9.27 17 14.14 18.18 21.02 12 17.77 5.82 21.02 7 14.14 2 9.27 8.91 8.26 12 2" />
                        </svg>
                    </div>
                </div>
            </div>
        </div>

        <!-- Filtreler ve Arama -->
        <div class="flex flex-col gap-4 rounded-lg border bg-card p-4 md:flex-row md:items-center md:justify-between">
            <div class="flex flex-1 flex-col gap-4 md:flex-row md:items-center">
                <!-- Arama -->
                <div class="relative flex-1">
                    <input
                        type="text"
                        placeholder="Ürün ara..."
                        v-model="searchQuery"
                        class="h-9 w-full rounded-md border bg-background px-3 pl-9 text-sm placeholder:text-muted-foreground focus:outline-none focus:ring-2 focus:ring-primary"
                    />
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute left-3 top-1/2 -translate-y-1/2 text-muted-foreground">
                        <circle cx="11" cy="11" r="8" />
                        <path d="m21 21-4.3-4.3" />
                    </svg>
                </div>

                <!-- Kategori Filtresi -->
                <select v-model="selectedCategory" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="">Tüm Kategoriler</option>
                    <option value="electronics">Elektronik</option>
                    <option value="fashion">Moda</option>
                    <option value="home">Ev & Yaşam</option>
                    <option value="sports">Spor</option>
                    <option value="books">Kitap</option>
                </select>

                <!-- Stok Durumu Filtresi -->
                <select v-model="selectedStock" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="">Tüm Stok Durumları</option>
                    <option value="in-stock">Stokta Var</option>
                    <option value="low-stock">Az Stok</option>
                    <option value="out-of-stock">Stokta Yok</option>
                </select>

                <!-- Sıralama -->
                <select v-model="sortBy" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="price-desc">En Yüksek Fiyat</option>
                    <option value="price-asc">En Düşük Fiyat</option>
                    <option value="rating-desc">En Yüksek Puan</option>
                    <option value="sales-desc">En Çok Satan</option>
                </select>
            </div>

            <!-- Dışa Aktar -->
            <div class="flex items-center gap-2">
                <button class="inline-flex items-center justify-center rounded-md border bg-background px-3 py-2 text-sm font-medium shadow-sm hover:bg-accent">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" />
                        <polyline points="7 10 12 15 17 10" />
                        <line x1="12" x2="12" y1="15" y2="3" />
                    </svg>
                    Excel'e Aktar
                </button>
                <button class="inline-flex items-center justify-center rounded-md border bg-background px-3 py-2 text-sm font-medium shadow-sm hover:bg-accent">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" />
                        <polyline points="7 10 12 15 17 10" />
                        <line x1="12" x2="12" y1="15" y2="3" />
                    </svg>
                    PDF'e Aktar
                </button>
            </div>
        </div>

        <!-- Ürün Tablosu -->
        <div class="rounded-lg border bg-card">
            <div class="relative overflow-x-auto">
                <table class="w-full text-left text-sm">
                    <thead class="bg-muted/50 text-xs uppercase">
                        <tr>
                            <th class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </th>
                            <th class="px-6 py-4">Ürün</th>
                            <th class="px-6 py-4">Kategori</th>
                            <th class="px-6 py-4">Satıcı</th>
                            <th class="px-6 py-4">Fiyat</th>
                            <th class="px-6 py-4">Stok</th>
                            <th class="px-6 py-4">Satış</th>
                            <th class="px-6 py-4">Puan</th>
                            <th class="px-6 py-4">İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="product in filteredProducts" :key="product.id" class="border-b">
                            <td class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-3">
                                    <img :src="product.image" :alt="product.name" class="h-10 w-10 rounded-lg object-cover" />
                                    <div>
                                        <p class="font-medium">{{ product.name }}</p>
                                        <p class="text-xs text-muted-foreground">SKU: {{ product.sku }}</p>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4">{{ product.category }}</td>
                            <td class="px-6 py-4">{{ product.seller }}</td>
                            <td class="px-6 py-4">₺{{ product.price }}</td>
                            <td class="px-6 py-4">
                                <span :class="[
                                    'rounded-full px-2 py-1 text-xs font-medium',
                                    product.stock > 50 ? 'bg-green-100 text-green-700' :
                                    product.stock > 0 ? 'bg-yellow-100 text-yellow-700' :
                                    'bg-red-100 text-red-700'
                                ]">
                                    {{ product.stock > 50 ? 'Stokta' : product.stock > 0 ? 'Az Stok' : 'Tükendi' }}
                                </span>
                            </td>
                            <td class="px-6 py-4">{{ product.sales }}</td>
                            <td class="px-6 py-4">
                                <div class="flex items-center">
                                    <span class="mr-2 font-medium">{{ product.rating }}</span>
                                    <div class="flex">
                                        <svg v-for="i in 5" :key="i" xmlns="http://www.w3.org/2000/svg" width="12" height="12" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" :class="i <= product.rating ? 'fill-yellow-400 text-yellow-400' : 'text-muted'">
                                            <polygon points="12 2 15.09 8.26 22 9.27 17 14.14 18.18 21.02 12 17.77 5.82 21.02 7 14.14 2 9.27 8.91 8.26 12 2" />
                                        </svg>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-2">
                                    <button class="rounded-md p-2 hover:bg-accent" title="Düzenle">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z" />
                                            <path d="m15 5 4 4" />
                                        </svg>
                                    </button>
                                    <button class="rounded-md p-2 hover:bg-accent" title="Detaylar">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z" />
                                            <path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z" />
                                        </svg>
                                    </button>
                                    <button class="rounded-md p-2 text-red-500 hover:bg-accent" title="Sil">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M3 6h18" />
                                            <path d="M19 6v14c0 1-1 2-2 2H7c-1 0-2-1-2-2V6" />
                                            <path d="M8 6V4c0-1 1-2 2-2h4c1 0 2 1 2 2v2" />
                                        </svg>
                                    </button>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <!-- Pagination -->
            <div class="flex items-center justify-between border-t px-6 py-4">
                <div class="text-sm text-muted-foreground">
                    Toplam <span class="font-medium">{{ totalProducts }}</span> üründen <span class="font-medium">1-10</span> arası gösteriliyor
                </div>
                <div class="flex items-center gap-2">
                    <button class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent disabled:opacity-50" :disabled="currentPage === 1">
                        Önceki
                    </button>
                    <div class="flex items-center gap-1">
                        <button v-for="page in totalPages" :key="page" class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent" :class="{ 'bg-primary text-primary-foreground': currentPage === page }">
                            {{ page }}
                        </button>
                    </div>
                    <button class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent disabled:opacity-50" :disabled="currentPage === totalPages">
                        Sonraki
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

// Durum değişkenleri
const searchQuery = ref('')
const selectedCategory = ref('')
const selectedStock = ref('')
const sortBy = ref('price-desc')
const currentPage = ref(1)

// Örnek ürün verileri
const products = [
    {
        id: 1,
        name: "iPhone 14 Pro Max",
        sku: "IP14PM-256-BLK",
        image: "https://api.dicebear.com/7.x/shapes/svg?seed=product1",
        category: "Elektronik",
        seller: "Teknoloji Plus",
        price: "54,999",
        stock: 85,
        sales: 234,
        rating: 4.8
    },
    {
        id: 2,
        name: "Samsung 4K Smart TV",
        sku: "SAM-TV-65-4K",
        image: "https://api.dicebear.com/7.x/shapes/svg?seed=product2",
        category: "Elektronik",
        seller: "Teknoloji Plus",
        price: "32,499",
        stock: 12,
        sales: 89,
        rating: 4.6
    },
    {
        id: 3,
        name: "Nike Air Max 2023",
        sku: "NIKE-AM-2023-42",
        image: "https://api.dicebear.com/7.x/shapes/svg?seed=product3",
        category: "Spor",
        seller: "Spor Market",
        price: "4,299",
        stock: 45,
        sales: 567,
        rating: 4.7
    },
    {
        id: 4,
        name: "Modern Çalışma Masası",
        sku: "DESK-MOD-120",
        image: "https://api.dicebear.com/7.x/shapes/svg?seed=product4",
        category: "Ev & Yaşam",
        seller: "Ev Dekor",
        price: "2,899",
        stock: 0,
        sales: 123,
        rating: 4.5
    },
    {
        id: 5,
        name: "Harry Potter Set",
        sku: "BOOK-HP-SET-TR",
        image: "https://api.dicebear.com/7.x/shapes/svg?seed=product5",
        category: "Kitap",
        seller: "Kitap Diyarı",
        price: "849",
        stock: 156,
        sales: 1234,
        rating: 4.9
    }
]

// Hesaplanan özellikler
const filteredProducts = computed(() => {
    let result = [...products]

    // Arama filtresi
    if (searchQuery.value) {
        const query = searchQuery.value.toLowerCase()
        result = result.filter(product =>
            product.name.toLowerCase().includes(query) ||
            product.sku.toLowerCase().includes(query)
        )
    }

    // Kategori filtresi
    if (selectedCategory.value) {
        result = result.filter(product => product.category.toLowerCase() === selectedCategory.value)
    }

    // Stok durumu filtresi
    if (selectedStock.value) {
        switch (selectedStock.value) {
            case 'in-stock':
                result = result.filter(product => product.stock > 50)
                break
            case 'low-stock':
                result = result.filter(product => product.stock > 0 && product.stock <= 50)
                break
            case 'out-of-stock':
                result = result.filter(product => product.stock === 0)
                break
        }
    }

    // Sıralama
    switch (sortBy.value) {
        case 'price-desc':
            result.sort((a, b) => parseFloat(b.price.replace(',', '')) - parseFloat(a.price.replace(',', '')))
            break
        case 'price-asc':
            result.sort((a, b) => parseFloat(a.price.replace(',', '')) - parseFloat(b.price.replace(',', '')))
            break
        case 'rating-desc':
            result.sort((a, b) => b.rating - a.rating)
            break
        case 'sales-desc':
            result.sort((a, b) => b.sales - a.sales)
            break
    }

    return result
})

const totalProducts = computed(() => filteredProducts.value.length)
const totalPages = computed(() => Math.ceil(totalProducts.value / 10))
</script> 