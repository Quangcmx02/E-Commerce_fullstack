<template>
    <section class="border-t bg-muted/40 py-16 md:py-24 lg:py-32">
        <div class="container space-y-8">
            <div class="flex flex-col items-center space-y-2">
                <h2 class="text-2xl font-bold tracking-tight md:text-3xl">Öne Çıkan Kategoriler</h2>
                <p class="text-muted-foreground">İhtiyacınız olan her şey kategorilere ayrılmış şekilde</p>
            </div>

            <div class="grid grid-cols-1 gap-4 sm:gap-6 sm:grid-cols-2 lg:grid-cols-4 px-4 sm:px-0">
                <router-link v-for="category in categories" :key="category.name" :to="'/products?category=' + category.name" class="group relative overflow-hidden rounded-lg border bg-background">
                    <div class="aspect-[4/3] overflow-hidden">
                        <img :src="category.image" :alt="category.name" class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105" />
                    </div>
                    <div class="p-4">
                        <h3 class="font-semibold">{{ category.name }}</h3>
                        <p class="text-sm text-muted-foreground">{{ category.productCount }} Ürün</p>
                    </div>
                </router-link>
            </div>
        </div>
    </section>
</template>

<script setup>

import { ref } from "vue";

const categories = ref([
    {
        name: "Elektronik",
        image: "https://images.unsplash.com/photo-1498049794561-7780e7231661?w=500&h=400&fit=crop",
        productCount: 1250,
    },
    {
        name: "Giyim",
        image: "https://images.unsplash.com/photo-1445205170230-053b83016050?w=500&h=400&fit=crop",
        productCount: 850,
    },
    {
        name: "Kitap",
        image: "https://images.unsplash.com/photo-1495446815901-a7297e633e8d?w=500&h=400&fit=crop",
        productCount: 650,
    },
    {
        name: "Spor",
        image: "https://images.unsplash.com/photo-1517836357463-d25dfeac3438?w=500&h=400&fit=crop",
        productCount: 450,
    },
    {
        name: "Ev & Yaşam",
        image: "https://images.unsplash.com/photo-1484101403633-562f891dc89a?w=500&h=400&fit=crop",
        productCount: 750,
    },
    {
        name: "Kozmetik",
        image: "https://images.unsplash.com/photo-1522335789203-aabd1fc54bc9?w=500&h=400&fit=crop",
        productCount: 550,
    },
    {
        name: "Oyuncak",
        image: "https://images.unsplash.com/photo-1558060370-d644479cb6f7?w=500&h=400&fit=crop",
        productCount: 350,
    },
    {
        name: "Otomotiv",
        image: "https://images.unsplash.com/photo-1511919884226-fd3cad34687c?w=500&h=400&fit=crop",
        productCount: 250,
    },
]);

</script>