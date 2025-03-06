<template>
    <div class="space-y-6">
        <!-- Başlık ve Açıklama -->
        <div>
            <h1 class="text-3xl font-bold tracking-tight">Profil Ayarları</h1>
            <p class="text-muted-foreground">Kişisel bilgilerinizi ve hesap ayarlarınızı yönetin.</p>
        </div>

        <!-- Profil Kartı -->
        <div class="rounded-lg border bg-card">
            <div class="flex flex-col items-center border-b p-6 md:flex-row md:items-start md:justify-between">
                <div class="flex flex-col items-center gap-4 md:flex-row">
                    <div class="relative">
                        <img src="https://github.com/shadcn.png" alt="Profil Fotoğrafı" class="h-24 w-24 rounded-full object-cover" />
                        <button class="absolute bottom-0 right-0 rounded-full bg-primary p-2 text-primary-foreground shadow-lg">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M21 12v7a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h7" />
                                <line x1="16" x2="22" y1="5" y2="5" />
                                <line x1="19" x2="19" y1="2" y2="8" />
                                <circle cx="9" cy="9" r="2" />
                                <path d="m21 15-3.086-3.086a2 2 0 0 0-2.828 0L6 21" />
                            </svg>
                        </button>
                    </div>
                    <div class="text-center md:text-left">
                        <h2 class="text-xl font-semibold">Ahmet Yılmaz</h2>
                        <p class="text-sm text-muted-foreground">Süper Admin</p>
                        <p class="text-sm text-muted-foreground">admin@example.com</p>
                    </div>
                </div>
                <div class="mt-4 flex items-center gap-2 md:mt-0">
                    <button class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                            <path d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z" />
                            <path d="m15 5 4 4" />
                        </svg>
                        Profili Düzenle
                    </button>
                </div>
            </div>

            <!-- Profil İstatistikleri -->
            <div class="grid gap-4 p-6 sm:grid-cols-2 lg:grid-cols-4">
                <div class="rounded-lg border p-4">
                    <p class="text-sm font-medium text-muted-foreground">Toplam Oturum</p>
                    <p class="mt-2 text-2xl font-bold">248</p>
                    <p class="mt-1 flex items-center text-sm text-green-500">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                            <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                            <polyline points="16 7 22 7 22 13" />
                        </svg>
                        12% artış
                    </p>
                </div>
                <div class="rounded-lg border p-4">
                    <p class="text-sm font-medium text-muted-foreground">Son Giriş</p>
                    <p class="mt-2 text-2xl font-bold">2 saat önce</p>
                    <p class="mt-1 text-sm text-muted-foreground">İstanbul, TR</p>
                </div>
                <div class="rounded-lg border p-4">
                    <p class="text-sm font-medium text-muted-foreground">İşlem Sayısı</p>
                    <p class="mt-2 text-2xl font-bold">1,024</p>
                    <p class="mt-1 flex items-center text-sm text-green-500">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-1">
                            <polyline points="22 7 13.5 15.5 8.5 10.5 2 17" />
                            <polyline points="16 7 22 7 22 13" />
                        </svg>
                        8% artış
                    </p>
                </div>
                <div class="rounded-lg border p-4">
                    <p class="text-sm font-medium text-muted-foreground">Aktif Oturum</p>
                    <p class="mt-2 text-2xl font-bold">3 cihaz</p>
                    <p class="mt-1 text-sm text-muted-foreground">2 masaüstü, 1 mobil</p>
                </div>
            </div>
        </div>

        <!-- Kişisel Bilgiler -->
        <div class="rounded-lg border bg-card">
            <div class="border-b p-6">
                <h3 class="text-lg font-medium">Kişisel Bilgiler</h3>
                <p class="text-sm text-muted-foreground">Profil bilgilerinizi güncelleyin.</p>
            </div>
            <div class="p-6">
                <form class="space-y-4">
                    <div class="grid gap-4 md:grid-cols-2">
                        <div>
                            <label class="text-sm font-medium">Ad</label>
                            <input type="text" v-model="profile.firstName" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                        </div>
                        <div>
                            <label class="text-sm font-medium">Soyad</label>
                            <input type="text" v-model="profile.lastName" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                        </div>
                    </div>
                    <div>
                        <label class="text-sm font-medium">E-posta</label>
                        <input type="email" v-model="profile.email" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                    </div>
                    <div>
                        <label class="text-sm font-medium">Telefon</label>
                        <input type="tel" v-model="profile.phone" class="mt-1 h-9 w-full rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary" />
                    </div>
                    <div>
                        <label class="text-sm font-medium">Biyografi</label>
                        <textarea v-model="profile.bio" rows="3" class="mt-1 w-full rounded-md border bg-background px-3 py-2 text-sm focus:outline-none focus:ring-2 focus:ring-primary"></textarea>
                    </div>
                </form>
            </div>
        </div>

        <!-- Güvenlik Ayarları -->
        <div class="rounded-lg border bg-card">
            <div class="border-b p-6">
                <h3 class="text-lg font-medium">Güvenlik Ayarları</h3>
                <p class="text-sm text-muted-foreground">Hesap güvenlik ayarlarınızı yönetin.</p>
            </div>
            <div class="divide-y">
                <!-- Şifre Değiştirme -->
                <div class="flex items-center justify-between p-6">
                    <div>
                        <p class="font-medium">Şifre Değiştir</p>
                        <p class="text-sm text-muted-foreground">En son 30 gün önce değiştirildi</p>
                    </div>
                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Şifre Değiştir</button>
                </div>

                <!-- İki Faktörlü Doğrulama -->
                <div class="flex items-center justify-between p-6">
                    <div>
                        <p class="font-medium">İki Faktörlü Doğrulama</p>
                        <p class="text-sm text-muted-foreground">Ekstra güvenlik için iki faktörlü doğrulamayı etkinleştirin</p>
                    </div>
                    <div class="flex items-center gap-2">
                        <span class="text-sm font-medium text-green-500">Aktif</span>
                        <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Yapılandır</button>
                    </div>
                </div>

                <!-- Oturum Geçmişi -->
                <div class="flex items-center justify-between p-6">
                    <div>
                        <p class="font-medium">Oturum Geçmişi</p>
                        <p class="text-sm text-muted-foreground">Aktif oturumlarınızı görüntüleyin ve yönetin</p>
                    </div>
                    <button class="rounded-md border bg-background px-4 py-2 text-sm hover:bg-accent">Görüntüle</button>
                </div>
            </div>
        </div>

        <!-- Bildirim Tercihleri -->
        <div class="rounded-lg border bg-card">
            <div class="border-b p-6">
                <h3 class="text-lg font-medium">Bildirim Tercihleri</h3>
                <p class="text-sm text-muted-foreground">Bildirim tercihlerinizi özelleştirin.</p>
            </div>
            <div class="divide-y">
                <div class="flex items-center justify-between p-6">
                    <div>
                        <p class="font-medium">E-posta Bildirimleri</p>
                        <p class="text-sm text-muted-foreground">Önemli güncellemeler için e-posta bildirimleri</p>
                    </div>
                    <div class="flex items-center gap-2">
                        <input type="checkbox" v-model="notifications.email" class="rounded border-muted" />
                    </div>
                </div>
                <div class="flex items-center justify-between p-6">
                    <div>
                        <p class="font-medium">Tarayıcı Bildirimleri</p>
                        <p class="text-sm text-muted-foreground">Anlık tarayıcı bildirimleri</p>
                    </div>
                    <div class="flex items-center gap-2">
                        <input type="checkbox" v-model="notifications.browser" class="rounded border-muted" />
                    </div>
                </div>
                <div class="flex items-center justify-between p-6">
                    <div>
                        <p class="font-medium">SMS Bildirimleri</p>
                        <p class="text-sm text-muted-foreground">Önemli güvenlik bildirimleri için SMS</p>
                    </div>
                    <div class="flex items-center gap-2">
                        <input type="checkbox" v-model="notifications.sms" class="rounded border-muted" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Kaydet Butonu -->
        <div class="flex justify-end">
            <button class="inline-flex items-center justify-center rounded-md bg-primary px-8 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">
                Değişiklikleri Kaydet
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

// Profil bilgileri
const profile = ref({
    firstName: 'Ahmet',
    lastName: 'Yılmaz',
    email: 'admin@example.com',
    phone: '+90 555 123 4567',
    bio: 'E-ticaret platformu süper admin yöneticisi.'
})

// Bildirim tercihleri
const notifications = ref({
    email: true,
    browser: true,
    sms: false
})
</script> 