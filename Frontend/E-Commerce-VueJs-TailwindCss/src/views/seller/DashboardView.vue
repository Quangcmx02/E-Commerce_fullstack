<template>
    <div class="space-y-6">
        <div>
            <h1 class="text-3xl font-bold tracking-tight">Dashboard</h1>
            <p class="text-muted-foreground">Mağazanızın genel durumunu buradan takip edebilirsiniz.</p>
        </div>

        <!-- İstatistikler -->
        <div class="grid gap-4 md:grid-cols-4">
            <!-- Toplam Satış -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Satış</p>
                        <h3 class="text-2xl font-bold mt-1">₺24,890.50</h3>
                    </div>
                    <div class="w-12 h-12 bg-primary/10 rounded-full flex items-center justify-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-6 h-6 text-primary">
                            <circle cx="12" cy="12" r="8" />
                            <path d="M14.5 9h-2.5a2 2 0 1 0 0 4h2a2 2 0 1 1 0 4h-3" />
                            <path d="M12 7v2" />
                            <path d="M12 15v2" />
                        </svg>
                    </div>
                </div>
                <div class="mt-4 flex items-center space-x-2 text-sm">
                    <span class="text-green-500 flex items-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-4 h-4 mr-1">
                            <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                            <polyline points="16 7 22 7 22 13" />
                        </svg>
                        12.5%
                    </span>
                    <span class="text-muted-foreground">Geçen aya göre</span>
                </div>
            </div>

            <!-- Toplam Sipariş -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Sipariş</p>
                        <h3 class="text-2xl font-bold mt-1">156</h3>
                    </div>
                    <div class="w-12 h-12 bg-primary/10 rounded-full flex items-center justify-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-6 h-6 text-primary">
                            <path d="M6 2 3 6v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V6l-3-4Z" />
                            <path d="M3 6h18" />
                            <path d="M16 10a4 4 0 0 1-8 0" />
                        </svg>
                    </div>
                </div>
                <div class="mt-4 flex items-center space-x-2 text-sm">
                    <span class="text-green-500 flex items-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-4 h-4 mr-1">
                            <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                            <polyline points="16 7 22 7 22 13" />
                        </svg>
                        8.2%
                    </span>
                    <span class="text-muted-foreground">Geçen aya göre</span>
                </div>
            </div>

            <!-- Toplam Müşteri -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Müşteri</p>
                        <h3 class="text-2xl font-bold mt-1">2,845</h3>
                    </div>
                    <div class="w-12 h-12 bg-primary/10 rounded-full flex items-center justify-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-6 h-6 text-primary">
                            <path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2" />
                            <circle cx="9" cy="7" r="4" />
                            <path d="M22 21v-2a4 4 0 0 0-3-3.87" />
                            <path d="M16 3.13a4 4 0 0 1 0 7.75" />
                        </svg>
                    </div>
                </div>
                <div class="mt-4 flex items-center space-x-2 text-sm">
                    <span class="text-green-500 flex items-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-4 h-4 mr-1">
                            <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                            <polyline points="16 7 22 7 22 13" />
                        </svg>
                        5.8%
                    </span>
                    <span class="text-muted-foreground">Geçen aya göre</span>
                </div>
            </div>

            <!-- Toplam Ürün -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Ürün</p>
                        <h3 class="text-2xl font-bold mt-1">486</h3>
                    </div>
                    <div class="w-12 h-12 bg-primary/10 rounded-full flex items-center justify-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-6 h-6 text-primary">
                            <path d="m7.5 4.27 9 5.15" />
                            <path d="M21 8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16Z" />
                            <path d="m3.3 7 8.7 5 8.7-5" />
                            <path d="M12 22V12" />
                        </svg>
                    </div>
                </div>
                <div class="mt-4 flex items-center space-x-2 text-sm">
                    <span class="text-red-500 flex items-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-4 h-4 mr-1">
                            <polyline points="22 17 13.5 8.5 8.5 13.5 2 7" />
                            <polyline points="16 17 22 17 22 11" />
                        </svg>
                        2.3%
                    </span>
                    <span class="text-muted-foreground">Geçen aya göre</span>
                </div>
            </div>
        </div>

        <!-- Son Siparişler -->
        <div class="mt-6">
            <div class="flex items-center justify-between mb-4">
                <h2 class="text-lg font-semibold">Son Siparişler</h2>
                <router-link :to="{ name: 'seller-orders' }" class="text-sm text-primary hover:underline">Tümünü Gör</router-link>
            </div>
            <div class="bg-card rounded-lg border border-border">
                <div class="relative w-full overflow-auto">
                    <table class="w-full caption-bottom text-sm">
                        <thead class="[&_tr]:border-b">
                            <tr class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted">
                                <th class="h-12 px-4 text-left align-middle font-medium text-muted-foreground">Sipariş No</th>
                                <th class="h-12 px-4 text-left align-middle font-medium text-muted-foreground">Müşteri</th>
                                <th class="h-12 px-4 text-left align-middle font-medium text-muted-foreground">Tutar</th>
                                <th class="h-12 px-4 text-left align-middle font-medium text-muted-foreground">Durum</th>
                                <th class="h-12 px-4 text-left align-middle font-medium text-muted-foreground">Tarih</th>
                            </tr>
                        </thead>
                        <tbody class="[&_tr:last-child]:border-0">
                            <tr v-for="order in recentOrders" :key="order.id" class="border-b transition-colors hover:bg-muted/50 data-[state=selected]:bg-muted">
                                <td class="p-4 align-middle">
                                    <router-link
                                        :to="{
                                            name: 'seller-order-detail',
                                            params: { id: order.id },
                                        }"
                                        class="font-medium hover:underline"
                                    >
                                        #{{ order.number }}
                                    </router-link>
                                </td>
                                <td class="p-4 align-middle">
                                    <div class="flex items-center space-x-2">
                                        <img :src="order.customer.avatar" :alt="order.customer.name" class="w-8 h-8 rounded-full" />
                                        <span>{{ order.customer.name }}</span>
                                    </div>
                                </td>
                                <td class="p-4 align-middle">
                                    {{ formatPrice(order.total) }}
                                </td>
                                <td class="p-4 align-middle">
                                    <span
                                        :class="[
                                            'inline-flex items-center rounded-full px-2 py-1 text-xs font-medium',
                                            {
                                                'bg-green-100 text-green-700': order.status === 'completed',
                                                'bg-yellow-100 text-yellow-700': order.status === 'processing',
                                                'bg-red-100 text-red-700': order.status === 'cancelled',
                                            },
                                        ]"
                                    >
                                        {{ getStatusText(order.status) }}
                                    </span>
                                </td>
                                <td class="p-4 align-middle">
                                    {{ formatDate(order.date) }}
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";

interface Customer {
    id: number;
    name: string;
    avatar: string;
}

interface Order {
    id: number;
    number: string;
    customer: Customer;
    total: number;
    status: "completed" | "processing" | "cancelled";
    date: string;
}

export default defineComponent({
    name: "DashboardView",
    data() {
        return {
            recentOrders: [
                {
                    id: 1,
                    number: "ORD-001",
                    customer: {
                        id: 1,
                        name: "Ahmet Yılmaz",
                        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=Ahmet",
                    },
                    total: 1250.0,
                    status: "completed",
                    date: "2024-01-15T10:30:00",
                },
                {
                    id: 2,
                    number: "ORD-002",
                    customer: {
                        id: 2,
                        name: "Ayşe Demir",
                        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=Ayse",
                    },
                    total: 850.0,
                    status: "processing",
                    date: "2024-01-15T09:15:00",
                },
                {
                    id: 3,
                    number: "ORD-003",
                    customer: {
                        id: 3,
                        name: "Mehmet Kaya",
                        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=Mehmet",
                    },
                    total: 2100.0,
                    status: "completed",
                    date: "2024-01-14T16:45:00",
                },
                {
                    id: 4,
                    number: "ORD-004",
                    customer: {
                        id: 4,
                        name: "Zeynep Şahin",
                        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=Zeynep",
                    },
                    total: 450.0,
                    status: "cancelled",
                    date: "2024-01-14T14:20:00",
                },
                {
                    id: 5,
                    number: "ORD-005",
                    customer: {
                        id: 5,
                        name: "Ali Öztürk",
                        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=Ali",
                    },
                    total: 1750.0,
                    status: "processing",
                    date: "2024-01-14T11:10:00",
                },
            ] as Order[],
        };
    },
    methods: {
        formatPrice(price: number): string {
            return new Intl.NumberFormat("tr-TR", {
                style: "currency",
                currency: "TRY",
            }).format(price);
        },
        formatDate(date: string): string {
            return new Intl.DateTimeFormat("tr-TR", {
                dateStyle: "medium",
                timeStyle: "short",
            }).format(new Date(date));
        },
        getStatusText(status: string): string {
            const statusMap: { [key: string]: string } = {
                completed: "Tamamlandı",
                processing: "İşleniyor",
                cancelled: "İptal Edildi",
            };
            return statusMap[status] || status;
        },
    },
});
</script>
