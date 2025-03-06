<template>
    <div class="container py-8">
        <div class="mb-8">
            <h1 class="text-3xl font-bold tracking-tight">Sepetim</h1>
            <p class="text-muted-foreground">Sepetinizdeki ürünleri yönetin</p>
        </div>

        <div v-if="loading" class="flex items-center justify-center py-12">
            <div class="h-8 w-8 animate-spin rounded-full border-4 border-primary border-t-transparent"></div>
        </div>

        <div v-else-if="cartItems.length === 0" class="rounded-lg border bg-card p-8 text-center">
            <div class="mx-auto mb-4 flex h-12 w-12 items-center justify-center rounded-full bg-muted">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-muted-foreground">
                    <path d="M6 2 3 6v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2V6l-3-4Z" />
                    <path d="M3 6h18" />
                    <path d="M16 10a4 4 0 0 1-8 0" />
                </svg>
            </div>
            <p class="text-lg font-semibold">Sepetiniz Boş</p>
            <p class="text-sm text-muted-foreground">Sepetinizde henüz ürün bulunmuyor. Alışverişe başlamak için ürünler sayfasını ziyaret edin.</p>
            <div class="mt-6">
                <router-link to="/products">
                    <Button>Alışverişe Başla</Button>
                </router-link>
            </div>
        </div>

        <div v-else class="grid grid-cols-1 gap-8 lg:grid-cols-12">
            <!-- Ürün Listesi -->
            <div class="lg:col-span-8">
                <div class="rounded-lg border bg-card">
                    <div v-for="(item, index) in cartItems" :key="item.id" class="flex items-start space-x-4 border-b p-6 last:border-0">
                        <!-- Ürün Görseli -->
                        <div class="h-24 w-24 flex-shrink-0 overflow-hidden rounded-lg">
                            <img :src="item.image" :alt="item.name" class="h-full w-full object-cover" />
                        </div>

                        <!-- Ürün Detayları -->
                        <div class="flex flex-1 flex-col">
                            <div class="flex items-start justify-between">
                                <div>
                                    <h3 class="font-semibold">{{ item.name }}</h3>
                                    <p class="mt-1 text-sm text-muted-foreground">{{ item.description }}</p>
                                </div>
                                <Button variant="ghost" size="icon" class="text-muted-foreground" @click="removeItem(index)">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                        <path d="M18 6 6 18" />
                                        <path d="m6 6 12 12" />
                                    </svg>
                                </Button>
                            </div>

                            <div class="mt-4 flex items-center justify-between">
                                <div class="flex items-center space-x-4">
                                    <Button variant="outline" size="icon" class="h-8 w-8" :disabled="item.quantity <= 1" @click="updateQuantity(index, -1)">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M5 12h14" />
                                        </svg>
                                    </Button>
                                    <span class="w-8 text-center">{{ item.quantity }}</span>
                                    <Button variant="outline" size="icon" class="h-8 w-8" @click="updateQuantity(index, 1)">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M5 12h14" />
                                            <path d="M12 5v14" />
                                        </svg>
                                    </Button>
                                </div>
                                <div class="flex items-baseline space-x-2">
                                    <span class="text-lg font-bold">{{ (item.price * item.quantity).toFixed(2) }} TL</span>
                                    <span v-if="item.oldPrice" class="text-sm text-muted-foreground line-through">{{ (item.oldPrice * item.quantity).toFixed(2) }} TL</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Sipariş Özeti -->
            <div class="lg:col-span-4">
                <div class="sticky top-8 rounded-lg border bg-card p-6">
                    <h2 class="text-lg font-semibold">Sipariş Özeti</h2>

                    <div class="mt-6 space-y-4">
                        <div class="flex justify-between text-sm">
                            <span class="text-muted-foreground">Ara Toplam</span>
                            <span>{{ subtotal.toFixed(2) }} TL</span>
                        </div>
                        <div class="flex justify-between text-sm">
                            <span class="text-muted-foreground">Kargo</span>
                            <span>{{ shipping.toFixed(2) }} TL</span>
                        </div>
                        <div v-if="discount > 0" class="flex justify-between text-sm">
                            <span class="text-muted-foreground">İndirim</span>
                            <span class="text-destructive">-{{ discount.toFixed(2) }} TL</span>
                        </div>
                        <div class="border-t pt-4">
                            <div class="flex justify-between">
                                <span class="font-semibold">Toplam</span>
                                <span class="font-semibold">{{ total.toFixed(2) }} TL</span>
                            </div>
                        </div>
                    </div>

                    <div class="mt-6 space-y-4">
                        <Input v-model="couponCode" placeholder="İndirim Kodu" />
                        <Button variant="outline" class="w-full" @click="applyCoupon">İndirim Kodunu Uygula</Button>
                        <Button class="w-full" @click="proceedToCheckout">Ödemeye Geç</Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, computed } from "vue";
import { useRouter } from "vue-router";
import Button from "@/components/ui/Form/Button.vue";
import Input from "@/components/ui/Form/Input.vue";

const router = useRouter();
const loading = ref(false);
const couponCode = ref("");

// Örnek sepet verileri
const cartItems = ref([
    {
        id: 1,
        name: "Kablosuz Kulaklık",
        description: "Aktif gürültü önleme özellikli premium kablosuz kulaklık",
        price: 199.99,
        oldPrice: 299.99,
        quantity: 1,
        image: "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500&h=400&fit=crop",
    },
    {
        id: 2,
        name: "Akıllı Saat",
        description: "Fitness takibi ve bildirimler için akıllı saat",
        price: 149.99,
        quantity: 2,
        image: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500&h=400&fit=crop",
    },
]);

// Hesaplanan değerler
const subtotal = computed(() => {
    return cartItems.value.reduce((total, item) => total + item.price * item.quantity, 0);
});

const shipping = computed(() => {
    return subtotal.value >= 500 ? 0 : 29.99;
});

const discount = computed(() => {
    // İndirim hesaplama mantığı burada olacak
    return 0;
});

const total = computed(() => {
    return subtotal.value + shipping.value - discount.value;
});

// Metodlar
const updateQuantity = (index, change) => {
    const newQuantity = cartItems.value[index].quantity + change;
    if (newQuantity > 0) {
        cartItems.value[index].quantity = newQuantity;
    }
};

const removeItem = (index) => {
    cartItems.value.splice(index, 1);
};

const applyCoupon = () => {
    // İndirim kodu uygulama mantığı burada olacak
    console.log("İndirim kodu uygulandı:", couponCode.value);
};

const proceedToCheckout = () => {
    router.push("/checkout");
};
</script>
