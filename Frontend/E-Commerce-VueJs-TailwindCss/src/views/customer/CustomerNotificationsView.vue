<template>
    <div class="container mx-auto p-6">
        <!-- Başlık ve Filtreler -->
        <div class="mb-8">
            <div class="flex flex-col md:flex-row md:items-center md:justify-between gap-4">
                <div>
                    <h1 class="text-2xl font-semibold text-foreground">Bildirimler</h1>
                    <p class="text-sm text-muted-foreground">Tüm bildirimlerinizi görüntüleyin ve yönetin</p>
                </div>
                <div class="flex items-center gap-3">
                    <button @click="markAllAsRead" class="flex items-center gap-2 text-sm text-primary hover:text-primary/80">
                        <CheckCircle class="w-4 h-4" />
                        Tümünü Okundu İşaretle
                    </button>
                    <button @click="clearAllNotifications" class="flex items-center gap-2 text-sm text-rose-500 hover:text-rose-600">
                        <Trash2 class="w-4 h-4" />
                        Tümünü Temizle
                    </button>
                </div>
            </div>

            <!-- Filtreler -->
            <div class="mt-6 flex flex-col md:flex-row gap-4">
                <div class="flex-1">
                    <input 
                        type="text" 
                        placeholder="Bildirimlerde ara..." 
                        v-model="searchQuery"
                        class="w-full h-10 px-3 rounded-lg border bg-background text-sm placeholder:text-muted-foreground focus:outline-none focus:ring-2 focus:ring-primary"
                    />
                </div>
                <div class="flex gap-4">
                    <select 
                        v-model="selectedType" 
                        class="h-10 rounded-lg border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary"
                    >
                        <option value="all">Tüm Tipler</option>
                        <option value="success">Başarılı</option>
                        <option value="warning">Uyarı</option>
                        <option value="error">Hata</option>
                    </select>
                    <select 
                        v-model="selectedStatus" 
                        class="h-10 rounded-lg border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary"
                    >
                        <option value="all">Tüm Durumlar</option>
                        <option value="unread">Okunmamış</option>
                        <option value="read">Okunmuş</option>
                    </select>
                </div>
            </div>
        </div>

        <!-- Bildirim Listesi -->
        <div class="space-y-4">
            <div v-for="notification in filteredNotifications" :key="notification.id" class="relative flex gap-4 p-4 rounded-lg border bg-card hover:bg-accent/50 transition-colors" :class="{ 'bg-primary/5': !notification.isRead }">
                <!-- İkon -->
                <div :class="[
                    'flex h-12 w-12 items-center justify-center rounded-full',
                    notification.type === 'success' ? 'bg-emerald-500/20 text-emerald-500' : 
                    notification.type === 'warning' ? 'bg-amber-500/20 text-amber-500' : 
                    'bg-rose-500/20 text-rose-500'
                ]">
                    <component :is="notification.icon" class="h-6 w-6" />
                </div>

                <!-- İçerik -->
                <div class="flex-1">
                    <div class="flex items-start justify-between gap-4">
                        <div>
                            <h3 class="font-medium" :class="{ 'text-foreground': !notification.isRead }">
                                {{ notification.title }}
                            </h3>
                            <p class="mt-1 text-sm text-muted-foreground">{{ notification.message }}</p>
                        </div>
                        <span class="text-xs text-muted-foreground whitespace-nowrap">{{ notification.time }}</span>
                    </div>

                    <!-- Aksiyonlar -->
                    <div class="mt-3 flex items-center gap-4">
                        <button 
                            v-if="notification.actionLink" 
                            class="text-sm text-primary hover:text-primary/80"
                            @click="handleAction(notification)"
                        >
                            {{ notification.actionText }}
                        </button>
                        <button 
                            v-if="!notification.isRead" 
                            @click="markAsRead(notification.id)"
                            class="text-xs text-muted-foreground hover:text-foreground"
                        >
                            Okundu İşaretle
                        </button>
                        <button 
                            @click="deleteNotification(notification.id)"
                            class="text-xs text-rose-500 hover:text-rose-600"
                        >
                            Sil
                        </button>
                    </div>
                </div>

                <!-- Okunmamış İşareti -->
                <div v-if="!notification.isRead" class="absolute right-4 top-4 h-2 w-2 rounded-full bg-primary"></div>
            </div>

            <!-- Boş Durum -->
            <div v-if="filteredNotifications.length === 0" class="flex flex-col items-center justify-center py-12 text-center">
                <Bell class="h-12 w-12 text-muted-foreground/50" />
                <h3 class="mt-4 text-lg font-medium">Bildirim Bulunamadı</h3>
                <p class="mt-2 text-sm text-muted-foreground">Seçilen filtrelere uygun bildirim bulunmamaktadır.</p>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted } from 'vue'
import { Bell, CheckCircle, AlertTriangle, XCircle, Trash2 } from 'lucide-vue-next'
import { useRouter } from 'vue-router'
import { useNotifications } from '@/composables/useNotifications'

const router = useRouter()

// Filtreler
const searchQuery = ref('')
const selectedType = ref('all')
const selectedStatus = ref('all')

// Bildirim sistemi
const {
    notifications,
    unreadCount,
    markAsRead,
    markAllAsRead,
    deleteNotification,
    clearAllNotifications,
    addSampleNotifications
} = useNotifications()

// Test için örnek bildirimler ekleme
onMounted(() => {
    addSampleNotifications()
})

// Filtrelenmiş bildirimler
const filteredNotifications = computed(() => {
    return notifications.value
        .filter(notification => {
            // Arama filtresi
            if (searchQuery.value && !notification.title.toLowerCase().includes(searchQuery.value.toLowerCase()) && 
                !notification.message.toLowerCase().includes(searchQuery.value.toLowerCase())) {
                return false
            }
            // Tip filtresi
            if (selectedType.value !== 'all' && notification.type !== selectedType.value) {
                return false
            }
            // Durum filtresi
            if (selectedStatus.value === 'read' && !notification.isRead) {
                return false
            }
            if (selectedStatus.value === 'unread' && notification.isRead) {
                return false
            }
            return true
        })
})

const handleAction = (notification: any) => {
    if (notification.actionLink) {
        router.push(notification.actionLink)
    }
}
</script> 