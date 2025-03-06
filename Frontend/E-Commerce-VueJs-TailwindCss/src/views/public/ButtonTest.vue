<template>
  <div class="min-h-screen bg-gray-900 p-8 space-y-8">
    <div class="space-y-4">
      <h2 class="text-xl font-bold text-white">Varyantlar</h2>
      <div class="flex flex-wrap gap-4">
        <Button variant="primary">Primary</Button>
        <Button variant="secondary">Secondary</Button>
        <Button variant="outline">Outline</Button>
        <Button variant="ghost">Ghost</Button>
        <Button variant="danger">Danger</Button>
        <Button variant="success">Success</Button>
      </div>
    </div>

    <div class="space-y-4">
      <h2 class="text-xl font-bold text-white">Boyutlar</h2>
      <div class="flex flex-wrap items-center gap-4">
        <Button size="sm">Küçük</Button>
        <Button size="md">Orta</Button>
        <Button size="lg">Büyük</Button>
      </div>
    </div>

    <div class="space-y-4">
      <h2 class="text-xl font-bold text-white">Durumlar</h2>
      <div class="flex flex-wrap gap-4">
        <Button loading variant="primary">Yükleniyor</Button>
        <Button disabled variant="primary">Devre Dışı</Button>
        <Button loading variant="secondary">Yükleniyor</Button>
        <Button disabled variant="secondary">Devre Dışı</Button>
      </div>
    </div>

    <div class="space-y-4">
      <h2 class="text-xl font-bold text-white">İkonlu Butonlar</h2>
      <div class="flex flex-wrap gap-4">
        <Button variant="primary">
          <template #leftIcon>
            <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 19l-7-7 7-7" />
            </svg>
          </template>
          Sol İkon
        </Button>
        <Button variant="secondary">
          Sağ İkon
          <template #rightIcon>
            <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
            </svg>
          </template>
        </Button>
        <Button variant="outline">
          <template #leftIcon>
            <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 16v1a3 3 0 003 3h10a3 3 0 003-3v-1m-4-8l-4-4m0 0L8 8m4-4v12" />
            </svg>
          </template>
          Yükle
        </Button>
      </div>
    </div>

    <div class="space-y-4">
      <h2 class="text-xl font-bold text-white">Kombinasyonlar</h2>
      <div class="flex flex-wrap gap-4">
        <Button variant="danger" size="sm" loading>Siliniyor</Button>
        <Button variant="success" size="lg">
          <template #leftIcon>
            <svg class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 13l4 4L19 7" />
            </svg>
          </template>
          Kaydet
        </Button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import Button from '@/components/ui/Button.vue'
</script> 