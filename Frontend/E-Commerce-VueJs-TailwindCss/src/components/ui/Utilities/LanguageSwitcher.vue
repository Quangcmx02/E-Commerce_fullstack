<template>
  <div class="relative" :class="className">
    <button
      type="button"
      class="flex items-center gap-2 rounded-lg bg-zinc-800 px-3 py-2 text-sm text-white hover:bg-zinc-700"
      @click="toggleDropdown"
    >
      <!-- Dil Bayrağı -->
      <img
        :src="languages[currentLanguage].flag"
        :alt="languages[currentLanguage].name"
        class="h-5 w-5 rounded-sm object-cover"
      />
      <span>{{ languages[currentLanguage].name }}</span>
      <svg
        class="h-4 w-4"
        fill="none"
        viewBox="0 0 24 24"
        stroke="currentColor"
      >
        <path
          stroke-linecap="round"
          stroke-linejoin="round"
          stroke-width="2"
          d="M19 9l-7 7-7-7"
        />
      </svg>
    </button>

    <!-- Dil Seçenekleri -->
    <div
      v-if="isOpen"
      class="absolute right-0 z-10 mt-2 w-48 rounded-lg bg-zinc-800 py-2 shadow-xl"
    >
      <button
        v-for="(lang, code) in languages"
        :key="code"
        type="button"
        class="flex w-full items-center gap-3 px-4 py-2 text-sm text-white hover:bg-zinc-700"
        :class="{ 'bg-zinc-700': currentLanguage === code }"
        @click="selectLanguage(code)"
      >
        <img
          :src="lang.flag"
          :alt="lang.name"
          class="h-5 w-5 rounded-sm object-cover"
        />
        {{ lang.name }}
      </button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, onUnmounted } from 'vue'

interface Language {
  name: string
  flag: string
  locale: string
}

interface Props {
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  className: ''
})

const emit = defineEmits(['change'])

const isOpen = ref(false)
const currentLanguage = ref('tr')

const languages: Record<string, Language> = {
  tr: {
    name: 'Türkçe',
    flag: 'https://flagcdn.com/w40/tr.png',
    locale: 'tr-TR'
  },
  en: {
    name: 'English',
    flag: 'https://flagcdn.com/w40/gb.png',
    locale: 'en-US'
  },
  de: {
    name: 'Deutsch',
    flag: 'https://flagcdn.com/w40/de.png',
    locale: 'de-DE'
  },
  fr: {
    name: 'Français',
    flag: 'https://flagcdn.com/w40/fr.png',
    locale: 'fr-FR'
  }
}

const toggleDropdown = () => {
  isOpen.value = !isOpen.value
}

const selectLanguage = (code: string) => {
  currentLanguage.value = code
  isOpen.value = false

  // Dil değişikliğini uygula
  document.documentElement.lang = languages[code].locale
  
  // Local storage'a kaydet
  localStorage.setItem('language', code)

  emit('change', {
    code,
    ...languages[code]
  })
}

// Dışarı tıklandığında dropdown'ı kapat
const handleClickOutside = (event: MouseEvent) => {
  const target = event.target as HTMLElement
  if (!target.closest('.relative')) {
    isOpen.value = false
  }
}

onMounted(() => {
  // Kaydedilmiş dili yükle
  const savedLanguage = localStorage.getItem('language')
  if (savedLanguage && languages[savedLanguage]) {
    selectLanguage(savedLanguage)
  }

  // Event listener ekle
  document.addEventListener('click', handleClickOutside)
})

onUnmounted(() => {
  // Event listener'ı temizle
  document.removeEventListener('click', handleClickOutside)
})
</script> 