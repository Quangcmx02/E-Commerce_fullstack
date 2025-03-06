<template>
  <div class="container py-8">
    <!-- Breadcrumb -->
    <nav class="mb-8 flex" aria-label="Breadcrumb">
      <ol class="inline-flex items-center space-x-1 text-sm text-muted-foreground md:space-x-2">
        <li>
          <router-link to="/" class="hover:text-foreground">Ana Sayfa</router-link>
        </li>
        <li>
          <span class="mx-2">/</span>
        </li>
        <li class="text-foreground">İndirimli Ürünler</li>
      </ol>
    </nav>

    <!-- Başlık ve Açıklama -->
    <div class="mb-8">
      <h1 class="text-3xl font-bold tracking-tight">İndirimli Ürünler</h1>
      <p class="mt-2 text-muted-foreground">En iyi fırsatları ve kampanyaları kaçırmayın</p>
    </div>

    <!-- Filtreler -->
    <div class="mb-8 grid gap-4 md:grid-cols-2 lg:grid-cols-4">
      <!-- Kategori Filtresi -->
      <div class="rounded-lg border bg-card p-4">
        <label class="text-sm font-medium">Kategori</label>
        <select v-model="filters.category" class="mt-2 w-full rounded-md border bg-background px-3 py-2">
          <option value="">Tümü</option>
          <option value="telefon">Telefon</option>
          <option value="laptop">Laptop</option>
          <option value="tablet">Tablet</option>
        </select>
      </div>

      <!-- Fiyat Aralığı -->
      <div class="rounded-lg border bg-card p-4">
        <label class="text-sm font-medium">Fiyat Aralığı</label>
        <div class="mt-2 grid grid-cols-2 gap-2">
          <input type="number" v-model="filters.minPrice" placeholder="Min" class="rounded-md border bg-background px-3 py-2">
          <input type="number" v-model="filters.maxPrice" placeholder="Max" class="rounded-md border bg-background px-3 py-2">
        </div>
      </div>

      <!-- İndirim Oranı -->
      <div class="rounded-lg border bg-card p-4">
        <label class="text-sm font-medium">Minimum İndirim</label>
        <select v-model="filters.minDiscount" class="mt-2 w-full rounded-md border bg-background px-3 py-2">
          <option value="10">%10 ve üzeri</option>
          <option value="20">%20 ve üzeri</option>
          <option value="30">%30 ve üzeri</option>
          <option value="40">%40 ve üzeri</option>
          <option value="50">%50 ve üzeri</option>
        </select>
      </div>

      <!-- Sıralama -->
      <div class="rounded-lg border bg-card p-4">
        <label class="text-sm font-medium">Sıralama</label>
        <select v-model="filters.sort" class="mt-2 w-full rounded-md border bg-background px-3 py-2">
          <option value="discount-desc">İndirim Oranı (Çok > Az)</option>
          <option value="price-asc">Fiyat (Az > Çok)</option>
          <option value="price-desc">Fiyat (Çok > Az)</option>
          <option value="name-asc">İsim (A > Z)</option>
        </select>
      </div>
    </div>

    <!-- Ürün Listesi -->
    <div v-if="!loading" class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
      <div v-for="product in filteredProducts" :key="product.id" class="group relative rounded-lg border bg-card">
        <!-- İndirim Etiketi -->
        <div class="absolute right-4 top-4 z-10">
          <span class="rounded-full bg-destructive px-2 py-1 text-xs font-medium text-destructive-foreground">
            %{{ product.discount }} İndirim
          </span>
        </div>

        <!-- Ürün Görseli -->
        <div class="aspect-square overflow-hidden rounded-t-lg">
          <img :src="product.image" :alt="product.name" class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105">
        </div>

        <!-- Ürün Bilgileri -->
        <div class="p-4">
          <h3 class="font-semibold">{{ product.name }}</h3>
          
          <!-- Fiyat Bilgisi -->
          <div class="mt-2 flex items-baseline space-x-2">
            <span class="text-xl font-bold">{{ formatPrice(product.price) }} TL</span>
            <span class="text-sm text-muted-foreground line-through">{{ formatPrice(product.oldPrice) }} TL</span>
          </div>

          <!-- Stok Durumu -->
          <div class="mt-2 flex items-center space-x-2">
            <div class="h-2 w-2 rounded-full" :class="{'bg-green-500': product.stock > 0, 'bg-destructive': product.stock === 0}"></div>
            <span class="text-sm text-muted-foreground">{{ product.stock > 0 ? 'Stokta' : 'Tükendi' }}</span>
          </div>

          <!-- Butonlar -->
          <div class="mt-4 grid grid-cols-2 gap-2">
            <button @click="addToCart(product.id)"
              class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
              :disabled="product.stock === 0">
              <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                <circle cx="8" cy="21" r="1" />
                <circle cx="19" cy="21" r="1" />
                <path d="M2.05 2.05h2l2.66 12.42a2 2 0 0 0 2 1.58h9.78a2 2 0 0 0 1.95-1.57l1.65-7.43H5.12" />
              </svg>
              Sepete Ekle
            </button>
            <button @click="addToFavorites(product.id)"
              class="inline-flex items-center justify-center rounded-md border px-4 py-2 text-sm font-medium hover:bg-accent transition-colors">
              <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                <path d="M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z" />
              </svg>
              Favorilere Ekle
            </button>
          </div>
        </div>
      </div>
    </div>

    <!-- Yükleniyor -->
    <div v-else class="grid gap-6 sm:grid-cols-2 lg:grid-cols-4">
      <div v-for="n in 8" :key="n" class="rounded-lg border bg-card">
        <div class="aspect-square animate-pulse bg-muted"></div>
        <div class="p-4 space-y-3">
          <div class="h-4 w-3/4 animate-pulse rounded bg-muted"></div>
          <div class="h-4 w-1/2 animate-pulse rounded bg-muted"></div>
          <div class="h-8 w-full animate-pulse rounded bg-muted"></div>
        </div>
      </div>
    </div>

    <!-- Boş Durum -->
    <div v-if="!loading && filteredProducts.length === 0" class="text-center py-12">
      <div class="flex flex-col items-center space-y-4">
        <svg class="w-12 h-12 text-muted-foreground" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9.172 16.172a4 4 0 015.656 0M9 10h.01M15 10h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z" />
        </svg>
        <div>
          <h3 class="text-lg font-semibold">Ürün Bulunamadı</h3>
          <p class="text-muted-foreground mt-1">Seçtiğiniz filtrelere uygun ürün bulunamadı.</p>
        </div>
        <button @click="resetFilters" class="inline-flex items-center justify-center rounded-md bg-primary px-6 py-3 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors">
          Filtreleri Sıfırla
        </button>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, computed } from 'vue'
import { useToast } from 'vue-toastification'

const toast = useToast()
const loading = ref(true)

// Filtreler
const filters = ref({
  category: '',
  minPrice: '',
  maxPrice: '',
  minDiscount: '10',
  sort: 'discount-desc'
})

// Örnek ürün verileri
const products = ref([
  {
    id: 1,
    name: 'iPhone 14 Pro',
    price: 54999,
    oldPrice: 64999,
    discount: 15,
    stock: 10,
    image: 'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-14-pro-finish-select-202209-6-1inch-deeppurple?wid=2560&hei=1440&fmt=p-jpg&qlt=80&.v=1663703840578',
    category: 'telefon'
  },
  {
    id: 2,
    name: 'Samsung Galaxy S23 Ultra',
    price: 49999,
    oldPrice: 59999,
    discount: 20,
    stock: 15,
    image: 'https://images.samsung.com/is/image/samsung/p6pim/tr/2302/gallery/tr-galaxy-s23-s918-sm-s918bzgctur-thumb-534863401',
    category: 'telefon'
  },
  {
    id: 3,
    name: 'MacBook Pro 14"',
    price: 72999,
    oldPrice: 89999,
    discount: 25,
    stock: 5,
    image: 'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/mbp14-spacegray-select-202301?wid=904&hei=840&fmt=jpeg&qlt=90&.v=1671304673229',
    category: 'laptop'
  },
  {
    id: 4,
    name: 'iPad Air',
    price: 24999,
    oldPrice: 32999,
    discount: 30,
    stock: 20,
    image: 'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/ipad-air-select-wifi-blue-202203?wid=940&hei=1112&fmt=png-alpha&.v=1645065732688',
    category: 'tablet'
  }
])

// Filtrelenmiş ürünler
const filteredProducts = computed(() => {
  let result = [...products.value]

  // Kategori filtresi
  if (filters.value.category) {
    result = result.filter(p => p.category === filters.value.category)
  }

  // Fiyat aralığı filtresi
  if (filters.value.minPrice) {
    result = result.filter(p => p.price >= Number(filters.value.minPrice))
  }
  if (filters.value.maxPrice) {
    result = result.filter(p => p.price <= Number(filters.value.maxPrice))
  }

  // İndirim oranı filtresi
  if (filters.value.minDiscount) {
    result = result.filter(p => p.discount >= Number(filters.value.minDiscount))
  }

  // Sıralama
  switch (filters.value.sort) {
    case 'discount-desc':
      result.sort((a, b) => b.discount - a.discount)
      break
    case 'price-asc':
      result.sort((a, b) => a.price - b.price)
      break
    case 'price-desc':
      result.sort((a, b) => b.price - a.price)
      break
    case 'name-asc':
      result.sort((a, b) => a.name.localeCompare(b.name))
      break
  }

  return result
})

// Metodlar
const formatPrice = (price) => {
  return new Intl.NumberFormat('tr-TR').format(price)
}

const addToCart = (productId) => {
  // Sepete ekleme işlemi burada yapılacak
  toast.success('Ürün sepete eklendi')
}

const addToFavorites = (productId) => {
  // Favorilere ekleme işlemi burada yapılacak
  toast.success('Ürün favorilere eklendi')
}

const resetFilters = () => {
  filters.value = {
    category: '',
    minPrice: '',
    maxPrice: '',
    minDiscount: '10',
    sort: 'discount-desc'
  }
}

// Sayfa yüklendiğinde
setTimeout(() => {
  loading.value = false
}, 1000)
</script> 