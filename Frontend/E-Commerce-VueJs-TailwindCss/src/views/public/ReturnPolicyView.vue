<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Başlık Bölümü -->
            <div class="text-center mb-12">
                <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl mb-4">
                    İade ve Değişim
                </h1>
                <p class="text-muted-foreground">
                    Kolay ve hızlı iade/değişim işlemleri için bilmeniz gereken her şey
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
                    <h3 class="text-lg font-semibold mb-2">14 Gün İade Hakkı</h3>
                    <p class="text-muted-foreground">Koşulsuz iade garantisi</p>
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
                                d="M16 15v-1a4 4 0 00-4-4H8m0 0l3 3m-3-3l3-3m9 14V5a2 2 0 00-2-2H6a2 2 0 00-2 2v16l4-2 4 2 4-2 4 2z"
                            />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold mb-2">Ücretsiz İade</h3>
                    <p class="text-muted-foreground">İade kargo ücreti bizden</p>
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
                                d="M9 12l2 2 4-4m6 2a9 9 0 11-18 0 9 9 0 0118 0z"
                            />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold mb-2">Kolay İşlem</h3>
                    <p class="text-muted-foreground">Hızlı onay süreci</p>
                </div>
            </div>

            <!-- Ana İçerik Bölümleri -->
            <div class="space-y-8">
                <!-- İade Süreci -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">İade Süreci</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>
                            Satın aldığınız ürünleri, teslim tarihinden itibaren 14 gün içerisinde
                            iade edebilirsiniz. İade sürecini başlatmak için aşağıdaki adımları
                            takip edebilirsiniz:
                        </p>
                        <ol class="mt-4 space-y-2">
                            <li>Hesabım > Siparişlerim sayfasına gidin</li>
                            <li>İade etmek istediğiniz siparişi seçin</li>
                            <li>"İade Talebi Oluştur" butonuna tıklayın</li>
                            <li>İade nedeninizi seçin ve açıklama ekleyin</li>
                            <li>İade kargo kodunuzu alın</li>
                            <li>Ürünü orijinal ambalajında kargoya verin</li>
                        </ol>
                    </div>
                </div>

                <!-- İade Koşulları -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">İade Koşulları</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>
                            İade işleminin gerçekleşebilmesi için ürünlerin aşağıdaki koşulları
                            sağlaması gerekmektedir:
                        </p>
                        <ul class="mt-4 space-y-2">
                            <li>Ürün kullanılmamış ve hasarsız olmalı</li>
                            <li>Orijinal ambalajı ve etiketleri sağlam olmalı</li>
                            <li>Tüm parçaları eksiksiz olmalı</li>
                            <li>Fatura/fiş ile birlikte gönderilmeli</li>
                        </ul>
                        <div class="mt-6">
                            <h3 class="text-lg font-semibold mb-2">İade Edilemeyen Ürünler:</h3>
                            <ul class="space-y-2">
                                <li>Kullanılmış veya hasar görmüş ürünler</li>
                                <li>Hijyen ürünleri (iç giyim, kozmetik vb.)</li>
                                <li>Özel üretim/kişiselleştirilmiş ürünler</li>
                                <li>Dijital içerik ve yazılımlar</li>
                            </ul>
                        </div>
                    </div>
                </div>

                <!-- Değişim Süreci -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Değişim Süreci</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>Ürün değişimi için iki farklı yöntem kullanabilirsiniz:</p>
                        <div class="mt-4 space-y-6">
                            <div>
                                <h3 class="text-lg font-semibold mb-2">1. Doğrudan Değişim:</h3>
                                <ul class="space-y-2">
                                    <li>Hesabınızdan değişim talebi oluşturun</li>
                                    <li>Yeni beden/renk seçiminizi yapın</li>
                                    <li>Değişim kargo kodunuzu alın</li>
                                    <li>Ürünü kargoya verin</li>
                                </ul>
                            </div>
                            <div>
                                <h3 class="text-lg font-semibold mb-2">2. İade ve Yeni Sipariş:</h3>
                                <ul class="space-y-2">
                                    <li>Mevcut ürünü iade edin</li>
                                    <li>İade tutarı hesabınıza geçsin</li>
                                    <li>Yeni ürün için sipariş verin</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Para İadesi -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Para İadesi</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>
                            İade ettiğiniz ürünlerin bedeli, ürünün depoya ulaşması ve kontrollerin
                            tamamlanmasının ardından en geç 2 iş günü içinde iade edilir.
                        </p>
                        <div class="mt-4">
                            <h3 class="text-lg font-semibold mb-2">İade Yöntemleri:</h3>
                            <ul class="space-y-2">
                                <li>Kredi kartına iade (3-7 iş günü)</li>
                                <li>Banka hesabına havale (1-2 iş günü)</li>
                                <li>Alışveriş kredisi olarak iade (anında)</li>
                            </ul>
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

                <!-- İade Formu Yönlendirme -->
                <div class="rounded-lg border bg-background p-6 text-center">
                    <h2 class="text-xl font-semibold mb-4">
                        İade Talebinde Bulunmak mı İstiyorsunuz?
                    </h2>
                    <p class="text-muted-foreground mb-6">
                        Hemen hesabınıza giriş yapın ve kolayca iade talebinizi oluşturun.
                    </p>
                    <div class="flex flex-col sm:flex-row justify-center gap-4">
                        <router-link
                            to="/customer/orders"
                            class="inline-flex items-center justify-center rounded-md bg-primary px-6 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
                        >
                            İade Talebi Oluştur
                        </router-link>
                        <router-link
                            to="/contact"
                            class="inline-flex items-center justify-center rounded-md border px-6 py-3 text-sm font-medium hover:bg-muted transition-colors"
                        >
                            Yardım Al
                        </router-link>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

// SSS
const faqs = [
    {
        id: 1,
        question: 'İade için kaç günüm var?',
        answer: 'Ürünü teslim aldığınız tarihten itibaren 14 gün içerisinde iade edebilirsiniz. Bu süre yasal iade hakkınızdır.',
    },
    {
        id: 2,
        question: 'İade kargo ücreti ödemem gerekiyor mu?',
        answer: 'Hayır, iade kargo ücreti tarafımızdan karşılanmaktadır. Size verilen iade kodu ile ücretsiz olarak kargoya verebilirsiniz.',
    },
    {
        id: 3,
        question: 'Değişim için ekstra ücret ödeyecek miyim?',
        answer: 'Hayır, aynı ürünün farklı beden veya renk değişimlerinde ekstra ücret talep edilmemektedir.',
    },
    {
        id: 4,
        question: 'Para iadesi ne zaman yapılır?',
        answer: 'İade ettiğiniz ürün depoya ulaştıktan ve kontroller tamamlandıktan sonra en geç 2 iş günü içinde iade işlemi başlatılır. Kredi kartına yapılan iadelerde bankanıza bağlı olarak 3-7 iş günü içinde hesabınıza yansır.',
    },
    {
        id: 5,
        question: 'Hediye olarak aldığım ürünü iade edebilir miyim?',
        answer: 'Evet, hediye olarak alınan ürünleri de iade edebilirsiniz. İade tutarı ürünü satın alan kişinin hesabına iade edilecektir.',
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
