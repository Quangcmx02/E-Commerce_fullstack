<template>
    <section class="border-t bg-muted/40 py-16 md:py-24 lg:py-32">
        <div class="container">
            <div class="grid grid-cols-1 gap-6 md:grid-cols-3 px-4 sm:px-0">
                <div class="flex flex-col items-center space-y-2 text-center p-4 bg-background rounded-lg">
                    <div class="flex h-12 w-12 items-center justify-center rounded-full border-2">
                        <TruckIcon class="h-6 w-6 text-foreground" />
                    </div>
                    <h3 class="font-semibold">Ücretsiz Kargo</h3>
                    <p class="text-sm text-muted-foreground">500 TL ve üzeri alışverişlerinizde kargo ücretsiz!</p>
                </div>

                <div class="flex flex-col items-center space-y-2 text-center p-4 bg-background rounded-lg">
                    <div class="flex h-12 w-12 items-center justify-center rounded-full border-2">
                        <LockClosedIcon class="h-6 w-6 text-foreground" />
                    </div>
                    <h3 class="font-semibold">Güvenli Ödeme</h3>
                    <p class="text-sm text-muted-foreground">256-bit SSL sertifikası ile güvenli alışveriş</p>
                </div>

                <div class="flex flex-col items-center space-y-2 text-center p-4 bg-background rounded-lg">
                    <div class="flex h-12 w-12 items-center justify-center rounded-full border-2">
                        <ChatBubbleLeftRightIcon class="h-6 w-6 text-foreground" />
                    </div>
                    <h3 class="font-semibold">7/24 Destek</h3>
                    <p class="text-sm text-muted-foreground">Müşteri hizmetlerimiz her zaman yanınızda</p>
                </div>
            </div>
        </div>
    </section>
</template>

<script setup>
import { TruckIcon, LockClosedIcon, ChatBubbleLeftRightIcon } from "@heroicons/vue/24/outline";
</script>
