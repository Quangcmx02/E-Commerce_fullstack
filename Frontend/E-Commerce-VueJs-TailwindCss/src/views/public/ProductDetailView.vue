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
                <li>
                    <router-link to="/categories" class="hover:text-foreground">Kategoriler</router-link>
                </li>
                <li>
                    <span class="mx-2">/</span>
                </li>
                <li>
                    <router-link :to="'/categories/' + product.category.slug" class="hover:text-foreground">{{ product.category.name }}</router-link>
                </li>
                <li>
                    <span class="mx-2">/</span>
                </li>
                <li class="text-foreground">{{ product.name }}</li>
            </ol>
        </nav>

        <!-- Yükleniyor -->
        <div v-if="loading" class="flex items-center justify-center py-12">
            <div class="h-8 w-8 animate-spin rounded-full border-4 border-primary border-t-transparent"></div>
        </div>

        <!-- Ürün Detayı -->
        <div v-else class="grid gap-8 lg:grid-cols-2">
            <!-- Sol Taraf - Ürün Görselleri -->
            <div class="space-y-4">
                <!-- Ana Görsel -->
                <div class="aspect-[4/3] overflow-hidden rounded-lg border bg-background">
                    <img :src="selectedImage || product.images[0]" :alt="product.name" class="h-full w-full object-cover" />
                </div>

                <!-- Küçük Görseller -->
                <div class="grid grid-cols-4 gap-4">
                    <button v-for="(image, index) in product.images" :key="index" class="aspect-square overflow-hidden rounded-lg border bg-background" :class="{ 'ring-2 ring-primary': selectedImage === image }" @click="selectedImage = image">
                        <img :src="image" :alt="product.name" class="h-full w-full object-cover" />
                    </button>
                </div>

                <!-- Öne Çıkan Özellikler -->
                <div class="mt-6 grid grid-cols-2 gap-4">
                    <div v-for="(value, key) in product.highlightedFeatures" :key="key" class="flex items-center space-x-3 rounded-lg border p-3 hover:bg-accent transition-colors">
                        <div class="flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10">
                            <FeatureIcons :name="value.icon" class="h-5 w-5 text-primary" />
                        </div>
                        <div>
                            <p class="text-sm font-medium">{{ key }}</p>
                            <p class="text-sm text-muted-foreground">{{ value.text }}</p>
                        </div>
                    </div>
                </div>

                <!-- Hızlı Bilgi ve Sosyal Paylaşım -->
                <div class="mt-6 grid gap-4">
                    <!-- Hızlı Bilgi -->
                    <div class="rounded-lg border p-4">
                        <div class="space-y-3">
                            <div class="flex items-center justify-between">
                                <span class="text-sm font-medium">Kargo Durumu</span>
                                <span class="text-sm text-green-600">Bugün kargoda</span>
                            </div>
                            <div class="flex items-center justify-between">
                                <span class="text-sm font-medium">Stok Durumu</span>
                                <span class="text-sm">{{ product.stock }} adet</span>
                            </div>
                            <div class="flex items-center justify-between">
                                <span class="text-sm font-medium">Garanti</span>
                                <span class="text-sm">2 Yıl</span>
                            </div>
                            <div class="flex items-center justify-between">
                                <span class="text-sm font-medium">İade</span>
                                <span class="text-sm">14 gün içinde ücretsiz iade</span>
                            </div>
                        </div>
                    </div>

                    <!-- Sosyal Paylaşım ve Favori -->
                    <div class="flex items-center justify-between rounded-lg border p-4">
                        <div class="flex items-center space-x-2">
                            <button class="rounded-lg p-2 hover:bg-accent">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-blue-600">
                                    <path d="M18 2h-3a5 5 0 0 0-5 5v3H7v4h3v8h4v-8h3l1-4h-4V7a1 1 0 0 1 1-1h3z" />
                                </svg>
                            </button>
                            <button class="rounded-lg p-2 hover:bg-accent">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-blue-400">
                                    <path d="M22 4s-.7 2.1-2 3.4c1.6 10-9.4 17.3-18 11.6 2.2.1 4.4-.6 6-2C3 15.5.5 9.6 3 5c2.2 2.6 5.6 4.1 9 4-.9-4.2 4-6.6 7-3.8 1.1 0 3-1.2 3-1.2z" />
                                </svg>
                            </button>
                            <button class="rounded-lg p-2 hover:bg-accent">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-green-600">
                                    <path d="M4 12v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2v-8" />
                                    <polyline points="16 6 12 2 8 6" />
                                    <line x1="12" y1="2" x2="12" y2="15" />
                                </svg>
                            </button>
                        </div>
                        <div class="flex items-center space-x-2">
                            <button class="flex items-center space-x-2 rounded-lg border px-4 py-2 hover:bg-accent">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z" />
                                </svg>
                                <span class="text-sm font-medium">Favorilere Ekle</span>
                            </button>
                            <button class="flex items-center space-x-2 rounded-lg border px-4 py-2 hover:bg-accent">
                                <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M21 11V5a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h6" />
                                    <path d="m12 12 4 10 1.7-4.3L22 16Z" />
                                </svg>
                                <span class="text-sm font-medium">Karşılaştır</span>
                            </button>
                        </div>
                    </div>
                </div>

                <!-- Renk/Model Seçenekleri -->
                <div class="mt-6">
                    <h3 class="mb-4 text-sm font-medium">Renk Seçenekleri</h3>
                    <div class="flex space-x-2">
                        <button
                            v-for="color in product.colors"
                            :key="color.name"
                            class="group relative h-9 w-9 overflow-hidden rounded-full border-2"
                            :class="{
                                'border-primary': color.name === selectedColor,
                                'border-transparent': color.name !== selectedColor,
                            }"
                            :style="{ backgroundColor: color.hex }"
                            @click="selectedColor = color.name"
                        >
                            <span class="sr-only">{{ color.name }}</span>
                            <span
                                class="absolute inset-0 rounded-full ring-2 ring-offset-2"
                                :class="{
                                    'ring-primary': color.name === selectedColor,
                                    'ring-transparent': color.name !== selectedColor,
                                }"
                            ></span>
                        </button>
                    </div>
                </div>
            </div>

            <!-- Sağ Taraf - Ürün Bilgileri -->
            <div class="space-y-6">
                <div>
                    <h1 class="text-3xl font-bold tracking-tight">{{ product.name }}</h1>
                    <p class="mt-2 text-muted-foreground">{{ product.description }}</p>
                </div>

                <!-- Fiyat ve İndirim -->
                <div class="flex items-baseline space-x-4">
                    <span class="text-3xl font-bold">{{ product.price }} TL</span>
                    <span v-if="product.oldPrice" class="text-xl text-muted-foreground line-through">{{ product.oldPrice }} TL</span>
                    <span v-if="product.discount" class="rounded-full bg-destructive px-2 py-1 text-sm font-medium text-destructive-foreground">%{{ product.discount }} İndirim</span>
                </div>

                <!-- Stok Durumu -->
                <div class="flex items-center space-x-2">
                    <div class="h-3 w-3 rounded-full" :class="product.stock > 0 ? 'bg-green-500' : 'bg-destructive'"></div>
                    <span class="text-sm">
                        {{ product.stock > 0 ? "Stokta" : "Stokta Yok" }}
                        <span v-if="product.stock > 0" class="text-muted-foreground">({{ product.stock }} adet)</span>
                    </span>
                </div>

                <!-- Adet Seçimi ve Sepete Ekle -->
                <div class="space-y-4">
                    <div class="flex items-center space-x-4">
                        <label for="quantity" class="text-sm font-medium">Adet:</label>
                        <div class="flex items-center rounded-md border">
                            <button class="px-3 py-2 text-muted-foreground hover:text-foreground disabled:pointer-events-none disabled:opacity-50" :disabled="quantity <= 1" @click="quantity--">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M5 12h14" />
                                </svg>
                            </button>
                            <input id="quantity" v-model="quantity" type="number" min="1" :max="product.stock" class="w-16 border-x px-3 py-2 text-center [appearance:textfield] [&::-webkit-inner-spin-button]:appearance-none [&::-webkit-outer-spin-button]:appearance-none" />
                            <button class="px-3 py-2 text-muted-foreground hover:text-foreground disabled:pointer-events-none disabled:opacity-50" :disabled="quantity >= product.stock" @click="quantity++">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                    <path d="M5 12h14" />
                                    <path d="M12 5v14" />
                                </svg>
                            </button>
                        </div>
                    </div>

                    <Button class="w-full" size="lg" :disabled="product.stock === 0" @click="addToCart(product, quantity)">
                        {{ product.stock === 0 ? "Stokta Yok" : "Sepete Ekle" }}
                    </Button>
                </div>

                <!-- Özellikler -->
                <div class="space-y-4">
                    <h2 class="text-lg font-semibold">Özellikler</h2>
                    <div class="grid gap-4 rounded-lg border p-4">
                        <div v-for="(value, key) in product.specifications" :key="key" class="grid grid-cols-2 gap-4 border-b py-2 last:border-0 last:pb-0 first:pt-0">
                            <span class="text-sm font-medium">{{ key }}</span>
                            <span class="text-sm text-muted-foreground">{{ value }}</span>
                        </div>
                    </div>
                </div>

                <!-- Kargo ve Teslimat -->
                <div class="space-y-4">
                    <h2 class="text-lg font-semibold">Kargo ve Teslimat</h2>
                    <div class="space-y-2 rounded-lg border p-4">
                        <div class="flex items-center space-x-2">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                <rect x="2" y="3" width="20" height="14" rx="2" ry="2" />
                                <line x1="8" y1="21" x2="16" y2="21" />
                                <line x1="12" y1="17" x2="12" y2="21" />
                            </svg>
                            <span class="text-sm">24 saatte kargoda</span>
                        </div>
                        <div class="flex items-center space-x-2">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                <path d="M21 10c0 7-9 13-9 13s-9-6-9-13a9 9 0 0 1 18 0z" />
                                <circle cx="12" cy="10" r="3" />
                            </svg>
                            <span class="text-sm">Ücretsiz kargo</span>
                        </div>
                        <div class="flex items-center space-x-2">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                <path d="M3 9l9-7 9 7v11a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2z" />
                                <polyline points="9 22 9 12 15 12 15 22" />
                            </svg>
                            <span class="text-sm">14 gün içinde ücretsiz iade</span>
                        </div>
                    </div>
                </div>

                <!-- Mağaza Bilgisi -->
                <div class="space-y-4">
                    <h2 class="text-lg font-semibold">Satıcı</h2>
                    <div class="rounded-lg border p-4">
                        <div class="flex items-start justify-between">
                            <div class="flex items-start space-x-4">
                                <div class="h-12 w-12 flex-shrink-0 overflow-hidden rounded-lg">
                                    <img :src="product.seller.logo" :alt="product.seller.name" class="h-full w-full object-cover" />
                                </div>
                                <div>
                                    <h3 class="font-semibold">{{ product.seller.name }}</h3>
                                    <div class="mt-1 flex items-center space-x-2">
                                        <div class="flex items-center">
                                            <svg v-for="i in 5" :key="i" :class="['h-4 w-4', i <= product.seller.rating ? 'text-yellow-400' : 'text-gray-300']" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                                                <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                                            </svg>
                                        </div>
                                        <span class="text-sm text-muted-foreground">
                                            {{ product.seller.rating }} / 5 ({{ product.seller.reviewCount }}
                                            değerlendirme)
                                        </span>
                                    </div>
                                    <div class="mt-2 space-y-1 text-sm text-muted-foreground">
                                        <div class="flex items-center space-x-2">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                                <path d="M20 10c0 6-8 12-8 12s-8-6-8-12a8 8 0 0 1 16 0Z" />
                                                <circle cx="12" cy="10" r="3" />
                                            </svg>
                                            <span>{{ product.seller.location }}</span>
                                        </div>
                                        <div class="flex items-center space-x-2">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                                <rect width="18" height="18" x="3" y="4" rx="2" ry="2" />
                                                <line x1="16" x2="16" y1="2" y2="6" />
                                                <line x1="8" x2="8" y1="2" y2="6" />
                                                <line x1="3" x2="21" y1="10" y2="10" />
                                            </svg>
                                            <span>{{ product.seller.memberSince }} tarihinden beri üye</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <router-link :to="'/seller/' + product.seller.id" class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 border border-input bg-background shadow-sm hover:bg-accent hover:text-accent-foreground h-9 px-4 py-2">Mağazayı Gör</router-link>
                        </div>
                        <div class="mt-4 grid grid-cols-3 gap-4 border-t pt-4">
                            <div class="text-center">
                                <p class="text-2xl font-bold text-primary">%98</p>
                                <p class="text-sm text-muted-foreground">Satıcı Puanı</p>
                            </div>
                            <div class="text-center">
                                <p class="text-2xl font-bold text-primary">1205</p>
                                <p class="text-sm text-muted-foreground">Toplam Satış</p>
                            </div>
                            <div class="text-center">
                                <p class="text-2xl font-bold text-primary">24sa</p>
                                <p class="text-sm text-muted-foreground">Cevap Süresi</p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Taksit ve Ödeme Seçenekleri -->
                <div class="space-y-4">
                    <h2 class="text-lg font-semibold">Taksit ve Ödeme Seçenekleri</h2>
                    <div class="rounded-lg border">
                        <!-- Taksit Seçenekleri -->
                        <div class="border-b p-4">
                            <div class="mb-4">
                                <h3 class="font-medium mb-2">Banka Seçenekleri ve Kampanyalar</h3>
                                <div class="grid grid-cols-2 sm:grid-cols-3 md:grid-cols-4 gap-4">
                                    <div v-for="bank in product.banks" :key="bank.name" class="p-4 border rounded-lg hover:shadow-md transition-shadow">
                                        <img :src="bank.logo" :alt="bank.name" class="h-8 object-contain mb-2" />
                                        <div class="space-y-1 text-sm">
                                            <p class="font-medium">{{ bank.name }}</p>
                                            <p class="text-muted-foreground">{{ bank.maxInstallment }} Taksit</p>
                                            <p v-if="bank.hasBonus" class="text-green-600">{{ bank.bonusAmount }} TL Bonus</p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="mt-6">
                                <h3 class="font-medium mb-4">Taksit Seçenekleri</h3>
                                <div class="grid gap-3">
                                    <div v-for="option in product.installmentOptions" :key="option.months" class="flex items-center justify-between rounded-md bg-muted p-3 hover:bg-accent transition-colors">
                                        <div class="space-y-1">
                                            <p class="font-medium">{{ option.months }} Taksit</p>
                                            <p v-if="option.rate > 0" class="text-xs text-muted-foreground">Vade farkı: %{{ option.rate }}</p>
                                            <p v-else class="text-xs text-green-600 font-medium">Vade farksız!</p>
                                        </div>
                                        <div class="text-right">
                                            <p class="font-medium">{{ (product.price / option.months).toFixed(2) }} TL x {{ option.months }}</p>
                                            <p class="text-xs text-muted-foreground">
                                                Toplam:
                                                {{ (product.price * (1 + option.rate / 100)).toFixed(2) }}
                                                TL
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- Ödeme Seçenekleri -->
                        <div class="p-4">
                            <h3 class="font-medium mb-4">Ödeme Seçenekleri</h3>
                            <div class="grid gap-4">
                                <div class="flex items-center space-x-4 p-3 rounded-lg border hover:shadow-md transition-shadow">
                                    <div class="flex h-12 w-12 items-center justify-center rounded-md bg-primary/10">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                            <rect width="20" height="14" x="2" y="5" rx="2" />
                                            <line x1="2" x2="22" y1="10" y2="10" />
                                        </svg>
                                    </div>
                                    <div class="flex-1">
                                        <p class="font-medium">Kredi/Banka Kartı</p>
                                        <p class="text-sm text-muted-foreground">Tüm kredi ve banka kartları ile güvenli ödeme</p>
                                    </div>
                                    <div class="text-sm text-green-600 font-medium">Ücretsiz</div>
                                </div>

                                <div class="flex items-center space-x-4 p-3 rounded-lg border hover:shadow-md transition-shadow">
                                    <div class="flex h-12 w-12 items-center justify-center rounded-md bg-primary/10">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                            <path d="M17 9V7a2 2 0 0 0-2-2H5a2 2 0 0 0-2 2v6a2 2 0 0 0 2 2h2" />
                                            <path d="M19 13v-2" />
                                            <rect width="12" height="8" x="8" y="11" rx="2" />
                                        </svg>
                                    </div>
                                    <div class="flex-1">
                                        <p class="font-medium">Havale/EFT</p>
                                        <p class="text-sm text-muted-foreground">Tüm bankalardan havale/EFT ile ödeme</p>
                                    </div>
                                    <div class="text-sm text-green-600 font-medium">%3 İndirim</div>
                                </div>

                                <div class="flex items-center space-x-4 p-3 rounded-lg border hover:shadow-md transition-shadow">
                                    <div class="flex h-12 w-12 items-center justify-center rounded-md bg-primary/10">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="text-primary">
                                            <rect width="16" height="16" x="4" y="4" rx="2" />
                                            <rect width="4" height="4" x="10" y="10" />
                                            <line x1="4" x2="20" y1="16" y2="16" />
                                        </svg>
                                    </div>
                                    <div class="flex-1">
                                        <p class="font-medium">Kapıda Ödeme</p>
                                        <p class="text-sm text-muted-foreground">Nakit veya kredi kartı ile kapıda ödeme</p>
                                    </div>
                                    <div class="text-sm text-destructive font-medium">+9.90 TL</div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Benzer Ürünler -->
        <div class="mt-16">
            <h2 class="mb-6 text-2xl font-bold tracking-tight">Benzer Ürünler</h2>
            <div class="grid grid-cols-1 gap-6 sm:grid-cols-2 lg:grid-cols-4">
                <div v-for="product in similarProducts" :key="product.id" class="group relative overflow-hidden rounded-lg border bg-background">
                    <div class="aspect-[4/3] overflow-hidden">
                        <img :src="product.image" :alt="product.name" class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105" />
                        <div v-if="product.discount" class="absolute right-2 top-2 rounded-full bg-destructive px-2 py-1 text-xs font-medium text-destructive-foreground">%{{ product.discount }} İndirim</div>
                    </div>
                    <div class="p-4">
                        <h3 class="font-semibold">{{ product.name }}</h3>
                        <p class="mt-1 text-sm text-muted-foreground line-clamp-2">
                            {{ product.description }}
                        </p>
                        <div class="mt-2 flex items-center justify-between">
                            <div class="flex items-baseline space-x-2">
                                <span class="text-lg font-bold">{{ product.price }} TL</span>
                                <span v-if="product.oldPrice" class="text-sm text-muted-foreground line-through">{{ product.oldPrice }} TL</span>
                            </div>
                            <Button size="sm" variant="secondary" @click="addToCart(product)">Sepete Ekle</Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Müşteri Yorumları -->
        <div class="mt-16">
            <h2 class="mb-6 text-2xl font-bold tracking-tight">Müşteri Değerlendirmeleri</h2>

            <!-- Değerlendirme Özeti -->
            <div class="grid gap-8 lg:grid-cols-12">
                <div class="lg:col-span-4">
                    <div class="rounded-lg border p-6">
                        <div class="text-center">
                            <div class="text-5xl font-bold">{{ product.rating }}/5</div>
                            <div class="mt-2 flex justify-center">
                                <div class="flex items-center">
                                    <svg v-for="i in 5" :key="i" :class="['h-5 w-5', i <= product.rating ? 'text-yellow-400' : 'text-gray-300']" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                                        <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                                    </svg>
                                </div>
                            </div>
                            <div class="mt-1 text-sm text-muted-foreground">{{ product.reviewCount }} değerlendirme</div>
                        </div>

                        <div class="mt-6 space-y-2">
                            <div v-for="rating in 5" :key="rating" class="flex items-center">
                                <div class="w-12 text-sm text-right">{{ 6 - rating }} yıldız</div>
                                <div class="mx-4 flex-1">
                                    <div class="h-2 rounded-full bg-muted">
                                        <div
                                            class="h-2 rounded-full bg-yellow-400"
                                            :style="{
                                                width: `${(product.ratingDistribution[5 - rating] / product.reviewCount) * 100}%`,
                                            }"
                                        ></div>
                                    </div>
                                </div>
                                <div class="w-12 text-sm">
                                    {{ product.ratingDistribution[5 - rating] }}
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="lg:col-span-8">
                    <!-- Yorum Yazma -->
                    <div class="mb-8 rounded-lg border p-6">
                        <h3 class="mb-4 text-lg font-semibold">Değerlendirme Yaz</h3>
                        <div class="space-y-4">
                            <div>
                                <label class="mb-2 block text-sm font-medium">Puanınız</label>
                                <div class="flex items-center space-x-1">
                                    <button v-for="rating in 5" :key="rating" class="rounded-md p-1 hover:bg-accent" @click="newReview.rating = rating">
                                        <svg :class="['h-6 w-6', rating <= newReview.rating ? 'text-yellow-400' : 'text-gray-300']" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                                            <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                                        </svg>
                                    </button>
                                </div>
                            </div>
                            <div>
                                <label for="comment" class="mb-2 block text-sm font-medium">Yorumunuz</label>
                                <textarea id="comment" v-model="newReview.comment" rows="4" class="w-full rounded-md border bg-transparent px-3 py-2 text-sm placeholder:text-muted-foreground focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:cursor-not-allowed disabled:opacity-50" placeholder="Bu ürün hakkında düşüncelerinizi paylaşın..."></textarea>
                            </div>
                            <button class="inline-flex items-center justify-center rounded-md text-sm font-medium transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring disabled:pointer-events-none disabled:opacity-50 bg-primary text-primary-foreground shadow hover:bg-primary/90 h-9 px-4 py-2" @click="submitReview">Değerlendirme Gönder</button>
                        </div>
                    </div>

                    <!-- Yorumlar Listesi -->
                    <div class="space-y-6">
                        <div v-for="review in product.reviews" :key="review.id" class="rounded-lg border p-6">
                            <div class="flex items-start justify-between">
                                <div>
                                    <div class="flex items-center space-x-2">
                                        <span class="font-semibold">{{ review.userName }}</span>
                                        <span class="text-sm text-muted-foreground">{{ review.date }}</span>
                                    </div>
                                    <div class="mt-1 flex items-center">
                                        <div class="flex items-center">
                                            <svg v-for="i in 5" :key="i" :class="['h-4 w-4', i <= review.rating ? 'text-yellow-400' : 'text-gray-300']" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                                                <path d="M9.049 2.927c.3-.921 1.603-.921 1.902 0l1.07 3.292a1 1 0 00.95.69h3.462c.969 0 1.371 1.24.588 1.81l-2.8 2.034a1 1 0 00-.364 1.118l1.07 3.292c.3.921-.755 1.688-1.54 1.118l-2.8-2.034a1 1 0 00-1.175 0l-2.8 2.034c-.784.57-1.838-.197-1.539-1.118l1.07-3.292a1 1 0 00-.364-1.118L2.98 8.72c-.783-.57-.38-1.81.588-1.81h3.461a1 1 0 00.951-.69l1.07-3.292z" />
                                            </svg>
                                        </div>
                                    </div>
                                </div>
                                <div class="flex items-center space-x-2">
                                    <span v-if="review.verifiedPurchase" class="rounded-full bg-green-100 px-2 py-1 text-xs font-medium text-green-700">Onaylı Alışveriş</span>
                                </div>
                            </div>
                            <p class="mt-4 text-sm">{{ review.comment }}</p>
                            <div class="mt-4 flex items-center space-x-4">
                                <button class="flex items-center space-x-1 text-sm text-muted-foreground hover:text-foreground">
                                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                        <path d="M14 9V5a3 3 0 0 0-3-3l-4 9v11h11.28a2 2 0 0 0 2-1.7l1.38-9a2 2 0 0 0-2-2.3zM7 22H4a2 2 0 0 1-2-2v-7a2 2 0 0 1 2-2h3" />
                                    </svg>
                                    <span>Faydalı ({{ review.helpfulCount }})</span>
                                </button>
                                <button class="text-sm text-muted-foreground hover:text-foreground">Yanıtla</button>
                            </div>
                            <!-- Yanıtlar -->
                            <div v-if="review.replies && review.replies.length > 0" class="mt-4 space-y-4 border-t pt-4">
                                <div v-for="reply in review.replies" :key="reply.id" class="ml-6 border-l-2 pl-4">
                                    <div class="flex items-center space-x-2">
                                        <span class="font-semibold">{{ reply.userName }}</span>
                                        <span v-if="reply.isSeller" class="rounded-full bg-primary/10 px-2 py-1 text-xs font-medium text-primary">Satıcı</span>
                                        <span class="text-sm text-muted-foreground">{{ reply.date }}</span>
                                    </div>
                                    <p class="mt-2 text-sm">{{ reply.comment }}</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">

import { ref, onMounted } from "vue";
import FeatureIcons from "@/components/icons/FeatureIcons.vue";

const loading = ref(true);
const quantity = ref(1);
const selectedImage = ref(null);

// Örnek ürün verisi
const product = ref({
    id: 1,
    name: "Kablosuz Kulaklık",
    description: "Aktif gürültü önleme özellikli premium kablosuz kulaklık. 30 saate kadar pil ömrü, su geçirmez tasarım ve üstün ses kalitesi.",
    price: 199.99,
    oldPrice: 299.99,
    discount: 33,
    stock: 15,
    images: ["https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/airpods-max-hero-select-202011?wid=940&hei=1112&fmt=png-alpha&.v=1604709293000", "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/airpods-max-select-silver-202011?wid=940&hei=1112&fmt=png-alpha&.v=1604021221000", "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/airpods-max-select-spacegray-202011?wid=940&hei=1112&fmt=png-alpha&.v=1604709293000", "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/airpods-max-select-green-202011?wid=940&hei=1112&fmt=png-alpha&.v=1604022364000"],
    category: {
        id: 1,
        name: "Elektronik",
        slug: "elektronik",
    },
    specifications: {
        "Bluetooth Sürümü": "5.0",
        "Pil Ömrü": "30 saat",
        "Şarj Süresi": "2 saat",
        "Su Geçirmezlik": "IPX4",
        "Aktif Gürültü Önleme": "Var",
        "Garanti Süresi": "2 Yıl",
    },
    seller: {
        id: 1,
        name: "TechStore",
        logo: "https://cdn-icons-png.flaticon.com/512/6681/6681204.png",
        rating: 4.8,
        reviewCount: 2458,
        location: "İstanbul, Türkiye",
        memberSince: "2020",
    },
    installmentOptions: [
        { months: 2, rate: 0 },
        { months: 3, rate: 0 },
        { months: 6, rate: 1.89 },
        { months: 9, rate: 2.19 },
        { months: 12, rate: 2.49 },
    ],
    banks: [
        {
            name: "Ziraat Bankası",
            logo: "https://upload.wikimedia.org/wikipedia/tr/7/75/Ziraat_Bankas%C4%B1_logo.png",
            maxInstallment: 12,
            hasBonus: true,
            bonusAmount: 50,
            minAmount: 100,
        },
        {
            name: "Garanti BBVA",
            logo: "https://upload.wikimedia.org/wikipedia/tr/c/c2/Garanti_BBVA.png",
            maxInstallment: 12,
            hasBonus: true,
            bonusAmount: 75,
            minAmount: 150,
        },
        {
            name: "İş Bankası",
            logo: "https://upload.wikimedia.org/wikipedia/commons/6/69/T%C3%BCrkiye_%C4%B0%C5%9F_Bankas%C4%B1_logo.png",
            maxInstallment: 9,
            hasBonus: true,
            bonusAmount: 60,
            minAmount: 120,
        },
        {
            name: "Yapı Kredi",
            logo: "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Yap%C4%B1_Kredi_Logo.svg/2560px-Yap%C4%B1_Kredi_Logo.svg.png",
            maxInstallment: 12,
            hasBonus: true,
            bonusAmount: 80,
            minAmount: 200,
        },
        {
            name: "Akbank",
            logo: "https://upload.wikimedia.org/wikipedia/commons/thumb/0/07/Akbank_logo.svg/2560px-Akbank_logo.svg.png",
            maxInstallment: 12,
            hasBonus: true,
            bonusAmount: 70,
            minAmount: 150,
        },
        {
            name: "QNB Finansbank",
            logo: "https://upload.wikimedia.org/wikipedia/tr/thumb/8/86/QNB_Finansbank_logo.png/1200px-QNB_Finansbank_logo.png",
            maxInstallment: 9,
            hasBonus: true,
            bonusAmount: 45,
            minAmount: 100,
        },
        {
            name: "Halkbank",
            logo: "https://upload.wikimedia.org/wikipedia/tr/9/95/Halkbank_logo.png",
            maxInstallment: 12,
            hasBonus: true,
            bonusAmount: 55,
            minAmount: 120,
        },
        {
            name: "Vakıfbank",
            logo: "https://upload.wikimedia.org/wikipedia/tr/1/1f/Vak%C4%B1fbank_logo.png",
            maxInstallment: 12,
            hasBonus: true,
            bonusAmount: 65,
            minAmount: 130,
        },
    ],
    rating: 4.7,
    reviewCount: 128,
    ratingDistribution: [89, 24, 10, 3, 2],
    reviews: [
        {
            id: 1,
            userName: "Ahmet Y.",
            date: "2 gün önce",
            rating: 5,
            comment: "Harika bir ürün! Ses kalitesi mükemmel, pil ömrü beklediğimden daha uzun. Aktif gürültü önleme özelliği gerçekten işe yarıyor.",
            verifiedPurchase: true,
            helpfulCount: 12,
            replies: [
                {
                    id: 1,
                    userName: "TechStore",
                    isSeller: true,
                    date: "1 gün önce",
                    comment: "Değerlendirmeniz için teşekkür ederiz! Ürünümüzden memnun kalmanıza sevindik.",
                },
            ],
        },
        {
            id: 2,
            userName: "Mehmet K.",
            date: "1 hafta önce",
            rating: 4,
            comment: "Genel olarak memnunum fakat kulaklığın kulak üstü pedleri biraz daha yumuşak olabilirdi.",
            verifiedPurchase: true,
            helpfulCount: 8,
        },
        {
            id: 3,
            userName: "Ayşe S.",
            date: "2 hafta önce",
            rating: 5,
            comment: "Uzun zamandır kullanıyorum, kesinlikle tavsiye ederim. Özellikle çalışırken dış sesleri engellemesi çok işime yarıyor.",
            verifiedPurchase: true,
            helpfulCount: 15,
        },
    ],
    highlightedFeatures: {
        Bluetooth: {
            icon: "bluetooth",
            text: "Bluetooth 5.0",
        },
        "Pil Ömrü": {
            icon: "battery",
            text: "30 saat",
        },
        "Su Geçirmezlik": {
            icon: "water",
            text: "IPX4",
        },
        "Gürültü Önleme": {
            icon: "noise",
            text: "Aktif",
        },
    },
    colors: [
        { name: "Uzay Grisi", hex: "#4A4A4A" },
        { name: "Gümüş", hex: "#E3E3E3" },
        { name: "Yeşil", hex: "#576856" },
        { name: "Gökyüzü Mavisi", hex: "#87A7C5" },
    ],
});

// Örnek benzer ürünler
const similarProducts = ref([
    {
        id: 2,
        name: "Akıllı Saat",
        description: "Fitness takibi ve bildirimler için akıllı saat",
        price: 149.99,
        image: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/MKU93_VW_34FR+watch-45-alum-midnight-nc-8s_VW_34FR_WF_CO_GEO_TR?wid=750&hei=712&trim=1%2C0&fmt=p-jpg&qlt=95&.v=1632171039000%2C1683236340653",
    },
    {
        id: 3,
        name: "Tablet",
        description: "10.5 inç ekranlı, güçlü işlemcili tablet",
        price: 299.99,
        oldPrice: 399.99,
        discount: 25,
        image: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/ipad-pro-12-11-select-202210?wid=545&hei=550&fmt=jpeg&qlt=95&.v=1664411207154",
    },
    {
        id: 4,
        name: "Bluetooth Hoparlör",
        description: "Taşınabilir kablosuz hoparlör",
        price: 79.99,
        image: "https://www.jbl.com.tr/dw/image/v2/AAUJ_PRD/on/demandware.static/-/Sites-masterCatalog_Harman/default/dw961ef644/1.JBL_FLIP6_HERO_BLACK_29399_x2.png?sw=537&sfrm=png",
    },
    {
        id: 5,
        name: "Akıllı Telefon",
        description: "Yüksek performanslı akıllı telefon",
        price: 999.99,
        oldPrice: 1299.99,
        discount: 23,
        image: "https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/iphone-15-pro-finish-select-202309-6-7inch-naturaltitanium?wid=545&hei=550&fmt=jpeg&qlt=95&.v=1692845702708",
    },
]);

// Metodlar
const addToCart = (product, quantity = 1) => {
    // Sepete ekleme işlemi (Pinia store'da yapılacak)
    console.log("Ürün sepete eklendi:", product, "Adet:", quantity);
};

// Sayfa yüklendiğinde
onMounted(() => {
    // Burada API'den ürün verisi çekilecek
    setTimeout(() => {
        loading.value = false;
    }, 1000);
});

const newReview = ref({
    rating: 0,
    comment: "",
});

const submitReview = () => {
    // Yorum gönderme işlemi
    console.log("Yorum gönderildi:", newReview.value);
    newReview.value = {
        rating: 0,
        comment: "",
    };
};

const selectedColor = ref("Uzay Grisi");
</script>
