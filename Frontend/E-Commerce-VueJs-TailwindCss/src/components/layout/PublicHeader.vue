<template>
    <header class="sticky top-0 z-50 w-full border-b border-border bg-background/95 backdrop-blur supports-[backdrop-filter]:bg-background/60">
        <div class="container flex h-14 items-center justify-between">
            <!-- Logo -->
            <div class="flex items-center">
                <router-link :to="{ name: 'home' }" class="flex items-center space-x-2">
                    <span class="text-lg font-bold sm:text-xl">E-Commerce</span>
                </router-link>
            </div>

            <!-- Ana Menü -->
            <div class="hidden md:flex items-center space-x-6">
                <router-link v-for="item in menuItems" :key="item.name" :to="item.to" class="text-sm font-medium transition-colors hover:text-primary" :class="{ 'text-primary': $route.name === item.routeName }">
                    {{ item.name }}
                </router-link>
            </div>

            <!-- Sağ Menü -->
            <div class="flex items-center space-x-2 sm:space-x-4">
                <!-- Arama -->
                <button @click="toggleSearch" class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 hover:bg-accent hover:text-accent-foreground h-9 w-9">
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="sm:w-5 sm:h-5">
                        <circle cx="11" cy="11" r="8" />
                        <path d="m21 21-4.3-4.3" />
                    </svg>
                </button>

                <!-- Sepet -->
                <router-link :to="{ name: 'cart' }" class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 hover:bg-accent hover:text-accent-foreground h-9 w-9 relative">
                    <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="sm:w-5 sm:h-5">
                        <circle cx="8" cy="21" r="1" />
                        <circle cx="19" cy="21" r="1" />
                        <path d="M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12" />
                    </svg>
                    <span v-if="cartItemCount > 0" class="absolute -top-1 -right-1 bg-primary text-white rounded-full text-[10px] w-4 h-4 flex items-center justify-center">
                        {{ cartItemCount }}
                    </span>
                </router-link>

                <!-- Kullanıcı Menüsü -->
                <div class="relative hidden sm:block">
                    <button @click="isUserMenuOpen = !isUserMenuOpen" class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 hover:bg-accent hover:text-accent-foreground h-9 w-9">
                        <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="sm:w-5 sm:h-5">
                            <path d="M19 21v-2a4 4 0 0 0-4-4H9a4 4 0 0 0-4 4v2" />
                            <circle cx="12" cy="7" r="4" />
                        </svg>
                    </button>
                    <div v-show="isUserMenuOpen" class="absolute right-0 mt-2 w-56 origin-top-right rounded-md bg-card shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none border">
                        <div class="py-1">
                            <router-link v-for="item in userMenuItems" :key="item.name" :to="item.to" class="block px-4 py-2 text-sm hover:bg-accent" @click="isUserMenuOpen = false">
                                {{ item.name }}
                            </router-link>
                            <div v-if="isLoggedIn" class="border-t border-border">
                                <button @click="handleLogout" class="block w-full text-left px-4 py-2 text-sm hover:bg-accent">Çıkış Yap</button>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Mobil Menü Butonu -->
                <button @click="toggleMenu" class="inline-flex md:hidden items-center justify-center rounded-md p-2 hover:bg-accent">
                    <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                        <path v-if="!isMenuOpen" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                        <path v-else stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                    </svg>
                </button>
            </div>
        </div>

        <!-- Mobil Menü -->
        <div v-show="isMenuOpen" class="fixed inset-0 z-50">
            <!-- Blur Arkaplan -->
            <div class="fixed inset-0 bg-black/50 backdrop-blur-sm" @click="toggleMenu"></div>

            <!-- Menü İçeriği -->
            <div class="relative z-50 h-[100dvh] w-full bg-background/95 backdrop-blur-sm supports-[backdrop-filter]:bg-background/60 overflow-y-auto">
                <div class="sticky top-0 flex items-center justify-between border-b border-border/40 bg-background/95 p-4">
                    <span class="text-lg font-semibold">Menü</span>
                    <button @click="toggleMenu" class="rounded-md p-1 text-muted-foreground transition-colors hover:text-foreground">
                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M18 6 6 18" />
                            <path d="m6 6 12 12" />
                        </svg>
                    </button>
                </div>

                <div class="p-4">
                    <!-- Ana Menü Linkleri -->
                    <div class="space-y-1">
                        <router-link
                            v-for="item in menuItems"
                            :key="item.name"
                            :to="item.to"
                            class="flex items-center rounded-lg px-3 py-3 text-base font-medium transition-colors hover:bg-accent"
                            :class="{
                                'bg-accent': $route.name === item.routeName,
                            }"
                            @click="toggleMenu"
                        >
                            {{ item.name }}
                        </router-link>
                    </div>

                    <!-- Kullanıcı Menüsü -->
                    <div class="mt-4 border-t border-border/40 pt-4">
                        <div class="space-y-1">
                            <router-link v-for="item in userMenuItems" :key="item.name" :to="item.to" class="flex items-center rounded-lg px-3 py-3 text-base font-medium transition-colors hover:bg-accent" @click="toggleMenu">
                                {{ item.name }}
                            </router-link>
                            <button v-if="isLoggedIn" @click="handleLogout" class="flex w-full items-center rounded-lg px-3 py-3 text-base font-medium transition-colors hover:bg-accent">Çıkış Yap</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Arama Modal -->
        <div v-if="isSearchOpen" class="fixed inset-0 z-50 flex items-start sm:items-center justify-center pt-16 sm:pt-0">
            <!-- Blur Arkaplan -->
            <div class="absolute inset-0 bg-background/80 backdrop-blur-sm" @click="toggleSearch"></div>

            <!-- Arama Input Container -->
            <div class="relative w-full max-w-lg px-4">
                <div class="relative">
                    <input v-model="searchQuery" type="text" placeholder="Ürün ara..." class="h-11 w-full rounded-lg border border-border bg-background px-4 pr-12 text-base outline-none transition-all placeholder:text-muted-foreground focus:border-primary" @keyup.enter="handleSearch" ref="searchInput" />
                    <button @click="toggleSearch" class="absolute right-3 top-1/2 -translate-y-1/2 rounded-md p-1 text-muted-foreground transition-colors hover:text-foreground">
                        <svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                            <path d="M18 6 6 18" />
                            <path d="m6 6 12 12" />
                        </svg>
                    </button>
                </div>
            </div>
        </div>
    </header>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";
import { useRouter } from "vue-router";

export default defineComponent({
    name: "PublicHeader",
    setup() {
        const router = useRouter();
        const isMenuOpen = ref(false);
        const isUserMenuOpen = ref(false);
        const isSearchOpen = ref(false);
        const searchQuery = ref("");
        const searchInput = ref<HTMLInputElement | null>(null);
        const cartItemCount = ref(0);
        const isLoggedIn = ref(false);

        const menuItems = [
            {
                name: "Ürünler",
                to: { name: "products" },
                routeName: "products",
            },
            {
                name: "Kategoriler",
                to: { name: "categories" },
                routeName: "categories",
            },
            {
                name: "Kampanyalar",
                to: { name: "discounts" },
                routeName: "discounts",
            },
        ];

        const userMenuItems = [
            { name: "Müşteri Paneli", to: { name: "customer-dashboard" } },
            { name: "Satıcı Paneli", to: { name: "seller-dashboard" } },
            { name: "Giriş Yap", to: { name: "login" } },
            { name: "Kayıt Ol", to: { name: "register" } },
        ];

        const toggleMenu = () => {
            isMenuOpen.value = !isMenuOpen.value;
            if (isMenuOpen.value) {
                document.body.style.overflow = "hidden";
            } else {
                document.body.style.overflow = "";
            }
        };

        const toggleSearch = () => {
            isSearchOpen.value = !isSearchOpen.value;
            if (isSearchOpen.value) {
                document.body.style.overflow = "hidden";
                setTimeout(() => {
                    searchInput.value?.focus();
                }, 100);
            } else {
                document.body.style.overflow = "";
                searchQuery.value = "";
            }
        };

        const handleSearch = () => {
            if (searchQuery.value.trim()) {
                router.push({
                    name: "search",
                    query: { q: searchQuery.value },
                });
                toggleSearch();
            }
        };

        const handleLogout = () => {
            // Logout işlemleri burada yapılacak
            isUserMenuOpen.value = false;
        };

        return {
            isMenuOpen,
            isUserMenuOpen,
            isSearchOpen,
            searchQuery,
            searchInput,
            cartItemCount,
            isLoggedIn,
            menuItems,
            userMenuItems,
            toggleMenu,
            toggleSearch,
            handleSearch,
            handleLogout,
        };
    },
});
</script>
