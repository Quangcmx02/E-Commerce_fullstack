<template>
  <div class="space-y-4" :class="className">
    <!-- Kanban Board -->
    <div class="flex gap-4 overflow-x-auto p-4">
      <!-- Sütunlar -->
      <div
        v-for="column in columns"
        :key="column.id"
        class="flex h-full w-80 shrink-0 flex-col rounded-lg border border-zinc-800 bg-zinc-900"
      >
        <!-- Sütun Başlığı -->
        <div class="flex items-center justify-between border-b border-zinc-800 p-3">
          <div class="flex items-center gap-2">
            <span
              class="h-2 w-2 rounded-full"
              :class="column.color"
            />
            <h3 class="text-sm font-medium text-white">{{ column.title }}</h3>
            <span class="rounded bg-zinc-800 px-2 py-0.5 text-xs text-zinc-400">
              {{ column.cards.length }}
            </span>
          </div>
          <button
            type="button"
            class="text-zinc-400 hover:text-white"
            @click="addCard(column.id)"
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
        </div>

        <!-- Kartlar -->
        <div
          class="flex-1 space-y-2 overflow-y-auto p-2"
          @dragover.prevent
          @drop="dropCard($event, column.id)"
        >
          <div
            v-for="card in column.cards"
            :key="card.id"
            class="rounded-lg border border-zinc-800 bg-zinc-800/50 p-3"
            draggable="true"
            @dragstart="dragCard($event, card, column.id)"
          >
            <!-- Kart İçeriği -->
            <div class="space-y-2">
              <div class="flex items-start justify-between gap-2">
                <h4 class="text-sm font-medium text-white">{{ card.title }}</h4>
                <div class="flex items-center gap-1">
                  <button
                    type="button"
                    class="text-zinc-400 hover:text-white"
                    @click="editCard(card)"
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
                        d="M15.232 5.232l3.536 3.536m-2.036-5.036a2.5 2.5 0 113.536 3.536L6.5 21.036H3v-3.572L16.732 3.732z"
                      />
                    </svg>
                  </button>
                  <button
                    type="button"
                    class="text-zinc-400 hover:text-red-500"
                    @click="deleteCard(card.id, column.id)"
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
                        d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16"
                      />
                    </svg>
                  </button>
                </div>
              </div>
              <p class="text-sm text-zinc-400">{{ card.description }}</p>
              <div class="flex items-center justify-between">
                <div class="flex -space-x-2">
                  <img
                    v-for="member in card.members"
                    :key="member.id"
                    :src="member.avatar"
                    :alt="member.name"
                    class="h-6 w-6 rounded-full border-2 border-zinc-900"
                    :title="member.name"
                  />
                </div>
                <span
                  v-if="card.dueDate"
                  class="text-xs text-zinc-400"
                >
                  {{ formatDate(card.dueDate) }}
                </span>
              </div>
              <div class="flex flex-wrap gap-1">
                <span
                  v-for="tag in card.tags"
                  :key="tag.id"
                  class="rounded-full px-2 py-0.5 text-xs"
                  :class="tag.color"
                >
                  {{ tag.name }}
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

interface Member {
  id: number
  name: string
  avatar: string
}

interface Tag {
  id: number
  name: string
  color: string
}

interface Card {
  id: number
  title: string
  description: string
  members: Member[]
  dueDate?: Date
  tags: Tag[]
}

interface Column {
  id: number
  title: string
  color: string
  cards: Card[]
}

interface Props {
  className?: string
}

const props = withDefaults(defineProps<Props>(), {
  className: ''
})

const emit = defineEmits(['update:columns'])

// Örnek veriler
const columns = ref<Column[]>([
  {
    id: 1,
    title: 'Yapılacak',
    color: 'bg-blue-500',
    cards: [
      {
        id: 1,
        title: 'Tasarım güncelleme',
        description: 'Ana sayfa tasarımını yenile',
        members: [
          {
            id: 1,
            name: 'John Doe',
            avatar: 'https://i.pravatar.cc/150?img=1'
          }
        ],
        dueDate: new Date('2024-03-20'),
        tags: [
          {
            id: 1,
            name: 'Tasarım',
            color: 'bg-purple-500/20 text-purple-500'
          }
        ]
      }
    ]
  },
  {
    id: 2,
    title: 'Devam Ediyor',
    color: 'bg-yellow-500',
    cards: []
  },
  {
    id: 3,
    title: 'Tamamlandı',
    color: 'bg-green-500',
    cards: []
  }
])

// Kart sürükleme işlemleri
const draggedCard = ref<{ card: Card; columnId: number } | null>(null)

const dragCard = (event: DragEvent, card: Card, columnId: number) => {
  draggedCard.value = { card, columnId }
}

const dropCard = (event: DragEvent, targetColumnId: number) => {
  if (!draggedCard.value) return

  const { card, columnId } = draggedCard.value
  if (columnId === targetColumnId) return

  // Kartı eski sütundan kaldır
  const sourceColumn = columns.value.find(col => col.id === columnId)
  if (sourceColumn) {
    sourceColumn.cards = sourceColumn.cards.filter(c => c.id !== card.id)
  }

  // Kartı yeni sütuna ekle
  const targetColumn = columns.value.find(col => col.id === targetColumnId)
  if (targetColumn) {
    targetColumn.cards.push(card)
  }

  draggedCard.value = null
  emit('update:columns', columns.value)
}

// Kart işlemleri
const addCard = (columnId: number) => {
  const column = columns.value.find(col => col.id === columnId)
  if (!column) return

  const newCard: Card = {
    id: Date.now(),
    title: 'Yeni Görev',
    description: 'Görev açıklaması',
    members: [],
    tags: []
  }

  column.cards.push(newCard)
  emit('update:columns', columns.value)
}

const editCard = (card: Card) => {
  // Kart düzenleme modalı açılabilir
  console.log('Edit card:', card)
}

const deleteCard = (cardId: number, columnId: number) => {
  const column = columns.value.find(col => col.id === columnId)
  if (!column) return

  column.cards = column.cards.filter(card => card.id !== cardId)
  emit('update:columns', columns.value)
}

// Yardımcı fonksiyonlar
const formatDate = (date: Date) => {
  return new Date(date).toLocaleDateString('tr-TR', {
    year: 'numeric',
    month: 'short',
    day: 'numeric'
  })
}
</script> 