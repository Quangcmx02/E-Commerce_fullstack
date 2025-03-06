<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Üst Bilgi -->
            <div class="mb-8">
                <router-link
                    to="/careers"
                    class="inline-flex items-center text-sm text-muted-foreground hover:text-primary mb-4"
                >
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        class="h-4 w-4 mr-1"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                    >
                        <path
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            stroke-width="2"
                            d="M10 19l-7-7m0 0l7-7m-7 7h18"
                        />
                    </svg>
                    Kariyer Fırsatlarına Dön
                </router-link>

                <div class="rounded-lg border bg-background p-6">
                    <div class="flex flex-col md:flex-row md:items-start md:justify-between">
                        <div>
                            <h1 class="text-2xl font-bold tracking-tight">{{ position.title }}</h1>
                            <div class="mt-2 flex items-center space-x-4 text-muted-foreground">
                                <span>{{ position.department }}</span>
                                <span>•</span>
                                <span>{{ position.location }}</span>
                            </div>
                            <div class="mt-4 flex flex-wrap gap-2">
                                <span
                                    v-for="(tag, index) in position.tags"
                                    :key="index"
                                    class="inline-flex items-center rounded-full bg-muted px-2.5 py-0.5 text-xs font-medium"
                                >
                                    {{ tag }}
                                </span>
                            </div>
                        </div>
                        <button
                            @click="showApplicationForm = true"
                            class="mt-4 md:mt-0 inline-flex items-center justify-center rounded-md bg-primary px-6 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
                        >
                            Başvuru Yap
                        </button>
                    </div>
                </div>
            </div>

            <!-- İçerik -->
            <div class="grid gap-8 md:grid-cols-3">
                <!-- Sol Taraf - Pozisyon Detayları -->
                <div class="md:col-span-2 space-y-8">
                    <div class="rounded-lg border bg-background p-6">
                        <h2 class="text-xl font-semibold mb-4">Pozisyon Hakkında</h2>
                        <div class="prose prose-muted max-w-none">
                            <p>{{ position.description }}</p>
                        </div>
                    </div>

                    <div class="rounded-lg border bg-background p-6">
                        <h2 class="text-xl font-semibold mb-4">Sorumluluklar</h2>
                        <ul class="list-disc list-inside space-y-2 text-muted-foreground">
                            <li v-for="(item, index) in position.responsibilities" :key="index">
                                {{ item }}
                            </li>
                        </ul>
                    </div>

                    <div class="rounded-lg border bg-background p-6">
                        <h2 class="text-xl font-semibold mb-4">Gereksinimler</h2>
                        <ul class="list-disc list-inside space-y-2 text-muted-foreground">
                            <li v-for="(item, index) in position.requirements" :key="index">
                                {{ item }}
                            </li>
                        </ul>
                    </div>
                </div>

                <!-- Sağ Taraf - Şirket Bilgileri -->
                <div class="space-y-6">
                    <div class="rounded-lg border bg-background p-6">
                        <h2 class="text-lg font-semibold mb-4">Çalışma Şekli</h2>
                        <div class="space-y-3 text-muted-foreground">
                            <div class="flex items-center space-x-2">
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    class="h-5 w-5"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                >
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="2"
                                        d="M21 13.255A23.931 23.931 0 0112 15c-3.183 0-6.22-.62-9-1.745M16 6V4a2 2 0 00-2-2h-4a2 2 0 00-2 2v2m4 6h.01M5 20h14a2 2 0 002-2V8a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"
                                    />
                                </svg>
                                <span>{{ position.type }}</span>
                            </div>
                            <div class="flex items-center space-x-2">
                                <svg
                                    xmlns="http://www.w3.org/2000/svg"
                                    class="h-5 w-5"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                    stroke="currentColor"
                                >
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="2"
                                        d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z"
                                    />
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="2"
                                        d="M15 11a3 3 0 11-6 0 3 3 0 016 0z"
                                    />
                                </svg>
                                <span>{{ position.location }}</span>
                            </div>
                        </div>
                    </div>

                    <div class="rounded-lg border bg-background p-6">
                        <h2 class="text-lg font-semibold mb-4">Başvuru Son Tarihi</h2>
                        <div class="flex items-center space-x-2 text-muted-foreground">
                            <svg
                                xmlns="http://www.w3.org/2000/svg"
                                class="h-5 w-5"
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
                            <span>{{ position.deadline }}</span>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Başvuru Formu Modal -->
            <div
                v-if="showApplicationForm"
                class="fixed inset-0 bg-background/80 backdrop-blur-sm z-50"
            >
                <div class="fixed inset-0 flex items-center justify-center p-4">
                    <div class="relative bg-background rounded-lg shadow-lg max-w-lg w-full p-6 border">
                        <button
                            @click="showApplicationForm = false"
                            class="absolute right-4 top-4 text-muted-foreground hover:text-foreground"
                        >
                            <svg
                                xmlns="http://www.w3.org/2000/svg"
                                class="h-6 w-6"
                                fill="none"
                                viewBox="0 0 24 24"
                                stroke="currentColor"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M6 18L18 6M6 6l12 12"
                                />
                            </svg>
                        </button>

                        <h2 class="text-xl font-semibold mb-6">Pozisyona Başvur</h2>

                        <form @submit.prevent="handleSubmit" class="space-y-4">
                            <div>
                                <label for="name" class="block text-sm font-medium mb-1"
                                    >Ad Soyad</label
                                >
                                <input
                                    type="text"
                                    id="name"
                                    v-model="form.name"
                                    class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                    required
                                />
                            </div>

                            <div>
                                <label for="email" class="block text-sm font-medium mb-1"
                                    >E-posta</label
                                >
                                <input
                                    type="email"
                                    id="email"
                                    v-model="form.email"
                                    class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                    required
                                />
                            </div>

                            <div>
                                <label for="phone" class="block text-sm font-medium mb-1"
                                    >Telefon</label
                                >
                                <input
                                    type="tel"
                                    id="phone"
                                    v-model="form.phone"
                                    class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                    required
                                />
                            </div>

                            <div>
                                <label for="cv" class="block text-sm font-medium mb-1">CV</label>
                                <input
                                    type="file"
                                    id="cv"
                                    accept=".pdf,.doc,.docx"
                                    @change="handleFileChange"
                                    class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                    required
                                />
                            </div>

                            <div>
                                <label for="coverLetter" class="block text-sm font-medium mb-1"
                                    >Ön Yazı</label
                                >
                                <textarea
                                    id="coverLetter"
                                    v-model="form.coverLetter"
                                    rows="4"
                                    class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                    required
                                ></textarea>
                            </div>

                            <div class="flex justify-end space-x-4 mt-6">
                                <button
                                    type="button"
                                    @click="showApplicationForm = false"
                                    class="px-4 py-2 border rounded-md hover:bg-muted transition-colors"
                                >
                                    İptal
                                </button>
                                <button
                                    type="submit"
                                    class="px-4 py-2 bg-primary text-primary-foreground rounded-md hover:bg-primary/90 transition-colors"
                                >
                                    Başvuru Yap
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { useRoute } from 'vue-router'

const route = useRoute()
const showApplicationForm = ref(false)

// Örnek pozisyon verisi
const position = ref({
    id: 1,
    title: 'Senior Frontend Developer',
    department: 'Yazılım Geliştirme',
    location: 'İstanbul',
    type: 'Tam Zamanlı',
    deadline: '30 Haziran 2024',
    tags: ['Vue.js', 'TypeScript', 'Tailwind CSS'],
    description:
        'Yenilikçi e-ticaret projelerimizde görev alacak, modern web teknolojilerine hakim, kullanıcı deneyimini ön planda tutan bir Frontend Developer arıyoruz.',
    responsibilities: [
        'Modern frontend teknolojilerini kullanarak web uygulamaları geliştirmek',
        'Mevcut uygulamaların performans optimizasyonunu yapmak',
        'UI/UX ekibiyle birlikte çalışarak tasarımları uygulamak',
        "Kod kalitesini artırmak için best practice'leri uygulamak",
        'Junior geliştiricilere mentorluk yapmak',
    ],
    requirements: [
        'En az 5 yıl frontend geliştirme deneyimi',
        'Vue.js ve ekosistemi konusunda derin bilgi',
        'TypeScript deneyimi',
        'Modern CSS teknolojilerine hakimiyet',
        'Git versiyon kontrol sistemi deneyimi',
        'Responsive tasarım prensipleri bilgisi',
        'Temiz kod yazma ve dokümantasyon alışkanlığı',
    ],
})

const form = ref({
    name: '',
    email: '',
    phone: '',
    cv: null as File | null,
    coverLetter: '',
})

const handleFileChange = (event: Event) => {
    const target = event.target as HTMLInputElement
    if (target.files) {
        form.value.cv = target.files[0]
    }
}

const handleSubmit = () => {
    // Form gönderme işlemi burada yapılacak
    console.log('Form data:', {
        ...form.value,
        positionId: position.value.id,
    })
    showApplicationForm.value = false
}

onMounted(() => {
    // Gerçek uygulamada burada API'den pozisyon detayları çekilecek
    console.log('Position ID:', route.params.id)
})
</script>
