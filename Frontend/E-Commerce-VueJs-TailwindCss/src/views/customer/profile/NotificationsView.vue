<template>
    <div class="space-y-6">
        <div class="space-y-2">
            <h2 class="text-2xl font-semibold tracking-tight">Bildirim Tercihleri</h2>
            <p class="text-sm text-muted-foreground">Hangi konularda bildirim almak istediğinizi yönetin</p>
        </div>

        <div class="space-y-6 bg-card rounded-lg border border-border p-4 mb-6">
            <div class="space-y-4">
                <div class="flex items-center justify-between">
                    <div class="space-y-0.5">
                        <h3 class="text-lg font-medium">E-posta Bildirimleri</h3>
                        <p class="text-sm text-muted-foreground">E-posta ile almak istediğiniz bildirimleri seçin</p>
                    </div>
                    <Switch v-model="notifications.email.enabled" />
                </div>

                <div class="space-y-4 ml-6" v-if="notifications.email.enabled">
                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Siparişler</Label>
                            <p class="text-sm text-muted-foreground">Sipariş durumu güncellemeleri ve takip bilgileri</p>
                        </div>
                        <Switch v-model="notifications.email.orders" />
                    </div>

                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Kampanyalar</Label>
                            <p class="text-sm text-muted-foreground">İndirimler, özel teklifler ve kampanyalar</p>
                        </div>
                        <Switch v-model="notifications.email.promotions" />
                    </div>

                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Ürün Tavsiyeleri</Label>
                            <p class="text-sm text-muted-foreground">İlginizi çekebilecek ürün önerileri</p>
                        </div>
                        <Switch v-model="notifications.email.recommendations" />
                    </div>

                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Stok Bildirimleri</Label>
                            <p class="text-sm text-muted-foreground">Takip ettiğiniz ürünlerin stok durumu</p>
                        </div>
                        <Switch v-model="notifications.email.stockAlerts" />
                    </div>
                </div>
            </div>

            <div class="space-y-4">
                <div class="flex items-center justify-between">
                    <div class="space-y-0.5">
                        <h3 class="text-lg font-medium">SMS Bildirimleri</h3>
                        <p class="text-sm text-muted-foreground">SMS ile almak istediğiniz bildirimleri seçin</p>
                    </div>
                    <Switch v-model="notifications.sms.enabled" />
                </div>

                <div class="space-y-4 ml-6" v-if="notifications.sms.enabled">
                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Sipariş Durumu</Label>
                            <p class="text-sm text-muted-foreground">Siparişinizin durumu değiştiğinde bildirim alın</p>
                        </div>
                        <Switch v-model="notifications.sms.orderStatus" />
                    </div>

                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Kargo Takibi</Label>
                            <p class="text-sm text-muted-foreground">Siparişiniz kargoya verildiğinde bildirim alın</p>
                        </div>
                        <Switch v-model="notifications.sms.shipping" />
                    </div>

                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Özel Kampanyalar</Label>
                            <p class="text-sm text-muted-foreground">Size özel kampanya ve indirimlerden haberdar olun</p>
                        </div>
                        <Switch v-model="notifications.sms.specialOffers" />
                    </div>
                </div>
            </div>

            <div class="space-y-4">
                <div class="flex items-center justify-between">
                    <div class="space-y-0.5">
                        <h3 class="text-lg font-medium">Tarayıcı Bildirimleri</h3>
                        <p class="text-sm text-muted-foreground">Web tarayıcınızda anlık bildirimler alın</p>
                    </div>
                    <Switch v-model="notifications.browser.enabled" />
                </div>

                <div class="space-y-4 ml-6" v-if="notifications.browser.enabled">
                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Yeni Mesajlar</Label>
                            <p class="text-sm text-muted-foreground">Yeni mesaj aldığınızda bildirim alın</p>
                        </div>
                        <Switch v-model="notifications.browser.messages" />
                    </div>

                    <div class="flex items-center justify-between">
                        <div class="space-y-0.5">
                            <Label>Fiyat Düşüşleri</Label>
                            <p class="text-sm text-muted-foreground">Favorinizdeki ürünlerin fiyatı düştüğünde bildirim alın</p>
                        </div>
                        <Switch v-model="notifications.browser.priceDrops" />
                    </div>
                </div>
            </div>

            <div class="flex justify-end">
                <Button @click="saveNotifications">Değişiklikleri Kaydet</Button>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import Switch from "@/components/ui/Form/Switch.vue";
import Button from "@/components/ui/Form/Button.vue";

const notifications = ref({
    email: {
        enabled: true,
        orders: true,
        promotions: true,
        recommendations: false,
        stockAlerts: true,
    },
    sms: {
        enabled: true,
        orderStatus: true,
        shipping: true,
        specialOffers: false,
    },
    browser: {
        enabled: true,
        messages: true,
        priceDrops: true,
    },
});

const saveNotifications = () => {
    // TODO: API'ye kaydetme işlemi
    console.log("Bildirim tercihleri kaydediliyor:", notifications.value);
};
</script>
