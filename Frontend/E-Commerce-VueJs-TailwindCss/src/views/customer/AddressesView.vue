<template>
    <div class="flex min-h-screen">
        <!-- Ana İçerik -->
        <div class="flex-1">
            <div class="container py-6">
                <div class="flex items-center justify-between">
                    <div>
                        <h2 class="text-2xl font-bold">Adreslerim</h2>
                        <p class="text-sm text-muted-foreground">Teslimat adreslerinizi buradan yönetebilirsiniz.</p>
                    </div>
                    <Button @click="showAddAddressModal = true">Yeni Adres Ekle</Button>
                </div>

                <!-- Adresler -->
                <div class="mt-6">
                    <div v-if="addresses.length === 0" class="text-center py-12">
                        <div class="rounded-full bg-primary/10 p-3 text-primary w-12 h-12 mx-auto mb-4 flex items-center justify-center">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                <path d="M20 10c0 6-8 12-8 12s-8-6-8-12a8 8 0 0 1 16 0Z" />
                                <circle cx="12" cy="10" r="3" />
                            </svg>
                        </div>
                        <h3 class="text-lg font-semibold mb-1">Henüz kayıtlı adresiniz yok</h3>
                        <p class="text-sm text-muted-foreground mb-4">Siparişlerinizin teslimatı için en az bir adres eklemelisiniz.</p>
                        <Button @click="showAddAddressModal = true">Yeni Adres Ekle</Button>
                    </div>

                    <div v-else class="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
                        <div v-for="address in addresses" :key="address.id" class="rounded-lg border bg-card p-6">
                            <div class="flex items-start justify-between">
                                <div>
                                    <h3 class="font-semibold">{{ address.title }}</h3>
                                    <p class="text-sm text-muted-foreground mt-1">{{ address.fullName }}</p>
                                </div>
                                <div class="flex items-center space-x-2">
                                    <button class="rounded-full p-2 hover:bg-muted" @click="editAddress(address)">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z" />
                                            <path d="m15 5 4 4" />
                                        </svg>
                                    </button>
                                    <button class="rounded-full p-2 hover:bg-muted text-destructive" @click="deleteAddress(address)">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M3 6h18" />
                                            <path d="M19 6v14c0 1-1 2-2 2H7c-1 0-2-1-2-2V6" />
                                            <path d="M8 6V4c0-1 1-2 2-2h4c1 0 2 1 2 2v2" />
                                        </svg>
                                    </button>
                                </div>
                            </div>
                            <div class="mt-4 space-y-2">
                                <p class="text-sm">{{ address.phone }}</p>
                                <p class="text-sm">
                                    {{ address.address }}
                                </p>
                                <p class="text-sm">{{ address.district }}/{{ address.city }}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Adres Ekleme/Düzenleme Modal -->
        <div v-if="showAddAddressModal" class="fixed inset-0 z-50 flex items-center justify-center bg-black/50">
            <div class="w-full max-w-lg rounded-lg bg-background p-6">
                <div class="flex items-center justify-between">
                    <h3 class="text-lg font-semibold">
                        {{ selectedAddress ? "Adresi Düzenle" : "Yeni Adres Ekle" }}
                    </h3>
                    <button class="rounded-full p-2 hover:bg-muted" @click="closeAddressModal">
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M18 6 6 18" />
                            <path d="m6 6 12 12" />
                        </svg>
                    </button>
                </div>
                <form @submit.prevent="saveAddress" class="mt-6 space-y-4">
                    <div class="grid gap-4 md:grid-cols-2">
                        <div class="space-y-2">
                            <Label for="title">Adres Başlığı</Label>
                            <Input id="title" v-model="addressForm.title" placeholder="Ev, İş vb." required />
                        </div>
                        <div class="space-y-2">
                            <Label for="fullName">Ad Soyad</Label>
                            <Input id="fullName" v-model="addressForm.fullName" placeholder="Ad Soyad" required />
                        </div>
                    </div>
                    <div class="space-y-2">
                        <Label for="phone">Telefon</Label>
                        <Input id="phone" v-model="addressForm.phone" placeholder="0(5XX) XXX XX XX" required />
                    </div>
                    <div class="space-y-2">
                        <Label for="address">Adres</Label>
                        <Textarea id="address" v-model="addressForm.address" placeholder="Açık adres" required />
                    </div>
                    <div class="grid gap-4 md:grid-cols-2">
                        <div class="space-y-2">
                            <Label for="city">İl</Label>
                            <Select id="city" v-model="addressForm.city" required>
                                <option value="">İl Seçin</option>
                                <option value="İstanbul">İstanbul</option>
                                <option value="Ankara">Ankara</option>
                                <option value="İzmir">İzmir</option>
                            </Select>
                        </div>
                        <div class="space-y-2">
                            <Label for="district">İlçe</Label>
                            <Select id="district" v-model="addressForm.district" required>
                                <option value="">İlçe Seçin</option>
                                <option value="Kadıköy">Kadıköy</option>
                                <option value="Beşiktaş">Beşiktaş</option>
                                <option value="Üsküdar">Üsküdar</option>
                            </Select>
                        </div>
                    </div>
                    <div class="flex justify-end space-x-2">
                        <Button variant="outline" type="button" @click="closeAddressModal">İptal</Button>
                        <Button type="submit">Kaydet</Button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref } from "vue";
import Button from "@/components/ui/Form/Button.vue";
import Input from "@/components/ui/Form/Input.vue";
import Select from "@/components/ui/Form/Select.vue";
import Textarea from "@/components/ui/Form/Textarea.vue";

const showAddAddressModal = ref(false);
const selectedAddress = ref(null);

const addressForm = ref({
    title: "",
    fullName: "",
    phone: "",
    address: "",
    city: "",
    district: "",
});

// Örnek veriler
const addresses = ref([
    {
        id: 1,
        title: "Ev",
        fullName: "Ahmet Yılmaz",
        phone: "0532 123 45 67",
        address: "Örnek Mahallesi, Örnek Sokak No:1 D:5",
        city: "İstanbul",
        district: "Kadıköy",
    },
    {
        id: 2,
        title: "İş",
        fullName: "Ahmet Yılmaz",
        phone: "0532 123 45 67",
        address: "Örnek Plaza, Kat:3 No:302",
        city: "İstanbul",
        district: "Beşiktaş",
    },
]);

const editAddress = (address) => {
    selectedAddress.value = address;
    addressForm.value = { ...address };
    showAddAddressModal.value = true;
};

const deleteAddress = (address) => {
    // API çağrısı yapılacak
    addresses.value = addresses.value.filter((a) => a.id !== address.id);
};

const saveAddress = () => {
    // API çağrısı yapılacak
    if (selectedAddress.value) {
        const index = addresses.value.findIndex((a) => a.id === selectedAddress.value.id);
        addresses.value[index] = { ...selectedAddress.value, ...addressForm.value };
    } else {
        addresses.value.push({
            id: addresses.value.length + 1,
            ...addressForm.value,
        });
    }
    closeAddressModal();
};

const closeAddressModal = () => {
    showAddAddressModal.value = false;
    selectedAddress.value = null;
    addressForm.value = {
        title: "",
        fullName: "",
        phone: "",
        address: "",
        city: "",
        district: "",
    };
};
</script>
