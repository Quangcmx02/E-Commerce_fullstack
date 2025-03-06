<template>
    <div :class="className">
        <TreeNode v-for="node in nodes" :key="node.id" :node="node" :selected-ids="selectedIds" :expanded-ids="expandedIds" :icon-size="iconSize" :indent-size="indentSize" @toggle="handleToggle" @select="handleSelect" />
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import type { Component } from "vue";

interface TreeNode {
    id: string | number;
    label: string;
    icon?: Component;
    iconColor?: string;
    children?: TreeNode[];
    data?: any;
}

interface Props {
    className?: string;
    nodes: TreeNode[];
    iconSize?: "sm" | "md" | "lg";
    indentSize?: "sm" | "md" | "lg";
    defaultExpanded?: boolean;
    defaultSelected?: (string | number)[];
}

const props = withDefaults(defineProps<Props>(), {
    className: "",
    iconSize: "md",
    indentSize: "md",
    defaultExpanded: false,
    defaultSelected: () => [],
});

const emit = defineEmits<{
    (e: "select", nodeIds: (string | number)[]): void;
    (e: "toggle", nodeId: string | number, expanded: boolean): void;
}>();

// Durum yönetimi
const selectedIds = ref<(string | number)[]>(props.defaultSelected);
const expandedIds = ref<(string | number)[]>([]);

// Başlangıçta tüm düğümleri genişlet
if (props.defaultExpanded) {
    const getAllNodeIds = (nodes: TreeNode[]): (string | number)[] => {
        return nodes.reduce(
            (acc, node) => {
                acc.push(node.id);
                if (node.children?.length) {
                    acc.push(...getAllNodeIds(node.children));
                }
                return acc;
            },
            [] as (string | number)[]
        );
    };
    expandedIds.value = getAllNodeIds(props.nodes);
}

// Olay işleyicileri
const handleToggle = (nodeId: string | number) => {
    const index = expandedIds.value.indexOf(nodeId);
    if (index === -1) {
        expandedIds.value.push(nodeId);
        emit("toggle", nodeId, true);
    } else {
        expandedIds.value.splice(index, 1);
        emit("toggle", nodeId, false);
    }
};

const handleSelect = (nodeId: string | number) => {
    const index = selectedIds.value.indexOf(nodeId);
    if (index === -1) {
        selectedIds.value.push(nodeId);
    } else {
        selectedIds.value.splice(index, 1);
    }
    emit("select", selectedIds.value);
};
</script>

<script lang="ts">
// TreeNode alt bileşeni
export default {
    name: "TreeNode",
    props: {
        node: {
            type: Object,
            required: true,
        },
        selectedIds: {
            type: Array,
            required: true,
        },
        expandedIds: {
            type: Array,
            required: true,
        },
        iconSize: {
            type: String,
            default: "md",
        },
        indentSize: {
            type: String,
            default: "md",
        },
        level: {
            type: Number,
            default: 0,
        },
    },
    emits: ["toggle", "select"],
    setup(props, { emit }) {
        const isExpanded = computed(() => props.expandedIds.includes(props.node.id));
        const isSelected = computed(() => props.selectedIds.includes(props.node.id));
        const hasChildren = computed(() => props.node.children?.length > 0);

        const indentClass = computed(() => {
            const sizes = {
                sm: "pl-4",
                md: "pl-6",
                lg: "pl-8",
            };
            return sizes[props.indentSize] || sizes.md;
        });

        const iconClass = computed(() => {
            const sizes = {
                sm: "h-4 w-4",
                md: "h-5 w-5",
                lg: "h-6 w-6",
            };
            return sizes[props.iconSize] || sizes.md;
        });

        return {
            isExpanded,
            isSelected,
            hasChildren,
            indentClass,
            iconClass,
            handleToggle: () => emit("toggle", props.node.id),
            handleSelect: () => emit("select", props.node.id),
        };
    },
    template: `
    <div :class="['relative', level > 0 ? indentClass : '']">
      <div
        class="group flex items-center py-1 px-2 hover:bg-zinc-800/50 rounded-lg cursor-pointer"
        :class="{ 'bg-zinc-800': isSelected }"
        @click="handleSelect"
      >
        <!-- Genişletme/Daraltma İkonu -->
        <button
          v-if="hasChildren"
          class="mr-1 p-0.5 rounded hover:bg-zinc-700"
          @click.stop="handleToggle"
        >
          <svg
            class="transition-transform"
            :class="[iconClass, isExpanded ? 'rotate-90' : '']"
            viewBox="0 0 20 20"
            fill="currentColor"
          >
            <path
              fill-rule="evenodd"
              d="M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z"
              clip-rule="evenodd"
            />
          </svg>
        </button>

        <!-- Öğe İkonu -->
        <component
          v-if="node.icon"
          :is="node.icon"
          :class="[iconClass, node.iconColor || 'text-zinc-400']"
        />

        <!-- Etiket -->
        <span class="ml-2 text-sm text-white">{{ node.label }}</span>
      </div>

      <!-- Alt Öğeler -->
      <div v-if="hasChildren && isExpanded">
        <TreeNode
          v-for="child in node.children"
          :key="child.id"
          :node="child"
          :selected-ids="selectedIds"
          :expanded-ids="expandedIds"
          :icon-size="iconSize"
          :indent-size="indentSize"
          :level="level + 1"
          @toggle="$emit('toggle', $event)"
          @select="$emit('select', $event)"
        />
      </div>
    </div>
  `,
};
</script>
