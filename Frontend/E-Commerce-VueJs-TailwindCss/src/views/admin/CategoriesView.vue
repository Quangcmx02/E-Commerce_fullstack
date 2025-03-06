<template>
    <div class="space-y-6">
        <!-- Başlık ve Açıklama -->
        <div class="flex items-center justify-between">
            <div>
                <h1 class="text-3xl font-bold tracking-tight">Kategori Yönetimi</h1>
                <p class="text-muted-foreground">Platformdaki tüm kategorileri buradan yönetebilirsiniz.</p>
            </div>
            <button class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                    <path d="M12 5v14M5 12h14"/>
                </svg>
                Yeni Kategori Ekle
            </button>
        </div>

        <!-- İstatistik Kartları -->
        <div class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
            <!-- Toplam Kategori -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Kategori</p>
                        <h2 class="mt-2 text-3xl font-bold">156</h2>
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
                            <path d="M4 20h16a2 2 0 0 0 2-2V8a2 2 0 0 0-2-2h-7.93a2 2 0 0 1-1.66-.9l-.82-1.2A2 2 0 0 0 7.93 3H4a2 2 0 0 0-2 2v13c0 1.1.9 2 2 2Z"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Aktif Kategori -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Aktif Kategori</p>
                        <h2 class="mt-2 text-3xl font-bold">142</h2>
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
                            <path d="M12 22c5.523 0 10-4.477 10-10S17.523 2 12 2 2 6.477 2 12s4.477 10 10 10z"/>
                            <path d="m9 12 2 2 4-4"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Toplam Ürün -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Ürün</p>
                        <h2 class="mt-2 text-3xl font-bold">8.5K</h2>
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
                            <path d="m7.5 4.27 9 5.15"/>
                            <path d="M21 8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16Z"/>
                            <path d="m3.3 7 8.7 5 8.7-5"/>
                            <path d="M12 22V12"/>
                        </svg>
                    </div>
                </div>
            </div>

            <!-- Ortalama Satış -->
            <div class="rounded-xl border bg-card p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Ortalama Satış</p>
                        <h2 class="mt-2 text-3xl font-bold">₺54.6K</h2>
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
                            <path d="M20.91 8.84 8.56 2.23a1.93 1.93 0 0 0-1.81 0L3.1 4.13a2.12 2.12 0 0 0-.05 3.69l12.22 6.93a2 2 0 0 0 1.94 0L21 12.51a2.12 2.12 0 0 0-.09-3.67Z"/>
                            <path d="m3.09 8.84 12.35-6.61a1.93 1.93 0 0 1 1.81 0l3.65 1.9a2.12 2.12 0 0 1 .1 3.69L8.73 14.75a2 2 0 0 1-1.94 0L3 12.51a2.12 2.12 0 0 1 .09-3.67Z"/>
                            <line x1="12" y1="22" x2="12" y2="13"/>
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
                        placeholder="Kategori ara..."
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
                    <option value="inactive">Pasif</option>
                </select>

                <!-- Üst Kategori Filtresi -->
                <select v-model="selectedParent" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="">Tüm Üst Kategoriler</option>
                    <option value="none">Ana Kategoriler</option>
                    <option v-for="category in parentCategories" :key="category.id" :value="category.id">
                        {{ category.name }}
                    </option>
                </select>

                <!-- Sıralama -->
                <select v-model="sortBy" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="name-asc">İsme Göre (A-Z)</option>
                    <option value="name-desc">İsme Göre (Z-A)</option>
                    <option value="products-desc">En Çok Ürün</option>
                    <option value="sales-desc">En Çok Satış</option>
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

        <!-- Kategori Tablosu -->
        <div class="rounded-lg border bg-card">
            <div class="relative overflow-x-auto">
                <table class="w-full text-left text-sm">
                    <thead class="bg-muted/50 text-xs uppercase">
                        <tr>
                            <th class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </th>
                            <th class="px-6 py-4">Kategori</th>
                            <th class="px-6 py-4">Üst Kategori</th>
                            <th class="px-6 py-4">Ürün Sayısı</th>
                            <th class="px-6 py-4">Alt Kategori</th>
                            <th class="px-6 py-4">Toplam Satış</th>
                            <th class="px-6 py-4">Durum</th>
                            <th class="px-6 py-4">İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="category in filteredCategories" :key="category.id" class="border-b">
                            <td class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-3">
                                    <div class="flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10">
                                        <component :is="category.icon" class="h-5 w-5 text-primary" />
                                    </div>
                                    <div>
                                        <p class="font-medium">{{ category.name }}</p>
                                        <p class="text-xs text-muted-foreground">Slug: {{ category.slug }}</p>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4">{{ category.parent || '-' }}</td>
                            <td class="px-6 py-4">{{ category.productCount }}</td>
                            <td class="px-6 py-4">{{ category.subCategoryCount }}</td>
                            <td class="px-6 py-4">₺{{ category.totalSales }}</td>
                            <td class="px-6 py-4">
                                <span :class="[
                                    'rounded-full px-2 py-1 text-xs font-medium',
                                    category.status === 'active' ? 'bg-green-100 text-green-700' : 'bg-red-100 text-red-700'
                                ]">
                                    {{ category.status === 'active' ? 'Aktif' : 'Pasif' }}
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
                                    <button class="rounded-md p-2 hover:bg-accent" title="Alt Kategoriler">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M3 3h18v18H3z"/>
                                            <path d="M21 9H3"/>
                                            <path d="M8 21V9"/>
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
                    Toplam <span class="font-medium">{{ totalCategories }}</span> kategoriden <span class="font-medium">1-10</span> arası gösteriliyor
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
const selectedParent = ref('')
const sortBy = ref('name-asc')
const currentPage = ref(1)

// Örnek kategori verileri
const categories = [
    {
        id: 1,
        name: "Elektronik",
        slug: "elektronik",
        icon: "DevicesIcon",
        parent: null,
        productCount: 1250,
        subCategoryCount: 8,
        totalSales: "1,250,000",
        status: "active"
    },
    {
        id: 2,
        name: "Akıllı Telefonlar",
        slug: "akilli-telefonlar",
        icon: "SmartphoneIcon",
        parent: "Elektronik",
        productCount: 450,
        subCategoryCount: 0,
        totalSales: "850,000",
        status: "active"
    },
    {
        id: 3,
        name: "Moda",
        slug: "moda",
        icon: "ShirtIcon",
        parent: null,
        productCount: 2800,
        subCategoryCount: 12,
        totalSales: "980,000",
        status: "active"
    },
    {
        id: 4,
        name: "Erkek Giyim",
        slug: "erkek-giyim",
        icon: "UserIcon",
        parent: "Moda",
        productCount: 1200,
        subCategoryCount: 5,
        totalSales: "420,000",
        status: "active"
    },
    {
        id: 5,
        name: "Ev & Yaşam",
        slug: "ev-yasam",
        icon: "HomeIcon",
        parent: null,
        productCount: 1800,
        subCategoryCount: 15,
        totalSales: "750,000",
        status: "active"
    }
]

// Ana kategorileri filtrele
const parentCategories = computed(() => {
    return categories.filter(category => !category.parent)
})

// Hesaplanan özellikler
const filteredCategories = computed(() => {
    let result = [...categories]

    // Arama filtresi
    if (searchQuery.value) {
        const query = searchQuery.value.toLowerCase()
        result = result.filter(category =>
            category.name.toLowerCase().includes(query) ||
            category.slug.toLowerCase().includes(query)
        )
    }

    // Durum filtresi
    if (selectedStatus.value) {
        result = result.filter(category => category.status === selectedStatus.value)
    }

    // Üst kategori filtresi
    if (selectedParent.value) {
        if (selectedParent.value === 'none') {
            result = result.filter(category => !category.parent)
        } else {
            result = result.filter(category => category.parent === selectedParent.value)
        }
    }

    // Sıralama
    switch (sortBy.value) {
        case 'name-asc':
            result.sort((a, b) => a.name.localeCompare(b.name))
            break
        case 'name-desc':
            result.sort((a, b) => b.name.localeCompare(a.name))
            break
        case 'products-desc':
            result.sort((a, b) => b.productCount - a.productCount)
            break
        case 'sales-desc':
            result.sort((a, b) => parseFloat(b.totalSales.replace(',', '')) - parseFloat(a.totalSales.replace(',', '')))
            break
    }

    return result
})

const totalCategories = computed(() => filteredCategories.value.length)
const totalPages = computed(() => Math.ceil(totalCategories.value / 10))
</script> 