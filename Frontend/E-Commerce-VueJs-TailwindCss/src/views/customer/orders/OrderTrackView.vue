<template>
    <div class="order-track-container max-w-5xl mx-auto p-6">
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
                <h1 class="text-2xl font-bold">Kargo Takip</h1>
            </div>
        </div>

        <!-- Kargo Bilgileri -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <div class="flex items-center justify-between mb-6">
                <div>
                    <h2 class="text-lg font-semibold">Kargo Bilgileri</h2>
                    <p class="text-sm text-muted-foreground mt-1">
                        Sipariş #{{ order.orderNumber }}
                    </p>
                </div>
                <div class="text-right">
                    <p class="text-sm font-medium">{{ order.shipping.company }}</p>
                    <p class="text-sm text-muted-foreground">
                        Takip No: {{ order.shipping.trackingNumber }}
                    </p>
                </div>
            </div>

            <!-- Kargo Durumu -->
            <div class="relative">
                <div class="flex items-center justify-between mb-2">
                    <div
                        v-for="(step, index) in trackingSteps"
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

        <!-- Teslimat Adresi -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <h2 class="text-lg font-semibold mb-4">Teslimat Adresi</h2>
            <div class="space-y-3">
                <p class="text-sm font-medium">{{ order.shippingAddress.fullName }}</p>
                <p class="text-sm text-muted-foreground">{{ order.shippingAddress.address }}</p>
                <p class="text-sm text-muted-foreground">
                    {{ order.shippingAddress.district }}/{{ order.shippingAddress.city }}
                </p>
                <p class="text-sm text-muted-foreground">{{ order.shippingAddress.phone }}</p>
            </div>
        </div>

        <!-- Kargo Hareketleri -->
        <div class="bg-card rounded-lg border border-border p-6">
            <h2 class="text-lg font-semibold mb-4">Kargo Hareketleri</h2>
            <div class="space-y-6">
                <div
                    v-for="movement in order.shipping.movements"
                    :key="movement.id"
                    class="relative pl-6 pb-6 last:pb-0"
                >
                    <!-- Sol çizgi -->
                    <div
                        class="absolute left-[11px] top-2 bottom-0 w-px bg-border"
                        v-if="!movement.isLast"
                    ></div>
                    <!-- Nokta -->
                    <div
                        :class="[
                            'absolute left-0 top-1 w-[23px] h-[23px] rounded-full border-4',
                            movement.isCompleted
                                ? 'border-primary bg-primary/20'
                                : 'border-muted-foreground bg-background',
                        ]"
                    ></div>
                    <!-- İçerik -->
                    <div>
                        <p class="text-sm font-medium">{{ movement.status }}</p>
                        <p class="text-xs text-muted-foreground mt-1">{{ movement.location }}</p>
                        <p class="text-xs text-muted-foreground">{{ movement.date }}</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

interface Address {
    fullName: string
    address: string
    district: string
    city: string
    phone: string
}

interface ShippingMovement {
    id: number
    status: string
    location: string
    date: string
    isCompleted: boolean
    isLast: boolean
}

interface Shipping {
    company: string
    trackingNumber: string
    movements: ShippingMovement[]
}

interface TrackingStep {
    id: number
    label: string
    status: 'completed' | 'current' | 'upcoming'
    date: string
}

interface Order {
    id: number
    orderNumber: string
    shippingAddress: Address
    shipping: Shipping
}

export default defineComponent({
    name: 'OrderTrackView',
    data() {
        return {
            order: {
                id: 1,
                orderNumber: 'ORD-2024-001',
                shippingAddress: {
                    fullName: 'Ahmet Yılmaz',
                    address: 'Atatürk Mah. Cumhuriyet Cad. No:123 D:4',
                    district: 'Çankaya',
                    city: 'Ankara',
                    phone: '0532 123 45 67',
                },
                shipping: {
                    company: 'Aras Kargo',
                    trackingNumber: '1234567890',
                    movements: [
                        {
                            id: 1,
                            status: 'Kargo şubeye ulaştı',
                            location: 'Ankara Çankaya Şubesi',
                            date: '16.01.2024 09:30',
                            isCompleted: true,
                            isLast: false,
                        },
                        {
                            id: 2,
                            status: 'Dağıtıma çıktı',
                            location: 'Ankara Çankaya Şubesi',
                            date: '16.01.2024 10:15',
                            isCompleted: true,
                            isLast: false,
                        },
                        {
                            id: 3,
                            status: 'Teslimat adresi ziyaret edildi',
                            location: 'Ankara Çankaya',
                            date: '16.01.2024 11:45',
                            isCompleted: true,
                            isLast: true,
                        },
                    ],
                },
            } as Order,
            trackingSteps: [
                { id: 1, label: 'Kargoya Verildi', status: 'completed', date: '15.01.2024 17:30' },
                { id: 2, label: 'Şubeye Ulaştı', status: 'completed', date: '16.01.2024 09:30' },
                { id: 3, label: 'Dağıtımda', status: 'current', date: '16.01.2024 10:15' },
                { id: 4, label: 'Teslim Edildi', status: 'upcoming', date: '-' },
            ] as TrackingStep[],
        }
    },
    computed: {
        progressWidth(): number {
            const completedSteps = this.trackingSteps.filter(
                (step) => step.status === 'completed',
            ).length
            const totalSteps = this.trackingSteps.length - 1
            return (completedSteps / totalSteps) * 100
        },
    },
    methods: {
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
