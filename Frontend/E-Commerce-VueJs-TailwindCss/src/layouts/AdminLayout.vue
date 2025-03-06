<template>
    <div class="min-h-screen bg-background">
        <AdminSidebar :is-open="isSidebarOpen" @toggle-sidebar="isSidebarOpen = !isSidebarOpen" />

        <div :class="['transition-all duration-300', isSidebarOpen ? 'lg:ml-64' : 'lg:ml-[69px]']">
            <AdminHeader @toggle-sidebar="isSidebarOpen = !isSidebarOpen" />

            <main class="w-full py-6 px-12">
                <router-view />
            </main>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import AdminSidebar from "@/components/admin/AdminSidebar.vue";
import AdminHeader from "@/components/admin/AdminHeader.vue";

const isSidebarOpen = ref(true);
</script>
