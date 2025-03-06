<template>
    <div>
        <!-- Sağ Tık Hedefi -->
        <div @contextmenu.prevent="showMenu">
            <slot />
        </div>

        <!-- Menü -->
        <Teleport to="body">
            <Transition enter-active-class="transition ease-out duration-100" enter-from-class="transform opacity-0 scale-95" enter-to-class="transform opacity-100 scale-100" leave-active-class="transition ease-in duration-75" leave-from-class="transform opacity-100 scale-100" leave-to-class="transform opacity-0 scale-95">
                <div v-if="isVisible" ref="menuRef" class="fixed z-50 w-56 rounded-md bg-zinc-800 py-1 shadow-lg ring-1 ring-black ring-opacity-5" :style="{ top: `${position.y}px`, left: `${position.x}px` }">
                    <div v-for="(item, index) in items" :key="index">
                        <!-- Ayırıcı -->
                        <div v-if="item.type === 'divider'" class="my-1 h-px bg-zinc-700" />

                        <!-- Menü Öğesi -->
                        <template v-else>
                            <button v-if="!item.disabled" class="flex w-full items-center px-4 py-2 text-sm text-zinc-300 hover:bg-zinc-700 hover:text-white" @click="handleItemClick(item)">
                                <component v-if="item.icon" :is="item.icon" class="mr-3 h-5 w-5 text-zinc-400" />
                                {{ item.label }}
                            </button>
                            <div v-else class="flex w-full items-center px-4 py-2 text-sm text-zinc-500">
                                <component v-if="item.icon" :is="item.icon" class="mr-3 h-5 w-5" />
                                {{ item.label }}
                            </div>
                        </template>
                    </div>
                </div>
            </Transition>
        </Teleport>
    </div>
</template>

<script setup lang="ts">

import { nextTick } from "vue";

import { ref, onMounted, onUnmounted } from "vue";
import type { Component } from "vue";

interface MenuItem {
    label: string;
    icon?: Component;
    action?: () => void;
    disabled?: boolean;
    type?: "item" | "divider";
}

interface Props {
    items: MenuItem[];
}

defineProps<Props>();

const isVisible = ref(false);
const position = ref({ x: 0, y: 0 });
const menuRef = ref<HTMLElement | null>(null);

const showMenu = (event: MouseEvent) => {
    // Menü pozisyonunu ayarla
    position.value = {
        x: event.clientX,
        y: event.clientY,
    };

    // Menünün ekran dışına taşmasını önle
    nextTick(() => {
        if (menuRef.value) {
            const menuRect = menuRef.value.getBoundingClientRect();
            const viewportWidth = window.innerWidth;
            const viewportHeight = window.innerHeight;

            if (position.value.x + menuRect.width > viewportWidth) {
                position.value.x = viewportWidth - menuRect.width;
            }

            if (position.value.y + menuRect.height > viewportHeight) {
                position.value.y = viewportHeight - menuRect.height;
            }
        }
    });

    isVisible.value = true;
};

const handleItemClick = (item: MenuItem) => {
    if (item.action) {
        item.action();
    }
    isVisible.value = false;
};

const handleClickOutside = (event: MouseEvent) => {
    if (menuRef.value && !menuRef.value.contains(event.target as Node)) {
        isVisible.value = false;
    }
};

onMounted(() => {
    document.addEventListener("click", handleClickOutside);
    document.addEventListener("contextmenu", handleClickOutside);
});

onUnmounted(() => {
    document.removeEventListener("click", handleClickOutside);
    document.removeEventListener("contextmenu", handleClickOutside);
});
</script>
