<template>
    <div class="space-y-2">
        <div class="flex items-center justify-center space-x-2">
            <input
                v-for="(digit, index) in length"
                :key="index"
                v-model="digits[index]"
                type="text"
                maxlength="1"
                class="h-12 w-12 rounded-lg border border-zinc-700 bg-zinc-800 text-center text-lg font-semibold text-white focus:border-primary focus:outline-none focus:ring-2 focus:ring-primary/20"
                :class="{ 'border-red-500 focus:border-red-500 focus:ring-red-500/20': error }"
                @input="handleInput($event, index)"
                @keydown="handleKeydown($event, index)"
                @paste="handlePaste"
            />
        </div>
        <p v-if="error" class="text-center text-sm text-red-500">{{ error }}</p>
    </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';

interface Props {
    modelValue?: string;
    length?: number;
    error?: string;
}

const props = withDefaults(defineProps<Props>(), {
    modelValue: '',
    length: 6,
    error: '',
});

const emit = defineEmits(['update:modelValue']);

const digits = ref<string[]>(Array(props.length).fill(''));

watch(() => props.modelValue, (newValue) => {
    if (newValue) {
        digits.value = newValue.split('').concat(Array(props.length - newValue.length).fill(''));
    }
}, { immediate: true });

watch(digits, (newValue) => {
    emit('update:modelValue', newValue.join(''));
}, { deep: true });

const handleInput = (event: Event, index: number) => {
    const input = event.target as HTMLInputElement;
    const value = input.value;

    // Sadece sayısal değerlere izin ver
    if (!/^\d*$/.test(value)) {
        input.value = '';
        digits.value[index] = '';
        return;
    }

    // Sonraki input'a geç
    if (value && index < props.length - 1) {
        const nextInput = input.parentElement?.children[index + 1] as HTMLInputElement;
        nextInput?.focus();
    }
};

const handleKeydown = (event: KeyboardEvent, index: number) => {
    if (event.key === 'Backspace' && !digits.value[index] && index > 0) {
        // Boş input silindiğinde önceki input'a geç
        const prevInput = (event.target as HTMLElement).parentElement?.children[index - 1] as HTMLInputElement;
        prevInput?.focus();
        digits.value[index - 1] = '';
    }
};

const handlePaste = (event: ClipboardEvent) => {
    event.preventDefault();
    const pastedData = event.clipboardData?.getData('text');
    if (!pastedData) return;

    // Sadece sayısal değerleri al
    const numbers = pastedData.replace(/\D/g, '').split('');
    digits.value = [...numbers.slice(0, props.length), ...Array(Math.max(0, props.length - numbers.length)).fill('')];

    // Son input'a odaklan
    const lastInput = (event.target as HTMLElement).parentElement?.children[props.length - 1] as HTMLInputElement;
    lastInput?.focus();
};
</script> 