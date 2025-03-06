<template>
    <div class="container mx-auto py-8">
        <!-- Breadcrumb -->
        <nav class="mb-8 flex" aria-label="Breadcrumb">
            <ol class="inline-flex items-center space-x-1 text-sm text-muted-foreground md:space-x-2">
                <li>
                    <router-link to="/" class="hover:text-foreground">Ana Sayfa</router-link>
                </li>
                <li>
                    <span class="mx-2">/</span>
                </li>
                <li>
                    <router-link to="/cart" class="hover:text-foreground">Sepet</router-link>
                </li>
                <li>
                    <span class="mx-2">/</span>
                </li>
                <li class="text-foreground">Ödeme</li>
            </ol>
        </nav>

        <div class="grid grid-cols-1 gap-8 lg:grid-cols-12">
            <!-- Sol Taraf - Form -->
            <div class="lg:col-span-8">
                <form @submit.prevent="handleSubmit" class="space-y-6">
                    <!-- Teslimat Bilgileri -->
                    <Card>
                        <template #header>
                            <div class="flex items-center space-x-4 px-6 py-4 border-b">
                                <div class="flex h-10 w-10 items-center justify-center rounded-full bg-primary/10">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                        <path d="M21 10V8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l2-1.14" />
                                        <path d="M3.3 7l8.7 5 8.7-5" />
                                        <path d="M12 22V12" />
                                    </svg>
                                </div>
                                <div>
                                    <h3 class="text-lg font-semibold">Teslimat Bilgileri</h3>
                                    <p class="text-sm text-muted-foreground">Siparişinizin teslim edileceği adresi girin</p>
                                </div>
                            </div>
                        </template>

                        <div class="space-y-6 p-6">
                            <div class="grid gap-4 sm:grid-cols-2">
                                <Input id="firstName" v-model="form.firstName" label="Ad" placeholder="Adınız" required />
                                <Input id="lastName" v-model="form.lastName" label="Soyad" placeholder="Soyadınız" required />
                            </div>

                            <Input id="phone" type="tel" v-model="form.phone" label="Telefon" placeholder="(5XX) XXX XX XX" required />

                            <Textarea id="address" v-model="form.address" label="Adres" placeholder="Açık adresiniz" :rows="3" required />

                            <div class="grid gap-4 sm:grid-cols-2">
                                <Select id="city" v-model="form.city" label="İl" placeholder="İl seçin" required>
                                    <option v-for="city in cities" :key="city" :value="city">
                                        {{ city }}
                                    </option>
                                </Select>

                                <Select id="district" v-model="form.district" label="İlçe" placeholder="İlçe seçin" required>
                                    <option v-for="district in districts" :key="district" :value="district">
                                        {{ district }}
                                    </option>
                                </Select>
                            </div>
                        </div>
                    </Card>

                    <!-- Fatura Bilgileri -->
                    <Card>
                        <template #header>
                            <div class="flex items-center space-x-4 px-6 py-4 border-b">
                                <div class="flex h-10 w-10 items-center justify-center rounded-full bg-primary/10">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                        <rect width="16" height="20" x="4" y="2" rx="2" />
                                        <path d="M8 10h8" />
                                        <path d="M8 14h4" />
                                    </svg>
                                </div>
                                <div>
                                    <h3 class="text-lg font-semibold">Fatura Bilgileri</h3>
                                    <p class="text-sm text-muted-foreground">Fatura bilgilerinizi girin</p>
                                </div>
                            </div>
                        </template>

                        <div class="space-y-6 p-6">
                            <Checkbox id="sameAsDelivery" v-model="form.sameAsDelivery" label="Fatura adresi teslimat adresi ile aynı" />

                            <div v-if="!form.sameAsDelivery" class="space-y-4">
                                <Select id="billType" v-model="form.billType" label="Fatura Türü" required>
                                    <option value="individual">Bireysel</option>
                                    <option value="corporate">Kurumsal</option>
                                </Select>

                                <Input v-if="form.billType === 'corporate'" id="taxNumber" v-model="form.taxNumber" label="Vergi Numarası" placeholder="Vergi numaranız" required />

                                <Input v-else id="identityNumber" v-model="form.identityNumber" label="T.C. Kimlik Numarası" placeholder="T.C. Kimlik numaranız" required />

                                <Textarea id="billAddress" v-model="form.billAddress" label="Fatura Adresi" placeholder="Fatura adresiniz" :rows="3" required />
                            </div>
                        </div>
                    </Card>

                    <!-- Kargo Seçimi -->
                    <Card>
                        <template #header>
                            <div class="flex items-center space-x-4 px-6 py-4 border-b">
                                <div class="flex h-10 w-10 items-center justify-center rounded-full bg-primary/10">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                        <path d="M21 5c0-1.1-.9-2-2-2H5c-1.1 0-2 .9-2 2m18 0v14c0 1.1-.9 2-2 2H5c-1.1 0-2-.9-2-2V5m18 0-9 6.5L3 5" />
                                    </svg>
                                </div>
                                <div>
                                    <h3 class="text-lg font-semibold">Kargo Seçimi</h3>
                                    <p class="text-sm text-muted-foreground">Tercih ettiğiniz kargo firmasını seçin</p>
                                </div>
                            </div>
                        </template>

                        <div class="p-6">
                            <div class="space-y-4">
                                <div v-for="(company, index) in shippingCompanies" :key="index" class="flex items-center justify-between p-4 rounded-lg border hover:border-primary/50 transition-colors cursor-pointer bg-card" :class="{ 'border-primary bg-primary/5': form.shippingCompany === company.id }" @click="form.shippingCompany = company.id">
                                    <div class="flex items-center space-x-4">
                                        <input type="radio" :id="company.id" :value="company.id" v-model="form.shippingCompany" class="h-4 w-4 text-primary border-gray-300 focus:ring-primary" />
                                        <div>
                                            <label :for="company.id" class="font-medium cursor-pointer">{{ company.name }}</label>
                                            <p class="text-sm text-muted-foreground">{{ company.description }}</p>
                                        </div>
                                    </div>
                                    <span class="text-sm font-medium" :class="company.price === 0 ? 'text-green-600' : ''">
                                        {{ company.price === 0 ? "Ücretsiz" : `${company.price} TL` }}
                                    </span>
                                </div>
                            </div>
                        </div>
                    </Card>

                    <!-- Ödeme Bilgileri -->
                    <Card>
                        <template #header>
                            <div class="flex items-center space-x-4 px-6 py-4 border-b">
                                <div class="flex h-10 w-10 items-center justify-center rounded-full bg-primary/10">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                        <rect width="20" height="14" x="2" y="5" rx="2" />
                                        <line x1="2" x2="22" y1="10" y2="10" />
                                    </svg>
                                </div>
                                <div>
                                    <h3 class="text-lg font-semibold">Ödeme Bilgileri</h3>
                                    <p class="text-sm text-muted-foreground">Güvenli ödeme için kart bilgilerinizi girin</p>
                                </div>
                            </div>
                        </template>

                        <div class="space-y-6 p-6">
                            <Input id="cardName" v-model="form.cardName" label="Kart Üzerindeki İsim" placeholder="Kart sahibinin adı" required />

                            <div class="relative">
                                <Input id="cardNumber" v-model="form.cardNumber" label="Kart Numarası" placeholder="XXXX XXXX XXXX XXXX" maxlength="19" @input="formatCardNumber" required />
                                <div class="absolute right-3 top-8">
                                    <img :src="getCardTypeImage(form.cardNumber)" alt="Card Type" class="h-6" v-if="getCardType(form.cardNumber)" />
                                </div>
                            </div>

                            <div class="grid gap-4 sm:grid-cols-2">
                                <Input id="expiryDate" v-model="form.expiryDate" label="Son Kullanma Tarihi" placeholder="AA/YY" maxlength="5" @input="formatExpiryDate" required />

                                <div class="relative">
                                    <Input id="cvv" v-model="form.cvv" label="CVV" placeholder="XXX" maxlength="3" required type="password" />
                                    <button type="button" class="absolute right-3 top-8 text-muted-foreground hover:text-foreground" @mousedown="showCVV = true" @mouseup="showCVV = false" @mouseleave="showCVV = false">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M2 12s3-7 10-7 10 7 10 7-3 7-10 7-10-7-10-7Z" />
                                            <circle cx="12" cy="12" r="3" />
                                        </svg>
                                    </button>
                                </div>
                            </div>

                            <div class="flex items-center space-x-2 text-sm">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-green-600">
                                    <path d="M21 12V7H5a2 2 0 0 1 0-4h14v4" />
                                    <path d="M3 5v14a2 2 0 0 0 2 2h16v-5" />
                                    <path d="M18 12a2 2 0 0 0 0 4h4v-4Z" />
                                </svg>
                                <span class="text-muted-foreground">256-bit SSL güvenli ödeme</span>
                            </div>
                        </div>
                    </Card>
                </form>
            </div>

            <!-- Sağ Taraf - Sipariş Özeti -->
            <div class="lg:col-span-4">
                <div class="sticky top-8 space-y-6">
                    <!-- Sipariş Özeti -->
                    <Card>
                        <template #header>
                            <div class="px-6 py-4 border-b">
                                <h3 class="text-lg font-semibold">Sipariş Özeti</h3>
                            </div>
                        </template>

                        <div class="p-6 space-y-6">
                            <!-- Ürünler -->
                            <div class="space-y-4">
                                <div v-for="item in cartItems" :key="item.id" class="flex justify-between text-sm pb-3 border-b last:border-0 last:pb-0">
                                    <span class="flex-1">
                                        {{ item.name }}
                                        <span class="text-muted-foreground">({{ item.quantity }}x)</span>
                                    </span>
                                    <span class="font-medium">{{ (item.price * item.quantity).toFixed(2) }} TL</span>
                                </div>
                            </div>

                            <div class="space-y-3 pt-3">
                                <div class="flex justify-between text-sm">
                                    <span>Ara Toplam</span>
                                    <span>{{ subtotal.toFixed(2) }} TL</span>
                                </div>
                                <div class="flex justify-between text-sm">
                                    <span>Kargo</span>
                                    <span>{{ shipping === 0 ? "Ücretsiz" : `${shipping.toFixed(2)} TL` }}</span>
                                </div>
                                <div v-if="discount > 0" class="flex justify-between text-sm text-green-600">
                                    <span>İndirim</span>
                                    <span>-{{ discount.toFixed(2) }} TL</span>
                                </div>
                                <div class="flex justify-between text-base font-semibold pt-3 border-t">
                                    <span>Toplam</span>
                                    <span>{{ total.toFixed(2) }} TL</span>
                                </div>
                            </div>
                        </div>
                    </Card>

                    <!-- Kupon Kodu -->
                    <Card>
                        <div class="p-6">
                            <div class="flex space-x-2">
                                <Input v-model="couponCode" placeholder="İndirim kodu" class="flex-1" />
                                <button type="button" class="px-6 py-2 bg-primary text-primary-foreground rounded-md hover:bg-primary/90 transition-colors" @click="applyCoupon">Uygula</button>
                            </div>
                        </div>
                    </Card>

                    <!-- Ödeme Butonu -->
                    <button type="submit" class="w-full flex items-center justify-center space-x-2 bg-primary text-primary-foreground h-12 px-8 rounded-md hover:bg-primary/90 transition-colors disabled:opacity-50 disabled:cursor-not-allowed text-base font-medium" :disabled="loading" @click="handleSubmit">
                        <span v-if="loading" class="animate-spin">
                            <svg class="w-5 h-5" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                                <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                                <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                            </svg>
                        </span>
                        <span>{{ loading ? "İşleniyor..." : "Siparişi Tamamla" }}</span>
                    </button>

                    <!-- Güvenli Ödeme Bilgisi -->
                    <div class="text-center space-y-3 mt-6">
                        <div class="flex justify-center items-center space-x-6">
                            <img src="https://raw.githubusercontent.com/muhammederdem/credit-card-form/master/src/assets/images/visa.png" alt="Visa" class="h-6" />
                            <img src="https://raw.githubusercontent.com/muhammederdem/credit-card-form/master/src/assets/images/mastercard.png" alt="Mastercard" class="h-6" />
                            <img src="https://www.troy.com.tr/assets/images/logo.svg" alt="Troy" class="h-6" />
                        </div>
                        <p class="text-xs text-muted-foreground">256-bit SSL sertifikası ile güvenli ödeme</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
// import Card from "@/components/ui/layout/Card.vue";
import Input from "@/components/ui/Form/Input.vue";
import Select from "@/components/ui/Form/Select.vue";
import Textarea from "@/components/ui/Form/Textarea.vue";
import Checkbox from "@/components/ui/Form/Checkbox.vue";

const loading = ref(false);
const showCVV = ref(false);
const couponCode = ref("");

// Form verisi
const form = ref({
    firstName: "",
    lastName: "",
    phone: "",
    address: "",
    city: "",
    district: "",
    sameAsDelivery: true,
    billType: "individual",
    taxNumber: "",
    identityNumber: "",
    billAddress: "",
    cardName: "",
    cardNumber: "",
    expiryDate: "",
    cvv: "",
    shippingCompany: "yurtici",
});

// Örnek veriler
const cities = ["İstanbul", "Ankara", "İzmir", "Bursa", "Antalya"];
const districts = ["Kadıköy", "Beşiktaş", "Şişli", "Üsküdar", "Maltepe"];

// Kargo firmaları
const shippingCompanies = [
    {
        id: "yurtici",
        name: "Yurtiçi Kargo",
        description: "2-3 iş günü içinde teslimat",
        price: 0,
    },
    {
        id: "aras",
        name: "Aras Kargo",
        description: "3-4 iş günü içinde teslimat",
        price: 19.9,
    },
    {
        id: "mng",
        name: "MNG Kargo",
        description: "2-4 iş günü içinde teslimat",
        price: 24.9,
    },
];

// Örnek sepet verileri
const cartItems = ref([
    {
        id: 1,
        name: "Kablosuz Kulaklık",
        price: 199.99,
        quantity: 1,
    },
    {
        id: 2,
        name: "Akıllı Saat",
        price: 149.99,
        quantity: 2,
    },
]);

// Hesaplanan değerler
const subtotal = computed(() => {
    return cartItems.value.reduce((total, item) => total + item.price * item.quantity, 0);
});

const shipping = computed(() => {
    const selectedCompany = shippingCompanies.find((company) => company.id === form.value.shippingCompany);
    return selectedCompany ? selectedCompany.price : 0;
});

const discount = computed(() => {
    // İndirim hesaplama mantığı
    return 0;
});

const total = computed(() => {
    return subtotal.value + shipping.value - discount.value;
});

// Format fonksiyonları
const formatCardNumber = (event: Event) => {
    const input = event.target as HTMLInputElement;
    let value = input.value.replace(/\D/g, "");
    value = value.replace(/(\d{4})/g, "$1 ").trim();
    form.value.cardNumber = value;
};

const formatExpiryDate = (event: Event) => {
    const input = event.target as HTMLInputElement;
    let value = input.value.replace(/\D/g, "");
    if (value.length >= 2) {
        value = value.slice(0, 2) + "/" + value.slice(2);
    }
    form.value.expiryDate = value;
};

// Kart türünü belirleme
const getCardType = (number: string) => {
    const cleaned = number.replace(/\D/g, "");
    if (cleaned.startsWith("4")) return "visa";
    if (/^5[1-5]/.test(cleaned)) return "mastercard";
    if (/^9/.test(cleaned)) return "troy";
    return null;
};

const getCardTypeImage = (number: string) => {
    const type = getCardType(number);
    if (type === "visa") return "https://raw.githubusercontent.com/muhammederdem/credit-card-form/master/src/assets/images/visa.png";
    if (type === "mastercard") return "https://raw.githubusercontent.com/muhammederdem/credit-card-form/master/src/assets/images/mastercard.png";
    if (type === "troy") return "https://www.troy.com.tr/assets/images/logo.svg";
    return null;
};

// Kupon kodu uygulama
const applyCoupon = () => {
    // Kupon kodu uygulama mantığı
    console.log("Kupon kodu uygulanıyor:", couponCode.value);
};

// Form gönderme
const handleSubmit = async () => {
    loading.value = true;
    try {
        // Sipariş tamamlama işlemleri
        await new Promise((resolve) => setTimeout(resolve, 2000));
        console.log("Sipariş tamamlandı:", form.value);
    } catch (error) {
        console.error("Sipariş tamamlanamadı:", error);
    } finally {
        loading.value = false;
    }
};
</script>
