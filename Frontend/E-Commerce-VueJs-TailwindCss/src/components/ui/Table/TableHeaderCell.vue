<template>
    <th
        :class="[
            'px-4 py-2 text-left font-medium text-zinc-400',
            sortable && 'cursor-pointer select-none',
            className
        ]"
        @click="handleSort"
    >
        <div class="flex items-center gap-2">
            <slot></slot>
            <div v-if="sortable" class="flex flex-col">
                <svg xmlns="http://www.w3.org/2000/svg" width="12" height="12" viewBox="0 0 24 24" fill="none" 
                    :stroke="sortDirection === 'asc' ? '#fff' : 'currentColor'" 
                    stroke-width="2" stroke-linecap="round" stroke-linejoin="round" 
                    class="feather feather-chevron-up">
                    <polyline points="18 15 12 9 6 15"></polyline>
                </svg>
                <svg xmlns="http://www.w3.org/2000/svg" width="12" height="12" viewBox="0 0 24 24" fill="none" 
                    :stroke="sortDirection === 'desc' ? '#fff' : 'currentColor'" 
                    stroke-width="2" stroke-linecap="round" stroke-linejoin="round" 
                    class="feather feather-chevron-down">
                    <polyline points="6 9 12 15 18 9"></polyline>
                </svg>
            </div>
        </div>
    </th>
</template>

<script setup lang="ts">
type SortDirection = 'asc' | 'desc' | null;

interface Props {
    sortable?: boolean;
    sortDirection?: SortDirection;
    className?: string;
}

const props = withDefaults(defineProps<Props>(), {
    sortable: false,
    sortDirection: null
});

const emit = defineEmits<{
    (e: 'sort'): void;
}>();

const handleSort = () => {
    if (props.sortable) {
        emit('sort');
    }
};
</script> 