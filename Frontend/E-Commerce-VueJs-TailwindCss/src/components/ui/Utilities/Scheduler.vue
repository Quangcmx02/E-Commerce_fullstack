<template>
  <div class="space-y-4" :class="className">
    <!-- Scheduler Başlığı -->
    <div class="flex items-center justify-between">
      <div class="flex items-center gap-4">
        <h2 class="text-lg font-medium text-white">Zamanlayıcı</h2>
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
          @click="previousPeriod"
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
          @click="nextPeriod"
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

    <!-- Scheduler İçeriği -->
    <div class="rounded-lg border border-zinc-800">
      <!-- Günlük Görünüm -->
      <div v-if="currentView === 'day'" class="divide-y divide-zinc-800">
        <!-- Saat Dilimleri -->
        <div
          v-for="hour in hours"
          :key="hour"
          class="group relative grid grid-cols-[100px_1fr] hover:bg-zinc-900/50"
        >
          <!-- Saat -->
          <div class="border-r border-zinc-800 p-3 text-sm text-zinc-400">
            {{ formatHour(hour) }}
          </div>

          <!-- Etkinlikler -->
          <div class="relative min-h-[60px] p-1">
            <div
              v-for="event in getEventsForHour(hour)"
              :key="event.id"
              class="absolute left-0 right-0 m-1 cursor-pointer rounded px-2 py-1 text-xs"
              :class="event.color"
              :style="{
                top: `${getEventPosition(event)}%`,
                height: `${getEventHeight(event)}%`
              }"
              @click="editEvent(event)"
            >
              <div class="font-medium">{{ event.title }}</div>
              <div class="text-xs opacity-75">
                {{ formatEventTime(event) }}
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- Haftalık Görünüm -->
      <div v-else-if="currentView === 'week'" class="divide-y divide-zinc-800">
        <!-- Günler -->
        <div class="grid grid-cols-8 border-b border-zinc-800 bg-zinc-900">
          <div class="p-3 text-center text-sm font-medium text-zinc-400">Saat</div>
          <div
            v-for="day in weekDays"
            :key="day.date"
            class="p-3 text-center"
          >
            <div class="text-sm font-medium text-zinc-400">
              {{ formatWeekDay(day.date) }}
            </div>
            <div
              class="mt-1 text-sm"
              :class="[
                day.isToday ? 'text-blue-500' : 'text-zinc-300'
              ]"
            >
              {{ formatDayNumber(day.date) }}
            </div>
          </div>
        </div>

        <!-- Saat Dilimleri -->
        <div
          v-for="hour in hours"
          :key="hour"
          class="grid grid-cols-8"
        >
          <!-- Saat -->
          <div class="border-r border-zinc-800 p-3 text-center text-sm text-zinc-400">
            {{ formatHour(hour) }}
          </div>

          <!-- Günlük Zaman Dilimleri -->
          <div
            v-for="day in weekDays"
            :key="day.date"
            class="relative min-h-[60px] border-r border-zinc-800 p-1 last:border-r-0"
          >
            <!-- Etkinlikler -->
            <div
              v-for="event in getEventsForDayAndHour(day.date, hour)"
              :key="event.id"
              class="absolute left-0 right-0 m-1 cursor-pointer rounded px-2 py-1 text-xs"
              :class="event.color"
              :style="{
                top: `${getEventPosition(event)}%`,
                height: `${getEventHeight(event)}%`
              }"
              @click="editEvent(event)"
            >
              <div class="font-medium">{{ event.title }}</div>
              <div class="text-xs opacity-75">
                {{ formatEventTime(event) }}
              </div>
            </div>
          </div>
        </div>
      </div>

      <!-- Aylık Görünüm -->
      <div v-else class="divide-y divide-zinc-800">
        <!-- Günler -->
        <div class="grid grid-cols-7 border-b border-zinc-800 bg-zinc-900">
          <div
            v-for="day in weekDayNames"
            :key="day"
            class="p-3 text-center text-sm font-medium text-zinc-400"
          >
            {{ day }}
          </div>
        </div>

        <!-- Takvim -->
        <div class="grid grid-cols-7">
          <div
            v-for="day in monthDays"
            :key="day.date"
            class="min-h-[120px] border-b border-r border-zinc-800 p-2 last:border-r-0"
            :class="{
              'bg-zinc-900': !day.isCurrentMonth
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
  recurrence?: {
    type: 'daily' | 'weekly' | 'monthly'
    interval: number
    endDate?: Date
  }
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
  { label: 'Gün', value: 'day' },
  { label: 'Hafta', value: 'week' },
  { label: 'Ay', value: 'month' }
]

const currentView = ref('week')
const currentDate = ref(new Date())

// Saat dilimleri
const hours = Array.from({ length: 24 }, (_, i) => i)

// Haftanın günleri
const weekDayNames = ['Pzt', 'Sal', 'Çar', 'Per', 'Cum', 'Cmt', 'Paz']

// Örnek etkinlikler
const events = ref<Event[]>([
  {
    id: 1,
    title: 'Ekip Toplantısı',
    description: 'Haftalık ekip toplantısı',
    start: new Date(2024, 2, 20, 10, 0),
    end: new Date(2024, 2, 20, 11, 30),
    color: 'bg-blue-500/20 text-blue-500',
    recurrence: {
      type: 'weekly',
      interval: 1,
      endDate: new Date(2024, 5, 30)
    }
  },
  {
    id: 2,
    title: 'Öğle Yemeği',
    start: new Date(2024, 2, 20, 12, 0),
    end: new Date(2024, 2, 20, 13, 0),
    color: 'bg-green-500/20 text-green-500',
    recurrence: {
      type: 'daily',
      interval: 1
    }
  },
  {
    id: 3,
    title: 'Proje Değerlendirme',
    description: 'Aylık proje değerlendirme toplantısı',
    start: new Date(2024, 2, 25, 14, 0),
    end: new Date(2024, 2, 25, 16, 0),
    color: 'bg-purple-500/20 text-purple-500',
    recurrence: {
      type: 'monthly',
      interval: 1
    }
  }
])

// Haftalık görünüm için günler
const weekDays = computed(() => {
  const days = []
  const firstDayOfWeek = new Date(currentDate.value)
  const day = firstDayOfWeek.getDay()
  const diff = firstDayOfWeek.getDate() - day + (day === 0 ? -6 : 1)
  firstDayOfWeek.setDate(diff)

  for (let i = 0; i < 7; i++) {
    const date = new Date(firstDayOfWeek.getTime() + i * 24 * 60 * 60 * 1000)
    days.push({
      date,
      isToday: isToday(date)
    })
  }

  return days
})

// Aylık görünüm için günler
const monthDays = computed(() => {
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
    const date = new Date(year, month - 1, prevMonth.getDate() - i)
    days.push({
      date,
      isCurrentMonth: false,
      isToday: isToday(date)
    })
  }

  // Mevcut ayın günlerini ekle
  for (let i = 1; i <= lastDay.getDate(); i++) {
    const date = new Date(year, month, i)
    days.push({
      date,
      isCurrentMonth: true,
      isToday: isToday(date)
    })
  }

  // Sonraki ayın günlerini ekle
  const remainingDays = 42 - days.length // 6 satır x 7 gün
  for (let i = 1; i <= remainingDays; i++) {
    const date = new Date(year, month + 1, i)
    days.push({
      date,
      isCurrentMonth: false,
      isToday: isToday(date)
    })
  }

  return days
})

// Navigasyon işlemleri
const previousPeriod = () => {
  const date = new Date(currentDate.value)
  switch (currentView.value) {
    case 'day':
      date.setDate(date.getDate() - 1)
      break
    case 'week':
      date.setDate(date.getDate() - 7)
      break
    case 'month':
      date.setMonth(date.getMonth() - 1)
      break
  }
  currentDate.value = date
}

const nextPeriod = () => {
  const date = new Date(currentDate.value)
  switch (currentView.value) {
    case 'day':
      date.setDate(date.getDate() + 1)
      break
    case 'week':
      date.setDate(date.getDate() + 7)
      break
    case 'month':
      date.setMonth(date.getMonth() + 1)
      break
  }
  currentDate.value = date
}

// Etkinlik işlemleri
const getEventsForHour = (hour: number) => {
  return getAllEvents().filter(event => {
    const eventDate = new Date(event.start)
    return (
      eventDate.getDate() === currentDate.value.getDate() &&
      eventDate.getMonth() === currentDate.value.getMonth() &&
      eventDate.getFullYear() === currentDate.value.getFullYear() &&
      eventDate.getHours() === hour
    )
  })
}

const getEventsForDayAndHour = (date: Date, hour: number) => {
  return getAllEvents().filter(event => {
    const eventDate = new Date(event.start)
    return (
      eventDate.getDate() === date.getDate() &&
      eventDate.getMonth() === date.getMonth() &&
      eventDate.getFullYear() === date.getFullYear() &&
      eventDate.getHours() === hour
    )
  })
}

const getEventsForDate = (date: Date) => {
  return getAllEvents().filter(event => {
    const eventDate = new Date(event.start)
    return (
      eventDate.getDate() === date.getDate() &&
      eventDate.getMonth() === date.getMonth() &&
      eventDate.getFullYear() === date.getFullYear()
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

// Tekrarlayan etkinlikleri hesapla
const getAllEvents = () => {
  const allEvents: Event[] = []

  events.value.forEach(event => {
    // Orijinal etkinliği ekle
    allEvents.push(event)

    // Tekrarlayan etkinlikleri ekle
    if (event.recurrence) {
      const { type, interval, endDate } = event.recurrence
      let currentDate = new Date(event.start)
      const maxDate = endDate || new Date(2024, 11, 31) // Varsayılan bitiş tarihi

      while (currentDate <= maxDate) {
        const newStart = new Date(currentDate)
        const newEnd = new Date(
          newStart.getTime() + (event.end.getTime() - event.start.getTime())
        )

        // Bir sonraki tekrar tarihini hesapla
        switch (type) {
          case 'daily':
            currentDate.setDate(currentDate.getDate() + interval)
            break
          case 'weekly':
            currentDate.setDate(currentDate.getDate() + interval * 7)
            break
          case 'monthly':
            currentDate.setMonth(currentDate.getMonth() + interval)
            break
        }

        // Yeni etkinliği ekle
        if (currentDate <= maxDate) {
          allEvents.push({
            ...event,
            id: event.id + currentDate.getTime(),
            start: newStart,
            end: newEnd
          })
        }
      }
    }
  })

  return allEvents
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

const formatWeekDay = (date: Date) => {
  return weekDayNames[date.getDay() === 0 ? 6 : date.getDay() - 1]
}

const formatDayNumber = (date: Date) => {
  return date.getDate()
}

const formatEventTime = (event: Event) => {
  const start = event.start.toLocaleTimeString('tr-TR', {
    hour: '2-digit',
    minute: '2-digit'
  })
  const end = event.end.toLocaleTimeString('tr-TR', {
    hour: '2-digit',
    minute: '2-digit'
  })
  return `${start} - ${end}`
}

const isToday = (date: Date) => {
  const today = new Date()
  return (
    date.getDate() === today.getDate() &&
    date.getMonth() === today.getMonth() &&
    date.getFullYear() === today.getFullYear()
  )
}
</script> 