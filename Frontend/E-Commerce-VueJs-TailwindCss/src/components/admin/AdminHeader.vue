<template>
    <header class="sticky top-0 z-30 border-b border-border bg-card">
        <div class="flex h-16 items-center justify-between px-4">
            <button @click="$emit('toggle-sidebar')" class="lg:hidden rounded-lg p-2 text-muted-foreground hover:bg-accent hover:text-foreground">
                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                    <line x1="3" x2="21" y1="6" y2="6" />
                    <line x1="3" x2="21" y1="12" y2="12" />
                    <line x1="3" x2="21" y1="18" y2="18" />
                </svg>
            </button>

            <!-- Sol Taraf -->
            <div class="flex items-center space-x-4">
                <div class="relative hidden md:block">
                    <input type="text" placeholder="Ara..." class="h-9 w-[300px] rounded-lg border bg-background px-3 pl-9 text-sm placeholder:text-muted-foreground focus:outline-none focus:ring-2 focus:ring-primary" />
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute left-3 top-1/2 -translate-y-1/2 text-muted-foreground">
                        <circle cx="11" cy="11" r="8" />
                        <path d="m21 21-4.3-4.3" />
                    </svg>
                </div>
            </div>

            <!-- Sağ Taraf -->
            <div class="flex items-center space-x-4">
                <!-- Bildirimler -->
                <div class="relative">
                    <button @click="isNotificationsOpen = !isNotificationsOpen" class="relative rounded-lg p-2 text-muted-foreground hover:bg-accent hover:text-foreground">
                        <Bell class="w-5 h-5" />
                        <span v-if="unreadCount > 0" class="absolute -right-0.5 -top-0.5 flex h-5 w-5 items-center justify-center rounded-full bg-primary text-xs font-medium text-primary-foreground">
                            {{ unreadCount }}
                        </span>
                    </button>

                    <!-- Bildirimler Dropdown -->
                    <NotificationsList
                        v-if="isNotificationsOpen"
                        :notifications="notifications"
                        all-notifications-route="/admin/notifications"
                        @mark-as-read="markAsRead"
                        @mark-all-as-read="markAllAsRead"
                    />
                </div>

                <!-- Profil Menü -->
                <div class="relative">
                    <button @click="isProfileMenuOpen = !isProfileMenuOpen" class="flex items-center space-x-3 rounded-lg p-2 hover:bg-accent">
                        <img src="https://github.com/shadcn.png" alt="Admin" class="h-8 w-8 rounded-full" />
                        <div class="hidden text-left md:block">
                            <p class="text-sm font-medium">Süper Admin</p>
                            <p class="text-xs text-muted-foreground">admin@example.com</p>
                        </div>
                    </button>

                    <!-- Profil Dropdown -->
                    <div v-if="isProfileMenuOpen" class="absolute right-0 mt-2 w-48 rounded-lg border bg-card py-1 shadow-lg">
                        <router-link :to="{ name: 'admin-profile' }" class="flex items-center px-4 py-2 text-sm text-muted-foreground hover:bg-accent hover:text-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                                <path d="M19 21v-2a4 4 0 0 0-4-4H9a4 4 0 0 0-4 4v2" />
                                <circle cx="12" cy="7" r="4" />
                            </svg>
                            Profil
                        </router-link>
                        <router-link :to="{ name: 'admin-settings' }" class="flex items-center px-4 py-2 text-sm text-muted-foreground hover:bg-accent hover:text-foreground">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                                <path d="M12.22 2h-.44a2 2 0 0 0-2 2v.18a2 2 0 0 1-1 1.73l-.43.25a2 2 0 0 1-2 0l-.15-.08a2 2 0 0 0-2.73.73l-.22.38a2 2 0 0 0 .73 2.73l.15.1a2 2 0 0 1 1 1.72v.51a2 2 0 0 1-1 1.74l-.15.09a2 2 0 0 0-.73 2.73l.22.38a2 2 0 0 0 2.73.73l.15-.08a2 2 0 0 1 2 0l.43.25a2 2 0 0 1 1 1.73V20a2 2 0 0 0 2 2h.44a2 2 0 0 0 2-2v-.18a2 2 0 0 1 1-1.73l.43-.25a2 2 0 0 1 2 0l.15.08a2 2 0 0 0 2.73-.73l.22-.39a2 2 0 0 0-.73-2.73l-.15-.08a2 2 0 0 1-1-1.74v-.5a2 2 0 0 1 1-1.74l.15-.09a2 2 0 0 0 .73-2.73l-.22-.38a2 2 0 0 0-2.73-.73l-.15.08a2 2 0 0 1-2 0l-.43-.25a2 2 0 0 1-1-1.73V4a2 2 0 0 0-2-2z" />
                                <circle cx="12" cy="12" r="3" />
                            </svg>
                            Ayarlar
                        </router-link>
                        <div class="my-1 border-t"></div>
                        <button @click="logout" class="flex w-full items-center px-4 py-2 text-sm text-red-500 hover:bg-accent">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                                <path d="M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4" />
                                <polyline points="16 17 21 12 16 7" />
                                <line x1="21" x2="9" y1="12" y2="12" />
                            </svg>
                            Çıkış Yap
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </header>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue"
import { Bell } from "lucide-vue-next"
import NotificationsList from '@/components/common/NotificationsList.vue'
import { useNotifications } from '@/composables/useNotifications'

const isProfileMenuOpen = ref(false)

// Bildirim sistemi
const {
    notifications,
    isNotificationsOpen,
    unreadCount,
    markAsRead,
    markAllAsRead,
    addSampleNotifications
} = useNotifications('admin')

// Test için örnek bildirimler ekleme
onMounted(() => {
    addSampleNotifications()
})

const logout = () => {
    // Çıkış işlemleri burada yapılacak
    console.log("Çıkış yapılıyor...")
}

defineEmits(["toggle-sidebar"])
</script>
