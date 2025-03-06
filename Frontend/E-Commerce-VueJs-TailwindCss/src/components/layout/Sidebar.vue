<template>
    <aside
        class="fixed left-0 top-0 z-40 h-screen w-64 -translate-x-full border-r bg-background transition-transform lg:translate-x-0"
    >
        <div class="flex h-full flex-col overflow-y-auto">
            <div class="flex h-16 items-center border-b px-6">
                <router-link :to="{ name: 'home' }" class="flex items-center space-x-2">
                    <span class="font-bold">Modern E-Ticaret</span>
                </router-link>
            </div>

            <!-- Menü -->
            <nav class="flex-1 space-y-1 p-4">
                <template v-if="role === 'seller'">
                    <router-link
                        :to="{ name: 'seller-dashboard' }"
                        class="flex items-center space-x-3 rounded-lg px-3 py-2 text-sm font-medium hover:bg-accent"
                        :class="{ 'bg-accent': isActive('seller-dashboard') }"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            class="h-4 w-4"
                        >
                            <rect width="7" height="9" x="3" y="3" rx="1" />
                            <rect width="7" height="5" x="14" y="3" rx="1" />
                            <rect width="7" height="9" x="14" y="12" rx="1" />
                            <rect width="7" height="5" x="3" y="16" rx="1" />
                        </svg>
                        <span>Panel</span>
                    </router-link>

                    <router-link
                        :to="{ name: 'seller-products' }"
                        class="flex items-center space-x-3 rounded-lg px-3 py-2 text-sm font-medium hover:bg-accent"
                        :class="{ 'bg-accent': isActive('seller-products') }"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            class="h-4 w-4"
                        >
                            <path d="m7.5 4.27 9 5.15" />
                            <path
                                d="M21 8a2 2 0 0 0-1-1.73l-7-4a2 2 0 0 0-2 0l-7 4A2 2 0 0 0 3 8v8a2 2 0 0 0 1 1.73l7 4a2 2 0 0 0 2 0l7-4A2 2 0 0 0 21 16Z"
                            />
                            <path d="m3.3 7 8.7 5 8.7-5" />
                            <path d="M12 22V12" />
                        </svg>
                        <span>Ürünler</span>
                    </router-link>

                    <router-link
                        :to="{ name: 'seller-orders' }"
                        class="flex items-center space-x-3 rounded-lg px-3 py-2 text-sm font-medium hover:bg-accent"
                        :class="{ 'bg-accent': isActive('seller-orders') }"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            class="h-4 w-4"
                        >
                            <circle cx="8" cy="21" r="1" />
                            <circle cx="19" cy="21" r="1" />
                            <path
                                d="M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12"
                            />
                        </svg>
                        <span>Siparişler</span>
                    </router-link>
                </template>

                <template v-else-if="role === 'customer'">
                    <router-link
                        :to="{ name: 'customer-dashboard' }"
                        class="flex items-center space-x-3 rounded-lg px-3 py-2 text-sm font-medium hover:bg-accent"
                        :class="{ 'bg-accent': isActive('customer-dashboard') }"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            class="h-4 w-4"
                        >
                            <rect width="7" height="9" x="3" y="3" rx="1" />
                            <rect width="7" height="5" x="14" y="3" rx="1" />
                            <rect width="7" height="9" x="14" y="12" rx="1" />
                            <rect width="7" height="5" x="3" y="16" rx="1" />
                        </svg>
                        <span>Panel</span>
                    </router-link>

                    <router-link
                        :to="{ name: 'customer-orders' }"
                        class="flex items-center space-x-3 rounded-lg px-3 py-2 text-sm font-medium hover:bg-accent"
                        :class="{ 'bg-accent': isActive('customer-orders') }"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            class="h-4 w-4"
                        >
                            <circle cx="8" cy="21" r="1" />
                            <circle cx="19" cy="21" r="1" />
                            <path
                                d="M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12"
                            />
                        </svg>
                        <span>Siparişlerim</span>
                    </router-link>

                    <router-link
                        :to="{ name: 'customer-favorites' }"
                        class="flex items-center space-x-3 rounded-lg px-3 py-2 text-sm font-medium hover:bg-accent"
                        :class="{ 'bg-accent': isActive('customer-favorites') }"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            class="h-4 w-4"
                        >
                            <path
                                d="M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z"
                            />
                        </svg>
                        <span>Favorilerim</span>
                    </router-link>

                    <router-link
                        :to="{ name: 'customer-addresses' }"
                        class="flex items-center space-x-3 rounded-lg px-3 py-2 text-sm font-medium hover:bg-accent"
                        :class="{ 'bg-accent': isActive('customer-addresses') }"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            class="h-4 w-4"
                        >
                            <path d="M20 10c0 6-8 12-8 12s-8-6-8-12a8 8 0 0 1 16 0Z" />
                            <circle cx="12" cy="10" r="3" />
                        </svg>
                        <span>Adreslerim</span>
                    </router-link>

                    <router-link
                        :to="{ name: 'customer-profile' }"
                        class="flex items-center space-x-3 rounded-lg px-3 py-2 text-sm font-medium hover:bg-accent"
                        :class="{ 'bg-accent': isActive('customer-profile ') }"
                    >
                        <svg
                            xmlns="http://www.w3.org/2000/svg"
                            width="24"
                            height="24"
                            viewBox="0 0 24 24"
                            fill="none"
                            stroke="currentColor"
                            stroke-width="2"
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            class="h-4 w-4"
                        >
                            <path
                                d="M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z"
                            />
                            <circle cx="12" cy="12" r="3" />
                        </svg>
                        <span>Ayarlar</span>
                    </router-link>
                </template>
            </nav>
        </div>
    </aside>
</template>

<script setup lang="ts">
import { useRoute } from 'vue-router'

interface Props {
    role?: 'seller' | 'customer' | null
}

const props = withDefaults(defineProps<Props>(), {
    role: null,
})

const route = useRoute()

const isActive = (name: string): boolean => {
    return route.name === name
}
</script>
