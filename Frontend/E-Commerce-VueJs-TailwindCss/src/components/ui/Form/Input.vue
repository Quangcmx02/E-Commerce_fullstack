<template>
    <div class="w-full space-y-1.5">
        <!-- Label -->
        <label v-if="label" :for="id" class="block text-sm font-medium text-zinc-200">
            {{ label }}
            <span v-if="required" class="text-red-500">*</span>
        </label>

        <!-- Input Container -->
        <div class="relative">
            <!-- Left Icon -->
            <div v-if="$slots.leftIcon || defaultLeftIcon" class="absolute inset-y-0 left-0 flex items-center pl-3">
                <slot name="leftIcon">
                    <svg v-if="type === 'email'" class="w-5 h-5 text-zinc-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z" />
                    </svg>
                    <svg v-if="type === 'password'" class="w-5 h-5 text-zinc-400" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                        <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
                    </svg>
                </slot>
            </div>

            <!-- Input Element -->
            <input :id="id" :type="actualType" :value="modelValue" :placeholder="placeholder" :disabled="disabled" :required="required" :class="inputClasses" @input="$emit('update:modelValue', ($event.target as HTMLInputElement).value)" @blur="$emit('blur', $event)" @focus="$emit('focus', $event)" />

            <!-- Right Icon -->
            <div v-if="type === 'password' || $slots.rightIcon" class="absolute inset-y-0 right-0 flex items-center pr-3">
                <slot name="rightIcon">
                    <button v-if="type === 'password'" type="button" class="text-zinc-400 hover:text-zinc-300 focus:outline-none" @click="togglePasswordVisibility">
                        <svg v-if="showPassword" class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z" />
                        </svg>
                        <svg v-else class="w-5 h-5" fill="none" stroke="currentColor" viewBox="0 0 24 24">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.88 9.88l-3.29-3.29m7.532 7.532l3.29 3.29M3 3l3.59 3.59m0 0A9.953 9.953 0 0112 5c4.478 0 8.268 2.943 9.543 7a10.025 10.025 0 01-4.132 5.411m0 0L21 21" />
                        </svg>
                    </button>
                </slot>
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
import { computed, ref, useSlots } from "vue";

type SizeType = "sm" | "md" | "lg";
type VariantType = "default" | "filled" | "outline" | "ghost";
type InputType = "text" | "number" | "email" | "password" | "tel" | "url" | "search";

const slots = useSlots();
const props = defineProps({
    modelValue: {
        type: [String, Number],
        default: "",
    },
    id: {
        type: String,
        default: () => "input-" + Math.random().toString(36).slice(2, 11),
    },
    label: {
        type: String,
        default: "",
    },
    type: {
        type: String as () => InputType,
        default: "text",
        validator: (value: string) => ["text", "number", "email", "password", "tel", "url", "search"].includes(value),
    },
    variant: {
        type: String as () => VariantType,
        default: "default",
        validator: (value: string) => ["default", "filled", "outline", "ghost"].includes(value),
    },
    placeholder: {
        type: String,
        default: "",
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
});

const showPassword = ref(false);

const defaultLeftIcon = computed(() => {
    return props.type === "email" || props.type === "password";
});

const actualType = computed(() => {
    if (props.type === "password") {
        return showPassword.value ? "text" : "password";
    }
    return props.type;
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

const inputClasses = computed(() => ["block w-full rounded-md shadow-sm px-4", "text-white placeholder:text-zinc-400", "focus:outline-none focus:ring-2 focus:ring-offset-2", slots.leftIcon || defaultLeftIcon.value ? "pl-10" : "", props.type === "password" || slots.rightIcon ? "pr-10" : "", variantClasses.value, sizeClasses[props.size], props.error ? "border-red-500 focus:border-red-500 focus:ring-red-500" : "", props.disabled ? "opacity-50 cursor-not-allowed" : "", props.className]);

const togglePasswordVisibility = () => {
    showPassword.value = !showPassword.value;
};

defineEmits(["update:modelValue", "blur", "focus"]);
</script>
