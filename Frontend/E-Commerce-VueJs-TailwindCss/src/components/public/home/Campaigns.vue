<template>
    <section class="py-16 md:py-24 lg:py-32 border-t">
        <div class="container space-y-8">
            <div class="flex flex-col items-center space-y-2">
                <h2 class="text-2xl font-bold tracking-tight md:text-3xl">Özel Kampanyalar</h2>
                <p class="text-muted-foreground">Kaçırılmayacak fırsatları yakalayın</p>
            </div>

            <div class="grid gap-4 sm:gap-6 grid-cols-1 md:grid-cols-2 lg:grid-cols-3 px-4 sm:px-0">
                <router-link :to="{ name: 'discounts' }" class="group relative overflow-hidden rounded-lg border bg-background">
                    <div class="aspect-[16/9] overflow-hidden">
                        <img src="https://images.unsplash.com/photo-1441986300917-64674bd600d8?w=800&h=450&fit=crop" alt="Yaz İndirimi" class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105" />
                    </div>
                    <div class="p-4">
                        <h3 class="text-lg font-semibold">Yaz Sezonu İndirimleri</h3>
                        <p class="mt-1 text-sm text-muted-foreground">Seçili yaz ürünlerinde %50'ye varan indirimler</p>
                        <Button class="mt-4" variant="secondary" size="sm">İncele</Button>
                    </div>
                </router-link>

                <router-link :to="{ name: 'discounts' }" class="group relative overflow-hidden rounded-lg border bg-background">
                    <div class="aspect-[16/9] overflow-hidden">
                        <img src="https://images.unsplash.com/photo-1472851294608-062f824d29cc?w=800&h=450&fit=crop" alt="Teknoloji Kampanyası" class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105" />
                    </div>
                    <div class="p-4">
                        <h3 class="text-lg font-semibold">Teknoloji Festivali</h3>
                        <p class="mt-1 text-sm text-muted-foreground">Elektronik ürünlerde süper fırsatlar</p>
                        <Button class="mt-4" variant="secondary" size="sm">İncele</Button>
                    </div>
                </router-link>

                <router-link :to="{ name: 'discounts' }" class="group relative overflow-hidden rounded-lg border bg-background lg:col-span-1 md:col-span-2 lg:col-span-1">
                    <div class="aspect-[16/9] overflow-hidden">
                        <img src="https://images.unsplash.com/photo-1607083206869-4c7672e72a8a?w=800&h=450&fit=crop" alt="Süper Fırsat" class="h-full w-full object-cover transition-transform duration-300 group-hover:scale-105" />
                    </div>
                    <div class="p-4">
                        <h3 class="text-lg font-semibold">Süper Fırsat Günleri</h3>
                        <p class="mt-1 text-sm text-muted-foreground">Her gün yeni süper fırsatlar</p>
                        <Button class="mt-4" variant="secondary" size="sm">İncele</Button>
                    </div>
                </router-link>
            </div>
        </div>
    </section>
</template>

<script setup>

import Button from '@/components/ui/Form/Button.vue';

</script>