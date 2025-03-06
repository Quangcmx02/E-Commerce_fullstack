<template>
    <nav :class="['flex', className]" aria-label="Breadcrumb">
        <ol class="flex items-center space-x-2">
            <slot />
        </ol>
    </nav>
</template>

<script setup lang="ts">
defineProps<{
    className?: string
}>()
</script>

<script lang="ts">
export interface BreadcrumbItem {
    label: string
    to?: string
    active?: boolean
}
</script> 