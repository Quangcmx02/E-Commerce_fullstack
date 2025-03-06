<template>
    <tbody :class="className">
        <tr v-for="item in items" :key="item.id">
            <slot name="row" :item="item">
                <td v-for="(value, key) in item" :key="key">{{ value }}</td>
            </slot>
        </tr>
    </tbody>
</template>

<script setup lang="ts">
export interface TableItem {
    id: number | string;
    [key: string]: any;
}

interface Props {
    items?: TableItem[];
    className?: string;
}

defineProps<Props>();

defineSlots<{
    row(props: { item: TableItem }): any;
}>();
</script> 