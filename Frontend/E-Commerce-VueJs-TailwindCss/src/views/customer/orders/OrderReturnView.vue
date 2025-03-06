<template>
    <div class="order-return-container max-w-5xl mx-auto p-6">
        <!-- Üst Başlık -->
        <div class="flex items-center justify-between mb-6">
            <div>
                <router-link
                    :to="{ name: 'customer-order-detail', params: { id: order.id } }"
                    class="inline-flex items-center text-sm text-muted-foreground hover:text-primary mb-2"
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
                        class="w-4 h-4 mr-1"
                    >
                        <path d="m15 18-6-6 6-6" />
                    </svg>
                    Sipariş Detayına Dön
                </router-link>
                <h1 class="text-2xl font-bold">Sipariş İade</h1>
            </div>
        </div>

        <!-- İade Bilgilendirmesi -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <div class="flex items-center space-x-4 mb-4">
                <div class="w-12 h-12 rounded-full bg-primary/10 flex items-center justify-center">
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
                        class="text-primary w-6 h-6"
                    >
                        <path d="M3 12a9 9 0 0 1 9-9 9.75 9.75 0 0 1 6.74 2.74L21 8" />
                        <path d="M21 3v5h-5" />
                        <path d="M21 12a9 9 0 0 1-9 9 9.75 9.75 0 0 1-6.74-2.74L3 16" />
                        <path d="M8 16H3v5" />
                    </svg>
                </div>
                <div>
                    <h2 class="text-lg font-semibold">İade Süreci</h2>
                    <p class="text-sm text-muted-foreground">
                        İade talebiniz onaylandıktan sonra kargo ücreti firmamız tarafından
                        karşılanacaktır.
                    </p>
                </div>
            </div>
            <div class="space-y-2 text-sm text-muted-foreground">
                <p>1. İade etmek istediğiniz ürünleri seçin</p>
                <p>2. İade nedeninizi belirtin</p>
                <p>3. Varsa açıklamanızı ekleyin</p>
                <p>4. İade talebinizi gönderin</p>
                <p>5. Onay sonrası kargo kodunuz SMS ile iletilecektir</p>
            </div>
        </div>

        <!-- Ürün Seçimi -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <h2 class="text-lg font-semibold mb-4">İade Edilecek Ürünler</h2>
            <div class="space-y-4">
                <div
                    v-for="product in order.products"
                    :key="product.id"
                    class="flex items-center py-4 border-b border-border last:border-0"
                >
                    <div class="flex-shrink-0 mr-4">
                        <label class="relative flex items-center">
                            <input
                                type="checkbox"
                                v-model="selectedProducts"
                                :value="product.id"
                                class="w-5 h-5 border-2 border-input rounded-md bg-background focus:outline-none focus:ring-2 focus:ring-primary/50 checked:bg-primary checked:border-primary"
                            />
                        </label>
                    </div>
                    <img
                        :src="product.image"
                        :alt="product.name"
                        class="w-16 h-16 rounded-lg object-cover mr-4"
                    />
                    <div class="flex-1">
                        <h3 class="font-medium">{{ product.name }}</h3>
                        <p class="text-sm text-muted-foreground">{{ product.variant }}</p>
                    </div>
                    <div class="text-right">
                        <p class="font-medium">{{ formatPrice(product.price) }}</p>
                        <p class="text-sm text-muted-foreground">{{ product.quantity }} Adet</p>
                    </div>
                </div>
            </div>
        </div>

        <!-- İade Nedeni -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <h2 class="text-lg font-semibold mb-4">İade Nedeni</h2>
            <div class="space-y-4">
                <div
                    v-for="reason in returnReasons"
                    :key="reason.id"
                    class="flex items-center space-x-3"
                >
                    <input
                        type="radio"
                        :id="'reason-' + reason.id"
                        v-model="selectedReason"
                        :value="reason.id"
                        class="w-4 h-4 border-2 border-input rounded-full bg-background focus:outline-none focus:ring-2 focus:ring-primary/50 checked:bg-primary checked:border-primary"
                    />
                    <label :for="'reason-' + reason.id" class="text-sm">{{ reason.label }}</label>
                </div>
            </div>
        </div>

        <!-- Açıklama -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <h2 class="text-lg font-semibold mb-4">Açıklama</h2>
            <textarea
                v-model="returnNote"
                rows="4"
                placeholder="İade ile ilgili eklemek istediğiniz notları buraya yazabilirsiniz..."
                class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50 resize-none"
            ></textarea>
        </div>

        <!-- Onay -->
        <div class="flex items-center justify-between">
            <div class="flex items-center space-x-2">
                <input
                    type="checkbox"
                    id="terms"
                    v-model="acceptTerms"
                    class="w-4 h-4 border-2 border-input rounded bg-background focus:outline-none focus:ring-2 focus:ring-primary/50 checked:bg-primary checked:border-primary"
                />
                <label for="terms" class="text-sm text-muted-foreground">
                    İade koşullarını okudum ve kabul ediyorum
                </label>
            </div>
            <button
                @click="submitReturn"
                :disabled="!isFormValid"
                :class="[
                    'px-6 py-3 rounded-md font-medium transition-colors',
                    isFormValid
                        ? 'bg-primary text-primary-foreground hover:bg-primary/90'
                        : 'bg-muted text-muted-foreground cursor-not-allowed',
                ]"
            >
                İade Talebini Gönder
            </button>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

interface Product {
    id: number
    name: string
    image: string
    variant: string
    price: number
    quantity: number
}

interface ReturnReason {
    id: number
    label: string
}

interface Order {
    id: number
    orderNumber: string
    products: Product[]
}

export default defineComponent({
    name: 'OrderReturnView',
    data() {
        return {
            order: {
                id: 1,
                orderNumber: 'ORD-2024-001',
                products: [
                    {
                        id: 1,
                        name: 'Ürün 1',
                        image: 'https://picsum.photos/200/200?random=1',
                        variant: 'Siyah, L Beden',
                        price: 450.0,
                        quantity: 2,
                    },
                    {
                        id: 2,
                        name: 'Ürün 2',
                        image: 'https://picsum.photos/200/200?random=2',
                        variant: 'Beyaz, M Beden',
                        price: 350.9,
                        quantity: 1,
                    },
                ],
            } as Order,
            returnReasons: [
                { id: 1, label: 'Ürün beklediğim gibi değil' },
                { id: 2, label: 'Yanlış/hasarlı ürün geldi' },
                { id: 3, label: 'Ürün bedeni uygun değil' },
                { id: 4, label: 'Ürünü beğenmedim' },
                { id: 5, label: 'Diğer' },
            ] as ReturnReason[],
            selectedProducts: [] as number[],
            selectedReason: null as number | null,
            returnNote: '',
            acceptTerms: false,
        }
    },
    computed: {
        isFormValid(): boolean {
            return (
                this.selectedProducts.length > 0 && this.selectedReason !== null && this.acceptTerms
            )
        },
    },
    methods: {
        formatPrice(price: number): string {
            return new Intl.NumberFormat('tr-TR', {
                style: 'currency',
                currency: 'TRY',
            }).format(price)
        },
        submitReturn() {
            if (!this.isFormValid) return

            // TODO: İade talebini gönder
            console.log('İade talebi gönderiliyor...', {
                orderId: this.order.id,
                products: this.selectedProducts,
                reason: this.selectedReason,
                note: this.returnNote,
            })
        },
    },
})
</script>
