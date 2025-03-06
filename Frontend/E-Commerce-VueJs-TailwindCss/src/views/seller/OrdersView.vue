<template>
    <div class="seller-orders">
        <!-- Üst Başlık -->
        <div class="flex items-center justify-between mb-6">
            <h1 class="text-2xl font-bold">Siparişler</h1>
        </div>

        <!-- Filtreler -->
        <div class="bg-card rounded-lg border border-border p-6 mb-6">
            <div class="flex flex-wrap gap-4">
                <!-- Arama -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">
                        Sipariş Ara
                    </label>
                    <div class="relative">
                        <input
                            v-model="filters.search"
                            type="text"
                            placeholder="Sipariş no veya müşteri adı"
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

                <!-- Durum -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">
                        Sipariş Durumu
                    </label>
                    <select
                        v-model="filters.status"
                        class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50"
                    >
                        <option value="">Tümü</option>
                        <option value="processing">İşleme Alındı</option>
                        <option value="shipped">Kargoya Verildi</option>
                        <option value="delivered">Teslim Edildi</option>
                        <option value="cancelled">İptal Edildi</option>
                        <option value="returned">İade Edildi</option>
                    </select>
                </div>

                <!-- Tarih Aralığı -->
                <div class="flex-1 min-w-[200px]">
                    <label class="text-sm font-medium text-card-foreground mb-2 block">
                        Tarih Aralığı
                    </label>
                    <select
                        v-model="filters.dateRange"
                        class="w-full px-3 py-2 bg-background border border-input rounded-md focus:outline-none focus:ring-2 focus:ring-primary/50"
                    >
                        <option value="all">Tüm Zamanlar</option>
                        <option value="today">Bugün</option>
                        <option value="yesterday">Dün</option>
                        <option value="last7days">Son 7 Gün</option>
                        <option value="last30days">Son 30 Gün</option>
                        <option value="thisMonth">Bu Ay</option>
                        <option value="lastMonth">Geçen Ay</option>
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
                        <option value="price_asc">Tutar (Artan)</option>
                        <option value="price_desc">Tutar (Azalan)</option>
                    </select>
                </div>
            </div>
        </div>

        <!-- Sipariş Listesi -->
        <div class="bg-card rounded-lg border border-border overflow-hidden">
            <div class="overflow-x-auto">
                <table class="w-full">
                    <thead>
                        <tr class="border-b border-border">
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Sipariş No
                            </th>
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Müşteri
                            </th>
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Tarih
                            </th>
                            <th
                                class="text-left py-3 px-4 text-sm font-medium text-muted-foreground"
                            >
                                Tutar
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
                            v-for="order in filteredOrders"
                            :key="order.id"
                            class="border-b border-border last:border-0"
                        >
                            <td class="py-3 px-4">
                                <span class="text-sm font-medium">#{{ order.orderNumber }}</span>
                            </td>
                            <td class="py-3 px-4">
                                <div class="flex items-center space-x-3">
                                    <div>
                                        <p class="text-sm font-medium">{{ order.customer.name }}</p>
                                        <p class="text-xs text-muted-foreground">
                                            {{ order.customer.email }}
                                        </p>
                                    </div>
                                </div>
                            </td>
                            <td class="py-3 px-4">
                                <span class="text-sm text-muted-foreground">{{ order.date }}</span>
                            </td>
                            <td class="py-3 px-4">
                                <span class="text-sm font-medium">{{
                                    formatPrice(order.total)
                                }}</span>
                            </td>
                            <td class="py-3 px-4">
                                <span
                                    :class="[
                                        'inline-flex items-center rounded-full px-2 py-1 text-xs font-medium',
                                        {
                                            'bg-blue-100 text-blue-700':
                                                order.status === 'processing',
                                            'bg-yellow-100 text-yellow-700':
                                                order.status === 'shipped',
                                            'bg-green-100 text-green-700':
                                                order.status === 'delivered',
                                            'bg-red-100 text-red-700': order.status === 'cancelled',
                                            'bg-orange-100 text-orange-700':
                                                order.status === 'returned',
                                        },
                                    ]"
                                >
                                    {{ getStatusText(order.status) }}
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
                                            <path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z" />
                                            <path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z" />
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
                                            <path
                                                d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z"
                                            />
                                            <path d="m15 5 4 4" />
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

interface Customer {
    name: string
    email: string
}

interface Order {
    id: number
    orderNumber: string
    customer: Customer
    date: string
    total: number
    status: 'processing' | 'shipped' | 'delivered' | 'cancelled' | 'returned'
}

interface Filters {
    search: string
    status: string
    dateRange: string
    sort: string
}

export default defineComponent({
    name: 'OrdersView',
    data() {
        return {
            currentPage: 1,
            totalPages: 5,
            filters: {
                search: '',
                status: '',
                dateRange: 'last30days',
                sort: 'newest',
            } as Filters,
            orders: [
                {
                    id: 1,
                    orderNumber: 'ORD-2024-001',
                    customer: {
                        name: 'Ahmet Yılmaz',
                        email: 'ahmet@example.com',
                    },
                    date: '15.01.2024',
                    total: 1250.9,
                    status: 'processing',
                },
                {
                    id: 2,
                    orderNumber: 'ORD-2024-002',
                    customer: {
                        name: 'Mehmet Demir',
                        email: 'mehmet@example.com',
                    },
                    date: '15.01.2024',
                    total: 890.0,
                    status: 'shipped',
                },
                {
                    id: 3,
                    orderNumber: 'ORD-2024-003',
                    customer: {
                        name: 'Ayşe Kaya',
                        email: 'ayse@example.com',
                    },
                    date: '14.01.2024',
                    total: 225.5,
                    status: 'delivered',
                },
                {
                    id: 4,
                    orderNumber: 'ORD-2024-004',
                    customer: {
                        name: 'Fatma Şahin',
                        email: 'fatma@example.com',
                    },
                    date: '14.01.2024',
                    total: 1250.0,
                    status: 'delivered',
                },
                {
                    id: 5,
                    orderNumber: 'ORD-2024-005',
                    customer: {
                        name: 'Ali Öztürk',
                        email: 'ali@example.com',
                    },
                    date: '13.01.2024',
                    total: 780.3,
                    status: 'cancelled',
                },
            ] as Order[],
        }
    },
    computed: {
        filteredOrders(): Order[] {
            return this.orders
                .filter((order) => {
                    if (this.filters.search) {
                        const searchLower = this.filters.search.toLowerCase()
                        const matchesOrderNumber = order.orderNumber
                            .toLowerCase()
                            .includes(searchLower)
                        const matchesCustomer = order.customer.name
                            .toLowerCase()
                            .includes(searchLower)
                        if (!matchesOrderNumber && !matchesCustomer) return false
                    }

                    if (this.filters.status && order.status !== this.filters.status) {
                        return false
                    }

                    // TODO: Tarih filtresi uygulanacak

                    return true
                })
                .sort((a, b) => {
                    switch (this.filters.sort) {
                        case 'oldest':
                            return a.id - b.id
                        case 'price_asc':
                            return a.total - b.total
                        case 'price_desc':
                            return b.total - a.total
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
                processing: 'İşleme Alındı',
                shipped: 'Kargoya Verildi',
                delivered: 'Teslim Edildi',
                cancelled: 'İptal Edildi',
                returned: 'İade Edildi',
            }
            return statusMap[status] || status
        },
    },
})
</script>
