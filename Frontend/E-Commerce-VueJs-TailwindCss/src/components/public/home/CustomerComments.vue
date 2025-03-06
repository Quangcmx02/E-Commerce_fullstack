<template>
    <section class="border-t bg-muted/40 py-16 md:py-24 lg:py-32">
        <div class="container">
            <div class="flex flex-col items-center space-y-2 mb-12">
                <h2 class="text-2xl font-bold tracking-tight md:text-3xl">Müşteri Yorumları</h2>
                <p class="text-muted-foreground">Müşterilerimizin deneyimleri ve değerlendirmeleri</p>
            </div>

            <div class="grid gap-6 md:grid-cols-2 lg:grid-cols-3">
                <!-- Yorum Kartı 1 -->
                <div class="group relative overflow-hidden rounded-xl border bg-card p-6 hover:shadow-lg transition-all">
                    <div class="absolute right-0 top-0 h-32 w-32 -translate-y-12 translate-x-12 transform rounded-full bg-primary/5"></div>

                    <div class="relative space-y-4">
                        <Rating modelValue="5" :max-stars="5" size="sm" disabled />

                        <!-- Yorum Metni -->
                        <p class="text-muted-foreground italic">"Ürünler çok kaliteli ve hızlı teslimat yapılıyor. Müşteri hizmetleri de oldukça ilgili. Kesinlikle tavsiye ederim!"</p>

                        <!-- Müşteri Bilgisi -->
                        <div class="flex items-center space-x-4 pt-4 border-t">
                            <div class="h-10 w-10 rounded-full bg-primary/10 flex items-center justify-center">
                                <UserCircleIcon class="h-6 w-6 text-primary" />
                            </div>
                            <div>
                                <h4 class="font-semibold">Ahmet Yılmaz</h4>
                                <p class="text-sm text-muted-foreground">İstanbul</p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Yorum Kartı 2 -->
                <div class="group relative overflow-hidden rounded-xl border bg-card p-6 hover:shadow-lg transition-all">
                    <div class="absolute right-0 top-0 h-32 w-32 -translate-y-12 translate-x-12 transform rounded-full bg-primary/5"></div>

                    <div class="relative space-y-4">
                        <Rating modelValue="5" :max-stars="5" size="sm" disabled />

                        <!-- Yorum Metni -->
                        <p class="text-muted-foreground italic">"Ürün çeşitliliği çok fazla ve fiyatlar da gayet uygun. Taksit seçenekleri de oldukça avantajlı. Teşekkürler!"</p>

                        <!-- Müşteri Bilgisi -->
                        <div class="flex items-center space-x-4 pt-4 border-t">
                            <div class="h-10 w-10 rounded-full bg-primary/10 flex items-center justify-center">
                                <UserCircleIcon class="h-6 w-6 text-primary" />
                            </div>
                            <div>
                                <h4 class="font-semibold">Ayşe Demir</h4>
                                <p class="text-sm text-muted-foreground">Ankara</p>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Yorum Kartı 3 -->
                <div class="group relative overflow-hidden rounded-xl border bg-card p-6 hover:shadow-lg transition-all">
                    <div class="absolute right-0 top-0 h-32 w-32 -translate-y-12 translate-x-12 transform rounded-full bg-primary/5"></div>

                    <div class="relative space-y-4">
                        <Rating modelValue="5" :max-stars="5" size="sm" disabled />

                        <!-- Yorum Metni -->
                        <p class="text-muted-foreground italic">"İade sürecinde hiç sorun yaşamadım. Müşteri hizmetleri çok yardımcı oldu. Bundan sonra alışverişlerimi buradan yapacağım."</p>

                        <!-- Müşteri Bilgisi -->
                        <div class="flex items-center space-x-4 pt-4 border-t">
                            <div class="h-10 w-10 rounded-full bg-primary/10 flex items-center justify-center">
                                <UserCircleIcon class="h-6 w-6 text-primary" />
                            </div>
                            <div>
                                <h4 class="font-semibold">Mehmet Kaya</h4>
                                <p class="text-sm text-muted-foreground">İzmir</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script setup>

import { UserCircleIcon } from "@heroicons/vue/24/outline";
import Rating from "@/components/ui/Form/Rating.vue"

</script>