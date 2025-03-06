<template>
    <div class="seller-products">
        <!-- Üst Başlık -->
        <div class="flex items-center justify-between mb-6">
            <h1 class="text-2xl font-bold">Ürünler</h1>
            <button
                class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:opacity-50 disabled:pointer-events-none ring-offset-background bg-primary text-primary-foreground hover:bg-primary/90 h-10 px-4 py-2"
            >
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
                    class="w-5 h-5 mr-2"
                >
                    <path d="M5 12h14" />
                    <path d="M12 5v14" />
                </svg>
                Yeni Ürün Ekle
            </button>
        </div>

        <!-- Filtreler -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <div class="flex flex-wrap gap-4">
                <!-- Arama -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">
                        Ürün Ara
                    </label>
                    <div class="relative">
                        <input
                            v-model="filters.search"
                            type="text"
                            placeholder="Ürün adı veya kodu"
                            class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50 pr-10"
                        />
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
                            class="absolute right-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground"
                        >
                            <circle cx="11" cy="11" r="8" />
                            <path d="m21 21-4.3-4.3" />
                        </svg>
                    </div>
                </div>

                <!-- Kategori -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">
                        Kategori
                    </label>
                    <select
                        v-model="filters.category"
                        class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50"
                    >
                        <option value="">Tümü</option>
                        <option
                            v-for="category in categories"
                            :key="category.id"
                            :value="category.id"
                        >
                            {{ category.name }}
                        </option>
                    </select>
                </div>

                <!-- Stok Durumu -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">
                        Stok Durumu
                    </label>
                    <select
                        v-model="filters.stock"
                        class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50"
                    >
                        <option value="">Tümü</option>
                        <option value="in_stock">Stokta Var</option>
                        <option value="low_stock">Az Stok</option>
                        <option value="out_of_stock">Stokta Yok</option>
                    </select>
                </div>

                <!-- Sıralama -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">
                        Sıralama
                    </label>
                    <select
                        v-model="filters.sort"
                        class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50"
                    >
                        <option value="newest">En Yeni</option>
                        <option value="oldest">En Eski</option>
                        <option value="price_asc">Fiyat (Artan)</option>
                        <option value="price_desc">Fiyat (Azalan)</option>
                        <option value="stock_asc">Stok (Artan)</option>
                        <option value="stock_desc">Stok (Azalan)</option>
                    </select>
                </div>
            </div>
        </div>

        <!-- Ürün Listesi -->
        <div class="bg-card rounded-lg border border-border overflow-hidden">
            <div class="overflow-x-auto">
                <table class="w-full">
                    <thead>
                        <tr class="border-b border-border">
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Ürün
                            </th>
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Kategori
                            </th>
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Stok
                            </th>
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Fiyat
                            </th>
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Durum
                            </th>
                            <th
                                class="text-right py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                İşlemler
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr
                            v-for="product in filteredProducts"
                            :key="product.id"
                            class="border-b border-border last:border-0"
                        >
                            <td class="py-3 px-4">
                                <div class="flex items-center space-x-3">
                                    <img
                                        :src="product.image"
                                        :alt="product.name"
                                        class="w-12 h-12 rounded-lg object-cover"
                                    />
                                    <div>
                                        <h3 class="text-sm font-medium">{{ product.name }}</h3>
                                        <p class="text-xs text-muted-foreground">
                                            SKU: {{ product.sku }}
                                        </p>
                                    </div>
                                </div>
                            </td>
                            <td class="py-3 px-4">
                                <span class="text-sm">{{ product.category }}</span>
                            </td>
                            <td class="py-3 px-4">
                                <div class="flex items-center space-x-2">
                                    <span
                                        :class="[
                                            'w-2 h-2 rounded-full',
                                            {
                                                'bg-green-500': product.stock > 10,
                                                'bg-yellow-500':
                                                    product.stock <= 10 && product.stock > 0,
                                                'bg-red-500': product.stock === 0,
                                            },
                                        ]"
                                    ></span>
                                    <span class="text-sm">{{ product.stock }} adet</span>
                                </div>
                            </td>
                            <td class="py-3 px-4">
                                <span class="text-sm font-medium">{{
                                    formatPrice(product.price)
                                }}</span>
                            </td>
                            <td class="py-3 px-4">
                                <span
                                    :class="[
                                        'inline-flex items-center rounded-full px-2 py-1 text-xs font-medium',
                                        {
                                            'bg-green-100 text-green-700':
                                                product.status === 'active',
                                            'bg-yellow-100 text-yellow-700':
                                                product.status === 'draft',
                                            'bg-red-100 text-red-700':
                                                product.status === 'inactive',
                                        },
                                    ]"
                                >
                                    {{ getStatusText(product.status) }}
                                </span>
                            </td>
                            <td class="py-3 px-4">
                                <div class="flex items-center justify-end space-x-2">
                                    <button
                                        class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 hover:bg-accent hover:text-accent-foreground h-9 w-9"
                                    >
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
                                            class="w-5 h-5"
                                        >
                                            <path
                                                d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z"
                                            />
                                            <path d="m15 5 4 4" />
                                        </svg>
                                    </button>
                                    <button
                                        class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 hover:bg-accent hover:text-accent-foreground h-9 w-9"
                                    >
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
                                            class="w-5 h-5"
                                        >
                                            <path d="M3 6h18" />
                                            <path d="M19 6v14c0 1-1 2-2 2H7c-1 0-2-1-2-2V6" />
                                            <path d="M8 6V4c0-1 1-2 2-2h4c1 0 2 1 2 2v2" />
                                            <line x1="10" x2="10" y1="11" y2="17" />
                                            <line x1="14" x2="14" y1="11" y2="17" />
                                        </svg>
                                    </button>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>

        <!-- Sayfalama -->
        <div class="mt-6 flex justify-center">
            <nav class="flex items-center space-x-2">
                <button
                    class="p-2 rounded-md hover:bg-accent disabled:opacity-50"
                    :disabled="currentPage === 1"
                >
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
                        class="w-5 h-5"
                    >
                        <path d="m15 18-6-6 6-6" />
                    </svg>
                </button>
                <span class="text-sm text-muted-foreground">
                    Sayfa {{ currentPage }} / {{ totalPages }}
                </span>
                <button
                    class="p-2 rounded-md hover:bg-accent disabled:opacity-50"
                    :disabled="currentPage === totalPages"
                >
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
                        class="w-5 h-5"
                    >
                        <path d="m9 18 6-6-6-6" />
                    </svg>
                </button>
            </nav>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

interface Category {
    id: number
    name: string
}

interface Product {
    id: number
    name: string
    sku: string
    category: string
    stock: number
    price: number
    status: 'active' | 'draft' | 'inactive'
    image: string
}

interface Filters {
    search: string
    category: number | string
    stock: string
    sort: string
}

export default defineComponent({
    name: 'ProductsView',
    data() {
        return {
            currentPage: 1,
            totalPages: 5,
            filters: {
                search: '',
                category: '',
                stock: '',
                sort: 'newest',
            } as Filters,
            categories: [
                { id: 1, name: 'Elektronik' },
                { id: 2, name: 'Giyim' },
                { id: 3, name: 'Ev & Yaşam' },
                { id: 4, name: 'Spor & Outdoor' },
                { id: 5, name: 'Kozmetik' },
            ] as Category[],
            products: [
                {
                    id: 1,
                    name: 'Kablosuz Kulaklık',
                    sku: 'PRD-001',
                    category: 'Elektronik',
                    stock: 45,
                    price: 1299.9,
                    status: 'active',
                    image: 'https://picsum.photos/200/200?random=1',
                },
                {
                    id: 2,
                    name: 'Akıllı Saat',
                    sku: 'PRD-002',
                    category: 'Elektronik',
                    stock: 12,
                    price: 2499.9,
                    status: 'active',
                    image: 'https://picsum.photos/200/200?random=2',
                },
                {
                    id: 3,
                    name: 'Spor Ayakkabı',
                    sku: 'PRD-003',
                    category: 'Spor & Outdoor',
                    stock: 8,
                    price: 899.9,
                    status: 'active',
                    image: 'https://picsum.photos/200/200?random=3',
                },
                {
                    id: 4,
                    name: 'Kot Pantolon',
                    sku: 'PRD-004',
                    category: 'Giyim',
                    stock: 0,
                    price: 459.9,
                    status: 'inactive',
                    image: 'https://picsum.photos/200/200?random=4',
                },
                {
                    id: 5,
                    name: 'Bluetooth Hoparlör',
                    sku: 'PRD-005',
                    category: 'Elektronik',
                    stock: 15,
                    price: 799.9,
                    status: 'draft',
                    image: 'https://picsum.photos/200/200?random=5',
                },
            ] as Product[],
        }
    },
    computed: {
        filteredProducts(): Product[] {
            return this.products
                .filter((product) => {
                    if (this.filters.search) {
                        const searchLower = this.filters.search.toLowerCase()
                        const matchesName = product.name.toLowerCase().includes(searchLower)
                        const matchesSku = product.sku.toLowerCase().includes(searchLower)
                        if (!matchesName && !matchesSku) return false
                    }

                    if (
                        this.filters.category &&
                        product.category !== this.getCategoryName(this.filters.category)
                    ) {
                        return false
                    }

                    if (this.filters.stock) {
                        switch (this.filters.stock) {
                            case 'in_stock':
                                if (product.stock <= 0) return false
                                break
                            case 'low_stock':
                                if (product.stock > 10 || product.stock === 0) return false
                                break
                            case 'out_of_stock':
                                if (product.stock > 0) return false
                                break
                        }
                    }

                    return true
                })
                .sort((a, b) => {
                    switch (this.filters.sort) {
                        case 'oldest':
                            return a.id - b.id
                        case 'price_asc':
                            return a.price - b.price
                        case 'price_desc':
                            return b.price - a.price
                        case 'stock_asc':
                            return a.stock - b.stock
                        case 'stock_desc':
                            return b.stock - a.stock
                        default:
                            return b.id - a.id
                    }
                })
        },
    },
    methods: {
        formatPrice(price: number): string {
            return new Intl.NumberFormat('tr-TR', {
                style: 'currency',
                currency: 'TRY',
            }).format(price)
        },
        getStatusText(status: string): string {
            const statusMap: { [key: string]: string } = {
                active: 'Aktif',
                draft: 'Taslak',
                inactive: 'Pasif',
            }
            return statusMap[status] || status
        },
        getCategoryName(id: number | string): string {
            const category = this.categories.find((c) => c.id === id)
            return category ? category.name : ''
        },
    },
})
</script>
