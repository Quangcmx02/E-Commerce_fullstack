<template>
    <footer class="border-t bg-card">
        <div class="container py-12 md:py-16">
            <div class="grid gap-8 sm:grid-cols-2 lg:grid-cols-4">
                <!-- Kurumsal -->
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold">Kurumsal</h3>
                    <ul class="space-y-2">
                        <li>
                            <router-link to="/about" class="text-sm text-muted-foreground hover:text-foreground">Hakkımızda</router-link>
                        </li>
                        <li>
                            <router-link to="/contact" class="text-sm text-muted-foreground hover:text-foreground">İletişim</router-link>
                        </li>
                        <li>
                            <router-link to="/careers" class="text-sm text-muted-foreground hover:text-foreground">Kariyer</router-link>
                        </li>
                        <li>
                            <router-link to="/blog" class="text-sm text-muted-foreground hover:text-foreground">Blog</router-link>
                        </li>
                    </ul>
                </div>

                <!-- Müşteri Hizmetleri -->
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold">Müşteri Hizmetleri</h3>
                    <ul class="space-y-2">
                        <li>
                            <router-link to="/faq" class="text-sm text-muted-foreground hover:text-foreground">Sıkça Sorulan Sorular</router-link>
                        </li>
                        <li>
                            <router-link to="/shipping" class="text-sm text-muted-foreground hover:text-foreground">Kargo ve Teslimat</router-link>
                        </li>
                        <li>
                            <router-link to="/return-policy" class="text-sm text-muted-foreground hover:text-foreground">İade ve Değişim</router-link>
                        </li>
                        <li>
                            <router-link to="/privacy-policy" class="text-sm text-muted-foreground hover:text-foreground">Gizlilik Politikası</router-link>
                        </li>
                    </ul>
                </div>

                <!-- İletişim -->
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold">İletişim</h3>
                    <ul class="space-y-2">
                        <li class="flex items-center space-x-2 text-sm text-muted-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                <path d="M22 16.92v3a2 2 0 0 1-2.18 2 19.79 19.79 0 0 1-8.63-3.07 19.5 19.5 0 0 1-6-6 19.79 19.79 0 0 1-3.07-8.67A2 2 0 0 1 4.11 2h3a2 2 0 0 1 2 1.72 12.84 12.84 0 0 0 .7 2.81 2 2 0 0 1-.45 2.11L8.09 9.91a16 16 0 0 0 6 6l1.27-1.27a2 2 0 0 1 2.11-.45 12.84 12.84 0 0 0 2.81.7A2 2 0 0 1 22 16.92z" />
                            </svg>
                            <span>0850 123 4567</span>
                        </li>
                        <li class="flex items-center space-x-2 text-sm text-muted-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                <rect width="20" height="16" x="2" y="4" rx="2" />
                                <path d="m22 7-8.97 5.7a1.94 1.94 0 0 1-2.06 0L2 7" />
                            </svg>
                            <span>info@example.com</span>
                        </li>
                        <li class="flex items-center space-x-2 text-sm text-muted-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                <path d="M20 10c0 6-8 12-8 12s-8-6-8-12a8 8 0 0 1 16 0Z" />
                                <circle cx="12" cy="10" r="3" />
                            </svg>
                            <span>İstanbul, Türkiye</span>
                        </li>
                    </ul>
                </div>

                <!-- Sosyal Medya -->
                <div class="space-y-4">
                    <h3 class="text-lg font-semibold">Bizi Takip Edin</h3>
                    <div class="flex space-x-4">
                        <a href="#" class="text-muted-foreground hover:text-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M18 2h-3a5 5 0 0 0-5 5v3H7v4h3v8h4v-8h3l1-4h-4V7a1 1 0 0 1 1-1h3z" />
                            </svg>
                        </a>
                        <a href="#" class="text-muted-foreground hover:text-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <rect width="20" height="20" x="2" y="2" rx="5" ry="5" />
                                <path d="M16 11.37A4 4 0 1 1 12.63 8 4 4 0 0 1 16 11.37z" />
                                <line x1="17.5" x2="17.51" y1="6.5" y2="6.5" />
                            </svg>
                        </a>
                        <a href="#" class="text-muted-foreground hover:text-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M22 4s-.7 2.1-2 3.4c1.6 10-9.4 17.3-18 11.6 2.2.1 4.4-.6 6-2C3 15.5.5 9.6 3 5c2.2 2.6 5.6 4.1 9 4-.9-4.2 4-6.6 7-3.8 1.1 0 3-1.2 3-1.2z" />
                            </svg>
                        </a>
                        <a href="#" class="text-muted-foreground hover:text-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M16 8a6 6 0 0 1 6 6v7h-4v-7a2 2 0 0 0-2-2 2 2 0 0 0-2 2v7h-4v-7a6 6 0 0 1 6-6z" />
                                <rect width="4" height="12" x="2" y="9" />
                                <circle cx="4" cy="4" r="2" />
                            </svg>
                        </a>
                    </div>
                    <div class="space-y-2">
                        <h4 class="text-sm font-medium">Mobil Uygulamalarımız</h4>
                        <div class="flex space-x-2">
                            <a href="#" class="block">
                                <img src="https://upload.wikimedia.org/wikipedia/commons/3/3c/Download_on_the_App_Store_Badge.svg" alt="App Store" class="h-8" />
                            </a>
                            <a href="#" class="block">
                                <img src="https://upload.wikimedia.org/wikipedia/commons/7/78/Google_Play_Store_badge_EN.svg" alt="Play Store" class="h-8" />
                            </a>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Alt Bilgi -->
            <div class="mt-8 border-t pt-8">
                <div class="flex flex-col items-center justify-between space-y-4 text-center md:flex-row md:space-y-0 md:text-left">
                    <p class="text-sm text-muted-foreground">&copy; 2024 Modern E-Ticaret. Tüm hakları saklıdır.</p>
                </div>
            </div>
        </div>
    </footer>
</template>

<script setup lang="ts">
// Component logic here if needed
</script>
