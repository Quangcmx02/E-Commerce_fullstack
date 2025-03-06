<template>
    <div class="fixed right-0 top-1/2 z-50 -translate-y-1/2" :class="className">
        <!-- Açma/Kapama Butonu -->
        <button type="button" class="absolute -left-12 flex h-12 w-12 items-center justify-center rounded-l-lg bg-zinc-800 text-white hover:bg-zinc-700" @click="togglePanel">
            <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor" :class="{ 'rotate-180': isOpen }">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10.325 4.317c.426-1.756 2.924-1.756 3.35 0a1.724 1.724 0 002.573 1.066c1.543-.94 3.31.826 2.37 2.37a1.724 1.724 0 001.065 2.572c1.756.426 1.756 2.924 0 3.35a1.724 1.724 0 00-1.066 2.573c.94 1.543-.826 3.31-2.37 2.37a1.724 1.724 0 00-2.572 1.065c-.426 1.756-2.924 1.756-3.35 0a1.724 1.724 0 00-2.573-1.066c-1.543.94-3.31-.826-2.37-2.37a1.724 1.724 0 00-1.065-2.572c-1.756-.426-1.756-2.924 0-3.35a1.724 1.724 0 001.066-2.573c-.94-1.543.826-3.31 2.37-2.37.996.608 2.296.07 2.572-1.065z" />
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
            </svg>
        </button>

        <!-- Panel -->
        <div class="w-80 transform bg-zinc-800 p-6 shadow-xl transition-transform" :class="isOpen ? 'translate-x-0' : 'translate-x-full'">
            <div class="space-y-6">
                <h2 class="text-lg font-medium text-white">Arayüz Özelleştirme</h2>

                <!-- Tema Seçimi -->
                <div class="space-y-4">
                    <h3 class="text-sm font-medium text-zinc-300">Tema</h3>
                    <ThemeSwitcher @change="handleThemeChange" />
                </div>

                <!-- Dil Seçimi -->
                <div class="space-y-4">
                    <h3 class="text-sm font-medium text-zinc-300">Dil</h3>
                    <LanguageSwitcher @change="handleLanguageChange" />
                </div>

                <!-- Font Boyutu -->
                <div class="space-y-4">
                    <h3 class="text-sm font-medium text-zinc-300">Font Boyutu</h3>
                    <div class="flex items-center gap-4">
                        <button type="button" class="rounded-lg bg-zinc-700 p-2 text-white hover:bg-zinc-600" @click="decreaseFontSize">
                            <svg class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M20 12H4" />
                            </svg>
                        </button>
                        <span class="text-sm text-white">{{ fontSize }}px</span>
                        <button type="button" class="rounded-lg bg-zinc-700 p-2 text-white hover:bg-zinc-600" @click="increaseFontSize">
                            <svg class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 4v16m8-8H4" />
                            </svg>
                        </button>
                    </div>
                </div>

                <!-- Animasyonlar -->
                <div class="space-y-4">
                    <h3 class="text-sm font-medium text-zinc-300">Animasyonlar</h3>
                    <div class="flex items-center justify-between">
                        <span class="text-sm text-zinc-400">Animasyonları Etkinleştir</span>
                        <Switch v-model="animations" @change="handleAnimationsChange" />
                    </div>
                </div>

                <!-- Renk Paleti -->
                <div class="space-y-4">
                    <h3 class="text-sm font-medium text-zinc-300">Ana Renk</h3>
                    <div class="grid grid-cols-6 gap-2">
                        <button v-for="color in colors" :key="color" type="button" class="aspect-square rounded-full" :style="{ backgroundColor: color }" :class="{ 'ring-2 ring-white': primaryColor === color }" @click="selectColor(color)" />
                    </div>
                </div>

                <!-- Sıfırlama Butonu -->
                <button type="button" class="w-full rounded-lg bg-zinc-700 px-4 py-2 text-sm text-white hover:bg-zinc-600" @click="resetSettings">Varsayılan Ayarlara Dön</button>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import ThemeSwitcher from "@/components/ui/Utilities/ThemeSwitcher.vue";
import LanguageSwitcher from "@/components/ui/Utilities/LanguageSwitcher.vue";
import Switch from "@/components/ui/Form/Switch.vue";

interface Props {
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    className: "",
});

const emit = defineEmits(["change"]);

const isOpen = ref(false);
const fontSize = ref(16);
const animations = ref(true);
const primaryColor = ref("#3B82F6");

const colors = [
    "#3B82F6", // Blue
    "#10B981", // Green
    "#F59E0B", // Yellow
    "#EF4444", // Red
    "#8B5CF6", // Purple
    "#EC4899", // Pink
    "#6B7280", // Gray
    "#000000", // Black
];

const togglePanel = () => {
    isOpen.value = !isOpen.value;
};

const handleThemeChange = (theme: string) => {
    emit("change", { type: "theme", value: theme });
};

const handleLanguageChange = (language: object) => {
    emit("change", { type: "language", value: language });
};

const decreaseFontSize = () => {
    if (fontSize.value > 12) {
        fontSize.value -= 1;
        document.documentElement.style.fontSize = `${fontSize.value}px`;
        emit("change", { type: "fontSize", value: fontSize.value });
    }
};

const increaseFontSize = () => {
    if (fontSize.value < 20) {
        fontSize.value += 1;
        document.documentElement.style.fontSize = `${fontSize.value}px`;
        emit("change", { type: "fontSize", value: fontSize.value });
    }
};

const handleAnimationsChange = (value: boolean) => {
    animations.value = value;
    document.documentElement.classList.toggle("no-animations", !value);
    emit("change", { type: "animations", value });
};

const selectColor = (color: string) => {
    primaryColor.value = color;
    document.documentElement.style.setProperty("--primary-color", color);
    emit("change", { type: "primaryColor", value: color });
};

const resetSettings = () => {
    // Varsayılan değerlere dön
    fontSize.value = 16;
    animations.value = true;
    primaryColor.value = "#3B82F6";

    // Değişiklikleri uygula
    document.documentElement.style.fontSize = "16px";
    document.documentElement.classList.remove("no-animations");
    document.documentElement.style.setProperty("--primary-color", "#3B82F6");

    // Local storage'ı temizle
    localStorage.removeItem("fontSize");
    localStorage.removeItem("animations");
    localStorage.removeItem("primaryColor");

    emit("change", { type: "reset" });
};

onMounted(() => {
    // Kaydedilmiş ayarları yükle
    const savedFontSize = localStorage.getItem("fontSize");
    const savedAnimations = localStorage.getItem("animations");
    const savedColor = localStorage.getItem("primaryColor");

    if (savedFontSize) {
        fontSize.value = parseInt(savedFontSize);
        document.documentElement.style.fontSize = `${fontSize.value}px`;
    }

    if (savedAnimations) {
        animations.value = savedAnimations === "true";
        document.documentElement.classList.toggle("no-animations", !animations.value);
    }

    if (savedColor) {
        primaryColor.value = savedColor;
        document.documentElement.style.setProperty("--primary-color", savedColor);
    }
});
</script>

<style>
.no-animations * {
    transition: none !important;
    animation: none !important;
}
</style>
