<template>
    <section class="border-t py-16 md:py-24 lg:py-32">
        <div class="container">
            <div class="relative overflow-hidden rounded-2xl bg-card px-6 py-16 border shadow-lg">
                <!-- Gradient Arka Plan -->
                <div class="absolute inset-0 bg-gradient-to-br from-primary/5 to-primary/10"></div>

                <!-- Dekoratif Daireler -->
                <div class="absolute -left-6 -top-6 h-24 w-24 rounded-full bg-primary/5"></div>
                <div class="absolute -bottom-6 -right-6 h-24 w-24 rounded-full bg-primary/5"></div>
                <div class="absolute left-1/2 top-0 h-16 w-16 -translate-x-1/2 rounded-full bg-primary/5"></div>

                <!-- İçerik -->
                <div class="relative">
                    <div class="flex flex-col items-center space-y-4 text-center">
                        <h2 class="text-2xl font-bold tracking-tight text-foreground md:text-3xl lg:text-4xl">Fırsatları Kaçırmayın!</h2>
                        <p class="max-w-2xl text-muted-foreground md:text-lg">En yeni ürünler, özel kampanyalar ve indirimlerden ilk siz haberdar olun.</p>
                        <div class="flex w-full max-w-md flex-col space-y-4 sm:flex-row sm:space-x-4 sm:space-y-0 items-center">
                            <Input variant="default" type="email" size="md" placeholder="E-posta adresiniz" />
                            <Button variant="primary" size="md" class="whitespace-nowrap">Abone Ol</Button>
                        </div>
                        <p class="text-sm text-muted-foreground">
                            Dilediğiniz zaman abonelikten çıkabilirsiniz.
                            <router-link :to="{ name: 'privacy-policy' }" class="text-primary hover:text-primary/80 underline">Gizlilik Politikası</router-link>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script setup>

import Button from "@/components/ui/Form/Button.vue"
import Input from "@/components/ui/Form/Input.vue"

</script>