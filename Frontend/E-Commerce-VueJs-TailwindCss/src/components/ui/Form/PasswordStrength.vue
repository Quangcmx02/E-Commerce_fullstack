<template>
  <div class="space-y-2" :class="className">
    <!-- Şifre Girişi -->
    <div class="relative">
      <input
        :type="showPassword ? 'text' : 'password'"
        v-model="password"
        class="w-full rounded-lg border border-zinc-800 bg-zinc-900 px-3 py-2 text-sm text-white placeholder-zinc-400 focus:border-blue-500 focus:outline-none"
        :placeholder="placeholder"
        @input="checkStrength"
      />
      <button
        type="button"
        class="absolute right-2 top-1/2 -translate-y-1/2 text-zinc-400 hover:text-white"
        @click="togglePassword"
      >
        <svg
          v-if="showPassword"
          class="h-5 w-5"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M15 12a3 3 0 11-6 0 3 3 0 016 0z"
          />
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"
          />
        </svg>
        <svg
          v-else
          class="h-5 w-5"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.88 9.88l-3.29-3.29m7.532 7.532l3.29 3.29M3 3l3.59 3.59m0 0A9.953 9.953 0 0112 5c4.478 0 8.268 2.943 9.543 7a10.025 10.025 0 01-4.132 5.411m0 0L21 21"
          />
        </svg>
      </button>
    </div>

    <!-- Güç Göstergesi -->
    <div class="space-y-1">
      <div class="flex gap-1">
        <div
          v-for="(level, index) in strengthLevels"
          :key="index"
          class="h-1 flex-1 rounded-full transition-all"
          :class="[
            index < strength
              ? strengthColors[strength - 1]
              : 'bg-zinc-800'
          ]"
        />
      </div>
      <p class="text-xs" :class="strengthTextColors[strength - 1]">
        {{ strengthText }}
      </p>
    </div>

    <!-- Gereksinimler -->
    <ul class="space-y-1 text-xs">
      <li
        v-for="(req, index) in requirements"
        :key="index"
        :class="req.met ? 'text-green-500' : 'text-zinc-400'"
        class="flex items-center gap-1"
      >
        <svg
          v-if="req.met"
          class="h-4 w-4"
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
          v-else
          class="h-4 w-4"
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
        {{ req.text }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

interface Props {
  className?: string
  placeholder?: string
  minLength?: number
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
  placeholder: 'Şifre girin',
  minLength: 8
})

const emit = defineEmits(['update:strength', 'input'])

const password = ref('')
const showPassword = ref(false)
const strength = ref(0)

const strengthLevels = [1, 2, 3, 4]

const strengthColors = [
  'bg-red-500',    // Çok Zayıf
  'bg-yellow-500', // Zayıf
  'bg-blue-500',   // Orta
  'bg-green-500'   // Güçlü
]

const strengthTextColors = [
  'text-red-500',    // Çok Zayıf
  'text-yellow-500', // Zayıf
  'text-blue-500',   // Orta
  'text-green-500'   // Güçlü
]

const strengthText = computed(() => {
  switch (strength.value) {
    case 1:
      return 'Çok Zayıf'
    case 2:
      return 'Zayıf'
    case 3:
      return 'Orta'
    case 4:
      return 'Güçlü'
    default:
      return ''
  }
})

const requirements = ref([
  {
    text: `En az ${props.minLength} karakter`,
    met: false,
    test: (pwd: string) => pwd.length >= props.minLength
  },
  {
    text: 'En az bir büyük harf',
    met: false,
    test: (pwd: string) => /[A-Z]/.test(pwd)
  },
  {
    text: 'En az bir küçük harf',
    met: false,
    test: (pwd: string) => /[a-z]/.test(pwd)
  },
  {
    text: 'En az bir rakam',
    met: false,
    test: (pwd: string) => /[0-9]/.test(pwd)
  },
  {
    text: 'En az bir özel karakter',
    met: false,
    test: (pwd: string) => /[!@#$%^&*(),.?":{}|<>]/.test(pwd)
  }
])

const togglePassword = () => {
  showPassword.value = !showPassword.value
}

const checkStrength = () => {
  // Gereksinimleri kontrol et
  let metCount = 0
  requirements.value.forEach(req => {
    req.met = req.test(password.value)
    if (req.met) metCount++
  })

  // Güç seviyesini hesapla
  strength.value = Math.ceil((metCount / requirements.value.length) * 4)

  emit('update:strength', strength.value)
  emit('input', password.value)
}
</script> 