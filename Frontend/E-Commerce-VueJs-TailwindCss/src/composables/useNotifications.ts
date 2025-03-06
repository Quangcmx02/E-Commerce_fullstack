import { ref, computed } from 'vue'
import { Bell, CheckCircle, AlertTriangle, XCircle, Package, ShoppingBag, DollarSign, UserPlus, Settings } from 'lucide-vue-next'

export interface Notification {
    id: number
    type: 'success' | 'warning' | 'error'
    icon: any
    title: string
    message: string
    time: string
    isRead: boolean
    actionLink?: string
    actionText?: string
}

export function useNotifications(role: 'admin' | 'seller' | 'customer' = 'admin') {
    const notifications = ref<Notification[]>([])
    const isNotificationsOpen = ref(false)

    // Okunmamış bildirim sayısı
    const unreadCount = computed(() => {
        return notifications.value.filter(n => !n.isRead).length
    })

    // Bildirim ekleme
    const addNotification = (notification: Omit<Notification, 'id' | 'icon' | 'isRead'>) => {
        const icon = notification.type === 'success' ? CheckCircle :
                    notification.type === 'warning' ? AlertTriangle : XCircle

        notifications.value.unshift({
            id: Date.now(),
            icon,
            isRead: false,
            ...notification
        })
    }

    // Bildirimi okundu işaretleme
    const markAsRead = (id: number) => {
        const notification = notifications.value.find(n => n.id === id)
        if (notification) {
            notification.isRead = true
        }
    }

    // Tüm bildirimleri okundu işaretleme
    const markAllAsRead = () => {
        notifications.value.forEach(notification => {
            notification.isRead = true
        })
    }

    // Bildirim silme
    const deleteNotification = (id: number) => {
        const index = notifications.value.findIndex(n => n.id === id)
        if (index !== -1) {
            notifications.value.splice(index, 1)
        }
    }

    // Tüm bildirimleri temizleme
    const clearAllNotifications = () => {
        notifications.value = []
    }

    // Admin için örnek bildirimler
    const addAdminSampleNotifications = () => {
        addNotification({
            type: 'success',
            title: 'Yeni Satıcı Kaydı',
            message: 'Elektronik kategorisinde yeni bir satıcı kaydı yapıldı.',
            time: '5 dakika önce',
            actionLink: '/admin/sellers',
            actionText: 'Satıcıyı Görüntüle'
        })

        addNotification({
            type: 'warning',
            title: 'Sistem Performansı',
            message: 'Sunucu yükü kritik seviyeye yaklaşıyor.',
            time: '1 saat önce',
            actionLink: '/admin/analytics',
            actionText: 'Detayları Görüntüle'
        })

        addNotification({
            type: 'error',
            title: 'Güvenlik Uyarısı',
            message: 'Şüpheli giriş denemeleri tespit edildi.',
            time: '2 saat önce',
            actionLink: '/admin/settings',
            actionText: 'Güvenlik Ayarları'
        })
    }

    // Satıcı için örnek bildirimler
    const addSellerSampleNotifications = () => {
        addNotification({
            type: 'success',
            title: 'Yeni Sipariş',
            message: '#12345 numaralı yeni sipariş alındı.',
            time: '5 dakika önce',
            actionLink: '/seller/orders/12345',
            actionText: 'Siparişi Görüntüle'
        })

        addNotification({
            type: 'warning',
            title: 'Stok Uyarısı',
            message: 'iPhone 14 Pro Max ürününde stok azalıyor.',
            time: '1 saat önce',
            actionLink: '/seller/products/iphone-14',
            actionText: 'Ürünü Görüntüle'
        })

        addNotification({
            type: 'success',
            title: 'Yeni Değerlendirme',
            message: 'Ürünlerinize yeni bir değerlendirme yapıldı.',
            time: '3 saat önce',
            actionLink: '/seller/reviews',
            actionText: 'Değerlendirmeyi Görüntüle'
        })
    }

    // Müşteri için örnek bildirimler
    const addCustomerSampleNotifications = () => {
        addNotification({
            type: 'success',
            title: 'Sipariş Durumu',
            message: 'Siparişiniz kargoya verildi.',
            time: '5 dakika önce',
            actionLink: '/customer/orders/12345',
            actionText: 'Siparişi Takip Et'
        })

        addNotification({
            type: 'warning',
            title: 'Fırsat Ürünü',
            message: 'Favorinizdeki ürün indirime girdi!',
            time: '1 saat önce',
            actionLink: '/customer/favorites',
            actionText: 'Ürünü Görüntüle'
        })

        addNotification({
            type: 'success',
            title: 'Kupon Kazandınız',
            message: '%20 indirim kuponu hesabınıza tanımlandı.',
            time: '2 saat önce',
            actionLink: '/customer/coupons',
            actionText: 'Kuponu Kullan'
        })
    }

    // Role göre örnek bildirimler ekleme
    const addSampleNotifications = () => {
        switch (role) {
            case 'admin':
                addAdminSampleNotifications()
                break
            case 'seller':
                addSellerSampleNotifications()
                break
            case 'customer':
                addCustomerSampleNotifications()
                break
        }
    }

    return {
        notifications,
        isNotificationsOpen,
        unreadCount,
        addNotification,
        markAsRead,
        markAllAsRead,
        deleteNotification,
        clearAllNotifications,
        addSampleNotifications
    }
}

// Bildirim tipi için yardımcı fonksiyonlar
export const getNotificationTypeClasses = (type: string) => {
    switch (type) {
        case 'success':
            return 'bg-emerald-500/20 text-emerald-500'
        case 'warning':
            return 'bg-amber-500/20 text-amber-500'
        case 'error':
            return 'bg-rose-500/20 text-rose-500'
        default:
            return 'bg-gray-500/20 text-gray-500'
    }
}

export const getNotificationIcon = (type: string) => {
    switch (type) {
        case 'success':
            return CheckCircle
        case 'warning':
            return AlertTriangle
        case 'error':
            return XCircle
        default:
            return Bell
    }
} 