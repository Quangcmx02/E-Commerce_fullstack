<template>
    <div class="flex min-h-full flex-col justify-center py-12 sm:px-6 lg:px-8">
        <div class="sm:mx-auto sm:w-full sm:max-w-md">
            <!-- Logo -->
            <div class="flex justify-center">
                <div class="h-12 w-12 rounded-full bg-primary/10 flex items-center justify-center">
                    <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                        <path d="M19 21v-2a4 4 0 0 0-4-4H9a4 4 0 0 0-4 4v2" />
                        <circle cx="12" cy="7" r="4" />
                    </svg>
                </div>
            </div>

            <h2 class="mt-6 text-center text-2xl font-bold leading-9 tracking-tight">Yeni Hesap Oluştur</h2>
            <p class="mt-2 text-center text-sm text-muted-foreground">
                Zaten hesabınız var mı?
                <router-link to="/login" class="font-medium text-primary hover:text-primary/90">Giriş yapın</router-link>
            </p>
        </div>

        <div class="mt-8 sm:mx-auto sm:w-full sm:max-w-[480px]">
            <div class="bg-card px-6 py-12 shadow-lg sm:rounded-lg sm:px-12">
                <form class="space-y-6" @submit.prevent="handleSubmit">
                    <div class="grid grid-cols-2 gap-4">
                        <div class="space-y-2">
                            <Input id="firstName" type="text" v-model="form.firstName" label="Ad" placeholder="Adınız" required />
                        </div>
                        <div class="space-y-2">
                            <Input id="lastName" type="text" v-model="form.lastName" label="Soyad" placeholder="Soyadınız" required />
                        </div>
                    </div>

                    <div class="space-y-2">
                        <Input id="email" type="email" v-model="form.email" label="E-posta" placeholder="ornek@email.com" autocomplete="email" required />
                        <p class="text-xs text-muted-foreground">Size özel kampanyalardan haberdar olmak için e-posta adresinizi girin.</p>
                    </div>

                    <div class="space-y-2">
                        <div class="relative">
                            <Input id="password" :type="showPassword ? 'text' : 'password'" v-model="form.password" label="Şifre" placeholder="••••••••" autocomplete="new-password" required />
                            <button type="button" class="absolute right-3 top-8 text-muted-foreground hover:text-foreground" @mousedown="showPassword = true" @mouseup="showPassword = false" @mouseleave="showPassword = false">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M2 12s3-7 10-7 10 7 10 7-3 7-10 7-10-7-10-7Z" />
                                    <circle cx="12" cy="12" r="3" />
                                </svg>
                            </button>
                        </div>
                        <div class="relative">
                            <Input id="passwordConfirm" :type="showPasswordConfirm ? 'text' : 'password'" v-model="form.passwordConfirm" label="Şifre Tekrar" placeholder="••••••••" autocomplete="new-password" required />
                            <button type="button" class="absolute right-3 top-8 text-muted-foreground hover:text-foreground" @mousedown="showPasswordConfirm = true" @mouseup="showPasswordConfirm = false" @mouseleave="showPasswordConfirm = false">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M2 12s3-7 10-7 10 7 10 7-3 7-10 7-10-7-10-7Z" />
                                    <circle cx="12" cy="12" r="3" />
                                </svg>
                            </button>
                        </div>
                        <div class="grid grid-cols-4 gap-2 mt-2">
                            <div class="h-1 rounded-full" :class="[passwordStrength >= 1 ? 'bg-red-500' : 'bg-border']"></div>
                            <div class="h-1 rounded-full" :class="[passwordStrength >= 2 ? 'bg-orange-500' : 'bg-border']"></div>
                            <div class="h-1 rounded-full" :class="[passwordStrength >= 3 ? 'bg-yellow-500' : 'bg-border']"></div>
                            <div class="h-1 rounded-full" :class="[passwordStrength >= 4 ? 'bg-green-500' : 'bg-border']"></div>
                        </div>
                        <p class="text-xs text-muted-foreground" :class="passwordStrengthColor">
                            {{ passwordStrengthText }}
                        </p>
                    </div>

                    <div class="space-y-4">
                        <Checkbox id="terms" v-model="form.terms" required>
                            <span class="text-sm text-muted-foreground">
                                <router-link to="/terms" class="font-medium text-foreground hover:text-primary">Kullanım Koşulları</router-link>
                                'nı ve
                                <router-link to="/privacy" class="font-medium text-foreground hover:text-primary">Gizlilik Politikası</router-link>
                                'nı okudum ve kabul ediyorum.
                            </span>
                        </Checkbox>

                        <Checkbox id="newsletter" v-model="form.newsletter">
                            <span class="text-sm text-muted-foreground">Kampanya ve fırsatlardan haberdar olmak istiyorum.</span>
                        </Checkbox>
                    </div>

                    <div class="space-y-6">
                        <button type="submit" class="flex w-full justify-center rounded-md bg-primary px-3 py-2 text-sm font-semibold text-primary-foreground shadow-sm hover:bg-primary/90 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-primary h-11" :disabled="loading || !form.terms || !isPasswordMatch">
                            <span v-if="loading" class="mr-2">
                                <svg class="h-5 w-5 animate-spin" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                                    <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                                    <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                                </svg>
                            </span>
                            {{ loading ? "Hesap Oluşturuluyor..." : "Hesap Oluştur" }}
                        </button>

                        <!-- Sosyal Medya ile Kayıt -->
                        <div class="relative">
                            <div class="absolute inset-0 flex items-center">
                                <div class="w-full border-t border-border"></div>
                            </div>
                            <div class="relative flex justify-center text-sm">
                                <span class="bg-card px-2 text-muted-foreground">veya şununla devam et</span>
                            </div>
                        </div>

                        <div class="grid grid-cols-2 gap-4">
                            <button type="button" class="flex w-full items-center justify-center gap-2 rounded-md bg-card px-3 py-2 text-sm font-semibold text-card-foreground shadow-sm ring-1 ring-inset ring-input hover:bg-accent transition-colors" @click="handleGoogleRegister">
                                <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 48 48">
                                    <path fill="#FFC107" d="M43.611 20.083H42V20H24v8h11.303c-1.649 4.657-6.08 8-11.303 8c-6.627 0-12-5.373-12-12s5.373-12 12-12c3.059 0 5.842 1.154 7.961 3.039l5.657-5.657C34.046 6.053 29.268 4 24 4C12.955 4 4 12.955 4 24s8.955 20 20 20s20-8.955 20-20c0-1.341-.138-2.65-.389-3.917z" />
                                    <path fill="#FF3D00" d="m6.306 14.691l6.571 4.819C14.655 15.108 18.961 12 24 12c3.059 0 5.842 1.154 7.961 3.039l5.657-5.657C34.046 6.053 29.268 4 24 4C16.318 4 9.656 8.337 6.306 14.691z" />
                                    <path fill="#4CAF50" d="M24 44c5.166 0 9.86-1.977 13.409-5.192l-6.19-5.238A11.91 11.91 0 0 1 24 36c-5.202 0-9.619-3.317-11.283-7.946l-6.522 5.025C9.505 39.556 16.227 44 24 44z" />
                                    <path fill="#1976D2" d="M43.611 20.083H42V20H24v8h11.303a12.04 12.04 0 0 1-4.087 5.571l.003-.002l6.19 5.238C36.971 39.205 44 34 44 24c0-1.341-.138-2.65-.389-3.917z" />
                                </svg>
                                Google
                            </button>
                            <button type="button" class="flex w-full items-center justify-center gap-2 rounded-md bg-[#1877F2] px-3 py-2 text-sm font-semibold text-white shadow-sm hover:bg-[#1877F2]/90 transition-colors" @click="handleFacebookRegister">
                                <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 24 24" fill="currentColor">
                                    <path d="M9.198 21.5h4v-8.01h3.604l.396-3.98h-4V7.5a1 1 0 0 1 1-1h3v-4h-3a5 5 0 0 0-5 5v2.01h-2l-.396 3.98h2.396v8.01Z" />
                                </svg>
                                Facebook
                            </button>
                        </div>
                    </div>
                </form>
            </div>

            <!-- Güvenlik Bilgisi -->
            <div class="mt-6 flex items-center justify-center space-x-2 text-sm text-muted-foreground">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                    <rect width="18" height="11" x="3" y="11" rx="2" ry="2" />
                    <path d="M7 11V7a5 5 0 0 1 10 0v4" />
                </svg>
                <span>256-bit SSL güvenli kayıt</span>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import Input from "@/components/ui/Form/Input.vue";
import Checkbox from "@/components/ui/Form/Checkbox.vue";

const loading = ref(false);
const showPassword = ref(false);
const showPasswordConfirm = ref(false);

const form = ref({
    firstName: "",
    lastName: "",
    email: "",
    password: "",
    passwordConfirm: "",
    terms: false,
    newsletter: false,
});

const passwordStrength = computed(() => {
    const password = form.value.password;
    let strength = 0;

    if (password.length >= 8) strength++;
    if (/[A-Z]/.test(password)) strength++;
    if (/[0-9]/.test(password)) strength++;
    if (/[^A-Za-z0-9]/.test(password)) strength++;

    return strength;
});

const passwordStrengthText = computed(() => {
    switch (passwordStrength.value) {
        case 0:
            return "Şifreniz çok zayıf";
        case 1:
            return "Şifreniz zayıf";
        case 2:
            return "Şifreniz orta";
        case 3:
            return "Şifreniz güçlü";
        case 4:
            return "Şifreniz çok güçlü";
        default:
            return "";
    }
});

const passwordStrengthColor = computed(() => {
    switch (passwordStrength.value) {
        case 0:
        case 1:
            return "text-red-500";
        case 2:
            return "text-orange-500";
        case 3:
            return "text-yellow-500";
        case 4:
            return "text-green-500";
        default:
            return "";
    }
});

const isPasswordMatch = computed(() => {
    return form.value.password === form.value.passwordConfirm && form.value.password !== "";
});

const handleSubmit = async () => {
    if (!isPasswordMatch.value) return;

    loading.value = true;
    try {
        // Kayıt işlemleri
        await new Promise((resolve) => setTimeout(resolve, 1000));
    } catch (error) {
        console.error("Kayıt hatası:", error);
    } finally {
        loading.value = false;
    }
};

const handleGoogleRegister = () => {
    // Google ile kayıt işlemleri
    console.log("Google ile kayıt yapılıyor...");
};

const handleFacebookRegister = () => {
    // Facebook ile kayıt işlemleri
    console.log("Facebook ile kayıt yapılıyor...");
};
</script>
