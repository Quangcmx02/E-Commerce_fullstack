<template>
    <nav
        :class="['flex items-center justify-between', className]"
        role="navigation"
        aria-label="Pagination"
    >
        <!-- Mobile View -->
        <div class="flex flex-1 justify-between sm:hidden">
            <button
                :disabled="currentPage === 1"
                :class="[
                    'relative inline-flex items-center px-4 py-2 text-sm font-medium rounded-md transition-colors',
                    currentPage === 1
                        ? 'text-zinc-500 cursor-not-allowed'
                        : 'text-zinc-400 hover:text-white hover:bg-zinc-800'
                ]"
                @click="$emit('update:currentPage', currentPage - 1)"
            >
                Önceki
            </button>
            <button
                :disabled="currentPage === totalPages"
                :class="[
                    'relative inline-flex items-center px-4 py-2 text-sm font-medium rounded-md transition-colors',
                    currentPage === totalPages
                        ? 'text-zinc-500 cursor-not-allowed'
                        : 'text-zinc-400 hover:text-white hover:bg-zinc-800'
                ]"
                @click="$emit('update:currentPage', currentPage + 1)"
            >
                Sonraki
            </button>
        </div>

        <!-- Desktop View -->
        <div class="hidden sm:flex-1 sm:flex sm:items-center sm:justify-between">
            <!-- Page Info -->
            <div>
                <p class="text-sm text-zinc-400">
                    Toplam
                    <span class="font-medium text-white">{{ totalItems }}</span>
                    öğeden
                    <span class="font-medium text-white">{{ startIndex }}-{{ endIndex }}</span>
                    arası gösteriliyor
                </p>
            </div>

            <!-- Page Numbers -->
            <div>
                <div class="flex items-center space-x-2">
                    <!-- Previous Button -->
                    <button
                        :disabled="currentPage === 1"
                        :class="[
                            'relative inline-flex items-center p-2 rounded-md transition-colors',
                            currentPage === 1
                                ? 'text-zinc-500 cursor-not-allowed'
                                : 'text-zinc-400 hover:text-white hover:bg-zinc-800'
                        ]"
                        @click="$emit('update:currentPage', currentPage - 1)"
                    >
                        <span class="sr-only">Önceki</span>
                        <svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                            <path fill-rule="evenodd" d="M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 0z" clip-rule="evenodd" />
                        </svg>
                    </button>

                    <!-- Page Numbers -->
                    <template v-for="page in visiblePages" :key="page">
                        <button
                            v-if="page !== '...'"
                            :class="[
                                'relative inline-flex items-center px-4 py-2 text-sm font-medium rounded-md transition-colors',
                                page === currentPage
                                    ? 'bg-zinc-800 text-white'
                                    : 'text-zinc-400 hover:text-white hover:bg-zinc-800'
                            ]"
                            @click="$emit('update:currentPage', page)"
                        >
                            {{ page }}
                        </button>
                        <span
                            v-else
                            class="relative inline-flex items-center px-4 py-2 text-sm font-medium text-zinc-400"
                        >
                            ...
                        </span>
                    </template>

                    <!-- Next Button -->
                    <button
                        :disabled="currentPage === totalPages"
                        :class="[
                            'relative inline-flex items-center p-2 rounded-md transition-colors',
                            currentPage === totalPages
                                ? 'text-zinc-500 cursor-not-allowed'
                                : 'text-zinc-400 hover:text-white hover:bg-zinc-800'
                        ]"
                        @click="$emit('update:currentPage', currentPage + 1)"
                    >
                        <span class="sr-only">Sonraki</span>
                        <svg class="h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor">
                            <path fill-rule="evenodd" d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z" clip-rule="evenodd" />
                        </svg>
                    </button>
                </div>
            </div>
        </div>
    </nav>
</template>

<script setup lang="ts">
import { computed } from 'vue'

interface Props {
    currentPage: number
    totalItems: number
    perPage: number
    maxVisiblePages?: number
    className?: string
}

const props = withDefaults(defineProps<Props>(), {
    maxVisiblePages: 5
})

defineEmits<{
    (e: 'update:currentPage', page: number): void
}>()

const totalPages = computed(() => Math.ceil(props.totalItems / props.perPage))

const startIndex = computed(() => ((props.currentPage - 1) * props.perPage) + 1)
const endIndex = computed(() => Math.min(startIndex.value + props.perPage - 1, props.totalItems))

const visiblePages = computed(() => {
    const pages: (number | string)[] = []
    const maxPages = props.maxVisiblePages
    const total = totalPages.value
    const current = props.currentPage

    // Always show first page
    pages.push(1)

    if (total <= maxPages) {
        // Show all pages if total is less than max visible pages
        for (let i = 2; i <= total; i++) {
            pages.push(i)
        }
    } else {
        const leftSide = Math.floor(maxPages / 2)
        const rightSide = maxPages - leftSide - 1

        // If current page is close to start
        if (current <= leftSide + 1) {
            for (let i = 2; i <= maxPages - 1; i++) {
                pages.push(i)
            }
            pages.push('...')
            pages.push(total)
        }
        // If current page is close to end
        else if (current >= total - rightSide) {
            pages.push('...')
            for (let i = total - maxPages + 2; i < total; i++) {
                pages.push(i)
            }
            pages.push(total)
        }
        // If current page is in middle
        else {
            pages.push('...')
            for (let i = current - leftSide + 1; i <= current + rightSide - 1; i++) {
                pages.push(i)
            }
            pages.push('...')
            pages.push(total)
        }
    }

    return pages
})
</script> 