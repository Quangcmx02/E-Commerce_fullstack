<template>
    <div class="product-detail">
        <!-- Üst Başlık -->
        <div class="flex items-center justify-between mb-6">
            <div class="flex items-center space-x-4">
                <button
                    class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 hover:bg-accent hover:text-accent-foreground h-9 w-9"
                    @click="$router.back()"
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
                <h1 class="text-2xl font-bold">Ürün Detayı</h1>
            </div>
            <div class="flex items-center space-x-2">
                <button
                    class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 bg-destructive text-destructive-foreground shadow-sm hover:bg-destructive/90 h-9 px-4"
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
                        <path d="M3 6h18" />
                        <path d="M19 6v14c0 1-1 2-2 2H7c-1 0-2-1-2-2V6" />
                        <path d="M8 6V4c0-1 1-2 2-2h4c1 0 2 1 2 2v2" />
                        <line x1="10" x2="10" y1="11" y2="17" />
                        <line x1="14" x2="14" y1="11" y2="17" />
                    </svg>
                    Ürünü Sil
                </button>
                <router-link
                    :to="{ name: 'seller-product-edit', params: { id: product.id } }"
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
                        <path d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z" />
                        <path d="m15 5 4 4" />
                    </svg>
                    Düzenle
                </router-link>
            </div>
        </div>

        <!-- Ürün Bilgileri -->
        <div class="grid gap-6 md:grid-cols-2">
            <!-- Temel Bilgiler -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Temel Bilgiler</h2>
                <div class="space-y-4">
                    <div class="flex items-center space-x-4">
                        <img
                            :src="product.image"
                            :alt="product.name"
                            class="w-24 h-24 rounded-lg object-cover"
                        />
                        <div>
                            <h3 class="text-base font-medium">{{ product.name }}</h3>
                            <p class="text-sm text-muted-foreground">SKU: {{ product.sku }}</p>
                            <p class="text-sm text-muted-foreground">
                                Barkod: {{ product.barcode }}
                            </p>
                        </div>
                    </div>
                    <div class="grid gap-4">
                        <div>
                            <label class="text-sm font-medium text-muted-foreground"
                                >Kategori</label
                            >
                            <p class="text-sm">{{ product.category }}</p>
                        </div>
                        <div>
                            <label class="text-sm font-medium text-muted-foreground">Marka</label>
                            <p class="text-sm">{{ product.brand }}</p>
                        </div>
                        <div>
                            <label class="text-sm font-medium text-muted-foreground">Durum</label>
                            <span
                                :class="[
                                    'inline-flex items-center rounded-full px-2 py-1 text-xs font-medium',
                                    {
                                        'bg-green-100 text-green-700': product.status === 'active',
                                        'bg-yellow-100 text-yellow-700': product.status === 'draft',
                                        'bg-red-100 text-red-700': product.status === 'inactive',
                                    },
                                ]"
                            >
                                {{ getStatusText(product.status) }}
                            </span>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Stok ve Fiyat -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Stok ve Fiyat</h2>
                <div class="grid gap-4">
                    <div class="flex items-center justify-between p-4 bg-background rounded-lg">
                        <div>
                            <p class="text-sm font-medium text-muted-foreground">Stok Durumu</p>
                            <div class="flex items-center space-x-2 mt-1">
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
                                <p class="text-2xl font-bold">{{ product.stock }} adet</p>
                            </div>
                        </div>
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
                            class="w-8 h-8 text-muted-foreground"
                        >
                            <path d="m7.5 4.27 9 5.15" />
                            <path
                                d="M21 8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16Z"
                            />
                            <path d="m3.3 7 8.7 5 8.7-5" />
                            <path d="M12 22V12" />
                        </svg>
                    </div>
                    <div class="flex items-center justify-between p-4 bg-background rounded-lg">
                        <div>
                            <p class="text-sm font-medium text-muted-foreground">Satış Fiyatı</p>
                            <p class="text-2xl font-bold">{{ formatPrice(product.price) }}</p>
                        </div>
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
                            class="w-8 h-8 text-muted-foreground"
                        >
                            <circle cx="12" cy="12" r="8" />
                            <path d="M14.5 9h-2.5a2 2 0 1 0 0 4h2a2 2 0 1 1 0 4h-3" />
                            <path d="M12 7v2" />
                            <path d="M12 15v2" />
                        </svg>
                    </div>
                    <div class="flex items-center justify-between p-4 bg-background rounded-lg">
                        <div>
                            <p class="text-sm font-medium text-muted-foreground">Maliyet</p>
                            <p class="text-2xl font-bold">{{ formatPrice(product.cost) }}</p>
                        </div>
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
                            class="w-8 h-8 text-muted-foreground"
                        >
                            <path
                                d="M20.91 8.84 8.56 2.23a1.93 1.93 0 0 0-1.81 0L3.1 4.13a2.12 2.12 0 0 0-.05 3.69l12.22 6.93a2 2 0 0 0 1.94 0L21 12.51a2.12 2.12 0 0 0-.09-3.67Z"
                            />
                            <path
                                d="m3.09 8.84 12.35-6.61a1.93 1.93 0 0 1 1.81 0l3.65 1.9a2.12 2.12 0 0 1 .1 3.69L8.73 14.75a2 2 0 0 1-1.94 0L3 12.51a2.12 2.12 0 0 1 .09-3.67Z"
                            />
                            <line x1="12" x2="12" y1="22" y2="13" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Açıklama -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Açıklama</h2>
                <div class="prose prose-sm max-w-none">
                    {{ product.description }}
                </div>
            </div>

            <!-- Özellikler -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Özellikler</h2>
                <div class="space-y-2">
                    <div
                        v-for="(value, key) in product.attributes"
                        :key="key"
                        class="flex items-center justify-between py-2 border-b border-border last:border-0"
                    >
                        <span class="text-sm font-medium text-muted-foreground">{{ key }}</span>
                        <span class="text-sm">{{ value }}</span>
                    </div>
                </div>
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
    name: 'ProductDetailView',
    data() {
        return {
            product: {
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
                    'Yüksek kaliteli ses deneyimi sunan, uzun pil ömrüne sahip kablosuz kulaklık. Active Noise Cancelling özelliği ile dış sesleri engelleyerek müzik keyfinizi artırır. Ergonomik tasarımı sayesinde uzun süre kullanımlarda bile rahatlıkla takılabilir.',
                image: 'https://picsum.photos/200/200?random=1',
                attributes: {
                    'Bluetooth Sürümü': '5.0',
                    'Pil Ömrü': '30 saat',
                    'Şarj Süresi': '2 saat',
                    'Su Dayanıklılığı': 'IPX4',
                    Renk: 'Siyah',
                    Garanti: '2 Yıl',
                },
            } as Product,
        }
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
    },
})
</script>
