<template>
    <div class="rounded-lg border bg-white p-4 shadow-sm dark:border-zinc-700 dark:bg-zinc-800" :class="className">
        <div class="flex items-start justify-between">
            <!-- Sipariş Başlığı ve Tarihi -->
            <div>
                <h3 class="text-lg font-semibold text-gray-900 dark:text-white">Sipariş #{{ order.id }}</h3>
                <p class="text-sm text-gray-600 dark:text-zinc-300">
                    {{ formatDate(order.date) }}
                </p>
            </div>

            <!-- Sipariş Durumu -->
            <div
                class="rounded-full px-3 py-1 text-sm font-medium"
                :class="{
                    'bg-green-100 text-green-800 dark:bg-green-900/30 dark:text-green-400': order.status === 'completed',
                    'bg-yellow-100 text-yellow-800 dark:bg-yellow-900/30 dark:text-yellow-400': order.status === 'processing',
                    'bg-red-100 text-red-800 dark:bg-red-900/30 dark:text-red-400': order.status === 'cancelled',
                }"
            >
                {{ getStatusText(order.status) }}
            </div>
        </div>

        <!-- Sipariş Ürünleri -->
        <div class="mt-4 space-y-3">
            <div v-for="item in order.items" :key="item.id" class="flex items-center gap-3">
                <img :src="item.image" :alt="item.name" class="h-16 w-16 rounded-md object-cover" @error="handleImageError" />
                <div class="flex-1">
                    <h4 class="font-medium text-gray-900 dark:text-white">
                        {{ item.name }}
                    </h4>
                    <p class="text-sm text-gray-600 dark:text-zinc-300">{{ item.quantity }} adet x {{ formatPrice(item.price) }}</p>
                </div>
                <div class="text-right">
                    <p class="font-medium text-gray-900 dark:text-white">
                        {{ formatPrice(item.quantity * item.price) }}
                    </p>
                </div>
            </div>
        </div>

        <!-- Sipariş Özeti -->
        <div class="mt-4 border-t pt-4 dark:border-zinc-700">
            <div class="flex justify-between text-sm">
                <span class="text-gray-600 dark:text-zinc-300">Ara Toplam:</span>
                <span class="font-medium text-gray-900 dark:text-white">{{ formatPrice(order.subtotal) }}</span>
            </div>
            <div class="mt-1 flex justify-between text-sm">
                <span class="text-gray-600 dark:text-zinc-300">Kargo:</span>
                <span class="font-medium text-gray-900 dark:text-white">{{ formatPrice(order.shipping) }}</span>
            </div>
            <div class="mt-3 flex justify-between text-lg font-semibold">
                <span class="text-gray-900 dark:text-white">Toplam:</span>
                <span class="text-gray-900 dark:text-white">{{ formatPrice(order.total) }}</span>
            </div>
        </div>

        <!-- Sipariş Detay Butonu -->
        <button @click="$emit('view-details', order.id)" class="mt-4 w-full rounded-lg bg-blue-600 px-4 py-2 text-center text-sm font-semibold text-white transition hover:bg-blue-700">Sipariş Detayları</button>
    </div>
</template>

<script setup lang="ts">
interface OrderItem {
    id: number;
    name: string;
    image: string;
    price: number;
    quantity: number;
}

interface Order {
    id: number;
    date: string;
    status: "completed" | "processing" | "cancelled";
    items: OrderItem[];
    subtotal: number;
    shipping: number;
    total: number;
}

interface Props {
    order: Order;
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    className: "",
});

defineEmits(["view-details"]);

const handleImageError = (e: Event) => {
    const target = e.target as HTMLImageElement;
    target.src = "/placeholder-product.png";
};

const formatPrice = (price: number) => {
    return new Intl.NumberFormat("tr-TR", {
        style: "currency",
        currency: "TRY",
    }).format(price);
};

const formatDate = (date: string) => {
    return new Date(date).toLocaleDateString("tr-TR", {
        year: "numeric",
        month: "long",
        day: "numeric",
    });
};

const getStatusText = (status: Order["status"]) => {
    const statusMap = {
        completed: "Tamamlandı",
        processing: "İşleniyor",
        cancelled: "İptal Edildi",
    };
    return statusMap[status];
};
</script>
