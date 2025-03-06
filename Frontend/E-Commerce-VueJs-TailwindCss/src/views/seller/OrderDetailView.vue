<template>
    <div class="flex min-h-screen">
        <!-- Ana İçerik -->
        <div class="flex-1">
            <div class="container py-6">
                <div class="flex items-center justify-between">
                    <div>
                        <h2 class="text-2xl font-bold">Sipariş Detayı</h2>
                        <p class="text-sm text-muted-foreground">Sipariş #{{ orderId }} detaylarını görüntülüyorsunuz.</p>
                    </div>
                    <Button variant="outline" @click="$router.back()">Geri Dön</Button>
                </div>

                <!-- Sipariş Durumu -->
                <div class="mt-6 rounded-lg border bg-card p-6">
                    <div class="flex items-center justify-between">
                        <div>
                            <p class="text-sm text-muted-foreground">Sipariş Durumu</p>
                            <div class="mt-1">
                                <Select v-model="order.status" class="w-40">
                                    <option value="Hazırlanıyor">Hazırlanıyor</option>
                                    <option value="Kargoya Verildi">Kargoya Verildi</option>
                                    <option value="Teslim Edildi">Teslim Edildi</option>
                                    <option value="İptal Edildi">İptal Edildi</option>
                                </Select>
                            </div>
                        </div>
                        <div class="text-right">
                            <p class="text-sm text-muted-foreground">Sipariş Tarihi</p>
                            <p class="mt-1 font-medium">{{ order.date }}</p>
                        </div>
                    </div>

                    <!-- Durum Çubuğu -->
                    <div class="mt-6">
                        <div class="relative">
                            <div class="absolute inset-0 flex items-center">
                                <div class="w-full border-t border-muted"></div>
                            </div>
                            <div class="relative flex justify-between">
                                <div v-for="(step, index) in orderSteps" :key="index" class="flex flex-col items-center">
                                    <div
                                        :class="{
                                            'h-8 w-8 rounded-full border-2 flex items-center justify-center bg-background': true,
                                            'border-primary': step.completed,
                                            'border-muted': !step.completed,
                                        }"
                                    >
                                        <svg v-if="step.completed" xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                            <polyline points="20 6 9 17 4 12" />
                                        </svg>
                                    </div>
                                    <p class="mt-2 text-xs">{{ step.label }}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Müşteri ve Kargo Bilgileri -->
                <div class="mt-6 grid gap-6 md:grid-cols-2">
                    <div class="rounded-lg border bg-card p-6">
                        <h3 class="font-semibold">Müşteri Bilgileri</h3>
                        <div class="mt-4 space-y-2">
                            <p class="font-medium">{{ order.customer.fullName }}</p>
                            <p class="text-sm">{{ order.customer.email }}</p>
                            <p class="text-sm">{{ order.customer.phone }}</p>
                            <Button variant="outline" size="sm" @click="viewCustomerDetails">Müşteri Detayları</Button>
                        </div>
                    </div>

                    <div class="rounded-lg border bg-card p-6">
                        <h3 class="font-semibold">Kargo Bilgileri</h3>
                        <div class="mt-4 space-y-4">
                            <div class="space-y-2">
                                <Label for="shippingCompany">Kargo Firması</Label>
                                <Select id="shippingCompany" v-model="order.shipping.company" class="w-full">
                                    <option value="Aras Kargo">Aras Kargo</option>
                                    <option value="Yurtiçi Kargo">Yurtiçi Kargo</option>
                                    <option value="MNG Kargo">MNG Kargo</option>
                                    <option value="PTT Kargo">PTT Kargo</option>
                                </Select>
                            </div>
                            <div class="space-y-2">
                                <Label for="trackingNumber">Takip Numarası</Label>
                                <Input id="trackingNumber" v-model="order.shipping.trackingNumber" />
                            </div>
                            <Button variant="outline" size="sm" @click="updateShippingInfo">Kargo Bilgilerini Güncelle</Button>
                        </div>
                    </div>
                </div>

                <!-- Teslimat Adresi -->
                <div class="mt-6 rounded-lg border bg-card p-6">
                    <h3 class="font-semibold">Teslimat Adresi</h3>
                    <div class="mt-4 space-y-2">
                        <p class="font-medium">{{ order.shippingAddress.fullName }}</p>
                        <p class="text-sm">{{ order.shippingAddress.phone }}</p>
                        <p class="text-sm">{{ order.shippingAddress.address }}</p>
                        <p class="text-sm">{{ order.shippingAddress.district }}/{{ order.shippingAddress.city }}</p>
                    </div>
                </div>

                <!-- Ürünler -->
                <div class="mt-6 rounded-lg border bg-card">
                    <div class="overflow-x-auto">
                        <table class="w-full">
                            <thead>
                                <tr class="border-b bg-muted/50">
                                    <th class="px-4 py-3 text-left text-sm font-medium">Ürün</th>
                                    <th class="px-4 py-3 text-center text-sm font-medium">Adet</th>
                                    <th class="px-4 py-3 text-right text-sm font-medium">Birim Fiyat</th>
                                    <th class="px-4 py-3 text-right text-sm font-medium">Toplam</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr v-for="item in order.items" :key="item.id" class="border-b">
                                    <td class="px-4 py-3">
                                        <div class="flex items-center space-x-3">
                                            <img :src="item.image" :alt="item.name" class="h-12 w-12 rounded-lg object-cover" />
                                            <div>
                                                <p class="font-medium">{{ item.name }}</p>
                                                <p class="text-sm text-muted-foreground">{{ item.variant }}</p>
                                            </div>
                                        </div>
                                    </td>
                                    <td class="px-4 py-3 text-center">{{ item.quantity }}</td>
                                    <td class="px-4 py-3 text-right">{{ item.price }} TL</td>
                                    <td class="px-4 py-3 text-right">{{ item.quantity * item.price }} TL</td>
                                </tr>
                            </tbody>
                            <tfoot>
                                <tr class="border-t">
                                    <td colspan="3" class="px-4 py-3 text-right font-medium">Ara Toplam</td>
                                    <td class="px-4 py-3 text-right">{{ order.subtotal }} TL</td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="px-4 py-3 text-right font-medium">Kargo</td>
                                    <td class="px-4 py-3 text-right">{{ order.shippingCost }} TL</td>
                                </tr>
                                <tr v-if="order.discount">
                                    <td colspan="3" class="px-4 py-3 text-right font-medium">İndirim</td>
                                    <td class="px-4 py-3 text-right text-green-600">-{{ order.discount }} TL</td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="px-4 py-3 text-right font-medium">Toplam</td>
                                    <td class="px-4 py-3 text-right font-bold">{{ order.total }} TL</td>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>

                <!-- İşlemler -->
                <div class="mt-6 flex justify-end space-x-2">
                    <Button variant="outline" @click="printOrder">Siparişi Yazdır</Button>
                    <Button variant="outline" @click="downloadInvoice">Faturayı İndir</Button>
                    <Button @click="saveChanges">Değişiklikleri Kaydet</Button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted, watch } from "vue";
import { useRoute, useRouter } from "vue-router";
import Button from "@/components/ui/Form/Button.vue";
import Input from "@/components/ui/Form/Input.vue";
import Select from "@/components/ui/Form/Select.vue";

const route = useRoute();
const router = useRouter();
const orderId = route.params.id;

// Örnek veri
const order = ref({
    id: orderId,
    status: "Kargoda",
    date: "2024-01-15",
    customer: {
        id: 1,
        fullName: "Ahmet Yılmaz",
        email: "ahmet@example.com",
        phone: "0532 123 45 67",
    },
    shippingAddress: {
        fullName: "Ahmet Yılmaz",
        phone: "0532 123 45 67",
        address: "Örnek Mahallesi, Örnek Sokak No:1 D:5",
        district: "Kadıköy",
        city: "İstanbul",
    },
    shipping: {
        company: "Aras Kargo",
        trackingNumber: "1234567890",
    },
    items: [
        {
            id: 1,
            name: "Kablosuz Kulaklık",
            variant: "Siyah",
            quantity: 1,
            price: 199.99,
            image: "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=100&h=100&fit=crop",
        },
        {
            id: 2,
            name: "Akıllı Saat",
            variant: "Gümüş",
            quantity: 1,
            price: 349.99,
            image: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=100&h=100&fit=crop",
        },
    ],
    subtotal: 549.98,
    shippingCost: 29.99,
    discount: 50,
    total: 529.97,
});

const orderSteps = ref([
    {
        label: "Sipariş Alındı",
        completed: true,
    },
    {
        label: "Hazırlanıyor",
        completed: true,
    },
    {
        label: "Kargoya Verildi",
        completed: true,
    },
    {
        label: "Teslim Edildi",
        completed: false,
    },
]);

// Sipariş durumu değiştiğinde durum çubuğunu güncelle
watch(
    () => order.value.status,
    (newStatus) => {
        switch (newStatus) {
            case "Hazırlanıyor":
                orderSteps.value[1].completed = true;
                orderSteps.value[2].completed = false;
                orderSteps.value[3].completed = false;
                break;
            case "Kargoya Verildi":
                orderSteps.value[1].completed = true;
                orderSteps.value[2].completed = true;
                orderSteps.value[3].completed = false;
                break;
            case "Teslim Edildi":
                orderSteps.value[1].completed = true;
                orderSteps.value[2].completed = true;
                orderSteps.value[3].completed = true;
                break;
            case "İptal Edildi":
                orderSteps.value[1].completed = false;
                orderSteps.value[2].completed = false;
                orderSteps.value[3].completed = false;
                break;
        }
    }
);

const viewCustomerDetails = () => {
    router.push(`/seller/customers/${order.value.customer.id}`);
};

const updateShippingInfo = async () => {
    // API çağrısı yapılacak
    try {
        // await api.updateShippingInfo(orderId, order.value.shipping)
        console.log("Kargo bilgileri güncellendi");
    } catch (error) {
        console.error("Kargo bilgileri güncellenemedi:", error);
    }
};

const saveChanges = async () => {
    // API çağrısı yapılacak
    try {
        // await api.updateOrder(orderId, order.value)
        console.log("Sipariş güncellendi");
    } catch (error) {
        console.error("Sipariş güncellenemedi:", error);
    }
};

const printOrder = () => {
    window.print();
};

const downloadInvoice = () => {
    // PDF indirme işlemi yapılacak
    console.log("Fatura indiriliyor...");
};

onMounted(async () => {
    try {
        // Sipariş detayları API'den alınacak
        // const response = await api.getOrderDetails(orderId)
        // order.value = response.data
    } catch (error) {
        console.error("Sipariş detayları alınamadı:", error);
        router.push("/seller/orders");
    }
});
</script>
