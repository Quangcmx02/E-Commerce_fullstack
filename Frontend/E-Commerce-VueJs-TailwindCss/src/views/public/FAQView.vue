<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Başlık Bölümü -->
            <div class="text-center mb-12">
                <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl mb-4">
                    Sıkça Sorulan Sorular
                </h1>
                <p class="text-muted-foreground">
                    Size yardımcı olabilecek en yaygın soruların cevaplarını burada bulabilirsiniz
                </p>
            </div>

            <!-- Kategori Filtreleri -->
            <div class="mb-8">
                <div class="flex flex-wrap gap-2">
                    <button
                        v-for="category in categories"
                        :key="category.id"
                        @click="selectedCategory = category.id"
                        :class="[
                            'px-4 py-2 rounded-md text-sm font-medium transition-colors duration-200',
                            selectedCategory === category.id
                                ? 'bg-primary text-primary-foreground'
                                : 'bg-background border hover:bg-muted',
                        ]"
                    >
                        {{ category.name }}
                    </button>
                </div>
            </div>

            <!-- Arama Kutusu -->
            <div class="mb-8">
                <div class="relative">
                    <input
                        type="text"
                        v-model="searchQuery"
                        placeholder="Soru ara..."
                        class="w-full px-4 py-3 bg-background border rounded-md focus:ring-primary focus:border-primary pl-10"
                    />
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        class="h-5 w-5 absolute left-3 top-1/2 transform -translate-y-1/2 text-muted-foreground"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                    >
                        <path
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            stroke-width="2"
                            d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"
                        />
                    </svg>
                </div>
            </div>

            <!-- SSS Listesi -->
            <div class="space-y-4">
                <div
                    v-for="question in filteredQuestions"
                    :key="question.id"
                    class="rounded-lg border bg-background overflow-hidden"
                >
                    <button
                        @click="toggleQuestion(question.id)"
                        class="w-full px-6 py-4 flex items-center justify-between hover:bg-muted/50 transition-colors"
                    >
                        <span class="font-medium">{{ question.question }}</span>
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            class="h-5 w-5 transform transition-transform duration-200"
                            :class="{ 'rotate-180': openQuestions.includes(question.id) }"
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
                        v-show="openQuestions.includes(question.id)"
                        class="px-6 py-4 border-t bg-muted/50"
                    >
                        <div class="prose prose-muted max-w-none">
                            <p>{{ question.answer }}</p>
                            <div v-if="question.links && question.links.length > 0" class="mt-4">
                                <p class="font-medium mb-2">Faydalı Bağlantılar:</p>
                                <ul class="list-disc list-inside space-y-1">
                                    <li v-for="(link, index) in question.links" :key="index">
                                        <router-link
                                            :to="link.url"
                                            class="text-primary hover:underline"
                                        >
                                            {{ link.text }}
                                        </router-link>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Boş Durum -->
            <div
                v-if="filteredQuestions.length === 0"
                class="flex flex-col items-center justify-center rounded-lg border bg-background p-12 text-center"
            >
                <div class="text-muted-foreground">
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        class="mx-auto h-12 w-12"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                    >
                        <path
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            stroke-width="2"
                            d="M8.228 9c.549-1.165 2.03-2 3.772-2 2.21 0 4 1.343 4 3 0 1.4-1.278 2.575-3.006 2.907-.542.104-.994.54-.994 1.093m0 3h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                        />
                    </svg>
                </div>
                <h3 class="mt-4 text-lg font-medium">Sonuç Bulunamadı</h3>
                <p class="mt-2 text-sm text-muted-foreground">
                    Aradığınız sorunun cevabını bulamadık. Lütfen farklı bir arama yapın veya
                    bizimle iletişime geçin.
                </p>
                <router-link
                    to="/contact"
                    class="mt-4 inline-flex items-center justify-center rounded-md bg-primary px-6 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
                >
                    İletişime Geç
                </router-link>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

// Örnek kategori verileri
const categories = [
    { id: 'all', name: 'Tüm Sorular' },
    { id: 'orders', name: 'Siparişler' },
    { id: 'shipping', name: 'Kargo ve Teslimat' },
    { id: 'returns', name: 'İade ve Değişim' },
    { id: 'payment', name: 'Ödeme' },
    { id: 'account', name: 'Hesap' },
]

// Örnek soru verileri
const questions = [
    {
        id: 1,
        categoryId: 'orders',
        question: 'Siparişimi nasıl takip edebilirim?',
        answer: 'Siparişinizi "Hesabım" sayfasından veya size gönderilen sipariş takip numarası ile kargo firmasının web sitesinden takip edebilirsiniz. Ayrıca siparişinizin durumu ile ilgili güncellemeleri e-posta ve SMS yoluyla da alacaksınız.',
        links: [
            { text: 'Sipariş Takibi', url: '/customer/orders' },
            { text: 'Sipariş Durumları Hakkında', url: '/customer/orders/track' },
        ],
    },
    {
        id: 2,
        categoryId: 'shipping',
        question: 'Kargo ücreti ne kadar?',
        answer: "150 TL ve üzeri alışverişlerinizde kargo ücretsizdir. 150 TL altındaki siparişlerinizde ise Türkiye'nin her yerine sabit 29.90 TL kargo ücreti uygulanmaktadır.",
    },
    {
        id: 3,
        categoryId: 'returns',
        question: 'Ürün iade sürecini nasıl başlatabilirim?',
        answer: 'Satın aldığınız ürünü 14 gün içinde iade edebilirsiniz. İade sürecini başlatmak için "Hesabım" > "Siparişlerim" sayfasından ilgili siparişi seçip "İade Talebi Oluştur" butonuna tıklayabilirsiniz.',
        links: [
            { text: 'İade Politikası', url: '/customer/orders/return' },
            { text: 'İade Talep Formu', url: '/customer/orders/return-form' },
        ],
    },
    {
        id: 4,
        categoryId: 'payment',
        question: 'Hangi ödeme yöntemlerini kullanabilirim?',
        answer: 'Kredi kartı, banka kartı, havale/EFT ve kapıda ödeme seçeneklerini kullanabilirsiniz. Kredi kartı ile ödemelerinizde 12 aya varan taksit imkanından yararlanabilirsiniz.',
    },
    {
        id: 5,
        categoryId: 'account',
        question: 'Şifremi unuttum, ne yapmalıyım?',
        answer: 'Giriş sayfasındaki "Şifremi Unuttum" bağlantısına tıklayarak e-posta adresinize şifre sıfırlama bağlantısı gönderebilirsiniz.',
        links: [{ text: 'Şifre Sıfırlama', url: '/reset-password' }],
    },
]

const selectedCategory = ref('all')
const searchQuery = ref('')
const openQuestions = ref<number[]>([])

// Filtrelenmiş sorular
const filteredQuestions = computed(() => {
    let filtered = questions

    // Kategori filtresi
    if (selectedCategory.value !== 'all') {
        filtered = filtered.filter((q) => q.categoryId === selectedCategory.value)
    }

    // Arama filtresi
    if (searchQuery.value) {
        const query = searchQuery.value.toLowerCase()
        filtered = filtered.filter(
            (q) =>
                q.question.toLowerCase().includes(query) || q.answer.toLowerCase().includes(query),
        )
    }

    return filtered
})

// Soru açma/kapama
const toggleQuestion = (id: number) => {
    const index = openQuestions.value.indexOf(id)
    if (index === -1) {
        openQuestions.value.push(id)
    } else {
        openQuestions.value.splice(index, 1)
    }
}
</script>
