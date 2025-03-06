<template>
    <div class="flex min-h-screen flex-col">
        <PublicHeader />

        <main class="flex-1">
            <router-view />
        </main>

        <PublicFooter />
    </div>
</template>

<script setup lang="ts">

import PublicHeader from '@/components/layout/PublicHeader.vue'
import PublicFooter from '@/components/layout/PublicFooter.vue'

</script>
