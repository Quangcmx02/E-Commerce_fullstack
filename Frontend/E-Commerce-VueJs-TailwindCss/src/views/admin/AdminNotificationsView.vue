<template>
    <div class="container mx-auto p-6">
        <!-- Başlık ve Filtreler -->
        <div class="mb-8">
            <div class="flex flex-col md:flex-row md:items-center md:justify-between gap-4">
                <div>
                    <h1 class="text-2xl font-semibold text-foreground">Bildirimler</h1>
                    <p class="text-sm text-muted-foreground">Tüm sistem bildirimlerini görüntüleyin ve yönetin</p>
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
import { ref, computed } from 'vue'
import { Bell, CheckCircle, AlertTriangle, XCircle, Trash2 } from 'lucide-vue-next'
import { useRouter } from 'vue-router'

const router = useRouter()

// Filtreler
const searchQuery = ref('')
const selectedType = ref('all')
const selectedStatus = ref('all')

// Örnek bildirim verileri
const notifications = ref([
    {
        id: 1,
        type: 'success',
        icon: CheckCircle,
        title: 'Yeni Sipariş Alındı',
        message: '#12345 numaralı sipariş başarıyla oluşturuldu ve ödeme alındı.',
        time: '5 dakika önce',
        isRead: false,
        actionLink: '/admin/orders/12345',
        actionText: 'Siparişi Görüntüle'
    },
    {
        id: 2,
        type: 'warning',
        icon: AlertTriangle,
        title: 'Stok Uyarısı',
        message: 'iPhone 14 Pro Max ürününün stok seviyesi kritik seviyenin altına düştü.',
        time: '1 saat önce',
        isRead: false,
        actionLink: '/admin/products/iphone-14',
        actionText: 'Ürünü Görüntüle'
    },
    {
        id: 3,
        type: 'error',
        icon: XCircle,
        title: 'Ödeme Hatası',
        message: '#12344 numaralı siparişin ödemesi başarısız oldu.',
        time: '2 saat önce',
        isRead: true,
        actionLink: '/admin/orders/12344',
        actionText: 'Siparişi Görüntüle'
    },
    {
        id: 4,
        type: 'success',
        icon: CheckCircle,
        title: 'Yeni Üye Kaydı',
        message: 'John Doe adlı yeni bir kullanıcı kayıt oldu.',
        time: '3 saat önce',
        isRead: true,
        actionLink: '/admin/users/john-doe',
        actionText: 'Kullanıcıyı Görüntüle'
    },
    {
        id: 5,
        type: 'warning',
        icon: AlertTriangle,
        title: 'Sistem Güncellemesi',
        message: 'Sistem bakımı için planlı kesinti yapılacak.',
        time: '1 gün önce',
        isRead: true
    }
])

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

// Bildirim işlemleri
const markAsRead = (id: number) => {
    const notification = notifications.value.find(n => n.id === id)
    if (notification) {
        notification.isRead = true
    }
}

const markAllAsRead = () => {
    notifications.value.forEach(notification => {
        notification.isRead = true
    })
}

const deleteNotification = (id: number) => {
    const index = notifications.value.findIndex(n => n.id === id)
    if (index !== -1) {
        notifications.value.splice(index, 1)
    }
}

const clearAllNotifications = () => {
    notifications.value = []
}

const handleAction = (notification: any) => {
    if (notification.actionLink) {
        router.push(notification.actionLink)
    }
}
</script> 