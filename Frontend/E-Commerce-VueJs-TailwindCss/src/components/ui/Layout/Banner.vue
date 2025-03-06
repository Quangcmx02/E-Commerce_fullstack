<template>
    <Transition
        enter-active-class="transition ease-out duration-300"
        enter-from-class="-translate-y-full"
        enter-to-class="translate-y-0"
        leave-active-class="transition ease-in duration-200"
        leave-from-class="translate-y-0"
        leave-to-class="-translate-y-full"
    >
        <div
            v-if="modelValue"
            class="fixed inset-x-0 top-0 z-50"
            :class="[
                type === 'success' ? 'bg-green-500' :
                type === 'error' ? 'bg-red-500' :
                type === 'warning' ? 'bg-yellow-500' :
                'bg-blue-500'
            ]"
        >
            <div class="mx-auto max-w-7xl py-3 px-3 sm:px-6 lg:px-8">
                <div class="flex flex-wrap items-center justify-between">
                    <div class="flex w-0 flex-1 items-center">
                        <span class="flex rounded-lg p-2">
                            <svg
                                v-if="type === 'success'"
                                class="h-6 w-6 text-white"
                                fill="none"
                                viewBox="0 0 24 24"
                                stroke="currentColor"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M5 13l4 4L19 7"
                                />
                            </svg>
                            <svg
                                v-else-if="type === 'error'"
                                class="h-6 w-6 text-white"
                                fill="none"
                                viewBox="0 0 24 24"
                                stroke="currentColor"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M6 18L18 6M6 6l12 12"
                                />
                            </svg>
                            <svg
                                v-else-if="type === 'warning'"
                                class="h-6 w-6 text-white"
                                fill="none"
                                viewBox="0 0 24 24"
                                stroke="currentColor"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M12 9v2m0 4h.01m-6.938 4h13.856c1.54 0 2.502-1.667 1.732-3L13.732 4c-.77-1.333-2.694-1.333-3.464 0L3.34 16c-.77 1.333.192 3 1.732 3z"
                                />
                            </svg>
                            <svg
                                v-else
                                class="h-6 w-6 text-white"
                                fill="none"
                                viewBox="0 0 24 24"
                                stroke="currentColor"
                            >
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M13 16h-1v-4h-1m1-4h.01M21 12a9 9 0 11-18 0 9 9 0 0118 0z"
                                />
                            </svg>
                        </span>
                        <p class="ml-3 truncate font-medium text-white">
                            <span>{{ message }}</span>
                        </p>
                    </div>
                    <div class="flex-shrink-0 sm:ml-3">
                        <button
                            v-if="action"
                            class="mr-2 rounded-md bg-white/20 px-3 py-1 text-sm font-medium text-white hover:bg-white/30 focus:outline-none"
                            @click="handleAction"
                        >
                            {{ action.label }}
                        </button>
                        <button
                            v-if="closable"
                            class="-mr-1 flex rounded-md p-2 hover:bg-white/20 focus:outline-none"
                            @click="$emit('update:modelValue', false)"
                        >
                            <span class="sr-only">Kapat</span>
                            <svg class="h-6 w-6 text-white" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path
                                    stroke-linecap="round"
                                    stroke-linejoin="round"
                                    stroke-width="2"
                                    d="M6 18L18 6M6 6l12 12"
                                />
                            </svg>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </Transition>
</template>

<script setup lang="ts">
interface BannerAction {
    label: string;
    callback: () => void;
}

interface Props {
    modelValue: boolean;
    message: string;
    type?: 'success' | 'error' | 'warning' | 'info';
    action?: BannerAction;
    closable?: boolean;
}

const props = withDefaults(defineProps<Props>(), {
    type: 'info',
    closable: true,
});

const emit = defineEmits<{
    (e: 'update:modelValue', value: boolean): void;
}>();

const handleAction = () => {
    if (props.action?.callback) {
        props.action.callback();
    }
};
</script> 