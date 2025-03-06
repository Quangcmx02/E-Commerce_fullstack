<template>
    <li class="flex items-center">
        <!-- Separator -->
        <template v-if="!first">
            <svg class="w-5 h-5 text-zinc-400 mx-2" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M9 5l7 7-7 7" />
            </svg>
        </template>

        <!-- Link or Text -->
        <template v-if="to && !active">
            <a :href="to" :class="['text-sm font-medium text-zinc-400 hover:text-white transition-colors', className]">
                <slot>{{ label }}</slot>
            </a>
        </template>
        <template v-else>
            <span :class="['text-sm font-medium', active ? 'text-white' : 'text-zinc-400', className]">
                <slot>{{ label }}</slot>
            </span>
        </template>
    </li>
</template>

<script setup lang="ts">
interface Props {
    label?: string
    to?: string
    active?: boolean
    first?: boolean
    className?: string
}

defineProps<Props>()
</script> 