<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Başlık Bölümü -->
            <div class="text-center mb-12">
                <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl mb-4">
                    Gizlilik Politikası
                </h1>
                <p class="text-muted-foreground">
                    Kişisel verilerinizin güvenliği ve gizliliği bizim için önemlidir
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
                                d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z"
                            />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold mb-2">Güvenli Veri</h3>
                    <p class="text-muted-foreground">SSL şifreleme ile güvenli iletişim</p>
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
                                d="M9 12l2 2 4-4m5.618-4.016A11.955 11.955 0 0112 2.944a11.955 11.955 0 01-8.618 3.04A12.02 12.02 0 003 9c0 5.591 3.824 10.29 9 11.622 5.176-1.332 9-6.03 9-11.622 0-1.042-.133-2.052-.382-3.016z"
                            />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold mb-2">KVKK Uyumlu</h3>
                    <p class="text-muted-foreground">Yasal düzenlemelere tam uyum</p>
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
                                d="M8 7V3m8 4V3m-9 8h10M5 21h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v12a2 2 0 002 2z"
                            />
                        </svg>
                    </div>
                    <h3 class="text-lg font-semibold mb-2">Düzenli Güncelleme</h3>
                    <p class="text-muted-foreground">Güncel yasal uyumluluk</p>
                </div>
            </div>

            <!-- Ana İçerik Bölümleri -->
            <div class="space-y-8">
                <!-- Veri Toplama -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Veri Toplama</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>
                            Hizmetlerimizi kullanırken aşağıdaki kişisel verilerinizi toplamaktayız:
                        </p>
                        <ul class="mt-4 space-y-2">
                            <li>Ad, soyad ve iletişim bilgileri</li>
                            <li>Sipariş ve ödeme bilgileri</li>
                            <li>Teslimat adresi bilgileri</li>
                            <li>Alışveriş tercihleri ve geçmişi</li>
                            <li>Site kullanım verileri ve çerezler</li>
                        </ul>
                    </div>
                </div>

                <!-- Veri Kullanımı -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Veri Kullanımı</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>Topladığımız verileri aşağıdaki amaçlarla kullanmaktayız:</p>
                        <ul class="mt-4 space-y-2">
                            <li>Siparişlerinizi işleme almak ve teslimatını sağlamak</li>
                            <li>Müşteri hizmetleri desteği sunmak</li>
                            <li>Ürün ve hizmetlerimizi geliştirmek</li>
                            <li>Kişiselleştirilmiş pazarlama iletişimi yapmak</li>
                            <li>Yasal yükümlülüklerimizi yerine getirmek</li>
                        </ul>
                    </div>
                </div>

                <!-- Veri Güvenliği -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Veri Güvenliği</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>Verilerinizin güvenliği için aldığımız önlemler:</p>
                        <ul class="mt-4 space-y-2">
                            <li>SSL şifreleme ile güvenli veri iletimi</li>
                            <li>Düzenli güvenlik denetimleri</li>
                            <li>Sınırlı personel erişimi</li>
                            <li>Güvenli veri depolama sistemleri</li>
                            <li>Düzenli yedekleme ve kurtarma prosedürleri</li>
                        </ul>
                    </div>
                </div>

                <!-- Çerez Politikası -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-4">Çerez Politikası</h2>
                    <div class="prose prose-muted max-w-none">
                        <p>Sitemizde kullanılan çerez türleri ve amaçları:</p>
                        <div class="mt-4 space-y-4">
                            <div>
                                <h3 class="text-lg font-semibold mb-2">Zorunlu Çerezler:</h3>
                                <p>Sitenin temel işlevleri için gerekli olan çerezler</p>
                            </div>
                            <div>
                                <h3 class="text-lg font-semibold mb-2">Performans Çerezleri:</h3>
                                <p>
                                    Site performansını ölçmek ve iyileştirmek için kullanılan
                                    çerezler
                                </p>
                            </div>
                            <div>
                                <h3 class="text-lg font-semibold mb-2">İşlevsellik Çerezleri:</h3>
                                <p>Tercihlerinizi hatırlamak için kullanılan çerezler</p>
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
                    <h2 class="text-xl font-semibold mb-4">
                        Gizlilik Politikası Hakkında Sorularınız mı Var?
                    </h2>
                    <p class="text-muted-foreground mb-6">
                        Bizimle iletişime geçin, size yardımcı olmaktan memnuniyet duyarız.
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

// SSS
const faqs = [
    {
        id: 1,
        question: 'Verilerim kimlerle paylaşılıyor?',
        answer: 'Verileriniz, yasal zorunluluklar dışında üçüncü taraflarla paylaşılmamaktadır. Hizmet sağlayıcılarımızla paylaşılan veriler, sadece hizmet sunumu için gerekli olan minimum düzeydedir.',
    },
    {
        id: 2,
        question: 'Verilerimi nasıl güncelleyebilirim?',
        answer: 'Hesabım sayfasından kişisel bilgilerinizi güncelleyebilir veya müşteri hizmetlerimizle iletişime geçerek yardım alabilirsiniz.',
    },
    {
        id: 3,
        question: 'Verilerimin silinmesini nasıl talep edebilirim?',
        answer: 'KVKK kapsamında verilerinizin silinmesini talep etme hakkına sahipsiniz. Bu talebinizi iletişim formu üzerinden veya yazılı olarak bize iletebilirsiniz.',
    },
    {
        id: 4,
        question: 'Çerezleri nasıl yönetebilirim?',
        answer: 'Tarayıcı ayarlarınızdan çerez tercihlerinizi yönetebilirsiniz. Zorunlu çerezler dışındaki tüm çerezleri devre dışı bırakabilirsiniz.',
    },
    {
        id: 5,
        question: 'Gizlilik politikası değişiklikleri nasıl duyuruluyor?',
        answer: 'Gizlilik politikamızda yapılan önemli değişiklikler, web sitemiz üzerinden duyurulur ve gerektiğinde e-posta ile bilgilendirme yapılır.',
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
