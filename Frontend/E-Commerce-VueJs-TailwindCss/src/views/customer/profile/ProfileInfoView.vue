<template>
    <div class="space-y-6">
        <div class="space-y-2">
            <h2 class="text-2xl font-semibold tracking-tight">Profil Bilgileri</h2>
            <p class="text-sm text-muted-foreground">Kişisel bilgilerinizi güncelleyin</p>
        </div>

        <div class="space-y-6 bg-card rounded-lg border border-border p-4 mb-6">
            <!-- Profil Fotoğrafı -->
            <div class="flex items-center space-x-4">
                <img src="https://api.dicebear.com/7.x/avataaars/svg?seed=Felix" alt="Profil Fotoğrafı" class="w-24 h-24 rounded-full" />
                <div class="space-y-2">
                    <h3 class="text-lg font-medium">Profil Fotoğrafı</h3>
                    <div class="flex space-x-2">
                        <Button>Fotoğraf Yükle</Button>
                        <Button variant="outline">Kaldır</Button>
                    </div>
                </div>
            </div>

            <!-- Kişisel Bilgiler -->
            <div class="space-y-4">
                <div class="grid gap-4 sm:grid-cols-2">
                    <div class="space-y-2">
                        <Label for="firstName">Ad</Label>
                        <Input id="firstName" v-model="profile.firstName" placeholder="Adınız" />
                    </div>
                    <div class="space-y-2">
                        <Label for="lastName">Soyad</Label>
                        <Input id="lastName" v-model="profile.lastName" placeholder="Soyadınız" />
                    </div>
                </div>

                <div class="space-y-2">
                    <Label for="email">E-posta</Label>
                    <Input id="email" v-model="profile.email" type="email" placeholder="ornek@email.com" />
                </div>

                <div class="space-y-2">
                    <Label for="phone">Telefon</Label>
                    <Input id="phone" v-model="profile.phone" type="tel" placeholder="0555 555 55 55" />
                </div>

                <div class="space-y-2">
                    <Label for="birthDate">Doğum Tarihi</Label>
                    <Input id="birthDate" v-model="profile.birthDate" type="date" />
                </div>

                <div class="space-y-2">
                    <Label for="gender">Cinsiyet</Label>
                    <Select id="gender" v-model="profile.gender">
                        <option value="">Seçiniz</option>
                        <option value="male">Erkek</option>
                        <option value="female">Kadın</option>
                        <option value="other">Diğer</option>
                    </Select>
                </div>
            </div>

            <!-- İletişim Tercihleri -->
            <div class="space-y-4">
                <h3 class="text-lg font-medium">İletişim Tercihleri</h3>
                <div class="space-y-2">
                    <div class="flex items-center space-x-2">
                        <Checkbox id="newsletter" v-model="profile.newsletter" />
                        <Label for="newsletter">E-bülten ve kampanyalardan haberdar olmak istiyorum</Label>
                    </div>
                    <div class="flex items-center space-x-2">
                        <Checkbox id="smsNotification" v-model="profile.smsNotification" />
                        <Label for="smsNotification">SMS ile bilgilendirme almak istiyorum</Label>
                    </div>
                </div>
            </div>

            <!-- Kaydet Butonu -->
            <div class="flex justify-end">
                <Button @click="saveProfile">Değişiklikleri Kaydet</Button>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Input from "@/components/ui/Form/Input.vue";
import Button from "@/components/ui/Form/Button.vue";
import Select from "@/components/ui/Form/Select.vue";
import Checkbox from "@/components/ui/Form/Checkbox.vue";

const profile = ref({
    firstName: "Ahmet",
    lastName: "Bülbül",
    email: "ahmet@email.com",
    phone: "0555 123 45 67",
    birthDate: "1990-01-01",
    gender: "male",
    newsletter: true,
    smsNotification: false,
});

const saveProfile = () => {
    // TODO: API'ye kaydetme işlemi
    console.log("Profil kaydediliyor:", profile.value);
};
</script>
