<template>
  <div class="space-y-4" :class="className">
    <!-- Grafik Başlığı -->
    <div v-if="title || description" class="space-y-1">
      <h3 v-if="title" class="text-lg font-medium text-white">{{ title }}</h3>
      <p v-if="description" class="text-sm text-zinc-400">{{ description }}</p>
    </div>

    <!-- Grafik Kontrolleri -->
    <div v-if="showControls" class="flex items-center gap-4">
      <!-- Grafik Tipi Seçimi -->
      <div class="flex items-center rounded-lg border border-zinc-800 bg-zinc-900">
        <button
          v-for="type in chartTypes"
          :key="type.value"
          class="px-3 py-1.5 text-sm"
          :class="[
            currentType === type.value
              ? 'bg-zinc-800 text-white'
              : 'text-zinc-400 hover:text-white'
          ]"
          @click="currentType = type.value"
        >
          {{ type.label }}
        </button>
      </div>

      <!-- Veri Aralığı -->
      <select
        v-if="showRange"
        v-model="currentRange"
        class="rounded-lg border border-zinc-800 bg-zinc-900 px-3 py-1.5 text-sm text-white"
      >
        <option
          v-for="range in ranges"
          :key="range.value"
          :value="range.value"
        >
          {{ range.label }}
        </option>
      </select>
    </div>

    <!-- Grafik Alanı -->
    <div
      class="relative h-[300px] rounded-lg border border-zinc-800 bg-zinc-900 p-4"
      ref="chartRef"
    >
      <!-- Yükleniyor -->
      <div
        v-if="loading"
        class="absolute inset-0 flex items-center justify-center bg-zinc-900/75"
      >
        <div class="h-8 w-8 animate-spin rounded-full border-4 border-zinc-600 border-t-white" />
      </div>

      <!-- Veri Yok -->
      <div
        v-else-if="!hasData"
        class="absolute inset-0 flex items-center justify-center"
      >
        <p class="text-sm text-zinc-400">Görüntülenecek veri yok</p>
      </div>

      <!-- Grafik -->
      <canvas
        v-else
        ref="canvasRef"
        class="h-full w-full"
      />
    </div>

    <!-- Grafik Açıklamaları -->
    <div
      v-if="showLegend && hasData"
      class="flex flex-wrap items-center gap-4"
    >
      <div
        v-for="(dataset, index) in chartData.datasets"
        :key="index"
        class="flex items-center gap-2"
      >
        <span
          class="h-3 w-3 rounded-full"
          :style="{ backgroundColor: dataset.borderColor }"
        />
        <span class="text-sm text-zinc-400">{{ dataset.label }}</span>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, onMounted, watch, computed } from 'vue'
import { Chart as ChartJS, registerables } from 'chart.js'

// Chart.js bileşenlerini kaydet
ChartJS.register(...registerables)

interface ChartDataset {
  label: string
  data: number[]
  borderColor?: string
  backgroundColor?: string
  borderWidth?: number
  fill?: boolean
}

interface ChartData {
  labels: string[]
  datasets: ChartDataset[]
}

interface Props {
  className?: string
  title?: string
  description?: string
  type?: 'line' | 'bar' | 'pie' | 'doughnut'
  data: ChartData
  options?: any
  showControls?: boolean
  showRange?: boolean
  showLegend?: boolean
  loading?: boolean
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
  type: 'line',
  showControls: true,
  showRange: true,
  showLegend: true,
  loading: false
})

const emit = defineEmits(['update:type', 'update:range'])

// Grafik referansları
const chartRef = ref<HTMLDivElement | null>(null)
const canvasRef = ref<HTMLCanvasElement | null>(null)
let chart: ChartJS | null = null

// Grafik tipleri
const chartTypes = [
  { label: 'Çizgi', value: 'line' },
  { label: 'Sütun', value: 'bar' },
  { label: 'Pasta', value: 'pie' },
  { label: 'Halka', value: 'doughnut' }
]

// Veri aralıkları
const ranges = [
  { label: 'Son 7 Gün', value: '7d' },
  { label: 'Son 30 Gün', value: '30d' },
  { label: 'Son 90 Gün', value: '90d' },
  { label: 'Son 1 Yıl', value: '1y' }
]

// Durum yönetimi
const currentType = ref(props.type)
const currentRange = ref('7d')
const hasData = computed(() => {
  return (
    props.data &&
    props.data.labels &&
    props.data.labels.length > 0 &&
    props.data.datasets &&
    props.data.datasets.length > 0
  )
})

// Grafik verisi
const chartData = computed(() => {
  return {
    labels: props.data.labels,
    datasets: props.data.datasets.map(dataset => ({
      ...dataset,
      borderColor: dataset.borderColor || getRandomColor(),
      backgroundColor: dataset.backgroundColor || (dataset.borderColor + '20') || (getRandomColor() + '20'),
      borderWidth: dataset.borderWidth || 2,
      fill: dataset.fill || false
    }))
  }
})

// Grafik seçenekleri
const chartOptions = computed(() => {
  return {
    responsive: true,
    maintainAspectRatio: false,
    plugins: {
      legend: {
        display: false
      }
    },
    scales: currentType.value === 'line' || currentType.value === 'bar'
      ? {
          y: {
            beginAtZero: true,
            grid: {
              color: '#27272a'
            },
            ticks: {
              color: '#71717a'
            }
          },
          x: {
            grid: {
              color: '#27272a'
            },
            ticks: {
              color: '#71717a'
            }
          }
        }
      : undefined,
    ...props.options
  }
})

// Grafik oluşturma/güncelleme
const createChart = () => {
  if (!canvasRef.value) return

  // Mevcut grafik varsa yok et
  if (chart) {
    chart.destroy()
  }

  // Yeni grafik oluştur
  const ctx = canvasRef.value.getContext('2d')
  if (!ctx) return

  chart = new ChartJS(ctx, {
    type: currentType.value,
    data: chartData.value,
    options: chartOptions.value
  })
}

// Yardımcı fonksiyonlar
const getRandomColor = () => {
  const letters = '0123456789ABCDEF'
  let color = '#'
  for (let i = 0; i < 6; i++) {
    color += letters[Math.floor(Math.random() * 16)]
  }
  return color
}

// İzleyiciler
watch(() => props.data, createChart, { deep: true })
watch(currentType, () => {
  emit('update:type', currentType.value)
  createChart()
})
watch(currentRange, () => {
  emit('update:range', currentRange.value)
})

// Yaşam döngüsü
onMounted(() => {
  if (hasData.value) {
    createChart()
  }
})
</script> 