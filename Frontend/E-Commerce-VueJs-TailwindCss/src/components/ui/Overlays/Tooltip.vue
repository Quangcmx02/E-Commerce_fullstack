<template>
    <div class="relative inline-block">
        <div @mouseenter="show = true" @mouseleave="show = false" class="inline-block">
            <slot />
        </div>
        <Transition enter-active-class="transition duration-200 ease-out" enter-from-class="opacity-0 scale-95" enter-to-class="opacity-100 scale-100" leave-active-class="transition duration-150 ease-in" leave-from-class="opacity-100 scale-100" leave-to-class="opacity-0 scale-95">
            <div v-if="show" :class="['absolute z-50 px-2 py-1 text-sm text-white bg-zinc-800 rounded shadow-lg', positionClasses[position], className]" role="tooltip">
                {{ text }}
                <div :class="['absolute w-2 h-2 bg-zinc-800 transform rotate-45', arrowClasses[position]]" />
            </div>
        </Transition>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";

interface Props {
    text: string;
    position?: "top" | "right" | "bottom" | "left";
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    position: "top",
    className: "",
});

const show = ref(false);

const positionClasses = {
    top: "-top-2 left-1/2 transform -translate-x-1/2 -translate-y-full",
    right: "top-1/2 left-full transform translate-x-2 -translate-y-1/2",
    bottom: "-bottom-2 left-1/2 transform -translate-x-1/2 translate-y-full",
    left: "top-1/2 right-full transform -translate-x-2 -translate-y-1/2",
};

const arrowClasses = {
    top: "bottom-0 left-1/2 transform -translate-x-1/2 translate-y-1/2",
    right: "top-1/2 left-0 transform -translate-y-1/2 -translate-x-1/2",
    bottom: "top-0 left-1/2 transform -translate-x-1/2 -translate-y-1/2",
    left: "top-1/2 right-0 transform -translate-y-1/2 translate-x-1/2",
};
</script>
