<template>
    <div class="order-detail-container max-w-5xl mx-auto p-6">
        <!-- Üst Başlık -->
        <div class="flex items-center justify-between mb-6">
            <div>
                <router-link
                    :to="{ name: 'customer-orders' }"
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
                    Siparişlere Dön
                </router-link>
                <h1 class="text-2xl font-bold">Sipariş #{{ order.orderNumber }}</h1>
            </div>
            <div class="flex items-center space-x-3">
                <router-link
                    v-if="order.status === 'shipped'"
                    :to="{ name: 'customer-order-track', params: { id: order.id } }"
                    class="px-4 py-2 bg-primary/10 text-primary rounded-md hover:bg-primary/20 transition-colors"
                >
                    Kargo Takip
                </router-link>
                <router-link
                    v-if="order.status === 'delivered' && !order.isReturnExpired"
                    :to="{ name: 'customer-order-return', params: { id: order.id } }"
                    class="px-4 py-2 bg-destructive/10 text-destructive rounded-md hover:bg-destructive/20 transition-colors"
                >
                    İade Et
                </router-link>
            </div>
        </div>

        <!-- Sipariş Durumu -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <div class="flex items-center justify-between mb-6">
                <h2 class="text-lg font-semibold">Sipariş Durumu</h2>
                <div
                    :class="[
                        'px-3 py-1 rounded-full text-sm font-medium',
                        {
                            'bg-blue-100 text-blue-700': order.status === 'processing',
                            'bg-yellow-100 text-yellow-700': order.status === 'shipped',
                            'bg-green-100 text-green-700': order.status === 'delivered',
                            'bg-red-100 text-red-700': order.status === 'cancelled',
                            'bg-orange-100 text-orange-700': order.status === 'returned',
                        },
                    ]"
                >
                    {{ getStatusText(order.status) }}
                </div>
            </div>
            <div class="relative">
                <div class="flex items-center justify-between mb-2">
                    <div
                        v-for="(step, index) in orderSteps"
                        :key="step.id"
                        class="flex flex-col items-center flex-1"
                    >
                        <div
                            :class="[
                                'w-8 h-8 rounded-full flex items-center justify-center text-sm font-medium mb-2',
                                getStepStyle(step.status),
                            ]"
                        >
                            {{ index + 1 }}
                        </div>
                        <div class="text-center">
                            <p
                                class="text-sm font-medium"
                                :class="
                                    step.status === 'completed'
                                        ? 'text-primary'
                                        : 'text-muted-foreground'
                                "
                            >
                                {{ step.label }}
                            </p>
                            <p class="text-xs text-muted-foreground">{{ step.date }}</p>
                        </div>
                    </div>
                </div>
                <div class="absolute top-4 left-0 right-0 h-0.5 -z-10">
                    <div class="h-full bg-border"></div>
                    <div class="h-full bg-primary" :style="{ width: progressWidth + '%' }"></div>
                </div>
            </div>
        </div>

        <!-- Teslimat ve Fatura Bilgileri -->
        <div class="grid grid-cols-1 md:grid-cols-2 gap-6 mb-6">
            <!-- Teslimat Bilgileri -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Teslimat Bilgileri</h2>
                <div class="space-y-3">
                    <p class="text-sm font-medium">{{ order.shippingAddress.fullName }}</p>
                    <p class="text-sm text-muted-foreground">{{ order.shippingAddress.address }}</p>
                    <p class="text-sm text-muted-foreground">
                        {{ order.shippingAddress.district }}/{{ order.shippingAddress.city }}
                    </p>
                    <p class="text-sm text-muted-foreground">{{ order.shippingAddress.phone }}</p>
                </div>
            </div>

            <!-- Fatura Bilgileri -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h2 class="text-lg font-semibold mb-4">Fatura Bilgileri</h2>
                <div class="space-y-3">
                    <p class="text-sm font-medium">{{ order.billingAddress.fullName }}</p>
                    <p class="text-sm text-muted-foreground">{{ order.billingAddress.address }}</p>
                    <p class="text-sm text-muted-foreground">
                        {{ order.billingAddress.district }}/{{ order.billingAddress.city }}
                    </p>
                    <p class="text-sm text-muted-foreground">{{ order.billingAddress.phone }}</p>
                    <p v-if="order.billingAddress.taxInfo" class="text-sm text-muted-foreground">
                        {{ order.billingAddress.taxInfo }}
                    </p>
                </div>
            </div>
        </div>

        <!-- Ürünler -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <h2 class="text-lg font-semibold mb-4">Sipariş Detayı</h2>
            <div class="space-y-4">
                <div
                    v-for="product in order.products"
                    :key="product.id"
                    class="flex items-center py-4 border-b border-border last:border-0"
                >
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

        <!-- Ödeme Özeti -->
        <div class="bg-card rounded-lg border border-border p-6">
            <h2 class="text-lg font-semibold mb-4">Ödeme Özeti</h2>
            <div class="space-y-3">
                <div class="flex justify-between text-sm">
                    <span class="text-muted-foreground">Ara Toplam</span>
                    <span>{{ formatPrice(order.subtotal) }}</span>
                </div>
                <div class="flex justify-between text-sm">
                    <span class="text-muted-foreground">Kargo</span>
                    <span>{{ formatPrice(order.shippingCost) }}</span>
                </div>
                <div v-if="order.discount" class="flex justify-between text-sm">
                    <span class="text-muted-foreground">İndirim</span>
                    <span class="text-destructive">-{{ formatPrice(order.discount) }}</span>
                </div>
                <div class="flex justify-between font-medium pt-3 border-t border-border">
                    <span>Toplam</span>
                    <span>{{ formatPrice(order.total) }}</span>
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
    image: string
    variant: string
    price: number
    quantity: number
}

interface Address {
    fullName: string
    address: string
    district: string
    city: string
    phone: string
    taxInfo?: string
}

interface OrderStep {
    id: number
    label: string
    status: 'completed' | 'current' | 'upcoming'
    date: string
}

interface Order {
    id: number
    orderNumber: string
    date: string
    status: 'processing' | 'shipped' | 'delivered' | 'cancelled' | 'returned'
    products: Product[]
    subtotal: number
    shippingCost: number
    discount: number
    total: number
    isReturnExpired: boolean
    shippingAddress: Address
    billingAddress: Address
}

export default defineComponent({
    name: 'OrderDetailView',
    data() {
        return {
            order: {
                id: 1,
                orderNumber: 'ORD-2024-001',
                date: '2024-01-15',
                status: 'processing',
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
                subtotal: 1250.9,
                shippingCost: 29.9,
                discount: 100.0,
                total: 1180.8,
                isReturnExpired: false,
                shippingAddress: {
                    fullName: 'Ahmet Yılmaz',
                    address: 'Atatürk Mah. Cumhuriyet Cad. No:123 D:4',
                    district: 'Çankaya',
                    city: 'Ankara',
                    phone: '0532 123 45 67',
                },
                billingAddress: {
                    fullName: 'Ahmet Yılmaz',
                    address: 'Atatürk Mah. Cumhuriyet Cad. No:123 D:4',
                    district: 'Çankaya',
                    city: 'Ankara',
                    phone: '0532 123 45 67',
                },
            } as Order,
            orderSteps: [
                { id: 1, label: 'Sipariş Alındı', status: 'completed', date: '15.01.2024 14:30' },
                { id: 2, label: 'Hazırlanıyor', status: 'current', date: '15.01.2024 15:45' },
                { id: 3, label: 'Kargoya Verildi', status: 'upcoming', date: '-' },
                { id: 4, label: 'Teslim Edildi', status: 'upcoming', date: '-' },
            ] as OrderStep[],
        }
    },
    computed: {
        progressWidth(): number {
            const completedSteps = this.orderSteps.filter(
                (step) => step.status === 'completed',
            ).length
            const totalSteps = this.orderSteps.length - 1
            return (completedSteps / totalSteps) * 100
        },
    },
    methods: {
        getStatusText(status: string): string {
            const statusMap: { [key: string]: string } = {
                processing: 'İşleme Alındı',
                shipped: 'Kargoya Verildi',
                delivered: 'Teslim Edildi',
                cancelled: 'İptal Edildi',
                returned: 'İade Edildi',
            }
            return statusMap[status] || status
        },
        formatPrice(price: number): string {
            return new Intl.NumberFormat('tr-TR', {
                style: 'currency',
                currency: 'TRY',
            }).format(price)
        },
        getStepStyle(status: string): string {
            switch (status) {
                case 'completed':
                    return 'bg-primary text-primary-foreground'
                case 'current':
                    return 'bg-primary/20 text-primary border-2 border-primary'
                default:
                    return 'bg-muted text-muted-foreground'
            }
        },
    },
})
</script>
