<template>
    <div class="absolute right-0 mt-2 w-80 rounded-lg border bg-card py-1 shadow-lg">
        <div class="px-4 py-2 border-b border-border">
            <div class="flex items-center justify-between">
                <h3 class="text-sm font-semibold">Bildirimler</h3>
                <button @click="markAllAsRead" class="text-xs text-primary hover:text-primary/80">
                    Tümünü Okundu İşaretle
                </button>
            </div>
        </div>
        <div class="max-h-[400px] overflow-y-auto">
            <div v-for="notification in notifications" :key="notification.id" class="relative px-4 py-3 hover:bg-accent" :class="{ 'bg-primary/5': !notification.isRead }">
                <div class="flex items-start gap-3">
                    <div :class="['flex h-8 w-8 items-center justify-center rounded-full', getNotificationTypeClasses(notification.type)]">
                        <component :is="notification.icon" class="h-4 w-4" />
                    </div>
                    <div class="flex-1">
                        <p class="text-sm font-medium" :class="{ 'text-foreground': !notification.isRead }">
                            {{ notification.title }}
                        </p>
                        <p class="text-xs text-muted-foreground">{{ notification.message }}</p>
                        <p class="mt-1 text-xs text-muted-foreground">{{ notification.time }}</p>
                        <div v-if="notification.actionLink" class="mt-2">
                            <router-link :to="notification.actionLink" class="text-xs text-primary hover:text-primary/80">
                                {{ notification.actionText }}
                            </router-link>
                        </div>
                    </div>
                    <button v-if="!notification.isRead" @click="markAsRead(notification.id)" class="absolute right-2 top-2 h-2 w-2 rounded-full bg-primary"></button>
                </div>
            </div>
        </div>
        <div class="border-t border-border p-2">
            <router-link :to="allNotificationsRoute" class="block rounded-md px-4 py-2 text-center text-sm text-muted-foreground hover:bg-accent">
                Tüm Bildirimleri Görüntüle
            </router-link>
        </div>
    </div>
</template>

<script setup lang="ts">
import { type Notification, getNotificationTypeClasses } from '@/composables/useNotifications'

defineProps<{
    notifications: Notification[]
    allNotificationsRoute: string
}>()

const emit = defineEmits<{
    (e: 'markAsRead', id: number): void
    (e: 'markAllAsRead'): void
}>()

const markAsRead = (id: number) => {
    emit('markAsRead', id)
}

const markAllAsRead = () => {
    emit('markAllAsRead')
}
</script> 