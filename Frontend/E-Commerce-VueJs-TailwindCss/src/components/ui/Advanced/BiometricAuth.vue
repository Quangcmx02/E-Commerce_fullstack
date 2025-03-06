<template>
  <div class="rounded-lg border border-zinc-800 bg-zinc-900 p-6" :class="className">
    <div class="space-y-6">
      <!-- Başlık -->
      <div class="text-center">
        <h3 class="text-lg font-medium text-white">Biyometrik Kimlik Doğrulama</h3>
        <p class="mt-1 text-sm text-zinc-400">
          {{ isAvailable ? 'Parmak izi veya yüz tanıma ile giriş yapın' : 'Biyometrik kimlik doğrulama kullanılamıyor' }}
        </p>
      </div>

      <!-- İkon -->
      <div class="flex justify-center">
        <div
          class="relative flex h-24 w-24 items-center justify-center rounded-full bg-zinc-800"
          :class="{ 'animate-pulse': authenticating }"
        >
          <svg
            v-if="type === 'fingerprint'"
            class="h-12 w-12 text-zinc-400"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M12 11c0 3.517-1.009 6.799-2.753 9.571m-3.44-2.04l.054-.09A13.916 13.916 0 008 11a4 4 0 118 0c0 1.017-.07 2.019-.203 3m-2.118 6.844A21.88 21.88 0 0015.171 17m3.839 1.132c.645-2.266.99-4.659.99-7.132A8 8 0 008 4.07M3 15.364c.64-1.319 1-2.8 1-4.364 0-1.457.39-2.823 1.07-4"
            />
          </svg>
          <svg
            v-else-if="type === 'face'"
            class="h-12 w-12 text-zinc-400"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M8 7a4 4 0 100 8 4 4 0 000-8zM8 11a2 2 0 100-4 2 2 0 000 4z"
            />
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M16 7a4 4 0 100 8 4 4 0 000-8zM16 11a2 2 0 100-4 2 2 0 000 4z"
            />
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M12 17c3.866 0 7-3.134 7-7s-3.134-7-7-7-7 3.134-7 7 3.134 7 7 7z"
            />
          </svg>
          <svg
            v-else
            class="h-12 w-12 text-zinc-400"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z"
            />
          </svg>

          <!-- Başarılı/Başarısız İkonları -->
          <div
            v-if="showResult"
            class="absolute -right-2 -top-2 rounded-full bg-zinc-900 p-1"
          >
            <svg
              v-if="isSuccess"
              class="h-6 w-6 text-green-500"
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
              class="h-6 w-6 text-red-500"
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
          </div>
        </div>
      </div>

      <!-- Durum Mesajı -->
      <div class="text-center">
        <p
          class="text-sm"
          :class="{
            'text-green-500': isSuccess,
            'text-red-500': !isSuccess && showResult,
            'text-zinc-400': !showResult
          }"
        >
          {{ statusMessage }}
        </p>
      </div>

      <!-- Butonlar -->
      <div class="space-y-3">
        <button
          type="button"
          class="w-full rounded-lg bg-blue-600 px-4 py-2 text-sm font-medium text-white hover:bg-blue-700 disabled:cursor-not-allowed disabled:opacity-50"
          :disabled="!isAvailable || authenticating"
          @click="authenticate"
        >
          {{ authenticating ? 'Doğrulanıyor...' : 'Biyometrik Doğrulama' }}
        </button>
        <button
          type="button"
          class="w-full rounded-lg bg-zinc-800 px-4 py-2 text-sm font-medium text-white hover:bg-zinc-700"
          @click="$emit('cancel')"
        >
          Alternatif Yöntem
        </button>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'

interface Props {
  className?: string
  type?: 'fingerprint' | 'face' | 'other'
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
  type: 'fingerprint'
})

const emit = defineEmits(['success', 'error', 'cancel'])

const isAvailable = ref(false)
const authenticating = ref(false)
const showResult = ref(false)
const isSuccess = ref(false)
const statusMessage = ref('Biyometrik kimlik doğrulama bekleniyor')

// Biyometrik kimlik doğrulama kullanılabilirliğini kontrol et
const checkAvailability = async () => {
  try {
    // Web Authentication API kontrolü
    if (window.PublicKeyCredential) {
      const available = await PublicKeyCredential.isUserVerifyingPlatformAuthenticatorAvailable()
      isAvailable.value = available
      if (!available) {
        statusMessage.value = 'Biyometrik kimlik doğrulama desteklenmiyor'
      }
    } else {
      isAvailable.value = false
      statusMessage.value = 'Biyometrik kimlik doğrulama desteklenmiyor'
    }
  } catch (error) {
    isAvailable.value = false
    statusMessage.value = 'Biyometrik kimlik doğrulama kullanılamıyor'
  }
}

// Biyometrik kimlik doğrulama işlemi
const authenticate = async () => {
  authenticating.value = true
  showResult.value = false
  statusMessage.value = 'Biyometrik kimlik doğrulanıyor...'

  try {
    // Simüle edilmiş biyometrik doğrulama
    await new Promise(resolve => setTimeout(resolve, 2000))

    // Başarılı
    isSuccess.value = true
    statusMessage.value = 'Kimlik doğrulama başarılı'
    emit('success')
  } catch (error) {
    // Başarısız
    isSuccess.value = false
    statusMessage.value = 'Kimlik doğrulama başarısız'
    emit('error', error)
  } finally {
    authenticating.value = false
    showResult.value = true
  }
}

onMounted(() => {
  checkAvailability()
})
</script> 