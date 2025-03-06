<template>
    <div class="space-y-6">
        <div>
            <h1 class="text-3xl font-bold tracking-tight">Platform Ayarları</h1>
            <p class="text-muted-foreground">E-ticaret platformunuzun tüm ayarlarını buradan yönetin.</p>
        </div>

        <div class="flex flex-col gap-6 md:flex-row">
            <div class="w-full md:w-64">
                <div class="sticky top-6 rounded-lg border bg-card">
                    <div class="flex flex-col">
                        <button v-for="tab in settingTabs" :key="tab.id" @click="activeTab = tab.id" class="flex items-center gap-3 px-4 py-3 text-sm transition-colors hover:bg-accent" :class="[activeTab === tab.id ? 'bg-primary/10 text-primary' : 'text-muted-foreground hover:text-foreground']">
                            <component :is="tab.icon" class="h-5 w-5" />
                            {{ tab.title }}
                        </button>
                    </div>
                </div>
            </div>

            <div class="flex-1 space-y-6">
                <div v-if="activeTab === 'general'" class="rounded-lg border bg-card">
                    <div class="border-b p-6">
                        <h2 class="text-lg font-medium">Genel Ayarlar</h2>
                        <p class="text-sm text-muted-foreground">Platform için temel ayarları yapılandırın.</p>
                    </div>
                    <div class="p-6 space-y-6">
                        <div class="space-y-4">
                            <div>
                                <label class="text-sm font-medium">Site Adı</label>
                                <input type="text" v-model="settings.siteName" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                            </div>
                            <div>
                                <label class="text-sm font-medium">Site Açıklaması</label>
                                <textarea v-model="settings.siteDescription" rows="3" class="mt-1 w-full rounded-md border bg-background px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-primary"></textarea>
                            </div>
                            <div>
                                <label class="text-sm font-medium">Logo</label>
                                <div class="mt-1 flex items-center gap-4">
                                    <img :src="settings.logo" alt="Site Logo" class="h-16 w-16 rounded-lg object-cover" />
                                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Logo Değiştir</button>
                                </div>
                            </div>
                        </div>

                        <div class="space-y-4">
                            <h3 class="text-base font-medium">İletişim Bilgileri</h3>
                            <div>
                                <label class="text-sm font-medium">E-posta Adresi</label>
                                <input type="email" v-model="settings.contactEmail" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                            </div>
                            <div>
                                <label class="text-sm font-medium">Telefon Numarası</label>
                                <input type="tel" v-model="settings.contactPhone" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                            </div>
                            <div>
                                <label class="text-sm font-medium">Adres</label>
                                <textarea v-model="settings.address" rows="3" class="mt-1 w-full rounded-md border bg-background px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-primary"></textarea>
                            </div>
                        </div>

                        <div class="space-y-4">
                            <h3 class="text-base font-medium">Sosyal Medya</h3>
                            <div>
                                <label class="text-sm font-medium">Facebook</label>
                                <input type="url" v-model="settings.socialMedia.facebook" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                            </div>
                            <div>
                                <label class="text-sm font-medium">Instagram</label>
                                <input type="url" v-model="settings.socialMedia.instagram" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                            </div>
                            <div>
                                <label class="text-sm font-medium">Twitter</label>
                                <input type="url" v-model="settings.socialMedia.twitter" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                            </div>
                        </div>
                    </div>
                </div>

                <div v-if="activeTab === 'security'" class="rounded-lg border bg-card">
                    <div class="border-b p-6">
                        <h2 class="text-lg font-medium">Güvenlik Ayarları</h2>
                        <p class="text-sm text-muted-foreground">Platform güvenlik ayarlarını yapılandırın.</p>
                    </div>
                    <div class="p-6 space-y-6">
                        <div class="space-y-4">
                            <h3 class="text-base font-medium">Şifre Politikası</h3>
                            <div class="flex items-center gap-2">
                                <input type="checkbox" v-model="settings.security.requireUppercase" class="rounded border-muted" />
                                <label class="text-sm">Büyük harf zorunlu</label>
                            </div>
                            <div class="flex items-center gap-2">
                                <input type="checkbox" v-model="settings.security.requireNumber" class="rounded border-muted" />
                                <label class="text-sm">Rakam zorunlu</label>
                            </div>
                            <div class="flex items-center gap-2">
                                <input type="checkbox" v-model="settings.security.requireSpecialChar" class="rounded border-muted" />
                                <label class="text-sm">Özel karakter zorunlu</label>
                            </div>
                            <div>
                                <label class="text-sm font-medium">Minimum şifre uzunluğu</label>
                                <input type="number" v-model="settings.security.minPasswordLength" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                            </div>
                        </div>

                        <div class="space-y-4">
                            <h3 class="text-base font-medium">Oturum Ayarları</h3>
                            <div>
                                <label class="text-sm font-medium">Oturum süresi (dakika)</label>
                                <input type="number" v-model="settings.security.sessionTimeout" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                            </div>
                            <div class="flex items-center gap-2">
                                <input type="checkbox" v-model="settings.security.forceLogout" class="rounded border-muted" />
                                <label class="text-sm">Şifre değişikliğinde tüm oturumları sonlandır</label>
                            </div>
                        </div>

                        <div class="space-y-4">
                            <h3 class="text-base font-medium">İki Faktörlü Doğrulama</h3>
                            <div class="flex items-center gap-2">
                                <input type="checkbox" v-model="settings.security.require2FA" class="rounded border-muted" />
                                <label class="text-sm">Yöneticiler için zorunlu</label>
                            </div>
                            <div class="flex items-center gap-2">
                                <input type="checkbox" v-model="settings.security.optional2FA" class="rounded border-muted" />
                                <label class="text-sm">Kullanıcılar için opsiyonel</label>
                            </div>
                        </div>
                    </div>
                </div>

                <div v-if="activeTab === 'notifications'" class="rounded-lg border bg-card">
                    <div class="border-b p-6">
                        <h2 class="text-lg font-medium">Bildirim Ayarları</h2>
                        <p class="text-sm text-muted-foreground">E-posta ve anlık bildirim tercihlerini yapılandırın.</p>
                    </div>
                    <div class="p-6 space-y-6">
                        <div class="space-y-4">
                            <h3 class="text-base font-medium">E-posta Bildirimleri</h3>
                            <div class="flex items-center justify-between">
                                <div>
                                    <p class="font-medium">Yeni Sipariş</p>
                                    <p class="text-sm text-muted-foreground">Yeni sipariş alındığında bildirim gönder</p>
                                </div>
                                <div class="flex items-center gap-2">
                                    <input type="checkbox" v-model="settings.notifications.orderEmail" class="rounded border-muted" />
                                </div>
                            </div>
                            <div class="flex items-center justify-between">
                                <div>
                                    <p class="font-medium">Stok Uyarısı</p>
                                    <p class="text-sm text-muted-foreground">Ürün stokları azaldığında bildirim gönder</p>
                                </div>
                                <div class="flex items-center gap-2">
                                    <input type="checkbox" v-model="settings.notifications.stockEmail" class="rounded border-muted" />
                                </div>
                            </div>
                            <div class="flex items-center justify-between">
                                <div>
                                    <p class="font-medium">Yeni Üyelik</p>
                                    <p class="text-sm text-muted-foreground">Yeni üye kaydı olduğunda bildirim gönder</p>
                                </div>
                                <div class="flex items-center gap-2">
                                    <input type="checkbox" v-model="settings.notifications.userEmail" class="rounded border-muted" />
                                </div>
                            </div>
                        </div>

                        <div class="space-y-4">
                            <h3 class="text-base font-medium">Anlık Bildirimler</h3>
                            <div class="flex items-center justify-between">
                                <div>
                                    <p class="font-medium">Masaüstü Bildirimleri</p>
                                    <p class="text-sm text-muted-foreground">Tarayıcı bildirimlerini etkinleştir</p>
                                </div>
                                <div class="flex items-center gap-2">
                                    <input type="checkbox" v-model="settings.notifications.desktop" class="rounded border-muted" />
                                </div>
                            </div>
                            <div class="flex items-center justify-between">
                                <div>
                                    <p class="font-medium">Mobil Bildirimler</p>
                                    <p class="text-sm text-muted-foreground">Mobil uygulama bildirimlerini etkinleştir</p>
                                </div>
                                <div class="flex items-center gap-2">
                                    <input type="checkbox" v-model="settings.notifications.mobile" class="rounded border-muted" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div v-if="activeTab === 'integrations'" class="rounded-lg border bg-card">
                    <div class="border-b p-6">
                        <h2 class="text-lg font-medium">Entegrasyon Ayarları</h2>
                        <p class="text-sm text-muted-foreground">Harici servis ve API entegrasyonlarını yapılandırın.</p>
                    </div>
                    <div class="p-6 space-y-6">
                        <div class="space-y-4">
                            <h3 class="text-base font-medium">Ödeme Sistemleri</h3>
                            <div class="rounded-lg border p-4">
                                <div class="flex items-center justify-between">
                                    <div class="flex items-center gap-3">
                                        <img src="https://picsum.photos/200" alt="Stripe" class="h-8 w-8 rounded-md" />
                                        <div>
                                            <p class="font-medium">Stripe</p>
                                            <p class="text-sm text-muted-foreground">Kredi kartı ödemeleri</p>
                                        </div>
                                    </div>
                                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Yapılandır</button>
                                </div>
                            </div>
                            <div class="rounded-lg border p-4">
                                <div class="flex items-center justify-between">
                                    <div class="flex items-center gap-3">
                                        <img src="https://picsum.photos/201" alt="PayPal" class="h-8 w-8 rounded-md" />
                                        <div>
                                            <p class="font-medium">PayPal</p>
                                            <p class="text-sm text-muted-foreground">PayPal ödemeleri</p>
                                        </div>
                                    </div>
                                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Yapılandır</button>
                                </div>
                            </div>
                        </div>

                        <div class="space-y-4">
                            <h3 class="text-base font-medium">Kargo Firmaları</h3>
                            <div class="rounded-lg border p-4">
                                <div class="flex items-center justify-between">
                                    <div class="flex items-center gap-3">
                                        <img src="https://picsum.photos/202" alt="UPS" class="h-8 w-8 rounded-md" />
                                        <div>
                                            <p class="font-medium">UPS</p>
                                            <p class="text-sm text-muted-foreground">UPS kargo entegrasyonu</p>
                                        </div>
                                    </div>
                                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Yapılandır</button>
                                </div>
                            </div>
                            <div class="rounded-lg border p-4">
                                <div class="flex items-center justify-between">
                                    <div class="flex items-center gap-3">
                                        <img src="https://picsum.photos/203" alt="FedEx" class="h-8 w-8 rounded-md" />
                                        <div>
                                            <p class="font-medium">FedEx</p>
                                            <p class="text-sm text-muted-foreground">FedEx kargo entegrasyonu</p>
                                        </div>
                                    </div>
                                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Yapılandır</button>
                                </div>
                            </div>
                        </div>

                        <div class="space-y-4">
                            <h3 class="text-base font-medium">Diğer Entegrasyonlar</h3>
                            <div class="rounded-lg border p-4">
                                <div class="flex items-center justify-between">
                                    <div class="flex items-center gap-3">
                                        <img src="https://picsum.photos/204" alt="Google Analytics" class="h-8 w-8 rounded-md" />
                                        <div>
                                            <p class="font-medium">Google Analytics</p>
                                            <p class="text-sm text-muted-foreground">Analitik entegrasyonu</p>
                                        </div>
                                    </div>
                                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Yapılandır</button>
                                </div>
                            </div>
                            <div class="rounded-lg border p-4">
                                <div class="flex items-center justify-between">
                                    <div class="flex items-center gap-3">
                                        <img src="https://picsum.photos/205" alt="Mailchimp" class="h-8 w-8 rounded-md" />
                                        <div>
                                            <p class="font-medium">Mailchimp</p>
                                            <p class="text-sm text-muted-foreground">E-posta pazarlama entegrasyonu</p>
                                        </div>
                                    </div>
                                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Yapılandır</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="flex justify-end">
                    <button class="inline-flex items-center justify-center rounded-md bg-primary px-8 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">Değişiklikleri Kaydet</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";

// Aktif sekme
const activeTab = ref("general");

// Ayar sekmeleri
const settingTabs = [
    {
        id: "general",
        title: "Genel Ayarlar",
        icon: "SettingsIcon",
    },
    {
        id: "security",
        title: "Güvenlik",
        icon: "ShieldIcon",
    },
    {
        id: "notifications",
        title: "Bildirimler",
        icon: "BellIcon",
    },
    {
        id: "integrations",
        title: "Entegrasyonlar",
        icon: "PlugIcon",
    },
];

// Örnek ayarlar verisi
const settings = ref({
    siteName: "E-Ticaret Platformu",
    siteDescription: "Modern ve güvenilir e-ticaret platformu",
    logo: "https://picsum.photos/200",
    contactEmail: "info@example.com",
    contactPhone: "+90 555 123 4567",
    address: "Örnek Mahallesi, Örnek Sokak No:1\nİstanbul, Türkiye",
    socialMedia: {
        facebook: "https://facebook.com",
        instagram: "https://instagram.com",
        twitter: "https://twitter.com",
    },
    security: {
        requireUppercase: true,
        requireNumber: true,
        requireSpecialChar: true,
        minPasswordLength: 8,
        sessionTimeout: 60,
        forceLogout: true,
        require2FA: true,
        optional2FA: true,
    },
    notifications: {
        orderEmail: true,
        stockEmail: true,
        userEmail: false,
        desktop: true,
        mobile: true,
    },
});
</script>
