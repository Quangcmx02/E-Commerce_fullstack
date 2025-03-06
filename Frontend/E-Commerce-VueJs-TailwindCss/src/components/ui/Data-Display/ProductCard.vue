<template>
  <div
    class="relative flex flex-col rounded-lg border bg-white shadow-sm dark:border-zinc-700 dark:bg-zinc-800"
    :class="className"
  >
    <!-- Ürün Resmi -->
    <div class="relative">
      <img
        :src="product.image"
        :alt="product.name"
        class="h-48 w-full rounded-t-lg object-cover"
        @error="handleImageError"
      />
      <!-- İndirim Etiketi -->
      <div
        v-if="product.discount"
        class="absolute left-2 top-2 rounded-full bg-red-500 px-2 py-1 text-xs font-semibold text-white"
      >
        -{{ product.discount }}%
      </div>
      <!-- Favori Butonu -->
      <button
        @click="$emit('toggle-favorite')"
        class="absolute right-2 top-2 rounded-full bg-white p-1.5 text-gray-700 transition hover:bg-gray-100 dark:bg-zinc-700 dark:text-zinc-200 dark:hover:bg-zinc-600"
      >
        <svg
          :class="{ 'text-red-500 fill-red-500': product.isFavorite }"
          class="h-5 w-5"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"
          />
        </svg>
      </button>
    </div>

    <!-- Ürün Bilgileri -->
    <div class="flex flex-1 flex-col p-4">
      <h3 class="mb-2 text-lg font-semibold text-gray-900 dark:text-white">
        {{ product.name }}
      </h3>
      <p class="mb-4 text-sm text-gray-600 dark:text-zinc-300">
        {{ product.description }}
      </p>

      <!-- Fiyat Bilgisi -->
      <div class="mt-auto">
        <div class="flex items-center gap-2">
          <span
            v-if="product.discount"
            class="text-sm text-gray-500 line-through dark:text-zinc-400"
          >
            {{ formatPrice(product.originalPrice) }}
          </span>
          <span class="text-xl font-bold text-gray-900 dark:text-white">
            {{ formatPrice(product.price) }}
          </span>
        </div>

        <!-- Stok Durumu -->
        <div
          class="mb-3 mt-2 text-sm"
          :class="{
            'text-green-600 dark:text-green-400': product.stock > 10,
            'text-yellow-600 dark:text-yellow-400':
              product.stock > 0 && product.stock <= 10,
            'text-red-600 dark:text-red-400': product.stock === 0,
          }"
        >
          {{
            product.stock === 0
              ? 'Stokta Yok'
              : product.stock <= 10
              ? 'Son ' + product.stock + ' ürün'
              : 'Stokta Mevcut'
          }}
        </div>

        <!-- Sepete Ekle Butonu -->
        <button
          @click="$emit('add-to-cart')"
          :disabled="product.stock === 0"
          class="mt-2 w-full rounded-lg bg-blue-600 px-4 py-2 text-center text-sm font-semibold text-white transition hover:bg-blue-700 disabled:cursor-not-allowed disabled:bg-gray-400 dark:disabled:bg-zinc-600"
        >
          {{ product.stock === 0 ? 'Stokta Yok' : 'Sepete Ekle' }}
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
interface Product {
  id: number;
  name: string;
  description: string;
  image: string;
  price: number;
  originalPrice?: number;
  discount?: number;
  stock: number;
  isFavorite: boolean;
}

interface Props {
  product: Product;
  className?: string;
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
});

defineEmits(['add-to-cart', 'toggle-favorite']);

const handleImageError = (e: Event) => {
  const target = e.target as HTMLImageElement;
  target.src = '/placeholder-product.png'; // Varsayılan ürün resmi
};

const formatPrice = (price: number) => {
  return new Intl.NumberFormat('tr-TR', {
    style: 'currency',
    currency: 'TRY',
  }).format(price);
};
</script> 