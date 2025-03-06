<template>
    <div class="product-create">
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
                <h1 class="text-2xl font-bold">Yeni Ürün</h1>
            </div>
            <div class="flex items-center space-x-2">
                <button
                    class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 bg-primary text-primary-foreground shadow hover:bg-primary/90 h-9 px-4"
                    @click="saveProduct"
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
                        <path d="M19 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h11l5 5v11a2 2 0 0 1-2 2z" />
                        <polyline points="17 21 17 13 7 13 7 21" />
                        <polyline points="7 3 7 8 15 8" />
                    </svg>
                    Kaydet
                </button>
            </div>
        </div>

        <!-- Form -->
        <form @submit.prevent="saveProduct" class="space-y-6">
            <!-- Temel Bilgiler -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Temel Bilgiler</h2>
                <div class="grid gap-4 md:grid-cols-2">
                    <div class="space-y-2">
                        <label class="text-sm font-medium">Ürün Adı</label>
                        <input
                            v-model="product.name"
                            type="text"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                            placeholder="Ürün adını girin"
                        />
                    </div>
                    <div class="space-y-2">
                        <label class="text-sm font-medium">SKU</label>
                        <input
                            v-model="product.sku"
                            type="text"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                            placeholder="SKU kodunu girin"
                        />
                    </div>
                    <div class="space-y-2">
                        <label class="text-sm font-medium">Barkod</label>
                        <input
                            v-model="product.barcode"
                            type="text"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                            placeholder="Barkod numarasını girin"
                        />
                    </div>
                    <div class="space-y-2">
                        <label class="text-sm font-medium">Kategori</label>
                        <select
                            v-model="product.category"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                        >
                            <option value="">Kategori seçin</option>
                            <option value="Elektronik">Elektronik</option>
                            <option value="Giyim">Giyim</option>
                            <option value="Ev & Yaşam">Ev & Yaşam</option>
                            <option value="Kitap">Kitap</option>
                        </select>
                    </div>
                    <div class="space-y-2">
                        <label class="text-sm font-medium">Marka</label>
                        <input
                            v-model="product.brand"
                            type="text"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                            placeholder="Marka adını girin"
                        />
                    </div>
                    <div class="space-y-2">
                        <label class="text-sm font-medium">Durum</label>
                        <select
                            v-model="product.status"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                        >
                            <option value="active">Aktif</option>
                            <option value="draft">Taslak</option>
                            <option value="inactive">Pasif</option>
                        </select>
                    </div>
                </div>
            </div>

            <!-- Stok ve Fiyat -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Stok ve Fiyat</h2>
                <div class="grid gap-4 md:grid-cols-3">
                    <div class="space-y-2">
                        <label class="text-sm font-medium">Stok Miktarı</label>
                        <input
                            v-model.number="product.stock"
                            type="number"
                            min="0"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                            placeholder="Stok miktarını girin"
                        />
                    </div>
                    <div class="space-y-2">
                        <label class="text-sm font-medium">Satış Fiyatı</label>
                        <input
                            v-model.number="product.price"
                            type="number"
                            min="0"
                            step="0.01"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                            placeholder="Satış fiyatını girin"
                        />
                    </div>
                    <div class="space-y-2">
                        <label class="text-sm font-medium">Maliyet</label>
                        <input
                            v-model.number="product.cost"
                            type="number"
                            min="0"
                            step="0.01"
                            class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                            placeholder="Maliyet fiyatını girin"
                        />
                    </div>
                </div>
            </div>

            <!-- Açıklama -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Açıklama</h2>
                <div class="space-y-2">
                    <label class="text-sm font-medium">Ürün Açıklaması</label>
                    <textarea
                        v-model="product.description"
                        rows="4"
                        class="flex w-full rounded-md border border-input bg-transparent px-3 py-2 text-sm shadow-sm transition-colors placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                        placeholder="Ürün açıklamasını girin"
                    ></textarea>
                </div>
            </div>

            <!-- Özellikler -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between mb-4">
                    <h2 class="text-lg font-semibold">Özellikler</h2>
                    <button
                        type="button"
                        class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 bg-secondary text-secondary-foreground shadow-sm hover:bg-secondary/80 h-9 px-4"
                        @click="addAttribute"
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
                        Özellik Ekle
                    </button>
                </div>
                <div class="space-y-4">
                    <div
                        v-for="(value, key) in product.attributes"
                        :key="key"
                        class="grid gap-4 md:grid-cols-[1fr,2fr,auto]"
                    >
                        <div class="space-y-2">
                            <label class="text-sm font-medium">Özellik Adı</label>
                            <input
                                :value="key"
                                @input="updateAttributeKey(key, $event.target.value)"
                                type="text"
                                class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                                placeholder="Özellik adını girin"
                            />
                        </div>
                        <div class="space-y-2">
                            <label class="text-sm font-medium">Değer</label>
                            <input
                                v-model="product.attributes[key]"
                                type="text"
                                class="flex h-9 w-full rounded-md border border-input bg-transparent px-3 py-1 text-sm shadow-sm transition-colors file:border-0 file:bg-transparent file:text-sm file:font-medium placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50"
                                placeholder="Değer girin"
                            />
                        </div>
                        <div class="flex items-end">
                            <button
                                type="button"
                                class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 hover:bg-accent hover:text-accent-foreground h-9 w-9"
                                @click="removeAttribute(key)"
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
                    </div>
                </div>
            </div>
        </form>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

interface Product {
    id?: number
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
    name: 'ProductCreateView',
    data() {
        return {
            product: {
                name: '',
                sku: '',
                barcode: '',
                category: '',
                brand: '',
                status: 'draft',
                stock: 0,
                price: 0,
                cost: 0,
                description: '',
                image: 'https://picsum.photos/200/200?random=1',
                attributes: {},
            } as Product,
        }
    },
    methods: {
        saveProduct() {
            // TODO: Implement save functionality
            console.log('Saving product:', this.product)
            this.$router.push({ name: 'seller-products' })
        },
        addAttribute() {
            const newKey = `Özellik ${Object.keys(this.product.attributes).length + 1}`
            this.product.attributes = {
                ...this.product.attributes,
                [newKey]: '',
            }
        },
        removeAttribute(key: string) {
            const { [key]: _, ...rest } = this.product.attributes
            this.product.attributes = rest
        },
        updateAttributeKey(oldKey: string, newKey: string) {
            if (oldKey === newKey) return
            const { [oldKey]: value, ...rest } = this.product.attributes
            this.product.attributes = {
                ...rest,
                [newKey]: value,
            }
        },
    },
})
</script>
