<template>
    <div class="space-y-6">
        <!-- Başlık ve Açıklama -->
        <div class="flex items-center justify-between">
            <div>
                <h1 class="text-3xl font-bold tracking-tight">İndirim Yönetimi</h1>
                <p class="text-muted-foreground">Platformdaki tüm indirim kampanyalarını buradan yönetebilirsiniz.</p>
            </div>
            <button class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                    <path d="M12 5v14M5 12h14"/>
                </svg>
                Yeni İndirim Kampanyası
            </button>
        </div>

        <!-- İstatistik Kartları -->
        <div class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
            <!-- Aktif Kampanyalar -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Aktif Kampanyalar</p>
                        <h2 class="mt-2 text-3xl font-bold">24</h2>
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
                            <path d="M4.9 19.1C1 15.2 1 8.8 4.9 4.9"/>
                            <path d="M7.8 16.2c-2.3-2.3-2.3-6.1 0-8.4"/>
                            <circle cx="12" cy="12" r="2"/>
                            <path d="M16.2 7.8c2.3 2.3 2.3 6.1 0 8.4"/>
                            <path d="M19.1 4.9C23 8.8 23 15.1 19.1 19"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Toplam İndirim -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam İndirim</p>
                        <h2 class="mt-2 text-3xl font-bold">₺156K</h2>
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
                            <line x1="19" y1="5" x2="5" y2="19"/>
                            <circle cx="6.5" cy="6.5" r="2.5"/>
                            <circle cx="17.5" cy="17.5" r="2.5"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Kupon Kullanımı -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Kupon Kullanımı</p>
                        <h2 class="mt-2 text-3xl font-bold">3.2K</h2>
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
                            <path d="M3 7v2a3 3 0 1 1 0 6v2c0 1.1.9 2 2 2h14a2 2 0 0 0 2-2v-2a3 3 0 1 1 0-6V7a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2Z"/>
                            <path d="M9 17v2"/>
                            <path d="M15 17v2"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Dönüşüm Oranı -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Dönüşüm Oranı</p>
                        <h2 class="mt-2 text-3xl font-bold">24.8%</h2>
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
                            <path d="M12 2v20"/>
                            <path d="m19 15-7 7-7-7"/>
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
                        placeholder="Kampanya adı veya kupon kodu ara..."
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
                    <option value="active">Aktif</option>
                    <option value="scheduled">Planlanmış</option>
                    <option value="expired">Süresi Dolmuş</option>
                    <option value="paused">Duraklatılmış</option>
                </select>

                <!-- İndirim Tipi -->
                <select v-model="selectedType" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="">Tüm Tipler</option>
                    <option value="percentage">Yüzde İndirim</option>
                    <option value="fixed">Sabit İndirim</option>
                    <option value="bogo">Al-Bir-Bedava</option>
                    <option value="shipping">Kargo Bedava</option>
                </select>

                <!-- Sıralama -->
                <select v-model="sortBy" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="usage-desc">En Çok Kullanılan</option>
                    <option value="date-desc">En Yeni</option>
                    <option value="date-asc">En Eski</option>
                    <option value="discount-desc">En Yüksek İndirim</option>
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

        <!-- İndirim Tablosu -->
        <div class="rounded-lg border bg-card">
            <div class="relative overflow-x-auto">
                <table class="w-full text-left text-sm">
                    <thead class="bg-muted/50 text-xs uppercase">
                        <tr>
                            <th class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </th>
                            <th class="px-6 py-4">Kampanya</th>
                            <th class="px-6 py-4">Tip</th>
                            <th class="px-6 py-4">İndirim</th>
                            <th class="px-6 py-4">Kullanım</th>
                            <th class="px-6 py-4">Başlangıç</th>
                            <th class="px-6 py-4">Bitiş</th>
                            <th class="px-6 py-4">Durum</th>
                            <th class="px-6 py-4">İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="discount in filteredDiscounts" :key="discount.id" class="border-b">
                            <td class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-3">
                                    <div class="flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                            <line x1="19" y1="5" x2="5" y2="19"/>
                                            <circle cx="6.5" cy="6.5" r="2.5"/>
                                            <circle cx="17.5" cy="17.5" r="2.5"/>
                                        </svg>
                                    </div>
                                    <div>
                                        <p class="font-medium">{{ discount.name }}</p>
                                        <p class="text-xs text-muted-foreground">{{ discount.code }}</p>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4">{{ discount.type }}</td>
                            <td class="px-6 py-4">
                                <span class="font-medium">
                                    {{ discount.type === 'percentage' ? `%${discount.value}` : 
                                       discount.type === 'fixed' ? `₺${discount.value}` :
                                       discount.type === 'bogo' ? 'Al-Bir-Bedava' : 'Kargo Bedava' }}
                                </span>
                            </td>
                            <td class="px-6 py-4">
                                <div>
                                    <p class="font-medium">{{ discount.usage }}/{{ discount.limit || '∞' }}</p>
                                    <div class="mt-1 h-1.5 w-24 rounded-full bg-muted">
                                        <div
                                            class="h-1.5 rounded-full bg-primary"
                                            :style="{ width: `${(discount.usage / (discount.limit || discount.usage)) * 100}%` }"
                                        ></div>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4">
                                <div>
                                    <p class="font-medium">{{ discount.startDate }}</p>
                                    <p class="text-xs text-muted-foreground">{{ discount.startTime }}</p>
                                </div>
                            </td>
                            <td class="px-6 py-4">
                                <div>
                                    <p class="font-medium">{{ discount.endDate }}</p>
                                    <p class="text-xs text-muted-foreground">{{ discount.endTime }}</p>
                                </div>
                            </td>
                            <td class="px-6 py-4">
                                <span :class="[
                                    'rounded-full px-2 py-1 text-xs font-medium',
                                    discount.status === 'active' ? 'bg-green-100 text-green-700' :
                                    discount.status === 'scheduled' ? 'bg-blue-100 text-blue-700' :
                                    discount.status === 'expired' ? 'bg-red-100 text-red-700' :
                                    'bg-yellow-100 text-yellow-700'
                                ]">
                                    {{ 
                                        discount.status === 'active' ? 'Aktif' :
                                        discount.status === 'scheduled' ? 'Planlanmış' :
                                        discount.status === 'expired' ? 'Süresi Dolmuş' :
                                        'Duraklatılmış'
                                    }}
                                </span>
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-2">
                                    <button class="rounded-md p-2 hover:bg-accent" title="Düzenle">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z" />
                                            <path d="m15 5 4 4" />
                                        </svg>
                                    </button>
                                    <button class="rounded-md p-2 hover:bg-accent" title="Detaylar">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z" />
                                            <path d="M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z" />
                                        </svg>
                                    </button>
                                    <button class="rounded-md p-2 text-red-500 hover:bg-accent" title="Sil">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M3 6h18" />
                                            <path d="M19 6v14c0 1-1 2-2 2H7c-1 0-2-1-2-2V6" />
                                            <path d="M8 6V4c0-1 1-2 2-2h4c1 0 2 1 2 2v2" />
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
                    Toplam <span class="font-medium">{{ totalDiscounts }}</span> kampanyadan <span class="font-medium">1-10</span> arası gösteriliyor
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
const selectedType = ref('')
const sortBy = ref('usage-desc')
const currentPage = ref(1)

// Örnek indirim verileri
const discounts = [
    {
        id: 1,
        name: "Yeni Yıl Kampanyası",
        code: "YILBASI2024",
        type: "percentage",
        value: 25,
        usage: 450,
        limit: 1000,
        startDate: "1 Ocak 2024",
        startTime: "00:00",
        endDate: "15 Ocak 2024",
        endTime: "23:59",
        status: "active"
    },
    {
        id: 2,
        name: "Hoşgeldin İndirimi",
        code: "WELCOME50",
        type: "fixed",
        value: 100,
        usage: 230,
        limit: null,
        startDate: "1 Ocak 2024",
        startTime: "00:00",
        endDate: "31 Aralık 2024",
        endTime: "23:59",
        status: "active"
    },
    {
        id: 3,
        name: "Kara Cuma",
        code: "BLACKFRIDAY",
        type: "percentage",
        value: 40,
        usage: 0,
        limit: 500,
        startDate: "24 Kasım 2024",
        startTime: "00:00",
        endDate: "27 Kasım 2024",
        endTime: "23:59",
        status: "scheduled"
    },
    {
        id: 4,
        name: "Ücretsiz Kargo",
        code: "FREESHIP",
        type: "shipping",
        value: null,
        usage: 890,
        limit: 1000,
        startDate: "1 Ocak 2024",
        startTime: "00:00",
        endDate: "31 Ocak 2024",
        endTime: "23:59",
        status: "active"
    },
    {
        id: 5,
        name: "2 Al 1 Öde",
        code: "BOGO2024",
        type: "bogo",
        value: null,
        usage: 125,
        limit: 200,
        startDate: "1 Ocak 2024",
        startTime: "00:00",
        endDate: "10 Ocak 2024",
        endTime: "23:59",
        status: "expired"
    }
]

// Hesaplanan özellikler
const filteredDiscounts = computed(() => {
    let result = [...discounts]

    // Arama filtresi
    if (searchQuery.value) {
        const query = searchQuery.value.toLowerCase()
        result = result.filter(discount =>
            discount.name.toLowerCase().includes(query) ||
            discount.code.toLowerCase().includes(query)
        )
    }

    // Durum filtresi
    if (selectedStatus.value) {
        result = result.filter(discount => discount.status === selectedStatus.value)
    }

    // Tip filtresi
    if (selectedType.value) {
        result = result.filter(discount => discount.type === selectedType.value)
    }

    // Sıralama
    switch (sortBy.value) {
        case 'usage-desc':
            result.sort((a, b) => b.usage - a.usage)
            break
        case 'date-desc':
            result.sort((a, b) => new Date(b.startDate) - new Date(a.startDate))
            break
        case 'date-asc':
            result.sort((a, b) => new Date(a.startDate) - new Date(b.startDate))
            break
        case 'discount-desc':
            result.sort((a, b) => {
                if (a.type === 'percentage' && b.type === 'percentage') {
                    return b.value - a.value
                }
                if (a.type === 'fixed' && b.type === 'fixed') {
                    return b.value - a.value
                }
                return 0
            })
            break
    }

    return result
})

const totalDiscounts = computed(() => filteredDiscounts.value.length)
const totalPages = computed(() => Math.ceil(totalDiscounts.value / 10))
</script> 