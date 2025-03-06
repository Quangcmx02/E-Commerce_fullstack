<template>
    <div class="orders-container max-w-5xl mx-auto p-6">
        <h1 class="text-2xl font-bold mb-6">Siparişlerim</h1>

        <!-- Filtreler -->
        <div class="bg-card rounded-lg border border-border p-4 mb-6">
            <div class="flex flex-wrap gap-4">
                <!-- Durum Filtresi -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">Sipariş Durumu</label>
                    <select v-model="filters.status" class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50">
                        <option value="">Tümü</option>
                        <option value="processing">İşleme Alındı</option>
                        <option value="shipped">Kargoya Verildi</option>
                        <option value="delivered">Teslim Edildi</option>
                        <option value="cancelled">İptal Edildi</option>
                        <option value="returned">İade Edildi</option>
                    </select>
                </div>

                <!-- Tarih Filtresi -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">Tarih Aralığı</label>
                    <select v-model="filters.dateRange" class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50">
                        <option value="all">Tüm Zamanlar</option>
                        <option value="last30">Son 30 Gün</option>
                        <option value="last90">Son 90 Gün</option>
                        <option value="last180">Son 180 Gün</option>
                        <option value="last365">Son 1 Yıl</option>
                    </select>
                </div>

                <!-- Arama -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">Sipariş Ara</label>
                    <div class="relative">
                        <input v-model="filters.search" type="text" placeholder="Sipariş no veya ürün adı" class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50 pr-10" />
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute right-3 top-1/2 -translate-y-1/2 w-4 h-4 text-muted-foreground">
                            <circle cx="11" cy="11" r="8" />
                            <path d="m21 21-4.3-4.3" />
                        </svg>
                    </div>
                </div>
            </div>
        </div>

        <!-- Sipariş Listesi -->
        <div class="space-y-4">
            <div v-for="order in filteredOrders" :key="order.id" class="bg-card rounded-lg border border-border overflow-hidden hover:border-primary/50 transition-colors">
                <!-- Sipariş Başlığı -->
                <div class="p-4 flex items-center justify-between border-b border-border">
                    <div class="flex items-center space-x-4">
                        <div>
                            <h3 class="font-semibold text-card-foreground">Sipariş #{{ order.orderNumber }}</h3>
                            <p class="text-sm text-muted-foreground">{{ order.date }}</p>
                        </div>
                    </div>
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

                <!-- Sipariş İçeriği -->
                <div class="p-4">
                    <div class="flex flex-wrap gap-4">
                        <!-- Ürün Görselleri -->
                        <div class="flex -space-x-3">
                            <img v-for="product in order.products.slice(0, 3)" :key="product.id" :src="product.image" :alt="product.name" class="w-12 h-12 rounded-lg border-2 border-background object-cover" />
                            <div v-if="order.products.length > 3" class="w-12 h-12 rounded-lg bg-primary/10 border-2 border-background flex items-center justify-center text-sm font-medium text-primary">+{{ order.products.length - 3 }}</div>
                        </div>

                        <!-- Sipariş Özeti -->
                        <div class="flex-1">
                            <div class="flex items-center justify-between">
                                <div>
                                    <p class="text-card-foreground">{{ order.products.length }} Ürün</p>
                                    <p class="text-sm text-muted-foreground">Toplam: {{ formatPrice(order.total) }}</p>
                                </div>
                                <div class="flex items-center space-x-2">
                                    <router-link
                                        :to="{
                                            name: 'customer-order-track',
                                            params: { id: order.id },
                                        }"
                                        v-if="order.status === 'shipped'"
                                        class="px-4 py-2 bg-primary/10 text-primary rounded-md hover:bg-primary/20 transition-colors"
                                    >
                                        Kargo Takip
                                    </router-link>
                                    <router-link
                                        :to="{
                                            name: 'customer-order-return',
                                            params: { id: order.id },
                                        }"
                                        v-if="order.status === 'delivered' && !order.isReturnExpired"
                                        class="px-4 py-2 bg-destructive/10 text-destructive rounded-md hover:bg-destructive/20 transition-colors"
                                    >
                                        İade Et
                                    </router-link>
                                    <router-link
                                        :to="{
                                            name: 'customer-order-detail',
                                            params: { id: order.id },
                                        }"
                                        class="px-4 py-2 bg-card text-card-foreground border border-input rounded-md hover:bg-accent transition-colors"
                                    >
                                        Detaylar
                                    </router-link>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Sipariş Bulunamadı -->
        <div v-if="filteredOrders.length === 0" class="text-center py-12">
            <div class="w-16 h-16 mx-auto mb-4 rounded-full bg-primary/10 flex items-center justify-center">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary w-8 h-8">
                    <path d="M9 17H7A5 5 0 0 1 7 7h2" />
                    <path d="M15 7h2a5 5 0 1 1 0 10h-2" />
                    <line x1="8" x2="16" y1="12" y2="12" />
                </svg>
            </div>
            <h3 class="text-xl font-semibold text-card-foreground">Sipariş Bulunamadı</h3>
            <p class="text-muted-foreground mt-2">Seçili filtrelerle eşleşen sipariş bulunmamaktadır.</p>
        </div>

        <!-- Sayfalama -->
        <div v-if="filteredOrders.length > 0" class="mt-6 flex justify-center">
            <nav class="flex items-center space-x-2">
                <button class="p-2 rounded-md hover:bg-accent disabled:opacity-50" :disabled="currentPage === 1">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-5 h-5">
                        <path d="m15 18-6-6 6-6" />
                    </svg>
                </button>
                <span class="text-sm text-muted-foreground">Sayfa {{ currentPage }} / {{ totalPages }}</span>
                <button class="p-2 rounded-md hover:bg-accent disabled:opacity-50" :disabled="currentPage === totalPages">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-5 h-5">
                        <path d="m9 18 6-6-6-6" />
                    </svg>
                </button>
            </nav>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

interface Product {
    id: number;
    name: string;
    image: string;
}

interface Order {
    id: number;
    orderNumber: string;
    date: string;
    status: "processing" | "shipped" | "delivered" | "cancelled" | "returned";
    products: Product[];
    total: number;
    isReturnExpired: boolean;
}

interface Filters {
    status: string;
    dateRange: string;
    search: string;
}

export default defineComponent({
    name: "OrdersView",
    data() {
        return {
            currentPage: 1,
            totalPages: 5,
            filters: {
                status: "",
                dateRange: "last30",
                search: "",
            } as Filters,
            orders: [
                {
                    id: 1,
                    orderNumber: "ORD-2024-001",
                    date: "2024-01-15",
                    status: "processing",
                    products: [
                        { id: 1, name: "Ürün 1", image: "https://picsum.photos/200/200?random=1" },
                        { id: 2, name: "Ürün 2", image: "https://picsum.photos/200/200?random=2" },
                        { id: 3, name: "Ürün 3", image: "https://picsum.photos/200/200?random=3" },
                        { id: 4, name: "Ürün 4", image: "https://picsum.photos/200/200?random=4" },
                    ],
                    total: 1250.9,
                    isReturnExpired: false,
                },
                {
                    id: 2,
                    orderNumber: "ORD-2024-002",
                    date: "2024-01-10",
                    status: "shipped",
                    products: [
                        { id: 5, name: "Ürün 5", image: "https://picsum.photos/200/200?random=5" },
                        { id: 6, name: "Ürün 6", image: "https://picsum.photos/200/200?random=6" },
                    ],
                    total: 450.0,
                    isReturnExpired: false,
                },
                {
                    id: 3,
                    orderNumber: "ORD-2024-003",
                    date: "2024-01-05",
                    status: "delivered",
                    products: [{ id: 7, name: "Ürün 7", image: "https://picsum.photos/200/200?random=7" }],
                    total: 199.9,
                    isReturnExpired: false,
                },
            ] as Order[],
        };
    },
    computed: {
        filteredOrders(): Order[] {
            return this.orders.filter((order) => {
                if (this.filters.status && order.status !== this.filters.status) return false;
                if (this.filters.search) {
                    const searchLower = this.filters.search.toLowerCase();
                    const matchesOrderNumber = order.orderNumber.toLowerCase().includes(searchLower);
                    const matchesProducts = order.products.some((product) => product.name.toLowerCase().includes(searchLower));
                    if (!matchesOrderNumber && !matchesProducts) return false;
                }
                return true;
            });
        },
    },
    methods: {
        getStatusText(status: string): string {
            const statusMap: { [key: string]: string } = {
                processing: "İşleme Alındı",
                shipped: "Kargoya Verildi",
                delivered: "Teslim Edildi",
                cancelled: "İptal Edildi",
                returned: "İade Edildi",
            };
            return statusMap[status] || status;
        },
        formatPrice(price: number): string {
            return new Intl.NumberFormat("tr-TR", {
                style: "currency",
                currency: "TRY",
            }).format(price);
        },
    },
});
</script>
