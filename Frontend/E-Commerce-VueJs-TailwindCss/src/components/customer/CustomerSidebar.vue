<template>
    <aside :class="['fixed left-0 top-0 z-40 h-screen border-r bg-card transition-all duration-300', isOpen ? 'w-full lg:w-64' : 'max-lg:hidden lg:w-[69px]']">
        <div class="flex mt-[1px] h-16 items-center border-b border-border" :class="{ 'px-6 justify-between': isOpen, 'justify-center': !isOpen }">
            <router-link v-if="isOpen" :to="{ name: 'customer-dashboard' }" class="flex items-center space-x-2 w-full">
                <span class="text-xl font-bold">Müşteri Paneli</span>
            </router-link>

            <button @click="$emit('toggle-sidebar')" class="rounded-lg p-2 text-muted-foreground hover:bg-accent hover:text-foreground">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                    <line x1="3" x2="21" y1="6" y2="6" />
                    <line x1="3" x2="21" y1="12" y2="12" />
                    <line x1="3" x2="21" y1="18" y2="18" />
                </svg>
            </button>
        </div>

        <nav class="space-y-1 p-2">
            <router-link v-for="item in menuItems" :key="item.path" :to="{ name: item.path }" class="flex items-center rounded-lg px-4 py-3 text-sm font-medium transition-colors hover:bg-accent" :class="[$route.name === item.path ? 'bg-primary/10 text-primary' : 'text-muted-foreground hover:text-foreground']">
                <component :is="item.icon" class="h-5 w-5" />
                <span v-if="isOpen" class="ml-3">{{ item.title }}</span>
            </router-link>
        </nav>

        <div class="absolute bottom-0 w-full border-t p-4">
            <div class="flex items-center" :class="{ 'justify-center': !isOpen }">
                <img src="https://github.com/shadcn.png" alt="Admin" class="h-8 w-8 rounded-full" />
                <div v-if="isOpen" class="ml-3">
                    <p class="text-sm font-medium">Customer</p>
                    <p class="text-xs text-muted-foreground">customer@example.com</p>
                </div>
            </div>
        </div>
    </aside>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import { useRoute } from "vue-router";
import { LayoutDashboard, MapPin, Heart, User, KeyRound, Bell, Share2, ShoppingBag, FileText, Truck, PackageX } from "lucide-vue-next";

const route = useRoute();

const props = defineProps<{
    isOpen: boolean;
}>();

const menuItems = [
    {
        title: "Dashboard",
        path: "customer-dashboard",
        icon: LayoutDashboard,
    },
    {
        title: "Adreslerim",
        path: "customer-addresses",
        icon: MapPin,
    },
    {
        title: "Favorilerim",
        path: "customer-favorites",
        icon: Heart,
    },
    {
        title: "Profilim",
        path: "customer-profile",
        icon: User,
    },
    {
        title: "Şifre Değiştir",
        path: "customer-profile-password",
        icon: KeyRound,
    },
    {
        title: "Bildirim Ayarlarım",
        path: "customer-profile-notifications",
        icon: Bell,
    },
    {
        title: "Sosyal Bağlantılarım",
        path: "customer-profile-social",
        icon: Share2,
    },
    {
        title: "Siparişlerim",
        path: "customer-orders",
        icon: ShoppingBag,
    },
    {
        title: "Sipariş Detay",
        path: "customer-order-detail",
        icon: FileText,
    },
    {
        title: "Sipariş Kargo Takip",
        path: "customer-order-track",
        icon: Truck,
    },
    {
        title: "Sipariş İade",
        path: "customer-order-return",
        icon: PackageX,
    },
];
</script>
