<template>
  <div class="space-y-4" :class="className">
    <!-- Gantt Başlığı -->
    <div class="flex items-center justify-between">
      <div class="flex items-center gap-4">
        <h2 class="text-lg font-medium text-white">Proje Zaman Çizelgesi</h2>
        <div class="flex items-center rounded-lg border border-zinc-800 bg-zinc-900">
          <button
            v-for="scale in timeScales"
            :key="scale.value"
            class="px-3 py-1.5 text-sm"
            :class="[
              currentScale === scale.value
                ? 'bg-zinc-800 text-white'
                : 'text-zinc-400 hover:text-white'
            ]"
            @click="currentScale = scale.value"
          >
            {{ scale.label }}
          </button>
        </div>
      </div>
      <div class="flex items-center gap-2">
        <button
          type="button"
          class="rounded-lg border border-zinc-800 bg-zinc-900 p-2 text-zinc-400 hover:text-white"
          @click="zoomOut"
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
              d="M20 12H4"
            />
          </svg>
        </button>
        <button
          type="button"
          class="rounded-lg border border-zinc-800 bg-zinc-900 p-2 text-zinc-400 hover:text-white"
          @click="zoomIn"
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
              d="M12 4v16m8-8H4"
            />
          </svg>
        </button>
        <button
          type="button"
          class="rounded-lg bg-blue-600 px-4 py-2 text-sm font-medium text-white hover:bg-blue-700"
          @click="addTask"
        >
          Görev Ekle
        </button>
      </div>
    </div>

    <!-- Gantt Şeması -->
    <div class="rounded-lg border border-zinc-800">
      <!-- Zaman Çizelgesi Başlığı -->
      <div class="grid border-b border-zinc-800 bg-zinc-900" :style="gridStyle">
        <div class="sticky left-0 w-64 border-r border-zinc-800 p-3">
          <h3 class="text-sm font-medium text-zinc-400">Görevler</h3>
        </div>
        <div class="overflow-hidden">
          <div class="flex">
            <div
              v-for="(period, index) in timePeriods"
              :key="index"
              class="flex-shrink-0 border-r border-zinc-800 p-3 text-center text-sm text-zinc-400"
              :style="{ width: `${columnWidth}px` }"
            >
              {{ formatPeriod(period) }}
            </div>
          </div>
        </div>
      </div>

      <!-- Görevler -->
      <div class="divide-y divide-zinc-800">
        <div
          v-for="task in tasks"
          :key="task.id"
          class="group relative grid hover:bg-zinc-900/50"
          :style="gridStyle"
        >
          <!-- Görev Bilgisi -->
          <div class="sticky left-0 flex w-64 items-center gap-2 border-r border-zinc-800 p-3">
            <button
              type="button"
              class="text-zinc-400 hover:text-white"
              @click="toggleSubtasks(task)"
              v-if="task.subtasks?.length"
            >
              <svg
                class="h-4 w-4 transition-transform"
                :class="{ 'rotate-90': task.expanded }"
                fill="none"
                viewBox="0 0 24 24"
                stroke="currentColor"
              >
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M9 5l7 7-7 7"
                />
              </svg>
            </button>
            <span
              class="flex-1 truncate text-sm"
              :class="[
                task.subtasks?.length ? 'font-medium text-white' : 'text-zinc-300'
              ]"
              :style="{ paddingLeft: `${task.level * 16}px` }"
            >
              {{ task.title }}
            </span>
          </div>

          <!-- Gantt Çubuğu -->
          <div class="relative">
            <div class="absolute inset-y-0 flex">
              <div
                v-for="(period, index) in timePeriods"
                :key="index"
                class="flex-shrink-0 border-r border-zinc-800"
                :style="{ width: `${columnWidth}px` }"
              />
            </div>
            <div
              v-if="task.start && task.end"
              class="absolute top-1/2 h-6 -translate-y-1/2 rounded"
              :class="[
                task.progress === 100
                  ? 'bg-green-500/20'
                  : task.progress > 0
                  ? 'bg-blue-500/20'
                  : 'bg-zinc-500/20'
              ]"
              :style="{
                left: `${getTaskStart(task)}px`,
                width: `${getTaskWidth(task)}px`
              }"
              @click="editTask(task)"
            >
              <!-- İlerleme Çubuğu -->
              <div
                class="absolute inset-y-0 rounded"
                :class="[
                  task.progress === 100
                    ? 'bg-green-500'
                    : task.progress > 0
                    ? 'bg-blue-500'
                    : 'bg-zinc-500'
                ]"
                :style="{ width: `${task.progress}%` }"
              />

              <!-- Bağımlılık Çizgileri -->
              <template v-if="task.dependencies">
                <svg
                  v-for="dep in task.dependencies"
                  :key="dep"
                  class="absolute -right-2 top-1/2 h-6 w-2 -translate-y-1/2"
                  viewBox="0 0 8 24"
                  fill="none"
                >
                  <path
                    d="M0 12H8"
                    stroke="currentColor"
                    stroke-width="2"
                  />
                </svg>
              </template>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

interface Task {
  id: number
  title: string
  start: Date
  end: Date
  progress: number
  level: number
  dependencies?: number[]
  subtasks?: Task[]
  expanded?: boolean
}

interface Props {
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  className: ''
})

const emit = defineEmits(['add-task', 'edit-task'])

// Zaman ölçeği seçenekleri
const timeScales = [
  { label: 'Gün', value: 'day' },
  { label: 'Hafta', value: 'week' },
  { label: 'Ay', value: 'month' }
]

const currentScale = ref('week')
const columnWidth = ref(100)

// Örnek görevler
const tasks = ref<Task[]>([
  {
    id: 1,
    title: 'Proje Planlaması',
    start: new Date(2024, 2, 1),
    end: new Date(2024, 2, 15),
    progress: 100,
    level: 0,
    subtasks: [
      {
        id: 2,
        title: 'Gereksinim Analizi',
        start: new Date(2024, 2, 1),
        end: new Date(2024, 2, 5),
        progress: 100,
        level: 1
      },
      {
        id: 3,
        title: 'Tasarım',
        start: new Date(2024, 2, 6),
        end: new Date(2024, 2, 10),
        progress: 100,
        level: 1,
        dependencies: [2]
      },
      {
        id: 4,
        title: 'Planlama',
        start: new Date(2024, 2, 11),
        end: new Date(2024, 2, 15),
        progress: 100,
        level: 1,
        dependencies: [3]
      }
    ],
    expanded: true
  },
  {
    id: 5,
    title: 'Geliştirme',
    start: new Date(2024, 2, 16),
    end: new Date(2024, 3, 15),
    progress: 50,
    level: 0,
    dependencies: [1],
    subtasks: [
      {
        id: 6,
        title: 'Frontend',
        start: new Date(2024, 2, 16),
        end: new Date(2024, 3, 5),
        progress: 70,
        level: 1
      },
      {
        id: 7,
        title: 'Backend',
        start: new Date(2024, 2, 16),
        end: new Date(2024, 3, 10),
        progress: 60,
        level: 1
      },
      {
        id: 8,
        title: 'Entegrasyon',
        start: new Date(2024, 3, 11),
        end: new Date(2024, 3, 15),
        progress: 0,
        level: 1,
        dependencies: [6, 7]
      }
    ],
    expanded: true
  }
])

// Zaman periyotlarını hesapla
const timePeriods = computed(() => {
  const periods: Date[] = []
  const start = new Date(2024, 2, 1)
  const end = new Date(2024, 3, 15)

  let current = new Date(start)
  while (current <= end) {
    periods.push(new Date(current))

    switch (currentScale.value) {
      case 'day':
        current.setDate(current.getDate() + 1)
        break
      case 'week':
        current.setDate(current.getDate() + 7)
        break
      case 'month':
        current.setMonth(current.getMonth() + 1)
        break
    }
  }

  return periods
})

// Grid stili
const gridStyle = computed(() => {
  return {
    display: 'grid',
    gridTemplateColumns: `256px 1fr`
  }
})

// Görev pozisyonu ve genişliği
const getTaskStart = (task: Task) => {
  const startDate = new Date(task.start)
  const firstDate = timePeriods.value[0]
  const diffTime = Math.abs(startDate.getTime() - firstDate.getTime())
  const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24))

  switch (currentScale.value) {
    case 'day':
      return diffDays * columnWidth.value
    case 'week':
      return (diffDays / 7) * columnWidth.value
    case 'month':
      return (diffDays / 30) * columnWidth.value
    default:
      return 0
  }
}

const getTaskWidth = (task: Task) => {
  const startDate = new Date(task.start)
  const endDate = new Date(task.end)
  const diffTime = Math.abs(endDate.getTime() - startDate.getTime())
  const diffDays = Math.ceil(diffTime / (1000 * 60 * 60 * 24))

  switch (currentScale.value) {
    case 'day':
      return diffDays * columnWidth.value
    case 'week':
      return (diffDays / 7) * columnWidth.value
    case 'month':
      return (diffDays / 30) * columnWidth.value
    default:
      return 0
  }
}

// Zoom işlemleri
const zoomIn = () => {
  columnWidth.value = Math.min(columnWidth.value + 20, 200)
}

const zoomOut = () => {
  columnWidth.value = Math.max(columnWidth.value - 20, 60)
}

// Alt görevleri aç/kapat
const toggleSubtasks = (task: Task) => {
  if (task.subtasks?.length) {
    task.expanded = !task.expanded
  }
}

// Görev işlemleri
const addTask = () => {
  emit('add-task')
}

const editTask = (task: Task) => {
  emit('edit-task', task)
}

// Yardımcı fonksiyonlar
const formatPeriod = (date: Date) => {
  switch (currentScale.value) {
    case 'day':
      return date.toLocaleDateString('tr-TR', { day: 'numeric' })
    case 'week':
      return `Hafta ${Math.ceil(date.getDate() / 7)}`
    case 'month':
      return date.toLocaleDateString('tr-TR', { month: 'short' })
    default:
      return ''
  }
}
</script> 