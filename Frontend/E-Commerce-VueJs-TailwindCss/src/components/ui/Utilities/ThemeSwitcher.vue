<template>
    <div class="relative" :class="className">
        <button type="button" class="flex items-center gap-2 rounded-lg bg-zinc-800 px-3 py-2 text-sm text-white hover:bg-zinc-700" @click="toggleDropdown">
            <!-- Tema İkonu -->
            <svg v-if="currentTheme === 'light'" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 3v1m0 16v1m9-9h-1M4 12H3m15.364 6.364l-.707-.707M6.343 6.343l-.707-.707m12.728 0l-.707.707M6.343 17.657l-.707.707M16 12a4 4 0 11-8 0 4 4 0 018 0z" />
            </svg>
            <svg v-else-if="currentTheme === 'dark'" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M20.354 15.354A9 9 0 018.646 3.646 9.003 9.003 0 0012 21a9.003 9.003 0 008.354-5.646z" />
            </svg>
            <svg v-else class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6a2 2 0 012-2h12a2 2 0 012 2v12a2 2 0 01-2 2H6a2 2 0 01-2-2V6z" />
            </svg>
            <span>{{ themeLabels[currentTheme] }}</span>
            <svg class="h-4 w-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M19 9l-7 7-7-7" />
            </svg>
        </button>

        <!-- Tema Seçenekleri -->
        <div v-if="isOpen" class="absolute right-0 z-10 mt-2 w-48 rounded-lg bg-zinc-800 py-2 shadow-xl">
            <button v-for="(label, theme) in themeLabels" :key="theme" type="button" class="flex w-full items-center gap-3 px-4 py-2 text-sm text-white hover:bg-zinc-700" :class="{ 'bg-zinc-700': currentTheme === theme }" @click="selectTheme(theme)">
                <!-- Tema İkonları -->
                <svg v-if="theme === 'light'" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 3v1m0 16v1m9-9h-1M4 12H3m15.364 6.364l-.707-.707M6.343 6.343l-.707-.707m12.728 0l-.707.707M6.343 17.657l-.707.707M16 12a4 4 0 11-8 0 4 4 0 018 0z" />
                </svg>
                <svg v-else-if="theme === 'dark'" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M20.354 15.354A9 9 0 018.646 3.646 9.003 9.003 0 0012 21a9.003 9.003 0 008.354-5.646z" />
                </svg>
                <svg v-else class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6a2 2 0 012-2h12a2 2 0 012 2v12a2 2 0 01-2 2H6a2 2 0 01-2-2V6z" />
                </svg>
                {{ label }}
            </button>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from "vue";

interface Props {
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    className: "",
});

const emit = defineEmits(["change"]);

const isOpen = ref(false);
const currentTheme = ref("system");

const themeLabels = {
    light: "Açık Tema",
    dark: "Koyu Tema",
    system: "Sistem Teması",
};

const toggleDropdown = () => {
    isOpen.value = !isOpen.value;
};

const selectTheme = (theme: keyof typeof themeLabels) => {
    currentTheme.value = theme;
    isOpen.value = false;

    // Tema değişikliğini uygula
    if (theme === "system") {
        // Sistem temasını kontrol et
        const prefersDark = window.matchMedia("(prefers-color-scheme: dark)").matches;
        document.documentElement.classList.toggle("dark", prefersDark);
    } else {
        document.documentElement.classList.toggle("dark", theme === "dark");
    }

    // Local storage'a kaydet
    localStorage.setItem("theme", theme);

    emit("change", theme);
};

// Dışarı tıklandığında dropdown'ı kapat
const handleClickOutside = (event: MouseEvent) => {
    const target = event.target as HTMLElement;
    if (!target.closest(".relative")) {
        isOpen.value = false;
    }
};

// Sistem tema değişikliğini dinle
const handleSystemThemeChange = (e: MediaQueryListEvent) => {
    if (currentTheme.value === "system") {
        document.documentElement.classList.toggle("dark", e.matches);
    }
};

onMounted(() => {
    // Kaydedilmiş temayı yükle
    const savedTheme = localStorage.getItem("theme") as keyof typeof themeLabels;
    if (savedTheme) {
        selectTheme(savedTheme);
    }

    // Event listener'ları ekle
    document.addEventListener("click", handleClickOutside);
    window.matchMedia("(prefers-color-scheme: dark)").addEventListener("change", handleSystemThemeChange);
});

onUnmounted(() => {
    // Event listener'ları temizle
    document.removeEventListener("click", handleClickOutside);
    window.matchMedia("(prefers-color-scheme: dark)").removeEventListener("change", handleSystemThemeChange);
});
</script>
