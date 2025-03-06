<template>
    <div class="flex min-h-full flex-col justify-center py-12 sm:px-6 lg:px-8">
        <div class="sm:mx-auto sm:w-full sm:max-w-md">
            <!-- Logo -->
            <div class="flex justify-center">
                <div class="h-12 w-12 rounded-full bg-primary/10 flex items-center justify-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                        <path d="M17 11h1a3 3 0 0 1 0 6h-1" />
                        <path d="M9 12v6" />
                        <path d="M13 12v6" />
                        <path d="M14 7.5c-1 0-1.44.5-3 .5s-2-.5-3-.5-1.72.5-2.5.5a2.5 2.5 0 0 1 0-5c.78 0 1.57.5 2.5.5S9.44 3 11 3s2 .5 3 .5 1.72-.5 2.5-.5a2.5 2.5 0 0 1 0 5c-.78 0-1.5-.5-2.5-.5Z" />
                        <path d="M5 8v12a2 2 0 0 0 2 2h8a2 2 0 0 0 2-2V8" />
                    </svg>
                </div>
            </div>

            <h2 class="mt-6 text-center text-2xl font-bold leading-9 tracking-tight">Hesabınıza Giriş Yapın</h2>
            <p class="mt-2 text-center text-sm text-muted-foreground">Hoş geldiniz! Lütfen bilgilerinizi girin.</p>
        </div>

        <div class="mt-8 sm:mx-auto sm:w-full sm:max-w-[480px]">
            <div class="bg-card px-6 py-12 shadow-lg sm:rounded-lg sm:px-12">
                <form class="space-y-6" @submit.prevent="handleSubmit">
                    <div class="space-y-2">
                        <Input id="email" type="email" v-model="form.email" label="E-posta" placeholder="ornek@email.com" autocomplete="email" required />
                        <p class="text-xs text-muted-foreground">Size özel kampanyalardan haberdar olmak için e-posta adresinizi girin.</p>
                    </div>

                    <div class="space-y-2">
                        <div class="relative">
                            <Input id="password" :type="showPassword ? 'text' : 'password'" v-model="form.password" label="Şifre" placeholder="••••••••" autocomplete="current-password" required />
                            <button type="button" class="absolute right-3 top-8 text-muted-foreground hover:text-foreground" @mousedown="showPassword = true" @mouseup="showPassword = false" @mouseleave="showPassword = false">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M2 12s3-7 10-7 10 7 10 7-3 7-10 7-10-7-10-7Z" />
                                    <circle cx="12" cy="12" r="3" />
                                </svg>
                            </button>
                        </div>
                        <div class="flex items-center justify-between">
                            <Checkbox id="remember" v-model="form.remember" label="Beni Hatırla" />
                            <router-link to="/forgot-password" class="text-sm font-medium text-primary hover:text-primary/90">Şifremi Unuttum</router-link>
                        </div>
                    </div>

                    <div class="space-y-6">
                        <button type="submit" class="flex w-full justify-center rounded-md bg-primary px-3 py-2 text-sm font-semibold text-primary-foreground shadow-sm hover:bg-primary/90 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary h-11" :disabled="loading">
                            <span v-if="loading" class="mr-2">
                                <svg class="h-5 w-5 animate-spin" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                                    <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                                    <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                </svg>
                            </span>
                            {{ loading ? "Giriş Yapılıyor..." : "Giriş Yap" }}
                        </button>

                        <!-- Sosyal Medya ile Giriş -->
                        <div class="relative">
                            <div class="absolute inset-0 flex items-center">
                                <div class="w-full border-t border-border"></div>
                            </div>
                            <div class="relative flex justify-center text-sm">
                                <span class="bg-card px-2 text-muted-foreground">veya şununla devam et</span>
                            </div>
                        </div>

                        <div class="grid grid-cols-2 gap-4">
                            <button type="button" class="flex w-full items-center justify-center gap-2 rounded-md bg-card px-3 py-2 text-sm font-semibold text-card-foreground shadow-sm ring-1 ring-inset ring-input hover:bg-accent transition-colors" @click="handleGoogleLogin">
                                <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 48 48">
                                    <path fill="#FFC107" d="M43.611 20.083H42V20H24v8h11.303c-1.649 4.657-6.08 8-11.303 8c-6.627 0-12-5.373-12-12s5.373-12 12-12c3.059 0 5.842 1.154 7.961 3.039l5.657-5.657C34.046 6.053 29.268 4 24 4C12.955 4 4 12.955 4 24s8.955 20 20 20s20-8.955 20-20c0-1.341-.138-2.65-.389-3.917z" />
                                    <path fill="#FF3D00" d="m6.306 14.691l6.571 4.819C14.655 15.108 18.961 12 24 12c3.059 0 5.842 1.154 7.961 3.039l5.657-5.657C34.046 6.053 29.268 4 24 4C16.318 4 9.656 8.337 6.306 14.691z" />
                                    <path fill="#4CAF50" d="M24 44c5.166 0 9.86-1.977 13.409-5.192l-6.19-5.238A11.91 11.91 0 0 1 24 36c-5.202 0-9.619-3.317-11.283-7.946l-6.522 5.025C9.505 39.556 16.227 44 24 44z" />
                                    <path fill="#1976D2" d="M43.611 20.083H42V20H24v8h11.303a12.04 12.04 0 0 1-4.087 5.571l.003-.002l6.19 5.238C36.971 39.205 44 34 44 24c0-1.341-.138-2.65-.389-3.917z" />
                                </svg>
                                Google
                            </button>
                            <button type="button" class="flex w-full items-center justify-center gap-2 rounded-md bg-[#1877F2] px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-[#1877F2]/90 transition-colors" @click="handleFacebookLogin">
                                <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 24 24" fill="currentColor">
                                    <path d="M9.198 21.5h4v-8.01h3.604l.396-3.98h-4V7.5a1 1 0 0 1 1-1h3v-4h-3a5 5 0 0 0-5 5v2.01h-2l-.396 3.98h2.396v8.01Z" />
                                </svg>
                                Facebook
                            </button>
                        </div>
                    </div>
                </form>

                <div class="mt-6">
                    <div class="relative">
                        <div class="absolute inset-0 flex items-center">
                            <div class="w-full border-t border-border"></div>
                        </div>
                        <div class="relative flex justify-center text-sm">
                            <span class="bg-card px-2 text-muted-foreground">Hesabınız yok mu?</span>
                        </div>
                    </div>

                    <div class="mt-6">
                        <router-link to="/register" class="flex w-full justify-center rounded-md bg-card px-3 py-2 text-sm font-semibold text-card-foreground shadow-sm ring-1 ring-inset ring-input hover:bg-accent transition-colors h-11 items-center">Hesap Oluştur</router-link>
                    </div>
                </div>
            </div>

            <!-- Güvenlik Bilgisi -->
            <div class="mt-6 flex items-center justify-center space-x-2 text-sm text-muted-foreground">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                    <rect width="18" height="11" x="3" y="11" rx="2" ry="2" />
                    <path d="M7 11V7a5 5 0 0 1 10 0v4" />
                </svg>
                <span>256-bit SSL güvenli giriş</span>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Input from "@/components/ui/Form/Input.vue";
import Checkbox from "@/components/ui/Form/Checkbox.vue";

const loading = ref(false);
const showPassword = ref(false);
const form = ref({
    email: "",
    password: "",
    remember: false,
});

const handleSubmit = async () => {
    loading.value = true;
    try {
        // Giriş işlemleri
        await new Promise((resolve) => setTimeout(resolve, 1000));
    } catch (error) {
        console.error("Giriş hatası:", error);
    } finally {
        loading.value = false;
    }
};

const handleGoogleLogin = () => {
    // Google ile giriş işlemleri
    console.log("Google ile giriş yapılıyor...");
};

const handleFacebookLogin = () => {
    // Facebook ile giriş işlemleri
    console.log("Facebook ile giriş yapılıyor...");
};
</script>
