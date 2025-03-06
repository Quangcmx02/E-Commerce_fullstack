<template>
    <section class="border-t py-16 md:py-24 lg:py-32 px-6">
        <div class="container space-y-8 rounded-2xl bg-muted/40 px-6 py-16 border shadow-lg">
            <div class="flex flex-col items-center space-y-2">
                <h2 class="text-2xl font-bold tracking-tight md:text-3xl">İş Ortaklarımız</h2>
                <p class="text-muted-foreground">Güvenilir markalarla çalışıyoruz</p>
            </div>

            <div class="grid grid-cols-2 gap-8 md:grid-cols-3 lg:grid-cols-6">
                <div v-for="brand in brands" :key="brand.id" class="flex items-center justify-center">
                    <img :src="brand.logo" :alt="brand.name" class="h-12 object-contain grayscale hover:grayscale-0 transition-all" />
                </div>
            </div>
        </div>
    </section>
</template>

<script setup>

import { ref } from "vue";

const brands = ref([
    {
        id: 1,
        name: "Apple",
        logo: "https://upload.wikimedia.org/wikipedia/commons/f/fa/Apple_logo_black.svg",
    },
    {
        id: 2,
        name: "Samsung",
        logo: "https://upload.wikimedia.org/wikipedia/commons/2/24/Samsung_Logo.svg",
    },
    {
        id: 3,
        name: "Sony",
        logo: "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ca/Sony_logo.svg/220px-Sony_logo.svg.png",
    },
    {
        id: 4,
        name: "LG",
        logo: "https://upload.wikimedia.org/wikipedia/commons/2/20/LG_symbol.svg",
    },
    {
        id: 5,
        name: "Nike",
        logo: "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a6/Logo_NIKE.svg/150px-Logo_NIKE.svg.png",
    },
    {
        id: 6,
        name: "Adidas",
        logo: "https://upload.wikimedia.org/wikipedia/commons/2/20/Adidas_Logo.svg",
    },
]);

</script>