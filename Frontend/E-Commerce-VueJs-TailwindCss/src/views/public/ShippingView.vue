<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Başlık Bölümü -->
            <div class="text-center mb-12">
                <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl mb-4">
                    Kargo ve Teslimat
                </h1>
                <p class="text-muted-foreground">
                    Siparişlerinizin teslimat süreçleri hakkında detaylı bilgi
                </p>
            </div>

            <!-- Bilgi Kartları -->
            <div class="grid gap-8 md:grid-cols-3 mb-12">
                <div class="rounded-lg border bg-background p-6 text-center">
                    <div class="text-primary mb-4">
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            class="h-8 w-8 mx-auto"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z"
                            />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold mb-2">Hızlı Teslimat</h3>
                    <p class="text-muted-foreground">2-3 iş günü içinde teslimat</p>
                </div>

                <div class="rounded-lg border bg-background p-6 text-center">
                    <div class="text-primary mb-4">
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            class="h-8 w-8 mx-auto"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M17 9V7a2 2 0 00-2-2H5a2 2 0 00-2 2v6a2 2 0 002 2h2m2 4h10a2 2 0 002-2v-6a2 2 0 00-2-2H9a2 2 0 00-2 2v6a2 2 0 002 2zm7-5a2 2 0 11-4 0 2 2 0 014 0z"
                            />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold mb-2">Ücretsiz Kargo</h3>
                    <p class="text-muted-foreground">150 TL ve üzeri alışverişlerde</p>
                </div>

                <div class="rounded-lg border bg-background p-6 text-center">
                    <div class="text-primary mb-4">
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            class="h-8 w-8 mx-auto"
                            fill="none"
                            viewBox="0 0 24 24"
                            stroke="currentColor"
                        >
                            <path
                                stroke-linecap="round"
                                stroke-linejoin="round"
                                stroke-width="2"
                                d="M9 5H7a2 2 0 00-2 2v12a2 2 0 002 2h10a2 2 0 002-2V7a2 2 0 00-2-2h-2M9 5a2 2 0 002 2h2a2 2 0 002-2M9 5a2 2 0 012-2h2a2 2 0 012 2"
                            />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold mb-2">Kolay Takip</h3>
                    <p class="text-muted-foreground">Online sipariş takibi</p>
                </div>
            </div>

            <!-- Ana İçerik Bölümleri -->
            <div class="space-y-8">
                <!-- Teslimat Süreleri -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Teslimat Süreleri</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>
                            Siparişleriniz, ödemenizin onaylanmasından sonra ortalama 2-3 iş günü
                            içerisinde teslim edilmektedir. Teslimat süreleri, gönderim yapılacak
                            adresin konumuna göre değişiklik gösterebilir.
                        </p>
                        <ul class="mt-4 space-y-2">
                            <li>İstanbul içi: 1-2 iş günü</li>
                            <li>Büyükşehirler: 2-3 iş günü</li>
                            <li>Diğer iller: 3-4 iş günü</li>
                            <li>Uzak mesafe: 4-5 iş günü</li>
                        </ul>
                    </div>
                </div>

                <!-- Kargo Ücretleri -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Kargo Ücretleri</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>
                            150 TL ve üzeri alışverişlerinizde kargo ücretsizdir. 150 TL altındaki
                            siparişlerinizde ise Türkiye'nin her yerine sabit 29.90 TL kargo ücreti
                            uygulanmaktadır.
                        </p>
                        <div class="mt-4">
                            <h3 class="text-lg font-semibold mb-2">Özel Durumlar:</h3>
                            <ul class="space-y-2">
                                <li>Mobilya ve beyaz eşya teslimatları için ek ücret alınabilir</li>
                                <li>Adalar ve özel bölgeler için ek ücret uygulanabilir</li>
                                <li>Ekspres teslimat seçeneği için farklı ücretler geçerlidir</li>
                            </ul>
                        </div>
                    </div>
                </div>

                <!-- Teslimat Bölgeleri -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Teslimat Bölgeleri</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>
                            Türkiye'nin 81 iline teslimat yapılmaktadır. Bazı uzak bölgeler ve
                            adalar için ek süre gerekebilir.
                        </p>
                        <div class="mt-4">
                            <h3 class="text-lg font-semibold mb-2">
                                Teslimat Yapılamayan Durumlar:
                            </h3>
                            <ul class="space-y-2">
                                <li>Yanlış veya eksik adres bilgisi</li>
                                <li>Ulaşılamayan adresler</li>
                                <li>Güvenlik nedeniyle girilemeyen bölgeler</li>
                            </ul>
                        </div>
                    </div>
                </div>

                <!-- Kargo Firmaları -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">
                        Anlaşmalı Kargo Firmaları
                    </h2>
                    <div class="prose prose-muted max-w-none">
                        <p>
                            Siparişleriniz aşağıdaki anlaşmalı kargo firmaları ile gönderilmektedir:
                        </p>
                        <div class="grid gap-6 md:grid-cols-2 mt-4">
                            <div
                                v-for="company in cargoCompanies"
                                :key="company.id"
                                class="flex items-center space-x-4 p-4 border rounded-md"
                            >
                                <img
                                    :src="company.logo"
                                    :alt="company.name"
                                    class="h-8 w-auto object-contain"
                                />
                                <div>
                                    <h4 class="font-medium">{{ company.name }}</h4>
                                    <p class="text-sm text-muted-foreground">
                                        {{ company.description }}
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Sıkça Sorulan Sorular -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Sıkça Sorulan Sorular</h2>
                    <div class="space-y-4">
                        <div
                            v-for="faq in faqs"
                            :key="faq.id"
                            class="rounded-lg border overflow-hidden"
                        >
                            <button
                                @click="toggleFaq(faq.id)"
                                class="w-full px-6 py-4 flex items-center justify-between hover:bg-muted/50 transition-colors"
                            >
                                <span class="font-medium">{{ faq.question }}</span>
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    class="h-5 w-5 transform transition-transform duration-200"
                                    :class="{ 'rotate-180': openFaqs.includes(faq.id) }"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                >
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="2"
                                        d="M19 9l-7 7-7-7"
                                    />
                                </svg>
                            </button>
                            <div
                                v-show="openFaqs.includes(faq.id)"
                                class="px-6 py-4 border-t bg-muted/50"
                            >
                                <p class="text-muted-foreground">{{ faq.answer }}</p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- İletişim Yönlendirme -->
                <div class="rounded-lg border bg-background p-6 text-center">
                    <h2 class="text-xl font-semibold mb-4">Başka Sorularınız mı Var?</h2>
                    <p class="text-muted-foreground mb-6">
                        Kargo ve teslimat ile ilgili diğer sorularınız için bizimle iletişime
                        geçebilirsiniz.
                    </p>
                    <router-link
                        to="/contact"
                        class="inline-flex items-center justify-center rounded-md bg-primary px-6 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
                    >
                        İletişime Geç
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

// Kargo firmaları
const cargoCompanies = [
    {
        id: 1,
        name: 'Yurtiçi Kargo',
        logo: '/images/cargo/yurtici.png',
        description: "Türkiye'nin her yerine teslimat",
    },
    {
        id: 2,
        name: 'Aras Kargo',
        logo: '/images/cargo/aras.png',
        description: 'Güvenilir teslimat hizmeti',
    },
    {
        id: 3,
        name: 'MNG Kargo',
        logo: '/images/cargo/mng.png',
        description: 'Hızlı ve güvenli teslimat',
    },
    {
        id: 4,
        name: 'PTT Kargo',
        logo: '/images/cargo/ptt.png',
        description: 'Yaygın şube ağı',
    },
]

// SSS
const faqs = [
    {
        id: 1,
        question: 'Siparişim ne zaman elime ulaşır?',
        answer: 'Siparişiniz, ödeme onayından sonra 2-3 iş günü içerisinde teslim edilir. Bu süre, teslimat adresinize göre değişiklik gösterebilir.',
    },
    {
        id: 2,
        question: 'Kargo takibini nasıl yapabilirim?',
        answer: 'Siparişiniz kargoya verildikten sonra size SMS ve e-posta ile bilgilendirme yapılacaktır. Bu bilgilendirmede yer alan kargo takip numarası ile siparişinizi takip edebilirsiniz.',
    },
    {
        id: 3,
        question: 'Teslimat sırasında evde değilsem ne olur?',
        answer: 'Kargo görevlisi adresinize geldiğinde sizi telefonla arayacaktır. Eğer ulaşamazsa, size bir bilgilendirme notu bırakarak en yakın şubeye teslim edecektir.',
    },
    {
        id: 4,
        question: 'Kargo ücretini nasıl öğrenebilirim?',
        answer: '150 TL ve üzeri alışverişlerinizde kargo ücretsizdir. 150 TL altındaki siparişlerinizde ise sabit 29.90 TL kargo ücreti uygulanmaktadır.',
    },
]

const openFaqs = ref<number[]>([])

const toggleFaq = (id: number) => {
    const index = openFaqs.value.indexOf(id)
    if (index === -1) {
        openFaqs.value.push(id)
    } else {
        openFaqs.value.splice(index, 1)
    }
}
</script>
