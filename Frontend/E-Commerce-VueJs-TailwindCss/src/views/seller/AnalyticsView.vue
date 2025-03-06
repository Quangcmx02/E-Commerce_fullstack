<template>
    <div class="analytics-view">
        <!-- Üst Başlık -->
        <div class="flex items-center justify-between mb-6">
            <div>
                <h1 class="text-2xl font-bold">Analitik</h1>
                <p class="text-sm text-muted-foreground mt-1">
                    Mağazanızın performans metriklerini görüntüleyin
                </p>
            </div>
            <div class="flex items-center space-x-2">
                <!-- Tarih Aralığı Seçici -->
                <select v-model="selectedRange" class="px-3 py-2 rounded-lg border border-input bg-background text-sm">
                    <option value="today">Bugün</option>
                    <option value="yesterday">Dün</option>
                    <option value="last7days">Son 7 Gün</option>
                    <option value="last30days">Son 30 Gün</option>
                    <option value="thisMonth">Bu Ay</option>
                    <option value="lastMonth">Geçen Ay</option>
                </select>
            </div>
        </div>

        <!-- Ana Metrikler -->
        <div class="grid gap-4 md:grid-cols-4 mb-6">
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
                    <span class="text-muted-foreground">Geçen döneme göre</span>
                </div>
            </div>

            <!-- Ortalama Sipariş Değeri -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Ort. Sipariş Değeri</p>
                        <h3 class="text-2xl font-bold mt-1">₺245.80</h3>
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
                    <span class="text-red-500 flex items-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-4 h-4 mr-1">
                            <polyline points="22 17 13.5 8.5 8.5 13.5 2 7" />
                            <polyline points="16 17 22 17 22 11" />
                        </svg>
                        2.3%
                    </span>
                    <span class="text-muted-foreground">Geçen döneme göre</span>
                </div>
            </div>

            <!-- Dönüşüm Oranı -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Dönüşüm Oranı</p>
                        <h3 class="text-2xl font-bold mt-1">3.24%</h3>
                    </div>
                    <div class="w-12 h-12 bg-primary/10 rounded-full flex items-center justify-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-6 h-6 text-primary">
                            <path d="M12 20V4" />
                            <path d="M5 11l7-7 7 7" />
                        </svg>
                    </div>
                </div>
                <div class="mt-4 flex items-center space-x-2 text-sm">
                    <span class="text-green-500 flex items-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-4 h-4 mr-1">
                            <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                            <polyline points="16 7 22 7 22 13" />
                        </svg>
                        0.8%
                    </span>
                    <span class="text-muted-foreground">Geçen döneme göre</span>
                </div>
            </div>

            <!-- Toplam Ziyaretçi -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between">
                    <div>
                        <p class="text-sm font-medium text-muted-foreground">Toplam Ziyaretçi</p>
                        <h3 class="text-2xl font-bold mt-1">12,486</h3>
                    </div>
                    <div class="w-12 h-12 bg-primary/10 rounded-full flex items-center justify-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-6 h-6 text-primary">
                            <path d="M3 12a9 9 0 1 0 18 0 9 9 0 0 0-18 0" />
                            <path d="M12 8h.01" />
                            <path d="M11 12h1v4h1" />
                        </svg>
                    </div>
                </div>
                <div class="mt-4 flex items-center space-x-2 text-sm">
                    <span class="text-green-500 flex items-center">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-4 h-4 mr-1">
                            <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                            <polyline points="16 7 22 7 22 13" />
                        </svg>
                        15.3%
                    </span>
                    <span class="text-muted-foreground">Geçen döneme göre</span>
                </div>
            </div>
        </div>

        <!-- Grafikler -->
        <div class="grid gap-6 md:grid-cols-2 mb-6">
            <!-- Satış Trendi -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between mb-4">
                    <h3 class="text-lg font-semibold">Satış Trendi</h3>
                    <select v-model="salesChartType" class="px-2 py-1 text-sm border border-input rounded-md bg-background">
                        <option value="daily">Günlük</option>
                        <option value="weekly">Haftalık</option>
                        <option value="monthly">Aylık</option>
                    </select>
                </div>
                <div class="h-[300px] flex items-center justify-center text-muted-foreground">
                    [Satış Trendi Grafiği]
                </div>
            </div>

            <!-- En Çok Satan Ürünler -->
            <div class="bg-card rounded-lg border border-border p-6">
                <div class="flex items-center justify-between mb-4">
                    <h3 class="text-lg font-semibold">En Çok Satan Ürünler</h3>
                    <select v-model="topProductsLimit" class="px-2 py-1 text-sm border border-input rounded-md bg-background">
                        <option value="5">Top 5</option>
                        <option value="10">Top 10</option>
                        <option value="20">Top 20</option>
                    </select>
                </div>
                <div class="space-y-4">
                    <div v-for="i in 5" :key="i" class="flex items-center justify-between">
                        <div class="flex items-center space-x-3">
                            <div class="w-10 h-10 bg-accent rounded-lg"></div>
                            <div>
                                <p class="font-medium">Ürün {{ i }}</p>
                                <p class="text-sm text-muted-foreground">{{ 100 - (i * 15) }} Satış</p>
                            </div>
                        </div>
                        <div class="text-right">
                            <p class="font-medium">₺{{ (1000 - (i * 150)).toLocaleString() }}</p>
                            <p class="text-sm text-muted-foreground">Toplam Gelir</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Alt Metrikler -->
        <div class="grid gap-6 md:grid-cols-3">
            <!-- Müşteri Memnuniyeti -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h3 class="text-lg font-semibold mb-4">Müşteri Memnuniyeti</h3>
                <div class="space-y-4">
                    <div class="flex items-center justify-between">
                        <span class="text-sm font-medium">5 Yıldız</span>
                        <div class="flex-1 mx-4">
                            <div class="h-2 bg-accent rounded-full">
                                <div class="h-2 bg-primary rounded-full" style="width: 75%"></div>
                            </div>
                        </div>
                        <span class="text-sm font-medium">75%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <span class="text-sm font-medium">4 Yıldız</span>
                        <div class="flex-1 mx-4">
                            <div class="h-2 bg-accent rounded-full">
                                <div class="h-2 bg-primary rounded-full" style="width: 15%"></div>
                            </div>
                        </div>
                        <span class="text-sm font-medium">15%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <span class="text-sm font-medium">3 Yıldız</span>
                        <div class="flex-1 mx-4">
                            <div class="h-2 bg-accent rounded-full">
                                <div class="h-2 bg-primary rounded-full" style="width: 7%"></div>
                            </div>
                        </div>
                        <span class="text-sm font-medium">7%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <span class="text-sm font-medium">2 Yıldız</span>
                        <div class="flex-1 mx-4">
                            <div class="h-2 bg-accent rounded-full">
                                <div class="h-2 bg-primary rounded-full" style="width: 2%"></div>
                            </div>
                        </div>
                        <span class="text-sm font-medium">2%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <span class="text-sm font-medium">1 Yıldız</span>
                        <div class="flex-1 mx-4">
                            <div class="h-2 bg-accent rounded-full">
                                <div class="h-2 bg-primary rounded-full" style="width: 1%"></div>
                            </div>
                        </div>
                        <span class="text-sm font-medium">1%</span>
                    </div>
                </div>
            </div>

            <!-- Ziyaretçi Kaynakları -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h3 class="text-lg font-semibold mb-4">Ziyaretçi Kaynakları</h3>
                <div class="space-y-4">
                    <div class="flex items-center justify-between">
                        <div class="flex items-center space-x-2">
                            <div class="w-3 h-3 bg-primary rounded-full"></div>
                            <span class="text-sm font-medium">Doğrudan Trafik</span>
                        </div>
                        <span class="text-sm font-medium">45%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <div class="flex items-center space-x-2">
                            <div class="w-3 h-3 bg-blue-500 rounded-full"></div>
                            <span class="text-sm font-medium">Sosyal Medya</span>
                        </div>
                        <span class="text-sm font-medium">25%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <div class="flex items-center space-x-2">
                            <div class="w-3 h-3 bg-green-500 rounded-full"></div>
                            <span class="text-sm font-medium">Organik Arama</span>
                        </div>
                        <span class="text-sm font-medium">20%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <div class="flex items-center space-x-2">
                            <div class="w-3 h-3 bg-yellow-500 rounded-full"></div>
                            <span class="text-sm font-medium">Referans</span>
                        </div>
                        <span class="text-sm font-medium">10%</span>
                    </div>
                </div>
            </div>

            <!-- Popüler Kategoriler -->
            <div class="bg-card rounded-lg border border-border p-6">
                <h3 class="text-lg font-semibold mb-4">Popüler Kategoriler</h3>
                <div class="space-y-4">
                    <div class="flex items-center justify-between">
                        <div class="flex items-center space-x-2">
                            <div class="w-3 h-3 bg-primary rounded-full"></div>
                            <span class="text-sm font-medium">Elektronik</span>
                        </div>
                        <span class="text-sm font-medium">35%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <div class="flex items-center space-x-2">
                            <div class="w-3 h-3 bg-purple-500 rounded-full"></div>
                            <span class="text-sm font-medium">Giyim</span>
                        </div>
                        <span class="text-sm font-medium">28%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <div class="flex items-center space-x-2">
                            <div class="w-3 h-3 bg-pink-500 rounded-full"></div>
                            <span class="text-sm font-medium">Kozmetik</span>
                        </div>
                        <span class="text-sm font-medium">20%</span>
                    </div>
                    <div class="flex items-center justify-between">
                        <div class="flex items-center space-x-2">
                            <div class="w-3 h-3 bg-orange-500 rounded-full"></div>
                            <span class="text-sm font-medium">Ev & Yaşam</span>
                        </div>
                        <span class="text-sm font-medium">17%</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue'

export default defineComponent({
    name: 'AnalyticsView',
    data() {
        return {
            selectedRange: 'last7days',
            salesChartType: 'daily',
            topProductsLimit: '5'
        }
    }
})
</script> 