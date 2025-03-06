<template>
    <div class="space-y-6">
        <!-- Başlık ve Açıklama -->
        <div class="flex items-center justify-between">
            <div>
                <h1 class="text-3xl font-bold tracking-tight">Raporlar & Analitik</h1>
                <p class="text-muted-foreground">Platform performansını ve istatistiklerini detaylı olarak görüntüleyin.</p>
            </div>
            <div class="flex items-center gap-2">
                <select v-model="dateRange" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="today">Bugün</option>
                    <option value="yesterday">Dün</option>
                    <option value="last7days">Son 7 Gün</option>
                    <option value="last30days">Son 30 Gün</option>
                    <option value="thisMonth">Bu Ay</option>
                    <option value="lastMonth">Geçen Ay</option>
                    <option value="custom">Özel Aralık</option>
                </select>
                <button class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"/>
                        <polyline points="7 10 12 15 17 10"/>
                        <line x1="12" y1="15" x2="12" y2="3"/>
                    </svg>
                    Rapor İndir
                </button>
            </div>
        </div>

        <!-- Özet İstatistikler -->
        <div class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
            <!-- Toplam Satış -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Satış</p>
                        <h2 class="mt-2 text-3xl font-bold">₺458.2K</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            18% artış
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

            <!-- Toplam Sipariş -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Sipariş</p>
                        <h2 class="mt-2 text-3xl font-bold">2.4K</h2>
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
                            <path d="M6 2 3 6v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V6l-3-4Z"/>
                            <path d="M3 6h18"/>
                            <path d="M16 10a4 4 0 0 1-8 0"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Yeni Müşteriler -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Yeni Müşteriler</p>
                        <h2 class="mt-2 text-3xl font-bold">892</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            25% artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"/>
                            <circle cx="9" cy="7" r="4"/>
                            <path d="M22 21v-2a4 4 0 0 0-3-3.87"/>
                            <path d="M16 3.13a4 4 0 0 1 0 7.75"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Ortalama Sepet -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Ortalama Sepet</p>
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
                            <circle cx="8" cy="21" r="1"/>
                            <circle cx="19" cy="21" r="1"/>
                            <path d="M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12"/>
                        </svg>
                    </div>
                </div>
            </div>
        </div>

        <!-- Grafik ve Analiz Bölümü -->
        <div class="grid gap-6 lg:grid-cols-2">
            <!-- Satış Grafiği -->
            <div class="rounded-xl border bg-card p-6">
                <div class="mb-4 flex items-center justify-between">
                    <h3 class="text-lg font-medium">Satış Grafiği</h3>
                    <select v-model="salesChartType" class="h-8 rounded-md border bg-background px-2 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                        <option value="daily">Günlük</option>
                        <option value="weekly">Haftalık</option>
                        <option value="monthly">Aylık</option>
                    </select>
                </div>
                <div class="h-80 w-full">
                    <!-- Grafik Komponenti Buraya Gelecek -->
                    <div class="flex h-full items-center justify-center text-muted-foreground">
                        Satış grafiği burada görüntülenecek
                    </div>
                </div>
            </div>

            <!-- Kategori Dağılımı -->
            <div class="rounded-xl border bg-card p-6">
                <div class="mb-4 flex items-center justify-between">
                    <h3 class="text-lg font-medium">Kategori Dağılımı</h3>
                    <select v-model="categoryChartMetric" class="h-8 rounded-md border bg-background px-2 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                        <option value="sales">Satış</option>
                        <option value="orders">Sipariş</option>
                        <option value="revenue">Gelir</option>
                    </select>
                </div>
                <div class="h-80 w-full">
                    <!-- Pasta Grafik Komponenti Buraya Gelecek -->
                    <div class="flex h-full items-center justify-center text-muted-foreground">
                        Kategori dağılım grafiği burada görüntülenecek
                    </div>
                </div>
            </div>
        </div>

        <!-- Detaylı Raporlar -->
        <div class="grid gap-6 lg:grid-cols-3">
            <!-- En Çok Satan Ürünler -->
            <div class="rounded-xl border bg-card p-6">
                <h3 class="mb-4 text-lg font-medium">En Çok Satan Ürünler</h3>
                <div class="space-y-4">
                    <div v-for="product in topProducts" :key="product.id" class="flex items-center gap-3">
                        <img :src="product.image" :alt="product.name" class="h-12 w-12 rounded-lg object-cover" />
                        <div class="flex-1">
                            <p class="font-medium">{{ product.name }}</p>
                            <p class="text-sm text-muted-foreground">{{ product.sales }} satış</p>
                        </div>
                        <div class="text-right">
                            <p class="font-medium">₺{{ product.revenue }}</p>
                            <p class="text-sm text-green-500">+{{ product.growth }}%</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- En İyi Satıcılar -->
            <div class="rounded-xl border bg-card p-6">
                <h3 class="mb-4 text-lg font-medium">En İyi Satıcılar</h3>
                <div class="space-y-4">
                    <div v-for="seller in topSellers" :key="seller.id" class="flex items-center gap-3">
                        <img :src="seller.avatar" :alt="seller.name" class="h-12 w-12 rounded-full object-cover" />
                        <div class="flex-1">
                            <p class="font-medium">{{ seller.name }}</p>
                            <p class="text-sm text-muted-foreground">{{ seller.orders }} sipariş</p>
                        </div>
                        <div class="text-right">
                            <p class="font-medium">₺{{ seller.revenue }}</p>
                            <p class="text-sm text-green-500">+{{ seller.growth }}%</p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Müşteri Memnuniyeti -->
            <div class="rounded-xl border bg-card p-6">
                <h3 class="mb-4 text-lg font-medium">Müşteri Memnuniyeti</h3>
                <div class="space-y-4">
                    <div v-for="metric in satisfactionMetrics" :key="metric.id" class="space-y-2">
                        <div class="flex items-center justify-between">
                            <p class="text-sm font-medium">{{ metric.name }}</p>
                            <p class="text-sm font-medium">{{ metric.value }}%</p>
                        </div>
                        <div class="h-2 rounded-full bg-muted">
                            <div
                                class="h-2 rounded-full bg-primary transition-all"
                                :style="{ width: `${metric.value}%` }"
                                :class="{
                                    'bg-green-500': metric.value >= 80,
                                    'bg-yellow-500': metric.value >= 60 && metric.value < 80,
                                    'bg-red-500': metric.value < 60
                                }"
                            ></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

// Durum değişkenleri
const dateRange = ref('last30days')
const salesChartType = ref('daily')
const categoryChartMetric = ref('sales')

// Örnek veriler
const topProducts = [
    {
        id: 1,
        name: "Kablosuz Kulaklık",
        image: "https://picsum.photos/200",
        sales: 245,
        revenue: "12,450",
        growth: 15
    },
    {
        id: 2,
        name: "Akıllı Saat",
        image: "https://picsum.photos/201",
        sales: 189,
        revenue: "9,450",
        growth: 12
    },
    {
        id: 3,
        name: "Tablet",
        image: "https://picsum.photos/202",
        sales: 156,
        revenue: "7,800",
        growth: 8
    }
]

const topSellers = [
    {
        id: 1,
        name: "Elektronik Market",
        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=1",
        orders: 456,
        revenue: "45,600",
        growth: 25
    },
    {
        id: 2,
        name: "Spor Mağazası",
        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=2",
        orders: 342,
        revenue: "34,200",
        growth: 18
    },
    {
        id: 3,
        name: "Kitap Dükkanı",
        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=3",
        orders: 289,
        revenue: "28,900",
        growth: 15
    }
]

const satisfactionMetrics = [
    {
        id: 1,
        name: "Genel Memnuniyet",
        value: 85
    },
    {
        id: 2,
        name: "Teslimat Memnuniyeti",
        value: 78
    },
    {
        id: 3,
        name: "Ürün Kalitesi",
        value: 92
    },
    {
        id: 4,
        name: "Müşteri Hizmetleri",
        value: 88
    }
]
</script> 