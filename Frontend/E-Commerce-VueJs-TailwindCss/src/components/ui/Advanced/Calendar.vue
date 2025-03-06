<template>
  <div class="space-y-4" :class="className">
    <!-- Takvim Başlığı -->
    <div class="flex items-center justify-between">
      <div class="flex items-center gap-4">
        <h2 class="text-lg font-medium text-white">
          {{ currentMonthYear }}
        </h2>
        <div class="flex items-center rounded-lg border border-zinc-800 bg-zinc-900">
          <button
            v-for="view in views"
            :key="view.value"
            class="px-3 py-1.5 text-sm"
            :class="[
              currentView === view.value
                ? 'bg-zinc-800 text-white'
                : 'text-zinc-400 hover:text-white'
            ]"
            @click="currentView = view.value"
          >
            {{ view.label }}
          </button>
        </div>
      </div>
      <div class="flex items-center gap-2">
        <button
          type="button"
          class="rounded-lg border border-zinc-800 bg-zinc-900 p-2 text-zinc-400 hover:text-white"
          @click="previousMonth"
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
              d="M15 19l-7-7 7-7"
            />
          </svg>
        </button>
        <button
          type="button"
          class="rounded-lg border border-zinc-800 bg-zinc-900 p-2 text-zinc-400 hover:text-white"
          @click="nextMonth"
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
              d="M9 5l7 7-7 7"
            />
          </svg>
        </button>
        <button
          type="button"
          class="rounded-lg bg-blue-600 px-4 py-2 text-sm font-medium text-white hover:bg-blue-700"
          @click="addEvent"
        >
          Etkinlik Ekle
        </button>
      </div>
    </div>

    <!-- Ay Görünümü -->
    <div v-if="currentView === 'month'" class="rounded-lg border border-zinc-800">
      <!-- Haftanın Günleri -->
      <div class="grid grid-cols-7 border-b border-zinc-800 bg-zinc-900">
        <div
          v-for="day in weekDays"
          :key="day"
          class="p-2 text-center text-sm font-medium text-zinc-400"
        >
          {{ day }}
        </div>
      </div>

      <!-- Takvim Günleri -->
      <div class="grid grid-cols-7">
        <div
          v-for="(day, index) in calendarDays"
          :key="index"
          class="min-h-[120px] border-b border-r border-zinc-800 p-2"
          :class="{
            'bg-zinc-900': !day.isCurrentMonth,
            'border-l': index % 7 === 0
          }"
        >
          <!-- Gün Başlığı -->
          <div class="flex items-center justify-between">
            <span
              class="text-sm"
              :class="[
                day.isToday
                  ? 'rounded-full bg-blue-600 px-2 py-0.5 text-white'
                  : day.isCurrentMonth
                  ? 'text-white'
                  : 'text-zinc-600'
              ]"
            >
              {{ day.date.getDate() }}
            </span>
            <button
              v-if="day.isCurrentMonth"
              type="button"
              class="text-zinc-400 hover:text-white"
              @click="addEvent(day.date)"
            >
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
                  d="M12 4v16m8-8H4"
                />
              </svg>
            </button>
          </div>

          <!-- Etkinlikler -->
          <div class="mt-1 space-y-1">
            <div
              v-for="event in getEventsForDate(day.date)"
              :key="event.id"
              class="cursor-pointer rounded px-1 py-0.5 text-xs"
              :class="event.color"
              @click="editEvent(event)"
            >
              {{ event.title }}
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Hafta Görünümü -->
    <div v-else-if="currentView === 'week'" class="rounded-lg border border-zinc-800">
      <!-- Saat Başlıkları -->
      <div class="grid grid-cols-8 border-b border-zinc-800 bg-zinc-900">
        <div class="p-2 text-center text-sm font-medium text-zinc-400">Saat</div>
        <div
          v-for="day in weekDays"
          :key="day"
          class="p-2 text-center text-sm font-medium text-zinc-400"
        >
          {{ day }}
        </div>
      </div>

      <!-- Saat Dilimleri -->
      <div class="divide-y divide-zinc-800">
        <div
          v-for="hour in hours"
          :key="hour"
          class="grid grid-cols-8"
        >
          <!-- Saat -->
          <div class="border-r border-zinc-800 p-2 text-center text-sm text-zinc-400">
            {{ formatHour(hour) }}
          </div>

          <!-- Günlük Zaman Dilimleri -->
          <div
            v-for="(day, index) in weekDates"
            :key="index"
            class="relative border-r border-zinc-800 p-2"
            :class="{ 'border-r-0': index === 6 }"
          >
            <!-- Etkinlikler -->
            <div
              v-for="event in getEventsForDateAndHour(day, hour)"
              :key="event.id"
              class="absolute left-0 right-0 m-1 cursor-pointer rounded px-2 py-1 text-xs"
              :class="event.color"
              :style="{
                top: `${getEventPosition(event)}%`,
                height: `${getEventHeight(event)}%`
              }"
              @click="editEvent(event)"
            >
              {{ event.title }}
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

interface Event {
  id: number
  title: string
  description?: string
  start: Date
  end: Date
  color: string
}

interface Props {
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  className: ''
})

const emit = defineEmits(['add-event', 'edit-event'])

// Görünüm seçenekleri
const views = [
  { label: 'Ay', value: 'month' },
  { label: 'Hafta', value: 'week' }
]

const currentView = ref('month')
const currentDate = ref(new Date())

// Haftanın günleri
const weekDays = ['Pzt', 'Sal', 'Çar', 'Per', 'Cum', 'Cmt', 'Paz']

// Saat dilimleri
const hours = Array.from({ length: 24 }, (_, i) => i)

// Örnek etkinlikler
const events = ref<Event[]>([
  {
    id: 1,
    title: 'Toplantı',
    description: 'Haftalık ekip toplantısı',
    start: new Date(2024, 2, 20, 10, 0),
    end: new Date(2024, 2, 20, 11, 30),
    color: 'bg-blue-500/20 text-blue-500'
  },
  {
    id: 2,
    title: 'Öğle Yemeği',
    start: new Date(2024, 2, 20, 12, 0),
    end: new Date(2024, 2, 20, 13, 0),
    color: 'bg-green-500/20 text-green-500'
  }
])

// Ay ve yıl başlığı
const currentMonthYear = computed(() => {
  return currentDate.value.toLocaleDateString('tr-TR', {
    month: 'long',
    year: 'numeric'
  })
})

// Takvim günlerini hesapla
const calendarDays = computed(() => {
  const year = currentDate.value.getFullYear()
  const month = currentDate.value.getMonth()
  const firstDay = new Date(year, month, 1)
  const lastDay = new Date(year, month + 1, 0)
  
  // Ayın ilk gününün haftanın hangi günü olduğunu bul (0: Pazar, 1: Pazartesi, ...)
  let firstDayOfWeek = firstDay.getDay()
  firstDayOfWeek = firstDayOfWeek === 0 ? 6 : firstDayOfWeek - 1 // Pazartesi'yi 0 yap
  
  const days = []
  
  // Önceki ayın günlerini ekle
  const prevMonth = new Date(year, month, 0)
  for (let i = firstDayOfWeek - 1; i >= 0; i--) {
    days.push({
      date: new Date(year, month - 1, prevMonth.getDate() - i),
      isCurrentMonth: false,
      isToday: false
    })
  }
  
  // Mevcut ayın günlerini ekle
  const today = new Date()
  for (let i = 1; i <= lastDay.getDate(); i++) {
    const date = new Date(year, month, i)
    days.push({
      date,
      isCurrentMonth: true,
      isToday:
        date.getDate() === today.getDate() &&
        date.getMonth() === today.getMonth() &&
        date.getFullYear() === today.getFullYear()
    })
  }
  
  // Sonraki ayın günlerini ekle
  const remainingDays = 42 - days.length // 6 satır x 7 gün
  for (let i = 1; i <= remainingDays; i++) {
    days.push({
      date: new Date(year, month + 1, i),
      isCurrentMonth: false,
      isToday: false
    })
  }
  
  return days
})

// Haftalık görünüm için tarihler
const weekDates = computed(() => {
  const dates = []
  const firstDayOfWeek = new Date(currentDate.value)
  const day = firstDayOfWeek.getDay()
  const diff = firstDayOfWeek.getDate() - day + (day === 0 ? -6 : 1)
  firstDayOfWeek.setDate(diff)
  
  for (let i = 0; i < 7; i++) {
    dates.push(new Date(firstDayOfWeek.getTime() + i * 24 * 60 * 60 * 1000))
  }
  
  return dates
})

// Navigasyon işlemleri
const previousMonth = () => {
  currentDate.value = new Date(
    currentDate.value.getFullYear(),
    currentDate.value.getMonth() - 1,
    1
  )
}

const nextMonth = () => {
  currentDate.value = new Date(
    currentDate.value.getFullYear(),
    currentDate.value.getMonth() + 1,
    1
  )
}

// Etkinlik işlemleri
const getEventsForDate = (date: Date) => {
  return events.value.filter(event => {
    const eventDate = new Date(event.start)
    return (
      eventDate.getDate() === date.getDate() &&
      eventDate.getMonth() === date.getMonth() &&
      eventDate.getFullYear() === date.getFullYear()
    )
  })
}

const getEventsForDateAndHour = (date: Date, hour: number) => {
  return events.value.filter(event => {
    const eventDate = new Date(event.start)
    return (
      eventDate.getDate() === date.getDate() &&
      eventDate.getMonth() === date.getMonth() &&
      eventDate.getFullYear() === date.getFullYear() &&
      eventDate.getHours() === hour
    )
  })
}

const getEventPosition = (event: Event) => {
  const minutes = event.start.getMinutes()
  return (minutes / 60) * 100
}

const getEventHeight = (event: Event) => {
  const duration = (event.end.getTime() - event.start.getTime()) / 1000 / 60 // dakika
  return (duration / 60) * 100
}

const addEvent = (date?: Date) => {
  emit('add-event', date)
}

const editEvent = (event: Event) => {
  emit('edit-event', event)
}

// Yardımcı fonksiyonlar
const formatHour = (hour: number) => {
  return `${hour.toString().padStart(2, '0')}:00`
}
</script> 