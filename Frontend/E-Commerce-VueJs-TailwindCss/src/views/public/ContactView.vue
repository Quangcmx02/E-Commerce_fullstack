<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Başlık Bölümü -->
            <div class="text-center mb-12">
                <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl mb-4">
                    Bizimle İletişime Geçin
                </h1>
                <p class="text-muted-foreground">
                    Sorularınız için bize ulaşın, en kısa sürede size dönüş yapacağız.
                </p>
            </div>

            <!-- İletişim Bilgileri ve Form Grid -->
            <div class="grid md:grid-cols-2 gap-8">
                <!-- İletişim Bilgileri -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-6">İletişim Bilgilerimiz</h2>

                    <div class="space-y-4">
                        <div class="flex items-start space-x-4">
                            <div class="text-primary">
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
                                        d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z"
                                    />
                                    <path
                                        stroke-linecap="round"
                                        stroke-linejoin="round"
                                        stroke-width="2"
                                        d="M15 11a3 3 0 11-6 0 3 3 0 016 0z"
                                    />
                                </svg>
                            </div>
                            <div>
                                <h3 class="font-medium">Adres</h3>
                                <p class="text-muted-foreground">
                                    Atatürk Cad. No:123<br />Kadıköy, İstanbul
                                </p>
                            </div>
                        </div>

                        <div class="flex items-start space-x-4">
                            <div class="text-primary">
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
                                        d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"
                                    />
                                </svg>
                            </div>
                            <div>
                                <h3 class="font-medium">E-posta</h3>
                                <p class="text-muted-foreground">info@ecommerce.com</p>
                            </div>
                        </div>

                        <div class="flex items-start space-x-4">
                            <div class="text-primary">
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
                                        d="M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z"
                                    />
                                </svg>
                            </div>
                            <div>
                                <h3 class="font-medium">Telefon</h3>
                                <p class="text-muted-foreground">+90 (212) 123 45 67</p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- İletişim Formu -->
                <div class="rounded-lg border bg-background p-6">
                    <h2 class="text-2xl font-bold tracking-tight mb-6">Mesaj Gönderin</h2>

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
                            <label for="subject" class="block text-sm font-medium mb-1">Konu</label>
                            <input
                                type="text"
                                id="subject"
                                v-model="form.subject"
                                class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                required
                            />
                        </div>

                        <div>
                            <label for="message" class="block text-sm font-medium mb-1"
                                >Mesajınız</label
                            >
                            <textarea
                                id="message"
                                v-model="form.message"
                                rows="4"
                                class="w-full px-4 py-2 bg-background border rounded-md focus:ring-primary focus:border-primary"
                                required
                            ></textarea>
                        </div>

                        <button
                            type="submit"
                            class="w-full bg-primary text-primary-foreground hover:bg-primary/90 px-6 py-3 rounded-md transition-colors duration-200"
                        >
                            Mesaj Gönder
                        </button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const form = ref({
    name: '',
    email: '',
    subject: '',
    message: '',
})

const handleSubmit = () => {
    // Form gönderme işlemi burada yapılacak
    console.log('Form data:', form.value)
}
</script>
