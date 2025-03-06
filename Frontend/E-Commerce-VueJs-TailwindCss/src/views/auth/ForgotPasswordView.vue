<template>
    <div class="flex min-h-full flex-col justify-center py-12 sm:px-6 lg:px-8">
        <div class="sm:mx-auto sm:w-full sm:max-w-md">
            <!-- Logo -->
            <div class="flex justify-center">
                <div class="h-12 w-12 rounded-full bg-primary/10 flex items-center justify-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                        <path d="M2 16.1A5 5 0 0 1 5.9 20M2 12.05A9 9 0 0 1 9.95 20M2 8V6a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2h-6"/>
                        <line x1="2" y1="20" x2="2" y2="20"/>
                    </svg>
                </div>
            </div>

            <h2 class="mt-6 text-center text-2xl font-bold leading-9 tracking-tight">
                Şifrenizi mi Unuttunuz?
            </h2>
            <p class="mt-2 text-center text-sm text-muted-foreground">
                Endişelenmeyin! E-posta adresinizi girin, size şifre sıfırlama bağlantısı gönderelim.
            </p>
        </div>

        <div class="mt-8 sm:mx-auto sm:w-full sm:max-w-[480px]">
            <div class="bg-card px-6 py-12 shadow-lg sm:rounded-lg sm:px-12">
                <form class="space-y-6" @submit.prevent="handleSubmit">
                    <div class="space-y-2">
                        <div class="relative">
                            <Input
                                id="email"
                                type="email"
                                v-model="form.email"
                                label="E-posta"
                                placeholder="ornek@email.com"
                                autocomplete="email"
                                required
                            />
                            <div class="absolute right-3 top-8 text-muted-foreground">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <rect width="20" height="16" x="2" y="4" rx="2"/>
                                    <path d="m22 7-8.97 5.7a1.94 1.94 0 0 1-2.06 0L2 7"/>
                                </svg>
                            </div>
                        </div>
                        <p class="text-xs text-muted-foreground">
                            Kayıtlı e-posta adresinizi girin. Size şifre sıfırlama talimatlarını göndereceğiz.
                        </p>
                    </div>

                    <div class="space-y-6">
                        <button
                            type="submit"
                            class="flex w-full justify-center rounded-md bg-primary px-3 py-2 text-sm font-semibold text-primary-foreground shadow-sm hover:bg-primary/90 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary h-11"
                            :disabled="loading || !form.email"
                        >
                            <span v-if="loading" class="mr-2">
                                <svg
                                    class="h-5 w-5 animate-spin"
                                    xmlns="http://www.w3.org/2000/svg"
                                    fill="none"
                                    viewBox="0 0 24 24"
                                >
                                    <circle
                                        class="opacity-25"
                                        cx="12"
                                        cy="12"
                                        r="10"
                                        stroke="currentColor"
                                        stroke-width="4"
                                    ></circle>
                                    <path
                                        class="opacity-75"
                                        fill="currentColor"
                                        d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
                                    ></path>
                                </svg>
                            </span>
                            {{ loading ? 'Gönderiliyor...' : 'Sıfırlama Bağlantısı Gönder' }}
                        </button>

                        <div class="text-center">
                            <router-link to="/login" class="text-sm font-medium text-primary hover:text-primary/90">
                                Giriş sayfasına geri dön
                            </router-link>
                        </div>
                    </div>
                </form>
            </div>

            <!-- Başarılı Gönderim Mesajı -->
            <div v-if="showSuccess" class="mt-6">
                <div class="rounded-md bg-green-50 p-4">
                    <div class="flex">
                        <div class="flex-shrink-0">
                            <svg class="h-5 w-5 text-green-400" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                                <path fill-rule="evenodd" d="M10 18a8 8 0 100-16 8 8 0 000 16zm3.857-9.809a.75.75 0 00-1.214-.882l-3.483 4.79-1.88-1.88a.75.75 0 10-1.06 1.061l2.5 2.5a.75.75 0 001.137-.089l4-5.5z" clip-rule="evenodd" />
                            </svg>
                        </div>
                        <div class="ml-3">
                            <p class="text-sm font-medium text-green-800">
                                Şifre sıfırlama bağlantısı e-posta adresinize gönderildi. Lütfen gelen kutunuzu kontrol edin.
                            </p>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Güvenlik Bilgisi -->
            <div class="mt-6 flex items-center justify-center space-x-2 text-sm text-muted-foreground">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                    <rect width="18" height="11" x="3" y="11" rx="2" ry="2" />
                    <path d="M7 11V7a5 5 0 0 1 10 0v4" />
                </svg>
                <span>256-bit SSL güvenli bağlantı</span>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import Input from '@/components/ui/Form/Input.vue'

const loading = ref(false)
const showSuccess = ref(false)
const form = ref({
    email: '',
})

const handleSubmit = async () => {
    loading.value = true
    try {
        // Şifre sıfırlama e-postası gönderme işlemleri
        await new Promise((resolve) => setTimeout(resolve, 1000))
        showSuccess.value = true
        form.value.email = ''
    } catch (error) {
        console.error('Şifre sıfırlama hatası:', error)
    } finally {
        loading.value = false
    }
}
</script> 