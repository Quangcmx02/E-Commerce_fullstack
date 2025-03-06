<template>
    <div class="relative inline-block text-left">
        <!-- Trigger -->
        <div @click="toggle" class="inline-block">
            <slot name="trigger" />
        </div>

        <!-- Dropdown Menu -->
        <Transition enter-active-class="transition duration-100 ease-out" enter-from-class="transform scale-95 opacity-0" enter-to-class="transform scale-100 opacity-100" leave-active-class="transition duration-75 ease-in" leave-from-class="transform scale-100 opacity-100" leave-to-class="transform scale-95 opacity-0">
            <div v-if="isOpen" :class="['absolute z-50 mt-2 rounded-md shadow-lg bg-zinc-900 ring-1 ring-zinc-800', positionClasses[position]]" @click="close">
                <div class="py-1" role="menu">
                    <slot />
                </div>
            </div>
        </Transition>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from "vue";

type Position = "left" | "right";

const props = withDefaults(
    defineProps<{
        position?: Position;
    }>(),
    {
        position: "left",
    }
);

const isOpen = ref(false);

const positionClasses: Record<Position, string> = {
    left: "left-0 origin-top-left",
    right: "right-0 origin-top-right",
};

const toggle = () => {
    isOpen.value = !isOpen.value;
};

const close = () => {
    isOpen.value = false;
};

const handleClickOutside = (event: MouseEvent) => {
    const target = event.target as HTMLElement;
    if (!target.closest(".relative")) {
        close();
    }
};

onMounted(() => {
    document.addEventListener("click", handleClickOutside);
});

onUnmounted(() => {
    document.removeEventListener("click", handleClickOutside);
});
</script>

<script lang="ts">
export interface DropdownItem {
    label: string;
    value: string | number;
    icon?: string;
    disabled?: boolean;
}
</script>
