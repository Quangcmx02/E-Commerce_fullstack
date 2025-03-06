<template>
    <div>
        <section class="relative py-12">
            <div class="absolute inset-0 bg-gradient-to-r from-background to-background/50 bg-muted/100"></div>
            <div class="container relative">
                <div class="flex flex-col items-center space-y-4 text-center">
                    <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl">Hakkımızda</h1>
                    <p class="mx-auto max-w-[700px] text-muted-foreground md:text-xl">E-ticaret dünyasında güvenilir alışverişin adresi</p>
                </div>
            </div>
        </section>

        <section class="py-12 border-t">
            <div class="container">
                <div class="grid md:grid-cols-2 gap-8">
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <h2 class="text-2xl font-bold tracking-tight">Misyonumuz</h2>
                        <p class="mt-4 text-muted-foreground">Müşterilerimize en kaliteli ürünleri, en uygun fiyatlarla sunarak, güvenli ve keyifli bir alışveriş deneyimi yaşatmak için çalışıyoruz.</p>
                    </div>
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <h2 class="text-2xl font-bold tracking-tight">Vizyonumuz</h2>
                        <p class="mt-4 text-muted-foreground">E-ticaret sektöründe öncü ve yenilikçi yaklaşımlarla, müşteri memnuniyetini en üst düzeyde tutan lider marka olmak.</p>
                    </div>
                </div>
            </div>
        </section>

        <section class="border-t bg-muted/40 py-12">
            <div class="container space-y-8">
                <div class="flex flex-col items-center space-y-2">
                    <h2 class="text-2xl font-bold tracking-tight md:text-3xl">Değerlerimiz</h2>
                </div>
                <div class="grid md:grid-cols-3 gap-6">
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <div class="flex h-12 w-12 items-center justify-center rounded-full border-2 mb-4 mx-auto">
                            <ShieldCheckIcon class="h-6 w-6 text-foreground" />
                        </div>
                        <h3 class="text-lg font-semibold text-center">Güvenilirlik</h3>
                        <p class="mt-2 text-sm text-muted-foreground text-center">Müşterilerimizin güvenini en değerli varlığımız olarak görüyoruz.</p>
                    </div>
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <div class="flex h-12 w-12 items-center justify-center rounded-full border-2 mb-4 mx-auto">
                            <UserGroupIcon class="h-6 w-6 text-foreground" />
                        </div>
                        <h3 class="text-lg font-semibold text-center">Müşteri Odaklılık</h3>
                        <p class="mt-2 text-sm text-muted-foreground text-center">Her kararımızda müşterilerimizin memnuniyetini ön planda tutuyoruz.</p>
                    </div>
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <div class="flex h-12 w-12 items-center justify-center rounded-full border-2 mb-4 mx-auto">
                            <LightBulbIcon class="h-6 w-6 text-foreground" />
                        </div>
                        <h3 class="text-lg font-semibold text-center">Yenilikçilik</h3>
                        <p class="mt-2 text-sm text-muted-foreground text-center">Sürekli gelişim ve yenilik için çalışıyoruz.</p>
                    </div>
                </div>
            </div>
        </section>

        <!-- İletişim Bilgileri -->
        <section class="py-12">
            <div class="container space-y-8">
                <div class="flex flex-col items-center space-y-2">
                    <h2 class="text-2xl font-bold tracking-tight md:text-3xl">İletişim</h2>
                </div>
                <div class="grid md:grid-cols-2 lg:grid-cols-4 gap-6">
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <div class="flex h-12 w-12 items-center justify-center rounded-full border-2 mb-4 mx-auto">
                            <MapPinIcon class="h-6 w-6 text-foreground" />
                        </div>
                        <h3 class="font-semibold text-center">Adres</h3>
                        <p class="mt-2 text-sm text-muted-foreground text-center">İstanbul, Türkiye</p>
                    </div>
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <div class="flex h-12 w-12 items-center justify-center rounded-full border-2 mb-4 mx-auto">
                            <PhoneIcon class="h-6 w-6 text-foreground" />
                        </div>
                        <h3 class="font-semibold text-center">Telefon</h3>
                        <p class="mt-2 text-sm text-muted-foreground text-center">+90 (212) XXX XX XX</p>
                    </div>
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <div class="flex h-12 w-12 items-center justify-center rounded-full border-2 mb-4 mx-auto">
                            <EnvelopeIcon class="h-6 w-6 text-foreground" />
                        </div>
                        <h3 class="font-semibold text-center">E-posta</h3>
                        <p class="mt-2 text-sm text-muted-foreground text-center">info@ecommerce.com</p>
                    </div>
                    <div class="group relative overflow-hidden rounded-lg border bg-background p-6">
                        <div class="flex h-12 w-12 items-center justify-center rounded-full border-2 mb-4 mx-auto">
                            <ClockIcon class="h-6 w-6 text-foreground" />
                        </div>
                        <h3 class="font-semibold text-center">Çalışma Saatleri</h3>
                        <p class="mt-2 text-sm text-muted-foreground text-center">7/24 Hizmet</p>
                    </div>
                </div>
            </div>
        </section>
    </div>
</template>

<script setup>
import { ShieldCheckIcon, UserGroupIcon, LightBulbIcon, MapPinIcon, PhoneIcon, EnvelopeIcon, ClockIcon } from "@heroicons/vue/24/outline";
</script>
