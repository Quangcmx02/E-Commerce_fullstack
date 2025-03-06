<template>
  <div :class="className">
    <!-- Tab Başlıkları -->
    <div class="border-b border-zinc-800">
      <nav class="-mb-px flex space-x-8" aria-label="Tabs">
        <button
          v-for="(tab, index) in tabs"
          :key="index"
          @click="activeTab = index"
          class="whitespace-nowrap border-b-2 py-4 px-1 text-sm font-medium transition-colors"
          :class="[
            activeTab === index
              ? 'border-blue-500 text-blue-500'
              : 'border-transparent text-zinc-400 hover:border-zinc-600 hover:text-zinc-300'
          ]"
        >
          {{ tab.title }}
        </button>
      </nav>
    </div>

    <!-- Tab İçerikleri -->
    <div class="mt-4">
      <div
        v-for="(tab, index) in tabs"
        :key="index"
        v-show="activeTab === index"
        class="text-sm text-zinc-400"
      >
        <component :is="tab.content" v-if="typeof tab.content === 'object'" />
        <template v-else>{{ tab.content }}</template>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import type { Component } from 'vue';

interface Tab {
  title: string;
  content: string | Component;
}

interface Props {
  className?: string;
  tabs: Tab[];
  defaultTab?: number;
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
  defaultTab: 0,
});

const activeTab = ref(props.defaultTab);
</script> 