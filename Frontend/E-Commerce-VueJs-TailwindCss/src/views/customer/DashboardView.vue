<template>
    <div class="space-y-6">
        <div>
            <h1 class="text-3xl font-bold tracking-tight">Dashboard</h1>
            <p class="text-muted-foreground">Hesabınızın genel durumunu buradan takip edebilirsiniz.</p>
        </div>

        <!-- İstatistik Kartları -->
        <div class="grid gap-6 md:grid-cols-2 lg:grid-cols-4 mb-8">
            <!-- Toplam Sipariş -->
            <div class="rounded-lg border bg-card p-6 hover:shadow-lg transition-shadow">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm text-muted-foreground">Toplam Sipariş</p>
                        <h3 class="mt-1 text-2xl font-bold">{{ stats.totalOrders }}</h3>
                        <p class="mt-1 text-xs text-green-500">Son 30 gün: {{ stats.lastMonthOrders }}</p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M6 2L3 6v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V6l-3-4z" />
                            <line x1="3" y1="6" x2="21" y2="6" />
                            <path d="M16 10a4 4 0 0 1-8 0" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Toplam Harcama -->
            <div class="rounded-lg border bg-card p-6 hover:shadow-lg transition-shadow">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm text-muted-foreground">Toplam Harcama</p>
                        <h3 class="mt-1 text-2xl font-bold">{{ stats.totalSpent }} TL</h3>
                        <p class="mt-1 text-xs text-green-500">Son 30 gün: {{ stats.lastMonthSpent }} TL</p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <line x1="12" y1="1" x2="12" y2="23" />
                            <path d="M17 5H9.5a3.5 3.5 0 0 0 0 7h5a3.5 3.5 0 0 1 0 7H6" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Favori Ürünler -->
            <div class="rounded-lg border bg-card p-6 hover:shadow-lg transition-shadow">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm text-muted-foreground">Favori Ürünler</p>
                        <h3 class="mt-1 text-2xl font-bold">{{ stats.favoriteProducts }}</h3>
                        <p class="mt-1 text-xs text-muted-foreground">Kayıtlı ürün</p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z" />
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Kayıtlı Adresler -->
            <div class="rounded-lg border bg-card p-6 hover:shadow-lg transition-shadow">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm text-muted-foreground">Kayıtlı Adresler</p>
                        <h3 class="mt-1 text-2xl font-bold">{{ stats.savedAddresses }}</h3>
                        <p class="mt-1 text-xs text-muted-foreground">Teslimat adresi</p>
                    </div>
                    <div class="rounded-full bg-primary/10 p-3 text-primary">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z" />
                            <circle cx="12" cy="10" r="3" />
                        </svg>
                    </div>
                </div>
            </div>
        </div>

        <!-- Son Siparişler ve Hızlı İşlemler -->
        <div class="grid gap-6 md:grid-cols-2">
            <!-- Son Siparişler -->
            <div class="rounded-lg border bg-card">
                <div class="p-6">
                    <h3 class="text-lg font-semibold mb-4">Son Siparişler</h3>
                    <div class="space-y-4">
                        <div v-for="order in recentOrders" :key="order.id" class="flex items-center justify-between p-4 rounded-lg border">
                            <div>
                                <p class="font-medium">Sipariş #{{ order.id }}</p>
                                <p class="text-sm text-muted-foreground">{{ order.date }}</p>
                            </div>
                            <div class="text-right">
                                <p class="font-medium">{{ order.total }} TL</p>
                                <p :class="['text-sm', order.status === 'Teslim Edildi' ? 'text-green-500' : 'text-orange-500']">
                                    {{ order.status }}
                                </p>
                            </div>
                        </div>
                    </div>
                    <div class="mt-4">
                        <router-link to="/customer/orders" class="text-primary hover:underline text-sm">Tüm Siparişleri Görüntüle →</router-link>
                    </div>
                </div>
            </div>

            <!-- Hızlı İşlemler -->
            <div class="rounded-lg border bg-card">
                <div class="p-6">
                    <h3 class="text-lg font-semibold mb-4">Hızlı İşlemler</h3>
                    <div class="grid grid-cols-2 gap-4">
                        <router-link to="/customer/profile" class="flex flex-col items-center p-4 rounded-lg border hover:bg-accent">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mb-2">
                                <path d="M20 21v-2a4 4 0 0 0-4-4H8a4 4 0 0 0-4 4v2" />
                                <circle cx="12" cy="7" r="4" />
                            </svg>
                            <span class="text-sm">Profili Düzenle</span>
                        </router-link>

                        <router-link to="/customer/addresses" class="flex flex-col items-center p-4 rounded-lg border hover:bg-accent">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mb-2">
                                <path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z" />
                                <circle cx="12" cy="10" r="3" />
                            </svg>
                            <span class="text-sm">Adresleri Yönet</span>
                        </router-link>

                        <router-link to="/customer/favorites" class="flex flex-col items-center p-4 rounded-lg border hover:bg-accent">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mb-2">
                                <path d="M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z" />
                            </svg>
                            <span class="text-sm">Favorilerim</span>
                        </router-link>

                        <router-link to="/customer/notifications" class="flex flex-col items-center p-4 rounded-lg border hover:bg-accent">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mb-2">
                                <path d="M6 8a6 6 0 0 1 12 0c0 7 3 9 3 9H3s3-2 3-9" />
                                <path d="M10.3 21a1.94 1.94 0 0 0 3.4 0" />
                            </svg>
                            <span class="text-sm">Bildirimler</span>
                        </router-link>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";

const user = ref({
    firstName: "Kullanıcı",
    lastName: "Soyad",
});

const stats = ref({
    totalOrders: 12,
    lastMonthOrders: 3,
    totalSpent: "2.459,90",
    lastMonthSpent: "899,90",
    favoriteProducts: 8,
    savedAddresses: 3,
});

const recentOrders = ref([
    {
        id: "1234",
        date: "15 Mart 2024",
        total: "459,90",
        status: "Teslim Edildi",
    },
    {
        id: "1233",
        date: "10 Mart 2024",
        total: "299,90",
        status: "Kargoda",
    },
    {
        id: "1232",
        date: "5 Mart 2024",
        total: "749,90",
        status: "Teslim Edildi",
    },
]);

onMounted(async () => {
    // API'den kullanıcı bilgilerini ve istatistikleri al
    try {
        // const response = await fetch('/api/user/dashboard')
        // const data = await response.json()
        // user.value = data.user
        // stats.value = data.stats
        // recentOrders.value = data.recentOrders
    } catch (error) {
        console.error("Dashboard bilgileri yüklenemedi:", error);
    }
});
</script>
2