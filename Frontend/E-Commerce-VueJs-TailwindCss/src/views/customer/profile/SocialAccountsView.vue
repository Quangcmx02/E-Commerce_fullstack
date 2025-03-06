<template>
    <div class="space-y-6">
        <div class="space-y-2">
            <h2 class="text-2xl font-semibold tracking-tight">Sosyal Hesaplar</h2>
            <p class="text-sm text-muted-foreground">Sosyal medya hesaplarınızı bağlayın ve tek hesapla giriş yapın</p>
        </div>

        <div class="space-y-6">
            <div class="flex items-center justify-between p-4 rounded-lg border">
                <div class="flex items-center space-x-4">
                    <div class="w-10 h-10 flex items-center justify-center rounded-lg bg-red-50">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-5 h-5 text-red-500">
                            <path d="M15.545 6.558a9.42 9.42 0 0 1 .139 1.626c0 2.434-.87 4.492-2.384 5.885h.002C11.978 15.292 10.158 16 8 16A8 8 0 1 1 8 0a7.689 7.689 0 0 1 5.352 2.082l-2.284 2.284A4.347 4.347 0 0 0 8 3.166c-2.087 0-3.86 1.408-4.492 3.304a4.792 4.792 0 0 0 0 3.063h.003c.635 1.893 2.405 3.301 4.492 3.301 1.078 0 2.004-.276 2.722-.764h-.003a3.702 3.702 0 0 0 1.599-2.431H8v-3.08h7.545z" />
                        </svg>
                    </div>
                    <div>
                        <h3 class="font-medium">Google</h3>
                        <p class="text-sm text-muted-foreground">
                            {{ socialAccounts.google ? "ahmet@gmail.com" : "Bağlı değil" }}
                        </p>
                    </div>
                </div>
                <Button :variant="socialAccounts.google ? 'destructive' : 'default'" @click="toggleAccount('google')">
                    {{ socialAccounts.google ? "Bağlantıyı Kes" : "Bağlan" }}
                </Button>
            </div>

            <div class="flex items-center justify-between p-4 rounded-lg border">
                <div class="flex items-center space-x-4">
                    <div class="w-10 h-10 flex items-center justify-center rounded-lg bg-blue-50">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-5 h-5 text-blue-600">
                            <path d="M18 2h-3a5 5 0 0 0-5 5v3H7v4h3v8h4v-8h3l1-4h-4V7a1 1 0 0 1 1-1h3z" />
                        </svg>
                    </div>
                    <div>
                        <h3 class="font-medium">Facebook</h3>
                        <p class="text-sm text-muted-foreground">
                            {{ socialAccounts.facebook ? "Ahmet Bülbül" : "Bağlı değil" }}
                        </p>
                    </div>
                </div>
                <Button :variant="socialAccounts.facebook ? 'destructive' : 'default'" @click="toggleAccount('facebook')">
                    {{ socialAccounts.facebook ? "Bağlantıyı Kes" : "Bağlan" }}
                </Button>
            </div>

            <div class="flex items-center justify-between p-4 rounded-lg border">
                <div class="flex items-center space-x-4">
                    <div class="w-10 h-10 flex items-center justify-center rounded-lg bg-sky-50">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-5 h-5 text-sky-500">
                            <path d="M22 4s-.7 2.1-2 3.4c1.6 10-9.4 17.3-18 11.6 2.2.1 4.4-.6 6-2C3 15.5.5 9.6 3 5c2.2 2.6 5.6 4.1 9 4-.9-4.2 4-6.6 7-3.8 1.1 0 3-1.2 3-1.2z" />
                        </svg>
                    </div>
                    <div>
                        <h3 class="font-medium">Twitter</h3>
                        <p class="text-sm text-muted-foreground">
                            {{ socialAccounts.twitter ? "@ahmetbulbul" : "Bağlı değil" }}
                        </p>
                    </div>
                </div>
                <Button :variant="socialAccounts.twitter ? 'destructive' : 'default'" @click="toggleAccount('twitter')">
                    {{ socialAccounts.twitter ? "Bağlantıyı Kes" : "Bağlan" }}
                </Button>
            </div>

            <div class="flex items-center justify-between p-4 rounded-lg border">
                <div class="flex items-center space-x-4">
                    <div class="w-10 h-10 flex items-center justify-center rounded-lg bg-zinc-50">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="w-5 h-5">
                            <path d="M12 20.94c1.5 0 2.75 1.06 4 1.06 3 0 6-8 6-12.22A4.91 4.91 0 0 0 17 5c-2.22 0-4 1.44-5 2-1-.56-2.78-2-5-2a4.9 4.9 0 0 0-5 4.78C2 14 5 22 8 22c1.25 0 2.5-1.06 4-1.06Z" />
                            <path d="M10 2c1 .5 2 2 2 5" />
                        </svg>
                    </div>
                    <div>
                        <h3 class="font-medium">Apple</h3>
                        <p class="text-sm text-muted-foreground">
                            {{ socialAccounts.apple ? "Apple ID ile bağlı" : "Bağlı değil" }}
                        </p>
                    </div>
                </div>
                <Button :variant="socialAccounts.apple ? 'destructive' : 'default'" @click="toggleAccount('apple')">
                    {{ socialAccounts.apple ? "Bağlantıyı Kes" : "Bağlan" }}
                </Button>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Button from "@/components/ui/Form/Button.vue";

const socialAccounts = ref({
    google: true,
    facebook: false,
    twitter: true,
    apple: false,
});

const toggleAccount = (platform: keyof typeof socialAccounts.value) => {
    socialAccounts.value[platform] = !socialAccounts.value[platform];
    // TODO: API'ye bağlanma/bağlantıyı kesme isteği gönder
    console.log(`${platform} hesabı ${socialAccounts.value[platform] ? "bağlandı" : "bağlantısı kesildi"}`);
};
</script>
