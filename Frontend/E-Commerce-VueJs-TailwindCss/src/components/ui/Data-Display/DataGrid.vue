<template>
    <div :class="className">
        <!-- Üst Araç Çubuğu -->
        <div class="mb-4 flex items-center justify-between">
            <!-- Arama -->
            <div class="flex items-center space-x-2">
                <input v-model="searchQuery" type="text" class="rounded-lg bg-zinc-800 px-3 py-1.5 text-sm text-white placeholder-zinc-400 focus:outline-none focus:ring-2 focus:ring-blue-500" :placeholder="searchPlaceholder" />
            </div>

            <!-- Sayfa Boyutu -->
            <div class="flex items-center space-x-2">
                <span class="text-sm text-zinc-400">Sayfa başına:</span>
                <select v-model="pageSize" class="rounded-lg bg-zinc-800 px-2 py-1.5 text-sm text-white focus:outline-none focus:ring-2 focus:ring-blue-500">
                    <option v-for="size in pageSizes" :key="size" :value="size">
                        {{ size }}
                    </option>
                </select>
            </div>
        </div>

        <!-- Tablo -->
        <div class="relative overflow-x-auto rounded-lg border border-zinc-800">
            <table class="w-full text-left text-sm">
                <thead class="bg-zinc-800 text-xs uppercase text-zinc-400">
                    <tr>
                        <!-- Seçim Sütunu -->
                        <th v-if="selectable" class="w-4 px-4 py-3">
                            <input type="checkbox" :checked="isAllSelected" :indeterminate="isIndeterminate" @change="toggleSelectAll" class="rounded border-zinc-600 bg-zinc-700 text-blue-500 focus:ring-blue-500" />
                        </th>

                        <!-- Sütun Başlıkları -->
                        <th v-for="column in columns" :key="column.field" class="px-4 py-3 font-medium" :class="{ 'cursor-pointer select-none': column.sortable }" @click="column.sortable && handleSort(column.field)">
                            <div class="flex items-center space-x-1">
                                <span>{{ column.header }}</span>
                                <span v-if="column.sortable" class="text-zinc-500">
                                    <svg v-if="sortField === column.field" class="h-4 w-4" :class="{ 'rotate-180': sortDirection === 'desc' }" viewBox="0 0 20 20" fill="currentColor">
                                        <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd" />
                                    </svg>
                                    <svg v-else class="h-4 w-4 text-zinc-600" viewBox="0 0 20 20" fill="currentColor">
                                        <path fill-rule="evenodd" d="M10 3a1 1 0 01.707.293l3 3a1 1 0 01-1.414 1.414L10 5.414 7.707 7.707a1 1 0 01-1.414-1.414l3-3A1 1 0 0110 3zm-3.707 9.293a1 1 0 011.414 0L10 14.586l2.293-2.293a1 1 0 011.414 1.414l-3 3a1 1 0 01-1.414 0l-3-3a1 1 0 010-1.414z" clip-rule="evenodd" />
                                    </svg>
                                </span>
                            </div>
                        </th>

                        <!-- İşlemler Sütunu -->
                        <th v-if="actions" class="w-24 px-4 py-3">
                            <span>İşlemler</span>
                        </th>
                    </tr>
                </thead>

                <tbody class="divide-y divide-zinc-800">
                    <tr v-for="(row, index) in paginatedRows" :key="row.id" class="bg-zinc-900 hover:bg-zinc-800/50">
                        <!-- Seçim Hücresi -->
                        <td v-if="selectable" class="w-4 px-4 py-3">
                            <input type="checkbox" :checked="selectedRows.includes(row.id)" @change="toggleSelectRow(row.id)" class="rounded border-zinc-600 bg-zinc-700 text-blue-500 focus:ring-blue-500" />
                        </td>

                        <!-- Veri Hücreleri -->
                        <td v-for="column in columns" :key="column.field" class="px-4 py-3 text-white">
                            <component v-if="column.cellRenderer" :is="column.cellRenderer" :value="row[column.field]" :row="row" :field="column.field" />
                            <template v-else>{{ row[column.field] }}</template>
                        </td>

                        <!-- İşlem Hücreleri -->
                        <td v-if="actions" class="px-4 py-3">
                            <div class="flex items-center space-x-2">
                                <slot name="actions" :row="row" :index="index" />
                            </div>
                        </td>
                    </tr>

                    <!-- Veri Yok -->
                    <tr v-if="paginatedRows.length === 0">
                        <td :colspan="columnCount" class="px-4 py-8 text-center text-sm text-zinc-400">
                            {{ emptyMessage }}
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

        <!-- Alt Araç Çubuğu -->
        <div class="mt-4 flex items-center justify-between">
            <!-- Seçim Bilgisi -->
            <div v-if="selectable" class="text-sm text-zinc-400">{{ selectedRows.length }} öğe seçildi</div>

            <!-- Sayfalama -->
            <div class="flex items-center space-x-2">
                <button :disabled="currentPage === 1" @click="currentPage--" class="rounded-lg bg-zinc-800 px-3 py-1.5 text-sm text-white hover:bg-zinc-700 disabled:opacity-50">Önceki</button>
                <span class="text-sm text-zinc-400">Sayfa {{ currentPage }} / {{ totalPages }}</span>
                <button :disabled="currentPage === totalPages" @click="currentPage++" class="rounded-lg bg-zinc-800 px-3 py-1.5 text-sm text-white hover:bg-zinc-700 disabled:opacity-50">Sonraki</button>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed, watch } from "vue";
import type { Component } from "vue";

interface Column {
    field: string;
    header: string;
    sortable?: boolean;
    cellRenderer?: Component;
}

interface Props {
    className?: string;
    columns: Column[];
    rows: any[];
    selectable?: boolean;
    actions?: boolean;
    pageSizes?: number[];
    defaultPageSize?: number;
    searchPlaceholder?: string;
    emptyMessage?: string;
}

const props = withDefaults(defineProps<Props>(), {
    className: "",
    selectable: false,
    actions: false,
    pageSizes: () => [10, 25, 50, 100],
    defaultPageSize: 10,
    searchPlaceholder: "Ara...",
    emptyMessage: "Veri bulunamadı.",
});

const emit = defineEmits<{
    (e: "sort", field: string, direction: "asc" | "desc"): void;
    (e: "select", selectedIds: any[]): void;
    (e: "search", query: string): void;
    (e: "page-change", page: number): void;
    (e: "page-size-change", size: number): void;
}>();

// Durum yönetimi
const searchQuery = ref("");
const sortField = ref("");
const sortDirection = ref<"asc" | "desc">("asc");
const selectedRows = ref<any[]>([]);
const currentPage = ref(1);
const pageSize = ref(props.defaultPageSize);

// Hesaplanan özellikler
const columnCount = computed(() => {
    let count = props.columns.length;
    if (props.selectable) count++;
    if (props.actions) count++;
    return count;
});

const filteredRows = computed(() => {
    let result = [...props.rows];

    // Arama
    if (searchQuery.value) {
        const query = searchQuery.value.toLowerCase();
        result = result.filter((row) => Object.values(row).some((value) => value && value.toString().toLowerCase().includes(query)));
    }

    // Sıralama
    if (sortField.value) {
        result.sort((a, b) => {
            const aVal = a[sortField.value];
            const bVal = b[sortField.value];

            if (aVal === bVal) return 0;

            const comparison = aVal > bVal ? 1 : -1;
            return sortDirection.value === "asc" ? comparison : -comparison;
        });
    }

    return result;
});

const totalPages = computed(() => Math.ceil(filteredRows.value.length / pageSize.value));

const paginatedRows = computed(() => {
    const start = (currentPage.value - 1) * pageSize.value;
    const end = start + pageSize.value;
    return filteredRows.value.slice(start, end);
});

const isAllSelected = computed(() => filteredRows.value.length > 0 && filteredRows.value.every((row) => selectedRows.value.includes(row.id)));

const isIndeterminate = computed(() => selectedRows.value.length > 0 && !isAllSelected.value);

// Olay işleyicileri
const handleSort = (field: string) => {
    if (sortField.value === field) {
        sortDirection.value = sortDirection.value === "asc" ? "desc" : "asc";
    } else {
        sortField.value = field;
        sortDirection.value = "asc";
    }
    emit("sort", field, sortDirection.value);
};

const toggleSelectAll = () => {
    if (isAllSelected.value) {
        selectedRows.value = [];
    } else {
        selectedRows.value = filteredRows.value.map((row) => row.id);
    }
    emit("select", selectedRows.value);
};

const toggleSelectRow = (id: any) => {
    const index = selectedRows.value.indexOf(id);
    if (index === -1) {
        selectedRows.value.push(id);
    } else {
        selectedRows.value.splice(index, 1);
    }
    emit("select", selectedRows.value);
};

// İzleyiciler
watch(searchQuery, (value) => {
    currentPage.value = 1;
    emit("search", value);
});

watch(pageSize, (value) => {
    currentPage.value = 1;
    emit("page-size-change", value);
});

watch(currentPage, (value) => {
    emit("page-change", value);
});
</script>
