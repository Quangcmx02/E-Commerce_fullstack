<template>
    <div :class="className">
        <div class="relative">
            <!-- Adımlar -->
            <nav class="flex items-center justify-between" aria-label="Progress">
                <ol role="list" class="flex w-full items-center">
                    <li v-for="(step, index) in steps" :key="index" class="relative flex-1" :class="{ 'pr-8': index !== steps.length - 1 }">
                        <!-- Çizgi -->
                        <div v-if="index !== steps.length - 1" class="absolute left-0 right-0 top-4 h-0.5" :class="[currentStep > index ? 'bg-blue-600' : 'bg-zinc-700']" />

                        <div class="group relative flex items-start">
                            <!-- Adım İkonu -->
                            <span class="flex h-9 items-center">
                                <span class="relative z-10 flex h-8 w-8 items-center justify-center rounded-full" :class="[currentStep > index ? 'bg-blue-600' : currentStep === index ? 'border-2 border-blue-600 bg-zinc-800' : 'border-2 border-zinc-700 bg-zinc-800']">
                                    <template v-if="currentStep > index">
                                        <svg class="h-5 w-5 text-white" viewBox="0 0 20 20" fill="currentColor">
                                            <path fill-rule="evenodd" d="M16.707 5.293a1 1 0 010 1.414l-8 8a1 1 0 01-1.414 0l-4-4a1 1 0 011.414-1.414L8 12.586l7.293-7.293a1 1 0 011.414 0z" clip-rule="evenodd" />
                                        </svg>
                                    </template>
                                    <template v-else>
                                        <span :class="[currentStep === index ? 'text-blue-600' : 'text-zinc-500']">
                                            {{ index + 1 }}
                                        </span>
                                    </template>
                                </span>
                            </span>

                            <!-- Adım Başlığı ve Açıklaması -->
                            <span class="ml-4">
                                <span class="text-sm font-medium" :class="[currentStep === index ? 'text-blue-600' : currentStep > index ? 'text-zinc-300' : 'text-zinc-500']">
                                    {{ step.title }}
                                </span>
                                <span v-if="step.description" class="mt-0.5 block text-sm text-zinc-500">
                                    {{ step.description }}
                                </span>
                            </span>
                        </div>
                    </li>
                </ol>
            </nav>

            <!-- İçerik -->
            <div class="mt-8">
                <slot :step="currentStep" />
            </div>

            <!-- Navigasyon Butonları -->
            <div class="mt-8 flex justify-between">
                <button v-if="currentStep > 0" class="rounded-md bg-zinc-800 px-4 py-2 text-sm font-medium text-white hover:bg-zinc-700 focus:outline-none" @click="prev">Geri</button>
                <button v-if="currentStep < steps.length - 1" class="ml-auto rounded-md bg-blue-600 px-4 py-2 text-sm font-medium text-white hover:bg-blue-700 focus:outline-none" @click="next">İleri</button>
                <button v-else class="ml-auto rounded-md bg-green-600 px-4 py-2 text-sm font-medium text-white hover:bg-green-700 focus:outline-none" @click="finish">Tamamla</button>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">

import { computed } from "vue";

interface Step {
    title: string;
    description?: string;
}

interface Props {
    className?: string;
    steps: Step[];
    modelValue: number;
}

const props = withDefaults(defineProps<Props>(), {
    className: "",
});

const emit = defineEmits<{
    (e: "update:modelValue", value: number): void;
    (e: "finish"): void;
}>();

const currentStep = computed({
    get: () => props.modelValue,
    set: (value) => emit("update:modelValue", value),
});

const next = () => {
    if (currentStep.value < props.steps.length - 1) {
        currentStep.value++;
    }
};

const prev = () => {
    if (currentStep.value > 0) {
        currentStep.value--;
    }
};

const finish = () => {
    emit("finish");
};
</script>
