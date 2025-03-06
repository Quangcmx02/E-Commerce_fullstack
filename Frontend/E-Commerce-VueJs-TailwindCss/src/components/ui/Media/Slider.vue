<template>
    <div class="space-y-2">
        <div v-if="label" class="flex items-center justify-between">
            <label class="text-sm font-medium text-zinc-300">{{ label }}</label>
            <span class="text-sm text-zinc-400">{{ modelValue }}</span>
        </div>
        <div class="relative">
            <input type="range" :min="min" :max="max" :step="step" :value="modelValue" :disabled="disabled" class="h-2 w-full cursor-pointer appearance-none rounded-lg bg-zinc-700 accent-primary disabled:cursor-not-allowed disabled:opacity-50" :class="[size === 'sm' && 'h-1', size === 'lg' && 'h-3']" @input="$emit('update:modelValue', Number($event.target.value))" />
            <div v-if="showTicks && !disabled" class="absolute left-0 right-0 flex justify-between px-1 pt-2">
                <span v-for="tick in ticks" :key="tick" class="h-1 w-1 rounded-full bg-zinc-500" :class="{ 'bg-primary': modelValue >= tick }"></span>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { computed } from "vue";

const props = defineProps({
    modelValue: {
        type: Number,
        required: true,
    },
    min: {
        type: Number,
        default: 0,
    },
    max: {
        type: Number,
        default: 100,
    },
    step: {
        type: Number,
        default: 1,
    },
    label: {
        type: String,
        default: "",
    },
    size: {
        type: String,
        default: "md",
        validator: (value: string) => ["sm", "md", "lg"].includes(value),
    },
    disabled: {
        type: Boolean,
        default: false,
    },
    showTicks: {
        type: Boolean,
        default: false,
    },
});

const ticks = computed(() => {
    const count = (props.max - props.min) / props.step;
    return Array.from({ length: count + 1 }, (_, i) => props.min + i * props.step);
});
</script>
