<template>
    <div class="space-y-6">
        <div class="space-y-2">
            <h2 class="text-2xl font-semibold tracking-tight">Şifre Değiştir</h2>
            <p class="text-sm text-muted-foreground">Hesap güvenliğiniz için şifrenizi güncelleyin</p>
        </div>

        <div class="space-y-6 bg-card rounded-lg border border-border p-4 mb-6">
            <div class="space-y-2">
                <Label for="currentPassword">Mevcut Şifre</Label>
                <Input id="currentPassword" v-model="form.currentPassword" type="password" placeholder="••••••••" />
            </div>

            <div class="space-y-2">
                <Label for="newPassword">Yeni Şifre</Label>
                <Input id="newPassword" v-model="form.newPassword" type="password" placeholder="••••••••" />
                <p class="text-xs text-muted-foreground">Şifreniz en az 8 karakter uzunluğunda olmalı ve büyük/küçük harf, rakam ve özel karakter içermelidir.</p>
            </div>

            <div class="space-y-2">
                <Label for="confirmPassword">Yeni Şifre (Tekrar)</Label>
                <Input id="confirmPassword" v-model="form.confirmPassword" type="password" placeholder="••••••••" />
            </div>

            <!-- Şifre Gereksinimleri -->
            <div class="space-y-2">
                <h3 class="text-sm font-medium">Şifre Gereksinimleri</h3>
                <ul class="space-y-1 text-sm">
                    <li class="flex items-center space-x-2">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" :class="['w-4 h-4', isLengthValid ? 'text-green-500' : 'text-muted-foreground']">
                            <polyline points="20 6 9 17 4 12" />
                        </svg>
                        <span :class="{ 'text-muted-foreground': !isLengthValid }">En az 8 karakter</span>
                    </li>
                    <li class="flex items-center space-x-2">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" :class="['w-4 h-4', hasUpperCase ? 'text-green-500' : 'text-muted-foreground']">
                            <polyline points="20 6 9 17 4 12" />
                        </svg>
                        <span :class="{ 'text-muted-foreground': !hasUpperCase }">En az 1 büyük harf</span>
                    </li>
                    <li class="flex items-center space-x-2">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" :class="['w-4 h-4', hasNumber ? 'text-green-500' : 'text-muted-foreground']">
                            <polyline points="20 6 9 17 4 12" />
                        </svg>
                        <span :class="{ 'text-muted-foreground': !hasNumber }">En az 1 rakam</span>
                    </li>
                    <li class="flex items-center space-x-2">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" :class="['w-4 h-4', hasSpecialChar ? 'text-green-500' : 'text-muted-foreground']">
                            <polyline points="20 6 9 17 4 12" />
                        </svg>
                        <span :class="{ 'text-muted-foreground': !hasSpecialChar }">En az 1 özel karakter</span>
                    </li>
                    <li class="flex items-center space-x-2">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" :class="['w-4 h-4', isPasswordMatch ? 'text-green-500' : 'text-muted-foreground']">
                            <polyline points="20 6 9 17 4 12" />
                        </svg>
                        <span :class="{ 'text-muted-foreground': !isPasswordMatch }">Şifreler eşleşmeli</span>
                    </li>
                </ul>
            </div>

            <Button class="w-full" :disabled="!isFormValid" @click="changePassword">Şifreyi Değiştir</Button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import Input from "@/components/ui/Form/Input.vue";
import Button from "@/components/ui/Form/Button.vue";

const form = ref({
    currentPassword: "",
    newPassword: "",
    confirmPassword: "",
});

// Şifre gereksinimleri kontrolleri
const isLengthValid = computed(() => form.value.newPassword.length >= 8);
const hasUpperCase = computed(() => /[A-Z]/.test(form.value.newPassword));
const hasNumber = computed(() => /[0-9]/.test(form.value.newPassword));
const hasSpecialChar = computed(() => /[!@#$%^&*(),.?":{}|<>]/.test(form.value.newPassword));
const isPasswordMatch = computed(() => form.value.newPassword && form.value.newPassword === form.value.confirmPassword);

// Form geçerliliği
const isFormValid = computed(() => form.value.currentPassword && isLengthValid.value && hasUpperCase.value && hasNumber.value && hasSpecialChar.value && isPasswordMatch.value);

const changePassword = () => {
    if (!isFormValid.value) return;

    // TODO: API'ye şifre değiştirme isteği gönder
    console.log("Şifre değiştiriliyor:", form.value);
};
</script>
