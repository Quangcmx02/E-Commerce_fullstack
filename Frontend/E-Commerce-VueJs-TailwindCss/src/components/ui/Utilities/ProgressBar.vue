<template>
  <div class="space-y-2" :class="className">
    <!-- Başlık ve Değer -->
    <div v-if="label || showValue" class="flex items-center justify-between">
      <span v-if="label" class="text-sm font-medium text-white">{{ label }}</span>
      <span v-if="showValue" class="text-sm text-zinc-400">{{ value }}%</span>
    </div>

    <!-- İlerleme Çubuğu -->
    <div
      class="relative overflow-hidden rounded-full"
      :class="[
        size === 'sm' ? 'h-1' : size === 'md' ? 'h-2' : 'h-3',
        { 'bg-zinc-800': !background }
      ]"
      :style="background ? { backgroundColor: background } : {}"
    >
      <!-- Arka Plan Animasyonu -->
      <div
        v-if="indeterminate"
        class="absolute inset-0 rounded-full"
        :class="[color]"
      >
        <div class="absolute inset-0 animate-progress-indeterminate rounded-full bg-current" />
      </div>

      <!-- İlerleme -->
      <div
        v-else
        class="h-full rounded-full transition-all duration-300"
        :class="[
          color,
          { 'animate-pulse': pulse }
        ]"
        :style="{ width: `${value}%` }"
      />
    </div>

    <!-- Alt Metin -->
    <p v-if="description" class="text-xs text-zinc-400">{{ description }}</p>
  </div>
</template>

<script setup lang="ts">
interface Props {
  className?: string
  label?: string
  value?: number
  color?: string
  background?: string
  size?: 'sm' | 'md' | 'lg'
  showValue?: boolean
  description?: string
  indeterminate?: boolean
  pulse?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
  value: 0,
  color: 'bg-blue-500',
  size: 'md',
  showValue: false,
  indeterminate: false,
  pulse: false
})
</script>

<style>
@keyframes progress-indeterminate {
  0% {
    transform: translateX(-100%);
  }
  100% {
    transform: translateX(100%);
  }
}

.animate-progress-indeterminate {
  animation: progress-indeterminate 1.5s infinite linear;
}
</style> 