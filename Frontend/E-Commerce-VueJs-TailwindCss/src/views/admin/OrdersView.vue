<template>
    <div class="space-y-6">
        <!-- Başlık ve Açıklama -->
        <div class="flex items-center justify-between">
            <div>
                <h1 class="text-3xl font-bold tracking-tight">Sipariş Yönetimi</h1>
                <p class="text-muted-foreground">Platformdaki tüm siparişleri buradan yönetebilirsiniz.</p>
            </div>
            <button class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                    <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"/>
                    <polyline points="17 8 12 3 7 8"/>
                    <line x1="12" y1="3" x2="12" y2="15"/>
                </svg>
                Sipariş Dışa Aktar
            </button>
        </div>

        <!-- İstatistik Kartları -->
        <div class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
            <!-- Toplam Sipariş -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Sipariş</p>
                        <h2 class="mt-2 text-3xl font-bold">12.5K</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            15% artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M6 2 3 6v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V6l-3-4Z"/>
                            <path d="M3 6h18"/>
                            <path d="M16 10a4 4 0 0 1-8 0"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Toplam Gelir -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Gelir</p>
                        <h2 class="mt-2 text-3xl font-bold">₺2.4M</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            12% artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <line x1="12" y1="1" x2="12" y2="23"/>
                            <path d="M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Ortalama Sipariş Değeri -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Ort. Sipariş Değeri</p>
                        <h2 class="mt-2 text-3xl font-bold">₺192</h2>
                        <p class="mt-1 flex items-center text-red-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 17 13.5 8.5 8.5 13.5 2 7" />
                                <polyline points="16 17 22 17 22 11" />
                            </svg>
                            3% azalış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <rect x="2" y="3" width="20" height="14" rx="2"/>
                            <line x1="2" y1="7" x2="22" y2="7"/>
                            <line x1="12" y1="21" x2="12" y2="17"/>
                            <line x1="8" y1="21" x2="16" y2="21"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- İade Oranı -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">İade Oranı</p>
                        <h2 class="mt-2 text-3xl font-bold">2.4%</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            0.5% iyileşme
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="m21.5 12-9 9-9-9M21.5 5l-9 9-9-9"/>
                        </svg>
                    </div>
                </div>
            </div>
        </div>

        <!-- Filtreler ve Arama -->
        <div class="flex flex-col gap-4 rounded-lg border bg-card p-4 md:flex-row md:items-center md:justify-between">
            <div class="flex flex-1 flex-col gap-4 md:flex-row md:items-center">
                <!-- Arama -->
                <div class="relative flex-1">
                    <input
                        type="text"
                        placeholder="Sipariş ID, müşteri adı veya e-posta ara..."
                        v-model="searchQuery"
                        class="h-9 w-full rounded-md border bg-background px-3 pl-9 text-sm placeholder:text-muted-foreground focus:outline-none focus:ring-2 focus:ring-primary"
                    />
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute left-3 top-1/2 -translate-y-1/2 text-muted-foreground">
                        <circle cx="11" cy="11" r="8" />
                        <path d="m21 21-4.3-4.3" />
                    </svg>
                </div>

                <!-- Durum Filtresi -->
                <select v-model="selectedStatus" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="">Tüm Durumlar</option>
                    <option value="pending">Beklemede</option>
                    <option value="processing">İşleniyor</option>
                    <option value="shipped">Kargoda</option>
                    <option value="delivered">Teslim Edildi</option>
                    <option value="cancelled">İptal Edildi</option>
                    <option value="refunded">İade Edildi</option>
                </select>

                <!-- Ödeme Durumu -->
                <select v-model="selectedPayment" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="">Tüm Ödemeler</option>
                    <option value="paid">Ödendi</option>
                    <option value="pending">Beklemede</option>
                    <option value="failed">Başarısız</option>
                    <option value="refunded">İade Edildi</option>
                </select>

                <!-- Tarih Aralığı -->
                <select v-model="dateRange" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="today">Bugün</option>
                    <option value="yesterday">Dün</option>
                    <option value="last7days">Son 7 Gün</option>
                    <option value="last30days">Son 30 Gün</option>
                    <option value="thisMonth">Bu Ay</option>
                    <option value="lastMonth">Geçen Ay</option>
                    <option value="custom">Özel Aralık</option>
                </select>
            </div>

            <!-- Dışa Aktar -->
            <div class="flex items-center gap-2">
                <button class="inline-flex items-center justify-center rounded-md border bg-background px-3 py-2 text-sm font-medium shadow-sm hover:bg-accent">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" />
                        <polyline points="7 10 12 15 17 10" />
                        <line x1="12" x2="12" y1="15" y2="3" />
                    </svg>
                    Excel'e Aktar
                </button>
                <button class="inline-flex items-center justify-center rounded-md border bg-background px-3 py-2 text-sm font-medium shadow-sm hover:bg-accent">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" />
                        <polyline points="7 10 12 15 17 10" />
                        <line x1="12" x2="12" y1="15" y2="3" />
                    </svg>
                    PDF'e Aktar
                </button>
            </div>
        </div>

        <!-- Sipariş Tablosu -->
        <div class="rounded-lg border bg-card">
            <div class="relative overflow-x-auto">
                <table class="w-full text-left text-sm">
                    <thead class="bg-muted/50 text-xs uppercase">
                        <tr>
                            <th class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </th>
                            <th class="px-6 py-4">Sipariş ID</th>
                            <th class="px-6 py-4">Müşteri</th>
                            <th class="px-6 py-4">Tarih</th>
                            <th class="px-6 py-4">Tutar</th>
                            <th class="px-6 py-4">Ödeme</th>
                            <th class="px-6 py-4">Durum</th>
                            <th class="px-6 py-4">İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="order in filteredOrders" :key="order.id" class="border-b">
                            <td class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-3">
                                    <div>
                                        <p class="font-medium">#{{ order.id }}</p>
                                        <p class="text-xs text-muted-foreground">{{ order.items }} ürün</p>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-3">
                                    <img :src="order.customerAvatar" :alt="order.customerName" class="h-8 w-8 rounded-full" />
                                    <div>
                                        <p class="font-medium">{{ order.customerName }}</p>
                                        <p class="text-xs text-muted-foreground">{{ order.customerEmail }}</p>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4">
                                <div>
                                    <p class="font-medium">{{ order.date }}</p>
                                    <p class="text-xs text-muted-foreground">{{ order.time }}</p>
                                </div>
                            </td>
                            <td class="px-6 py-4">₺{{ order.amount }}</td>
                            <td class="px-6 py-4">
                                <span :class="[
                                    'rounded-full px-2 py-1 text-xs font-medium',
                                    order.payment === 'paid' ? 'bg-green-100 text-green-700' :
                                    order.payment === 'pending' ? 'bg-yellow-100 text-yellow-700' :
                                    order.payment === 'failed' ? 'bg-red-100 text-red-700' :
                                    'bg-blue-100 text-blue-700'
                                ]">
                                    {{ 
                                        order.payment === 'paid' ? 'Ödendi' :
                                        order.payment === 'pending' ? 'Beklemede' :
                                        order.payment === 'failed' ? 'Başarısız' :
                                        'İade Edildi'
                                    }}
                                </span>
                            </td>
                            <td class="px-6 py-4">
                                <span :class="[
                                    'rounded-full px-2 py-1 text-xs font-medium',
                                    order.status === 'pending' ? 'bg-yellow-100 text-yellow-700' :
                                    order.status === 'processing' ? 'bg-blue-100 text-blue-700' :
                                    order.status === 'shipped' ? 'bg-purple-100 text-purple-700' :
                                    order.status === 'delivered' ? 'bg-green-100 text-green-700' :
                                    order.status === 'cancelled' ? 'bg-red-100 text-red-700' :
                                    'bg-gray-100 text-gray-700'
                                ]">
                                    {{ 
                                        order.status === 'pending' ? 'Beklemede' :
                                        order.status === 'processing' ? 'İşleniyor' :
                                        order.status === 'shipped' ? 'Kargoda' :
                                        order.status === 'delivered' ? 'Teslim Edildi' :
                                        order.status === 'cancelled' ? 'İptal Edildi' :
                                        'İade Edildi'
                                    }}
                                </span>
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-2">
                                    <button class="rounded-md p-2 hover:bg-accent" title="Detaylar">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z" />
                                            <path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z" />
                                        </svg>
                                    </button>
                                    <button class="rounded-md p-2 hover:bg-accent" title="Düzenle">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z" />
                                            <path d="m15 5 4 4" />
                                        </svg>
                                    </button>
                                    <button class="rounded-md p-2 text-red-500 hover:bg-accent" title="İptal Et">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <circle cx="12" cy="12" r="10"/>
                                            <line x1="15" y1="9" x2="9" y2="15"/>
                                            <line x1="9" y1="9" x2="15" y2="15"/>
                                        </svg>
                                    </button>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <!-- Pagination -->
            <div class="flex items-center justify-between border-t px-6 py-4">
                <div class="text-sm text-muted-foreground">
                    Toplam <span class="font-medium">{{ totalOrders }}</span> siparişten <span class="font-medium">1-10</span> arası gösteriliyor
                </div>
                <div class="flex items-center gap-2">
                    <button class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent disabled:opacity-50" :disabled="currentPage === 1">
                        Önceki
                    </button>
                    <div class="flex items-center gap-1">
                        <button v-for="page in totalPages" :key="page" class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent" :class="{ 'bg-primary text-primary-foreground': currentPage === page }">
                            {{ page }}
                        </button>
                    </div>
                    <button class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent disabled:opacity-50" :disabled="currentPage === totalPages">
                        Sonraki
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

// Durum değişkenleri
const searchQuery = ref('')
const selectedStatus = ref('')
const selectedPayment = ref('')
const dateRange = ref('last7days')
const currentPage = ref(1)

// Örnek sipariş verileri
const orders = [
    {
        id: "ORD-2024-001",
        items: 3,
        customerName: "Ahmet Yılmaz",
        customerEmail: "ahmet@example.com",
        customerAvatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=1",
        date: "15 Ocak 2024",
        time: "14:30",
        amount: "1,250",
        payment: "paid",
        status: "delivered"
    },
    {
        id: "ORD-2024-002",
        items: 1,
        customerName: "Ayşe Demir",
        customerEmail: "ayse@example.com",
        customerAvatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=2",
        date: "15 Ocak 2024",
        time: "15:45",
        amount: "450",
        payment: "pending",
        status: "processing"
    },
    {
        id: "ORD-2024-003",
        items: 2,
        customerName: "Mehmet Kaya",
        customerEmail: "mehmet@example.com",
        customerAvatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=3",
        date: "15 Ocak 2024",
        time: "16:20",
        amount: "850",
        payment: "paid",
        status: "shipped"
    },
    {
        id: "ORD-2024-004",
        items: 4,
        customerName: "Zeynep Şahin",
        customerEmail: "zeynep@example.com",
        customerAvatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=4",
        date: "15 Ocak 2024",
        time: "17:10",
        amount: "2,150",
        payment: "failed",
        status: "cancelled"
    },
    {
        id: "ORD-2024-005",
        items: 2,
        customerName: "Ali Öztürk",
        customerEmail: "ali@example.com",
        customerAvatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=5",
        date: "15 Ocak 2024",
        time: "18:00",
        amount: "750",
        payment: "refunded",
        status: "refunded"
    }
]

// Hesaplanan özellikler
const filteredOrders = computed(() => {
    let result = [...orders]

    // Arama filtresi
    if (searchQuery.value) {
        const query = searchQuery.value.toLowerCase()
        result = result.filter(order =>
            order.id.toLowerCase().includes(query) ||
            order.customerName.toLowerCase().includes(query) ||
            order.customerEmail.toLowerCase().includes(query)
        )
    }

    // Durum filtresi
    if (selectedStatus.value) {
        result = result.filter(order => order.status === selectedStatus.value)
    }

    // Ödeme durumu filtresi
    if (selectedPayment.value) {
        result = result.filter(order => order.payment === selectedPayment.value)
    }

    // Tarih filtresi (gerçek uygulamada implement edilmeli)
    // ...

    return result
})

const totalOrders = computed(() => filteredOrders.value.length)
const totalPages = computed(() => Math.ceil(totalOrders.value / 10))
</script> 