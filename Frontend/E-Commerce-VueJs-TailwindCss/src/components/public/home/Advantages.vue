<template>
    <section class="py-16 md:py-24 lg:py-32">
        <div class="container">
            <div class="flex flex-col items-center space-y-2 mb-12">
                <h2 class="text-2xl font-bold tracking-tight md:text-3xl">Alışveriş Avantajları</h2>
                <p class="text-muted-foreground">Size özel ayrıcalıklarla alışverişin keyfini çıkarın</p>
            </div>

            <div class="grid gap-6 md:grid-cols-2 lg:grid-cols-4">
                <!-- Kolay İade -->
                <div class="group relative overflow-hidden rounded-xl border bg-card p-6 hover:shadow-lg transition-all">
                    <div class="absolute right-0 top-0 h-24 w-24 -translate-y-8 translate-x-8 transform rounded-full bg-primary/10 group-hover:bg-primary/20 transition-all"></div>

                    <div class="relative space-y-4">
                        <div class="flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10 text-primary group-hover:bg-primary group-hover:text-primary-foreground transition-all">
                            <ArrowUturnLeftIcon class="h-5 w-5" />
                        </div>

                        <div class="space-y-2">
                            <h3 class="font-semibold">Kolay İade</h3>
                            <p class="text-sm text-muted-foreground">30 gün içinde ücretsiz iade hakkı</p>
                        </div>
                    </div>
                </div>

                <!-- Hızlı Teslimat -->
                <div class="group relative overflow-hidden rounded-xl border bg-card p-6 hover:shadow-lg transition-all">
                    <div class="absolute right-0 top-0 h-24 w-24 -translate-y-8 translate-x-8 transform rounded-full bg-primary/10 group-hover:bg-primary/20 transition-all"></div>

                    <div class="relative space-y-4">
                        <div class="flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10 text-primary group-hover:bg-primary group-hover:text-primary-foreground transition-all">
                            <BoltIcon class="h-5 w-5" />
                        </div>

                        <div class="space-y-2">
                            <h3 class="font-semibold">Hızlı Teslimat</h3>
                            <p class="text-sm text-muted-foreground">Aynı gün kargo ve teslimat imkanı</p>
                        </div>
                    </div>
                </div>

                <!-- Taksit Seçenekleri -->
                <div class="group relative overflow-hidden rounded-xl border bg-card p-6 hover:shadow-lg transition-all">
                    <div class="absolute right-0 top-0 h-24 w-24 -translate-y-8 translate-x-8 transform rounded-full bg-primary/10 group-hover:bg-primary/20 transition-all"></div>

                    <div class="relative space-y-4">
                        <div class="flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10 text-primary group-hover:bg-primary group-hover:text-primary-foreground transition-all">
                            <CreditCardIcon class="h-5 w-5" />
                        </div>

                        <div class="space-y-2">
                            <h3 class="font-semibold">Taksit Seçenekleri</h3>
                            <p class="text-sm text-muted-foreground">12 aya varan taksit imkanları</p>
                        </div>
                    </div>
                </div>

                <!-- Mobil Uygulama -->
                <div class="group relative overflow-hidden rounded-xl border bg-card p-6 hover:shadow-lg transition-all">
                    <div class="absolute right-0 top-0 h-24 w-24 -translate-y-8 translate-x-8 transform rounded-full bg-primary/10 group-hover:bg-primary/20 transition-all"></div>

                    <div class="relative space-y-4">
                        <div class="flex h-10 w-10 items-center justify-center rounded-lg bg-primary/10 text-primary group-hover:bg-primary group-hover:text-primary-foreground transition-all">
                            <DevicePhoneMobileIcon class="h-5 w-5" />
                        </div>

                        <div class="space-y-2">
                            <h3 class="font-semibold">Mobil Uygulama</h3>
                            <p class="text-sm text-muted-foreground">Özel indirimlerle mobil alışveriş</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script setup>
import { ArrowUturnLeftIcon, BoltIcon, CreditCardIcon, DevicePhoneMobileIcon } from "@heroicons/vue/24/outline";
</script>
