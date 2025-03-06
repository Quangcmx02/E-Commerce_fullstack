<template>
    <Teleport to="body">
        <div class="fixed inset-x-0 bottom-0 z-50 p-4 pointer-events-none">
            <TransitionGroup
                enter-active-class="transition ease-out duration-300"
                enter-from-class="translate-y-2 opacity-0"
                enter-to-class="translate-y-0 opacity-100"
                leave-active-class="transition ease-in duration-200"
                leave-from-class="translate-y-0 opacity-100"
                leave-to-class="translate-y-2 opacity-0"
            >
                <div
                    v-for="snackbar in snackbars"
                    :key="snackbar.id"
                    class="pointer-events-auto mb-2 flex w-full max-w-sm mx-auto items-center justify-between rounded-lg bg-zinc-800 p-4 shadow-lg"
                >
                    <div class="flex items-center">
                        <p class="text-sm text-white">{{ snackbar.message }}</p>
                    </div>
                    <div class="ml-4 flex flex-shrink-0">
                        <button
                            v-if="snackbar.action"
                            class="mr-2 text-sm font-medium text-blue-500 hover:text-blue-400 focus:outline-none"
                            @click="handleAction(snackbar)"
                        >
                            {{ snackbar.action.label }}
                        </button>
                        <button
                            class="text-zinc-400 hover:text-zinc-300 focus:outline-none"
                            @click="removeSnackbar(snackbar.id)"
                        >
                            <svg class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
                                <path
                                    fill-rule="evenodd"
                                    d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
                                    clip-rule="evenodd"
                                />
                            </svg>
                        </button>
                    </div>
                </div>
            </TransitionGroup>
        </div>
    </Teleport>
</template>

<script setup lang="ts">
import { ref } from 'vue';

interface SnackbarAction {
    label: string;
    callback: () => void;
}

interface Snackbar {
    id: number;
    message: string;
    action?: SnackbarAction;
    duration?: number;
}

const snackbars = ref<Snackbar[]>([]);
let snackbarId = 0;

const show = (snackbar: Omit<Snackbar, 'id'>) => {
    const id = ++snackbarId;
    const duration = snackbar.duration ?? 5000;

    snackbars.value.push({ ...snackbar, id });

    if (duration > 0) {
        setTimeout(() => {
            removeSnackbar(id);
        }, duration);
    }
};

const removeSnackbar = (id: number) => {
    const index = snackbars.value.findIndex(s => s.id === id);
    if (index > -1) {
        snackbars.value.splice(index, 1);
    }
};

const handleAction = (snackbar: Snackbar) => {
    if (snackbar.action?.callback) {
        snackbar.action.callback();
    }
    removeSnackbar(snackbar.id);
};

defineExpose({
    show,
});
</script> 