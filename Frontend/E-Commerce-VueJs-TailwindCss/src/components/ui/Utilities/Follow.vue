<template>
    <div class="inline-flex items-center space-x-2">
        <!-- Takip Et Butonu -->
        <button
            @click="toggleFollow"
            class="inline-flex items-center space-x-2 rounded-lg px-4 py-2 text-sm font-medium transition-colors"
            :class="[
                isFollowing
                    ? variant === 'primary'
                        ? 'bg-primary/10 text-primary hover:bg-primary/20'
                        : 'bg-zinc-800 text-white hover:bg-zinc-700'
                    : 'bg-primary text-white hover:bg-primary/90',
                loading && 'cursor-wait opacity-75',
                disabled && 'cursor-not-allowed opacity-50'
            ]"
            :disabled="disabled || loading"
        >
            <!-- Yükleniyor İkonu -->
            <svg
                v-if="loading"
                class="h-4 w-4 animate-spin"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
            >
                <circle
                    class="opacity-25"
                    cx="12"
                    cy="12"
                    r="10"
                    stroke="currentColor"
                    stroke-width="4"
                ></circle>
                <path
                    class="opacity-75"
                    fill="currentColor"
                    d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
                ></path>
            </svg>

            <!-- Takip İkonu -->
            <svg
                v-else-if="showIcon"
                class="h-5 w-5"
                xmlns="http://www.w3.org/2000/svg"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
            >
                <path
                    v-if="isFollowing"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M5 13l4 4L19 7"
                />
                <path
                    v-else
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M12 4v16m8-8H4"
                />
            </svg>

            <!-- Buton Metni -->
            <span>{{ buttonText }}</span>
        </button>

        <!-- Takipçi Sayısı -->
        <span v-if="showCount" class="text-sm text-zinc-400">
            {{ formatNumber(count) }} takipçi
        </span>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';

interface Props {
    modelValue?: boolean;
    count?: number;
    loading?: boolean;
    disabled?: boolean;
    showIcon?: boolean;
    showCount?: boolean;
    variant?: 'primary' | 'secondary';
    followText?: string;
    followingText?: string;
}

const props = withDefaults(defineProps<Props>(), {
    modelValue: false,
    count: 0,
    loading: false,
    disabled: false,
    showIcon: true,
    showCount: false,
    variant: 'primary',
    followText: 'Takip Et',
    followingText: 'Takip Ediliyor',
});

const emit = defineEmits(['update:modelValue', 'follow', 'unfollow']);

const isFollowing = ref(props.modelValue);

const buttonText = computed(() => {
    return isFollowing.value ? props.followingText : props.followText;
});

const toggleFollow = () => {
    if (props.loading || props.disabled) return;

    isFollowing.value = !isFollowing.value;
    emit('update:modelValue', isFollowing.value);
    emit(isFollowing.value ? 'follow' : 'unfollow');
};

const formatNumber = (num: number) => {
    if (num >= 1000000) {
        return (num / 1000000).toFixed(1) + 'M';
    }
    if (num >= 1000) {
        return (num / 1000).toFixed(1) + 'B';
    }
    return num.toString();
};
</script> 