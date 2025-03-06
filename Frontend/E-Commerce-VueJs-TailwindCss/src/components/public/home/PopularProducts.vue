<template>
    <section class="py-16 md:py-24 lg:py-32">
        <div class="container space-y-8">
            <div class="flex flex-col items-center space-y-2">
                <h2 class="text-2xl font-bold tracking-tight md:text-3xl">Popüler Ürünler</h2>
                <p class="text-muted-foreground">En çok tercih edilen ürünleri keşfedin</p>
            </div>

            <div class="grid grid-cols-1 gap-4 sm:gap-6 sm:grid-cols-2 lg:grid-cols-4 px-4 sm:px-0">
                <router-link :to="{ name: 'product-detail' }" v-for="product in popularProducts" :key="product.id" class="group relative overflow-hidden rounded-lg border bg-background">
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
                </router-link>
            </div>
        </div>
    </section>
</template>

<script setup>

import { ref } from 'vue';
import Button from '@/components/ui/Form/Button.vue';

const popularProducts = ref([
    {
        id: 1,
        name: "Kablosuz Kulaklık",
        description: "Aktif gürültü önleme özellikli premium kablosuz kulaklık",
        price: 199.99,
        oldPrice: 299.99,
        discount: 33,
        image: "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=500&h=400&fit=crop",
    },
    {
        id: 2,
        name: "Akıllı Saat",
        description: "Fitness takibi ve bildirimler için akıllı saat",
        price: 149.99,
        image: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=500&h=400&fit=crop",
    },
    {
        id: 3,
        name: "Güneş Gözlüğü",
        description: "Polarize camlı şık tasarım güneş gözlüğü",
        price: 299.99,
        oldPrice: 399.99,
        discount: 25,
        image: "https://images.unsplash.com/photo-1572635196237-14b3f281503f?w=500&h=400&fit=crop",
    },
    {
        id: 4,
        name: "Spor Ayakkabı",
        description: "Hafif ve konforlu koşu ayakkabısı",
        price: 249.99,
        image: "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=500&h=400&fit=crop",
    },
    {
        id: 5,
        name: "Akıllı Telefon",
        description: "108MP kamera ve 5G desteği ile yeni nesil akıllı telefon",
        price: 4999.99,
        oldPrice: 5999.99,
        discount: 17,
        image: "https://images.unsplash.com/photo-1511707171634-5f897ff02aa9?w=500&h=400&fit=crop",
    },
    {
        id: 6,
        name: "Tablet Bilgisayar",
        description: "İş ve eğlence için ideal tablet bilgisayar",
        price: 1999.99,
        image: "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=500&h=400&fit=crop",
    },
    {
        id: 7,
        name: "Bluetooth Hoparlör",
        description: "Su geçirmez taşınabilir bluetooth hoparlör",
        price: 129.99,
        oldPrice: 179.99,
        discount: 28,
        image: "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?w=500&h=400&fit=crop",
    },
    {
        id: 8,
        name: "Oyun Konsolu",
        description: "4K gaming deneyimi sunan yeni nesil konsol",
        price: 7999.99,
        image: "https://images.unsplash.com/photo-1486401899868-0e435ed85128?w=500&h=400&fit=crop",
    },
]);

const addToCart = (product) => {
    console.log("Ürün sepete eklendi:", product);
};
</script>
