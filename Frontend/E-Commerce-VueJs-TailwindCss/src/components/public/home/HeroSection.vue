<template>
    <section class="relative">
        <div class="absolute inset-0 bg-gradient-to-r from-background to-background/50 bg-muted/100"></div>

        <div class="container relative">
            <div class="flex flex-col items-center space-y-4 py-12 text-center sm:py-16 md:py-24 lg:py-32 xl:py-64">
                <h1 class="text-2xl font-bold tracking-tighter sm:text-3xl md:text-4xl lg:text-5xl px-4">Modern Alışverişin Adresi</h1>

                <p class="mx-auto max-w-[700px] text-muted-foreground text-sm md:text-xl px-4">En yeni ürünleri keşfedin, güvenle alışveriş yapın ve özel fırsatlardan yararlanın.</p>

                <div class="flex flex-col space-y-3 sm:flex-row sm:space-y-0 sm:space-x-4 px-4">
                    <router-link :to="{ name: 'products' }">
                        <Button variant="primary" class="w-full sm:w-auto">Alışverişe Başla</Button>
                    </router-link>

                    <router-link :to="{ name: 'register' }">
                        <Button variant="outline" class="w-full sm:w-auto">Üye Ol</Button>
                    </router-link>
                </div>
            </div>
        </div>
    </section>
</template>

<script setup>

import Button from '@/components/ui/Form/Button.vue';

</script>