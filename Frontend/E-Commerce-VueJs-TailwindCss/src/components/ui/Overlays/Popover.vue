<template>
    <div class="relative inline-block">
        <div @click="toggle" class="inline-block">
            <slot name="trigger" />
        </div>
        <Transition enter-active-class="transition duration-200 ease-out" enter-from-class="opacity-0 scale-95" enter-to-class="opacity-100 scale-100" leave-active-class="transition duration-150 ease-in" leave-from-class="opacity-100 scale-100" leave-to-class="opacity-0 scale-95">
            <div v-if="isOpen" v-click-outside="close" :class="['absolute z-50 p-4 bg-zinc-800 rounded-lg shadow-lg min-w-[200px]', positionClasses[position], className]">
                <slot />
            </div>
        </Transition>
    </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { vClickOutside } from "@/directives/click-outside";

interface Props {
    position?: "top" | "right" | "bottom" | "left";
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    position: "bottom",
    className: "",
});

const isOpen = ref(false);

const positionClasses = {
    top: "bottom-full left-1/2 transform -translate-x-1/2 mb-2",
    right: "left-full top-1/2 transform -translate-y-1/2 ml-2",
    bottom: "top-full left-1/2 transform -translate-x-1/2 mt-2",
    left: "right-full top-1/2 transform -translate-y-1/2 mr-2",
};

const toggle = () => {
    isOpen.value = !isOpen.value;
};

const close = () => {
    isOpen.value = false;
};
</script>
