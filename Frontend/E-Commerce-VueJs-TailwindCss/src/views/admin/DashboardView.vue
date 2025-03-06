<template>
    <div class="space-y-6">
        <!-- Başlık -->
        <div>
            <h1 class="text-3xl font-bold tracking-tight">Dashboard</h1>
            <p class="text-muted-foreground">Platformun genel durumunu buradan takip edebilirsiniz.</p>
        </div>

        <!-- İstatistik Kartları -->
        <div class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
            <!-- Toplam Kullanıcı -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Kullanıcı</p>
                        <h2 class="mt-2 text-3xl font-bold">12.5K</h2>
                        <p class="mt-1 flex items-center text-sm text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            12% artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2" />
                            <circle cx="9" cy="7" r="4" />
                            <path d="M22 21v-2a4 4 0 0 0-3-3.87" />
                            <path d="M16 3.13a4 4 0 0 1 0 7.75" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Toplam Satış -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Satış</p>
                        <h2 class="mt-2 text-3xl font-bold">₺245.8K</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            8% artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M20.91 8.84 8.56 2.23a1.93 1.93 0 0 0-1.81 0L3.1 4.13a2.12 2.12 0 0 0-.05 3.69l12.22 6.93a2 2 0 0 0 1.94 0L21 12.51a2.12 2.12 0 0 0-.09-3.67Z" />
                            <path d="m3.09 8.84 12.35-6.61a1.93 1.93 0 0 1 1.81 0l3.65 1.9a2.12 2.12 0 0 1 .1 3.69L8.73 14.75a2 2 0 0 1-1.94 0L3 12.51a2.12 2.12 0 0 1 .09-3.67Z" />
                            <line x1="12" y1="22" x2="12" y2="13" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Aktif Satıcılar -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Aktif Satıcılar</p>
                        <h2 class="mt-2 text-3xl font-bold">1.2K</h2>
                        <p class="mt-1 flex items-center text-red-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 17 13.5 8.5 8.5 13.5 2 7" />
                                <polyline points="16 17 22 17 22 11" />
                            </svg>
                            3% düşüş
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M3 3v18h18" />
                            <path d="m19 9-5 5-4-4-3 3" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Toplam Ürün -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Ürün</p>
                        <h2 class="mt-2 text-3xl font-bold">8.4K</h2>
                        <p class="mt-1 flex items-center text-green-500">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                                <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                                <polyline points="16 7 22 7 22 13" />
                            </svg>
                            5% artış
                        </p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="m7.5 4.27 9 5.15" />
                            <path d="M21 8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16Z" />
                            <path d="m3.3 7 8.7 5 8.7-5" />
                            <path d="M12 22V12" />
                        </svg>
                    </div>
                </div>
            </div>
        </div>

        <!-- Grafikler -->
        <div class="grid gap-6 lg:grid-cols-2">
            <!-- Satış Grafiği -->
            <div class="rounded-xl border bg-card p-6">
                <div class="mb-4 flex items-center justify-between">
                    <h3 class="text-lg font-medium">Satış İstatistikleri</h3>
                    <select class="rounded-lg border bg-background px-2 py-1 text-sm">
                        <option>Son 7 Gün</option>
                        <option>Son 30 Gün</option>
                        <option>Son 3 Ay</option>
                        <option>Son 1 Yıl</option>
                    </select>
                </div>
                <div class="h-[300px]">
                    <!-- Grafik buraya gelecek -->
                </div>
            </div>

            <!-- En Çok Satan Ürünler -->
            <div class="rounded-xl border bg-card p-6">
                <div class="mb-4 flex items-center justify-between">
                    <h3 class="text-lg font-medium">En Çok Satan Ürünler</h3>
                    <select class="rounded-lg border bg-background px-2 py-1 text-sm">
                        <option>Son 7 Gün</option>
                        <option>Son 30 Gün</option>
                        <option>Son 3 Ay</option>
                        <option>Son 1 Yıl</option>
                    </select>
                </div>
                <div class="space-y-4">
                    <div v-for="product in topProducts" :key="product.id" class="flex items-center justify-between">
                        <div class="flex items-center space-x-4">
                            <img :src="product.image" :alt="product.name" class="h-12 w-12 rounded-lg object-cover" />
                            <div>
                                <h4 class="font-medium">{{ product.name }}</h4>
                                <p class="text-sm text-muted-foreground">{{ product.category }}</p>
                            </div>
                        </div>
                        <div class="text-right">
                            <p class="font-medium">{{ product.sales }} Satış</p>
                            <p class="text-sm text-muted-foreground">₺{{ product.revenue }}</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Son İşlemler -->
        <div class="rounded-xl border bg-card">
            <div class="border-b p-6">
                <h3 class="text-lg font-medium">Son İşlemler</h3>
            </div>
            <div class="p-6">
                <div class="relative overflow-x-auto">
                    <table class="w-full text-left text-sm">
                        <thead class="bg-muted/50 text-xs uppercase">
                            <tr>
                                <th class="px-6 py-3">İşlem ID</th>
                                <th class="px-6 py-3">Kullanıcı</th>
                                <th class="px-6 py-3">Tür</th>
                                <th class="px-6 py-3">Tutar</th>
                                <th class="px-6 py-3">Durum</th>
                                <th class="px-6 py-3">Tarih</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr v-for="transaction in recentTransactions" :key="transaction.id" class="border-b">
                                <td class="px-6 py-4">#{{ transaction.id }}</td>
                                <td class="px-6 py-4">{{ transaction.user }}</td>
                                <td class="px-6 py-4">{{ transaction.type }}</td>
                                <td class="px-6 py-4">₺{{ transaction.amount }}</td>
                                <td class="px-6 py-4">
                                    <span :class="['rounded-full px-2 py-1 text-xs font-medium', transaction.status === 'Başarılı' ? 'bg-green-100 text-green-700' : transaction.status === 'Beklemede' ? 'bg-yellow-100 text-yellow-700' : 'bg-red-100 text-red-700']">
                                        {{ transaction.status }}
                                    </span>
                                </td>
                                <td class="px-6 py-4">{{ transaction.date }}</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
// Örnek veriler
const topProducts = [
    {
        id: 1,
        name: "iPhone 14 Pro",
        category: "Elektronik",
        image: "https://example.com/iphone.jpg",
        sales: 245,
        revenue: "367.5K",
    },
    {
        id: 2,
        name: "MacBook Pro M2",
        category: "Elektronik",
        image: "https://example.com/macbook.jpg",
        sales: 189,
        revenue: "472.5K",
    },
    {
        id: 3,
        name: "AirPods Pro",
        category: "Elektronik",
        image: "https://example.com/airpods.jpg",
        sales: 312,
        revenue: "156K",
    },
    {
        id: 4,
        name: "iPad Air",
        category: "Elektronik",
        image: "https://example.com/ipad.jpg",
        sales: 156,
        revenue: "234K",
    },
];

const recentTransactions = [
    {
        id: "TR123456",
        user: "Ahmet Yılmaz",
        type: "Satış",
        amount: "1,250.00",
        status: "Başarılı",
        date: "2024-02-15 14:30",
    },
    {
        id: "TR123457",
        user: "Mehmet Demir",
        type: "İade",
        amount: "450.00",
        status: "Beklemede",
        date: "2024-02-15 13:45",
    },
    {
        id: "TR123458",
        user: "Ayşe Kaya",
        type: "Satış",
        amount: "2,750.00",
        status: "Başarılı",
        date: "2024-02-15 12:15",
    },
    {
        id: "TR123459",
        user: "Fatma Şahin",
        type: "Satış",
        amount: "890.00",
        status: "İptal",
        date: "2024-02-15 11:30",
    },
    {
        id: "TR123460",
        user: "Ali Öztürk",
        type: "Satış",
        amount: "1,890.00",
        status: "Başarılı",
        date: "2024-02-15 10:45",
    },
];
</script>
