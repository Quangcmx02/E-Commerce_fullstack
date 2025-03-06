<template>
    <div class="min-h-screen bg-background">
        <SellerSidebar :is-open="isSidebarOpen" @toggle-sidebar="isSidebarOpen = !isSidebarOpen" />

        <div :class="['transition-all duration-300', isSidebarOpen ? 'lg:ml-64' : 'lg:ml-[69px]']">
            <SellerHeader @toggle-sidebar="isSidebarOpen = !isSidebarOpen" />
            
            <main class="w-full py-6 px-12">
                <router-view />
            </main>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import SellerSidebar from "@/components/seller/SellerSidebar.vue";
import SellerHeader from "@/components/seller/SellerHeader.vue";

const isSidebarOpen = ref(true);
</script>
