<template>
  <div
    class="rounded-lg border bg-white p-4 shadow-sm dark:border-zinc-700 dark:bg-zinc-800"
    :class="className"
  >
    <div class="flex items-start justify-between">
      <!-- İstatistik İkonu -->
      <div
        class="rounded-lg p-2"
        :class="{
          'bg-blue-100 text-blue-600 dark:bg-blue-900/30 dark:text-blue-400':
            variant === 'primary',
          'bg-green-100 text-green-600 dark:bg-green-900/30 dark:text-green-400':
            variant === 'success',
          'bg-yellow-100 text-yellow-600 dark:bg-yellow-900/30 dark:text-yellow-400':
            variant === 'warning',
          'bg-red-100 text-red-600 dark:bg-red-900/30 dark:text-red-400':
            variant === 'danger',
        }"
      >
        <slot name="icon">
          <svg
            class="h-6 w-6"
            xmlns="http://www.w3.org/2000/svg"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M13 7h8m0 0v8m0-8l-8 8-4-4-6 6"
            />
          </svg>
        </slot>
      </div>

      <!-- Trend İkonu -->
      <div
        v-if="trend"
        class="flex items-center gap-1 text-sm font-medium"
        :class="{
          'text-green-600 dark:text-green-400': trend > 0,
          'text-red-600 dark:text-red-400': trend < 0,
          'text-gray-600 dark:text-zinc-400': trend === 0,
        }"
      >
        <svg
          v-if="trend !== 0"
          class="h-4 w-4"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            :d="
              trend > 0
                ? 'M13 7h8m0 0v8m0-8l-8 8-4-4-6 6'
                : 'M13 17h8m0 0V9m0 8l-8-8-4 4-6-6'
            "
          />
        </svg>
        {{ Math.abs(trend) }}%
      </div>
    </div>

    <!-- İstatistik Değeri ve Başlığı -->
    <div class="mt-4">
      <h4 class="text-2xl font-bold text-gray-900 dark:text-white">
        {{ formatValue(value) }}
      </h4>
      <p class="mt-1 text-sm text-gray-600 dark:text-zinc-300">{{ title }}</p>
    </div>

    <!-- Alt Bilgi -->
    <p
      v-if="subtitle"
      class="mt-4 text-sm text-gray-600 dark:text-zinc-300"
      v-html="subtitle"
    ></p>
  </div>
</template>

<script setup lang="ts">
interface Props {
  title: string;
  value: number;
  variant?: 'primary' | 'success' | 'warning' | 'danger';
  trend?: number;
  subtitle?: string;
  format?: 'number' | 'currency' | 'percent';
  className?: string;
}

const props = withDefaults(defineProps<Props>(), {
  variant: 'primary',
  format: 'number',
  className: '',
});

const formatValue = (value: number) => {
  switch (props.format) {
    case 'currency':
      return new Intl.NumberFormat('tr-TR', {
        style: 'currency',
        currency: 'TRY',
      }).format(value);
    case 'percent':
      return new Intl.NumberFormat('tr-TR', {
        style: 'percent',
        minimumFractionDigits: 1,
      }).format(value / 100);
    default:
      return new Intl.NumberFormat('tr-TR').format(value);
  }
};
</script> 