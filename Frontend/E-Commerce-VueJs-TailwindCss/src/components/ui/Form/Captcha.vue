<template>
  <div class="rounded-lg border border-zinc-800 bg-zinc-900 p-4" :class="className">
    <div class="space-y-4">
      <!-- Captcha Başlığı -->
      <div class="flex items-center justify-between">
        <h3 class="text-sm font-medium text-white">Robot Olmadığını Doğrula</h3>
        <button
          type="button"
          class="text-zinc-400 hover:text-white"
          @click="refreshCaptcha"
        >
          <svg
            class="h-5 w-5"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M4 4v5h.582m15.356 2A8.001 8.001 0 004.582 9m0 0H9m11 11v-5h-.581m0 0a8.003 8.003 0 01-15.357-2m15.357 2H15"
            />
          </svg>
        </button>
      </div>

      <!-- Captcha Görüntüsü -->
      <div class="relative">
        <canvas
          ref="canvasRef"
          class="h-20 w-full rounded bg-zinc-800"
          @click="refreshCaptcha"
        />
        <div
          v-if="loading"
          class="absolute inset-0 flex items-center justify-center bg-zinc-900/75"
        >
          <div class="h-8 w-8 animate-spin rounded-full border-4 border-zinc-600 border-t-white" />
        </div>
      </div>

      <!-- Captcha Girişi -->
      <div class="space-y-2">
        <input
          v-model="userInput"
          type="text"
          class="w-full rounded-lg border border-zinc-800 bg-zinc-900 px-3 py-2 text-sm text-white placeholder-zinc-400 focus:border-blue-500 focus:outline-none"
          placeholder="Yukarıdaki metni girin"
          :maxlength="captchaLength"
          @input="handleInput"
        />
        <p
          v-if="error"
          class="text-sm text-red-500"
        >
          {{ error }}
        </p>
      </div>

      <!-- Doğrulama Butonu -->
      <button
        type="button"
        class="w-full rounded-lg bg-blue-600 px-4 py-2 text-sm font-medium text-white hover:bg-blue-700 disabled:cursor-not-allowed disabled:opacity-50"
        :disabled="loading || userInput.length !== captchaLength"
        @click="verify"
      >
        Doğrula
      </button>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'

interface Props {
  className?: string
  captchaLength?: number
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
  captchaLength: 6
})

const emit = defineEmits(['verify', 'refresh'])

const canvasRef = ref<HTMLCanvasElement | null>(null)
const loading = ref(false)
const userInput = ref('')
const error = ref('')
const captchaText = ref('')

// Rastgele metin oluştur
const generateCaptchaText = () => {
  const chars = 'ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnpqrstuvwxyz23456789'
  let text = ''
  for (let i = 0; i < props.captchaLength; i++) {
    text += chars.charAt(Math.floor(Math.random() * chars.length))
  }
  return text
}

// Canvas'a captcha çiz
const drawCaptcha = () => {
  const canvas = canvasRef.value
  if (!canvas) return

  const ctx = canvas.getContext('2d')
  if (!ctx) return

  // Canvas boyutlarını ayarla
  canvas.width = canvas.offsetWidth
  canvas.height = canvas.offsetHeight

  // Arka planı temizle
  ctx.fillStyle = '#27272a' // zinc-800
  ctx.fillRect(0, 0, canvas.width, canvas.height)

  // Metni çiz
  ctx.font = 'bold 24px sans-serif'
  ctx.textAlign = 'center'
  ctx.textBaseline = 'middle'

  // Her karakteri farklı renk ve açıyla çiz
  const chars = captchaText.value.split('')
  const charWidth = canvas.width / (chars.length + 2)
  chars.forEach((char, i) => {
    ctx.save()
    ctx.translate(charWidth * (i + 1.5), canvas.height / 2)
    ctx.rotate((Math.random() - 0.5) * 0.4)
    ctx.fillStyle = `hsl(${Math.random() * 360}, 70%, 70%)`
    ctx.fillText(char, 0, 0)
    ctx.restore()
  })

  // Gürültü ekle
  for (let i = 0; i < 50; i++) {
    ctx.beginPath()
    ctx.arc(
      Math.random() * canvas.width,
      Math.random() * canvas.height,
      1,
      0,
      Math.PI * 2
    )
    ctx.fillStyle = `hsl(${Math.random() * 360}, 70%, 70%)`
    ctx.fill()
  }

  // Çizgiler ekle
  for (let i = 0; i < 3; i++) {
    ctx.beginPath()
    ctx.moveTo(Math.random() * canvas.width, Math.random() * canvas.height)
    ctx.lineTo(Math.random() * canvas.width, Math.random() * canvas.height)
    ctx.strokeStyle = `hsl(${Math.random() * 360}, 70%, 70%)`
    ctx.lineWidth = 1
    ctx.stroke()
  }
}

// Captcha'yı yenile
const refreshCaptcha = () => {
  loading.value = true
  error.value = ''
  userInput.value = ''

  // Yeni captcha oluştur
  captchaText.value = generateCaptchaText()

  // Kısa bir gecikme ekle
  setTimeout(() => {
    drawCaptcha()
    loading.value = false
    emit('refresh')
  }, 500)
}

// Kullanıcı girişini kontrol et
const handleInput = () => {
  error.value = ''
  userInput.value = userInput.value.slice(0, props.captchaLength)
}

// Doğrulama
const verify = () => {
  if (userInput.value.toLowerCase() === captchaText.value.toLowerCase()) {
    emit('verify', true)
    error.value = ''
  } else {
    emit('verify', false)
    error.value = 'Yanlış kod. Lütfen tekrar deneyin.'
    refreshCaptcha()
  }
}

// Bileşen yüklendiğinde ilk captcha'yı oluştur
onMounted(() => {
  refreshCaptcha()
})
</script> 