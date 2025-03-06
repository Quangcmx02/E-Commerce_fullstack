<template>
    <div class="products">
        <!-- Üst Başlık -->
        <div class="flex items-center justify-between mb-6">
            <div class="flex items-center space-x-4">
                <h1 class="text-2xl font-bold">Ürünler</h1>
            </div>
            <div class="flex items-center space-x-2">
                <router-link
                    :to="{ name: 'seller-product-create' }"
                    class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 bg-primary text-primary-foreground shadow hover:bg-primary/90 h-9 px-4"
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
                        class="w-4 h-4 mr-2"
                    >
                        <path d="M5 12h14" />
                        <path d="M12 5v14" />
                    </svg>
                    Yeni Ürün
                </router-link>
            </div>
        </div>

        <!-- Filtreler -->
        <div class="bg-card rounded-lg border border-border p-4 mb-6">
            <div class="grid gap-4 md:grid-cols-4">
                <div class="space-y-2">
                    <label class="text-sm font-medium">Arama</label>
                    <input
                        v-model="filters.search"
                        type="text"
                        class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                        placeholder="Ürün adı, SKU veya barkod"
                    />
                </div>
                <div class="space-y-2">
                    <label class="text-sm font-medium">Kategori</label>
                    <select
                        v-model="filters.category"
                        class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                    >
                        <option value="">Tümü</option>
                        <option value="Elektronik">Elektronik</option>
                        <option value="Giyim">Giyim</option>
                        <option value="Ev & Yaşam">Ev & Yaşam</option>
                        <option value="Kitap">Kitap</option>
                    </select>
                </div>
                <div class="space-y-2">
                    <label class="text-sm font-medium">Durum</label>
                    <select
                        v-model="filters.status"
                        class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                    >
                        <option value="">Tümü</option>
                        <option value="active">Aktif</option>
                        <option value="draft">Taslak</option>
                        <option value="inactive">Pasif</option>
                    </select>
                </div>
                <div class="space-y-2">
                    <label class="text-sm font-medium">Stok Durumu</label>
                    <select
                        v-model="filters.stock"
                        class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                    >
                        <option value="">Tümü</option>
                        <option value="in_stock">Stokta</option>
                        <option value="low_stock">Düşük Stok</option>
                        <option value="out_of_stock">Stokta Yok</option>
                    </select>
                </div>
            </div>
        </div>

        <!-- Ürün Listesi -->
        <div class="bg-card rounded-lg border border-border">
            <div class="relative w-full overflow-auto">
                <table class="w-full caption-bottom text-sm">
                    <thead class="[&_tr]:border-b">
                        <tr
                            class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted"
                        >
                            <th
                                class="h-12 px-4 text-left align-middle font-medium text-muted-foreground"
                            >
                                Ürün
                            </th>
                            <th
                                class="h-12 px-4 text-left align-middle font-medium text-muted-foreground"
                            >
                                SKU
                            </th>
                            <th
                                class="h-12 px-4 text-left align-middle font-medium text-muted-foreground"
                            >
                                Kategori
                            </th>
                            <th
                                class="h-12 px-4 text-left align-middle font-medium text-muted-foreground"
                            >
                                Stok
                            </th>
                            <th
                                class="h-12 px-4 text-left align-middle font-medium text-muted-foreground"
                            >
                                Fiyat
                            </th>
                            <th
                                class="h-12 px-4 text-left align-middle font-medium text-muted-foreground"
                            >
                                Durum
                            </th>
                            <th
                                class="h-12 px-4 align-middle font-medium text-muted-foreground text-right"
                            >
                                İşlemler
                            </th>
                        </tr>
                    </thead>
                    <tbody class="[&_tr:last-child]:border-0">
                        <tr
                            v-for="product in filteredProducts"
                            :key="product.id"
                            class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted"
                        >
                            <td class="p-4 align-middle">
                                <div class="flex items-center space-x-2">
                                    <img
                                        :src="product.image"
                                        :alt="product.name"
                                        class="h-8 w-8 rounded-lg object-cover"
                                    />
                                    <span class="font-medium">{{ product.name }}</span>
                                </div>
                            </td>
                            <td class="p-4 align-middle">
                                {{ product.sku }}
                            </td>
                            <td class="p-4 align-middle">
                                {{ product.category }}
                            </td>
                            <td class="p-4 align-middle">
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
                                    <span>{{ product.stock }} adet</span>
                                </div>
                            </td>
                            <td class="p-4 align-middle">
                                {{ formatPrice(product.price) }}
                            </td>
                            <td class="p-4 align-middle">
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
                            <td class="p-4 align-middle">
                                <div class="flex items-center justify-end space-x-2">
                                    <router-link
                                        :to="{
                                            name: 'seller-product-detail',
                                            params: { id: product.id },
                                        }"
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
                                            class="w-4 h-4"
                                        >
                                            <path
                                                d="M2 12s3-7 10-7 10 7 10 7-3 7-10 7-10-7-10-7Z"
                                            />
                                            <circle cx="12" cy="12" r="3" />
                                        </svg>
                                    </router-link>
                                    <router-link
                                        :to="{
                                            name: 'seller-product-edit',
                                            params: { id: product.id },
                                        }"
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
                                            class="w-4 h-4"
                                        >
                                            <path
                                                d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z"
                                            />
                                            <path d="m15 5 4 4" />
                                        </svg>
                                    </router-link>
                                    <button
                                        class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 hover:bg-accent hover:text-accent-foreground h-9 w-9"
                                        @click="deleteProduct(product)"
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
                                            class="w-4 h-4"
                                        >
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
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

interface Product {
    id: number
    name: string
    sku: string
    barcode: string
    category: string
    brand: string
    status: 'active' | 'draft' | 'inactive'
    stock: number
    price: number
    cost: number
    description: string
    image: string
    attributes: { [key: string]: string }
}

export default defineComponent({
    name: 'ProductsView',
    data() {
        return {
            products: [
                {
                    id: 1,
                    name: 'Kablosuz Kulaklık',
                    sku: 'PRD-001',
                    barcode: '8680001234567',
                    category: 'Elektronik',
                    brand: 'TechBrand',
                    status: 'active',
                    stock: 45,
                    price: 1299.9,
                    cost: 850.0,
                    description:
                        'Yüksek kaliteli ses deneyimi sunan, uzun pil ömrüne sahip kablosuz kulaklık.',
                    image: 'https://picsum.photos/200/200?random=1',
                    attributes: {
                        'Bluetooth Sürümü': '5.0',
                        'Pil Ömrü': '30 saat',
                        'Şarj Süresi': '2 saat',
                        'Su Dayanıklılığı': 'IPX4',
                        Renk: 'Siyah',
                        Garanti: '2 Yıl',
                    },
                },
                {
                    id: 2,
                    name: 'Akıllı Saat',
                    sku: 'PRD-002',
                    barcode: '8680001234568',
                    category: 'Elektronik',
                    brand: 'TechBrand',
                    status: 'active',
                    stock: 8,
                    price: 2499.9,
                    cost: 1750.0,
                    description: 'Sağlık takibi ve bildirim özellikleri ile akıllı saat.',
                    image: 'https://picsum.photos/200/200?random=2',
                    attributes: {
                        'Ekran Boyutu': '1.4 inç',
                        'Pil Ömrü': '7 gün',
                        'Su Dayanıklılığı': '5 ATM',
                        Renk: 'Gümüş',
                        Garanti: '2 Yıl',
                    },
                },
                {
                    id: 3,
                    name: 'Spor Ayakkabı',
                    sku: 'PRD-003',
                    barcode: '8680001234569',
                    category: 'Giyim',
                    brand: 'SportBrand',
                    status: 'active',
                    stock: 120,
                    price: 899.9,
                    cost: 450.0,
                    description: 'Rahat ve şık tasarımlı spor ayakkabı.',
                    image: 'https://picsum.photos/200/200?random=3',
                    attributes: {
                        Numara: '42',
                        Renk: 'Siyah/Beyaz',
                        Malzeme: 'Tekstil/Sentetik',
                        Taban: 'EVA',
                    },
                },
            ] as Product[],
            filters: {
                search: '',
                category: '',
                status: '',
                stock: '',
            },
        }
    },
    computed: {
        filteredProducts(): Product[] {
            return this.products.filter((product) => {
                const searchMatch =
                    !this.filters.search ||
                    product.name.toLowerCase().includes(this.filters.search.toLowerCase()) ||
                    product.sku.toLowerCase().includes(this.filters.search.toLowerCase()) ||
                    product.barcode.toLowerCase().includes(this.filters.search.toLowerCase())

                const categoryMatch =
                    !this.filters.category || product.category === this.filters.category

                const statusMatch = !this.filters.status || product.status === this.filters.status

                const stockMatch = this.matchStockFilter(product.stock)

                return searchMatch && categoryMatch && statusMatch && stockMatch
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
        matchStockFilter(stock: number): boolean {
            switch (this.filters.stock) {
                case 'in_stock':
                    return stock > 10
                case 'low_stock':
                    return stock <= 10 && stock > 0
                case 'out_of_stock':
                    return stock === 0
                default:
                    return true
            }
        },
        deleteProduct(product: Product) {
            // TODO: Implement delete functionality
            const index = this.products.findIndex((p) => p.id === product.id)
            if (index !== -1) {
                this.products.splice(index, 1)
            }
        },
    },
})
</script>
