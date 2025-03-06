<template>
    <div class="w-full space-y-1.5">
        <!-- Label -->
        <label v-if="label" :for="id" class="block text-sm font-medium text-zinc-200">
            {{ label }}
            <span v-if="required" class="text-red-500">*</span>
        </label>

        <!-- Select Container -->
        <div class="relative">
            <!-- Multiple Select Display -->
            <div
                v-if="multiple"
                :class="[
                    'flex flex-wrap gap-1 min-h-[2.5rem] p-1 rounded-md cursor-pointer',
                    variantClasses,
                    sizeClasses[size],
                    error ? 'border-red-500 focus:border-red-500 focus:ring-red-500' : '',
                    disabled ? 'opacity-50 cursor-not-allowed' : '',
                    className
                ]"
                @click="toggleDropdown"
            >
                <span
                    v-for="item in selectedItems"
                    :key="item.value"
                    class="inline-flex items-center px-2 py-1 text-sm bg-zinc-700 rounded"
                >
                    {{ item.label }}
                    <button
                        v-if="!disabled"
                        @click.stop="removeItem(item.value)"
                        class="ml-1 text-zinc-400 hover:text-white focus:outline-none"
                    >
                        <svg class="w-4 h-4" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M6 18L18 6M6 6l12 12" />
                        </svg>
                    </button>
                </span>
                <span v-if="!selectedItems.length" class="text-zinc-400 px-4 py-1">{{ placeholder }}</span>
            </div>

            <!-- Single Select Display -->
            <div
                v-else
                :class="[
                    'relative flex items-center min-h-[2.5rem] rounded-md cursor-pointer',
                    variantClasses,
                    sizeClasses[size],
                    error ? 'border-red-500 focus:border-red-500 focus:ring-red-500' : '',
                    disabled ? 'opacity-50 cursor-not-allowed' : '',
                    className
                ]"
                @click="toggleDropdown"
            >
                <span v-if="selectedOption" class="block pl-4 pr-10 truncate">
                    {{ selectedOption.label }}
                </span>
                <span v-else class="block pl-4 pr-10 text-zinc-400 truncate">
                    {{ placeholder }}
                </span>

                <!-- Chevron Icon -->
                <div class="absolute inset-y-0 right-0 flex items-center pr-2 pointer-events-none">
                    <svg class="w-5 h-5 text-zinc-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
                    </svg>
                </div>
            </div>

            <!-- Dropdown Menu -->
            <div
                v-if="isOpen"
                class="absolute z-50 w-full mt-1 bg-zinc-900 border border-zinc-700 rounded-md shadow-lg"
            >
                <!-- Search Input -->
                <div v-if="searchable" class="p-2 border-b border-zinc-700">
                    <input
                        type="text"
                        v-model="searchQuery"
                        placeholder="Ara..."
                        class="w-full px-3 py-1 text-sm text-white bg-zinc-800 border border-zinc-600 rounded focus:outline-none focus:border-zinc-500"
                        @click.stop
                    />
                </div>

                <!-- Options List -->
                <div class="max-h-60 overflow-auto">
                    <div v-if="!filteredOptions.length" class="px-4 py-2 text-sm text-zinc-400">
                        Sonuç bulunamadı
                    </div>
                    <template v-else>
                        <div
                            v-for="option in filteredOptions"
                            :key="option.value"
                            class="flex items-center px-4 py-2 cursor-pointer hover:bg-zinc-800"
                            @click="selectOption(option)"
                        >
                            <template v-if="multiple">
                                <input
                                    type="checkbox"
                                    :checked="isSelected(option.value)"
                                    class="w-4 h-4 mr-2 border-zinc-600 rounded focus:ring-zinc-500"
                                />
                            </template>
                            <span :class="{ 'font-medium': isSelected(option.value) }">
                                {{ option.label }}
                            </span>
                        </div>
                    </template>
                </div>
            </div>
        </div>

        <!-- Error Message -->
        <p v-if="error" class="text-sm text-red-500">
            {{ error }}
        </p>

        <!-- Helper Text -->
        <p v-else-if="helperText" class="text-sm text-zinc-400">
            {{ helperText }}
        </p>
    </div>
</template>

<script setup lang="ts">
import { computed, ref, onMounted, onUnmounted } from "vue";

type SizeType = "sm" | "md" | "lg";
type VariantType = "default" | "filled" | "outline" | "ghost";

interface Option {
    label: string;
    value: string | number;
}

const props = defineProps({
    modelValue: {
        type: [String, Number, Array],
        default: "",
    },
    id: {
        type: String,
        default: () => "select-" + Math.random().toString(36).slice(2, 11),
    },
    label: {
        type: String,
        default: "",
    },
    placeholder: {
        type: String,
        default: "",
    },
    variant: {
        type: String as () => VariantType,
        default: "default",
        validator: (value: string) => ["default", "filled", "outline", "ghost"].includes(value),
    },
    size: {
        type: String as () => SizeType,
        default: "md",
        validator: (value: string) => ["sm", "md", "lg"].includes(value),
    },
    disabled: {
        type: Boolean,
        default: false,
    },
    required: {
        type: Boolean,
        default: false,
    },
    error: {
        type: String,
        default: "",
    },
    helperText: {
        type: String,
        default: "",
    },
    className: {
        type: String,
        default: "",
    },
    multiple: {
        type: Boolean,
        default: false,
    },
    searchable: {
        type: Boolean,
        default: false,
    },
    options: {
        type: Array as () => Option[],
        default: () => [],
    },
});

const emit = defineEmits(["update:modelValue", "blur", "focus", "change"]);

const isOpen = ref(false);
const searchQuery = ref("");

const selectedItems = computed(() => {
    if (!props.multiple) return [];
    const selected = Array.isArray(props.modelValue) ? props.modelValue : [];
    return props.options.filter(option => selected.includes(option.value));
});

const selectedOption = computed(() => {
    if (props.multiple) return null;
    return props.options.find(option => option.value === props.modelValue);
});

const filteredOptions = computed(() => {
    if (!props.searchable || !searchQuery.value) return props.options;
    const query = searchQuery.value.toLowerCase();
    return props.options.filter(option => 
        option.label.toLowerCase().includes(query)
    );
});

const toggleDropdown = () => {
    if (!props.disabled) {
        isOpen.value = !isOpen.value;
        if (!isOpen.value) {
            searchQuery.value = "";
        }
    }
};

const closeDropdown = (e: MouseEvent) => {
    const target = e.target as HTMLElement;
    if (!target.closest('.relative')) {
        isOpen.value = false;
        searchQuery.value = "";
    }
};

const isSelected = (value: string | number) => {
    if (props.multiple) {
        return Array.isArray(props.modelValue) && props.modelValue.includes(value);
    }
    return props.modelValue === value;
};

const toggleOption = (option: Option) => {
    if (!props.multiple || props.disabled) return;

    const currentValue = Array.isArray(props.modelValue) ? props.modelValue : [];
    const newValue = isSelected(option.value)
        ? currentValue.filter(v => v !== option.value)
        : [...currentValue, option.value];

    emit("update:modelValue", newValue);
    emit("change", newValue);
};

const removeItem = (value: string | number) => {
    if (!props.multiple || props.disabled) return;

    const newValue = Array.isArray(props.modelValue)
        ? props.modelValue.filter(v => v !== value)
        : [];

    emit("update:modelValue", newValue);
    emit("change", newValue);
};

const selectOption = (option: Option) => {
    if (props.multiple) {
        toggleOption(option);
    } else {
        emit("update:modelValue", option.value);
        emit("change", option.value);
        isOpen.value = false;
        searchQuery.value = "";
    }
};

onMounted(() => {
    document.addEventListener("click", closeDropdown);
});

onUnmounted(() => {
    document.removeEventListener("click", closeDropdown);
});

const variantClasses = computed(
    () =>
        ({
            default: "bg-zinc-900 border border-zinc-700 focus:border-zinc-600 focus:ring-zinc-600 focus:ring-offset-zinc-900",
            filled: "bg-zinc-800 border-transparent hover:bg-zinc-700/50 focus:bg-zinc-800 focus:border-zinc-600 focus:ring-zinc-600 focus:ring-offset-zinc-900",
            outline: "bg-transparent border-2 border-zinc-700 hover:border-zinc-600 focus:border-zinc-500 focus:ring-zinc-600 focus:ring-offset-zinc-900",
            ghost: "bg-transparent border-transparent hover:bg-zinc-800/50 focus:bg-zinc-800 focus:border-zinc-600 focus:ring-zinc-600 focus:ring-offset-zinc-900",
        })[props.variant]
);

const sizeClasses: Record<SizeType, string> = {
    sm: "h-8 text-sm",
    md: "h-10 text-base",
    lg: "h-12 text-lg",
};
</script> 