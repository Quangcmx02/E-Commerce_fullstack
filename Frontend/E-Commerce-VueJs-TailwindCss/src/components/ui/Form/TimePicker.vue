<template>
  <div class="space-y-2">
    <label v-if="label" class="text-sm font-medium text-zinc-300">{{ label }}</label>
    <div class="relative">
      <input
        type="text"
        :value="displayValue"
        :disabled="disabled"
        class="h-10 w-full rounded-lg border border-zinc-700 bg-zinc-800 px-3 text-sm text-zinc-300 placeholder:text-zinc-500 focus:border-primary focus:outline-none focus:ring-2 focus:ring-primary/20 disabled:cursor-not-allowed disabled:opacity-50"
        :placeholder="format === '24h' ? 'HH:mm' : 'hh:mm AM/PM'"
        @focus="showDropdown = true"
        @blur="handleBlur"
        readonly
      />
      <div
        v-if="showDropdown && !disabled"
        class="absolute left-0 z-10 mt-1 w-64 rounded-lg border border-zinc-700 bg-zinc-800 p-4 shadow-lg"
        @mousedown.prevent
      >
        <div class="flex items-center justify-between gap-4">
          <!-- Saat -->
          <div class="flex flex-col items-center">
            <button
              type="button"
              class="rounded-md p-1 hover:bg-zinc-700"
              @click="adjustHour(1)"
            >
              <svg class="h-4 w-4 text-zinc-400" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M14.707 12.707a1 1 0 01-1.414 0L10 9.414l-3.293 3.293a1 1 0 01-1.414-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 010 1.414z" clip-rule="evenodd" />
              </svg>
            </button>
            <input
              type="text"
              :value="hours"
              class="w-12 rounded-md border border-zinc-700 bg-zinc-900 px-2 py-1 text-center text-sm text-zinc-300"
              readonly
            />
            <button
              type="button"
              class="rounded-md p-1 hover:bg-zinc-700"
              @click="adjustHour(-1)"
            >
              <svg class="h-4 w-4 text-zinc-400" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd" />
              </svg>
            </button>
          </div>

          <span class="text-lg font-medium text-zinc-400">:</span>

          <!-- Dakika -->
          <div class="flex flex-col items-center">
            <button
              type="button"
              class="rounded-md p-1 hover:bg-zinc-700"
              @click="adjustMinute(1)"
            >
              <svg class="h-4 w-4 text-zinc-400" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M14.707 12.707a1 1 0 01-1.414 0L10 9.414l-3.293 3.293a1 1 0 01-1.414-1.414l4-4a1 1 0 011.414 0l4 4a1 1 0 010 1.414z" clip-rule="evenodd" />
              </svg>
            </button>
            <input
              type="text"
              :value="minutes"
              class="w-12 rounded-md border border-zinc-700 bg-zinc-900 px-2 py-1 text-center text-sm text-zinc-300"
              readonly
            />
            <button
              type="button"
              class="rounded-md p-1 hover:bg-zinc-700"
              @click="adjustMinute(-1)"
            >
              <svg class="h-4 w-4 text-zinc-400" viewBox="0 0 20 20" fill="currentColor">
                <path fill-rule="evenodd" d="M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z" clip-rule="evenodd" />
              </svg>
            </button>
          </div>

          <!-- AM/PM -->
          <div v-if="format === '12h'" class="flex flex-col items-center">
            <button
              type="button"
              class="rounded-md px-2 py-1 text-sm text-zinc-300 hover:bg-zinc-700"
              @click="togglePeriod"
            >
              {{ period }}
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue';

const props = defineProps({
  modelValue: {
    type: String,
    required: true,
  },
  label: {
    type: String,
    default: '',
  },
  format: {
    type: String,
    default: '24h',
    validator: (value: string) => ['12h', '24h'].includes(value),
  },
  disabled: {
    type: Boolean,
    default: false,
  },
});

const emit = defineEmits(['update:modelValue']);

const showDropdown = ref(false);

// Saat ve dakika değerlerini parse et
const parseTime = (timeString: string) => {
  const [hours, minutes] = timeString.split(':').map(Number);
  return { hours, minutes };
};

// Başlangıç değerlerini ayarla
const { hours: initialHours, minutes: initialMinutes } = parseTime(props.modelValue);
const hours = ref(initialHours);
const minutes = ref(initialMinutes);
const period = ref(hours.value >= 12 ? 'PM' : 'AM');

// Görüntülenecek değer
const displayValue = computed(() => {
  let displayHours = hours.value;
  if (props.format === '12h') {
    displayHours = displayHours % 12 || 12;
    return `${String(displayHours).padStart(2, '0')}:${String(minutes.value).padStart(2, '0')} ${period.value}`;
  }
  return `${String(displayHours).padStart(2, '0')}:${String(minutes.value).padStart(2, '0')}`;
});

// Saat ayarlama
const adjustHour = (delta: number) => {
  let newHours = hours.value + delta;
  if (props.format === '24h') {
    newHours = ((newHours % 24) + 24) % 24;
  } else {
    newHours = ((newHours % 12) + 12) % 12 || 12;
  }
  hours.value = newHours;
  updateValue();
};

// Dakika ayarlama
const adjustMinute = (delta: number) => {
  minutes.value = ((minutes.value + delta) % 60 + 60) % 60;
  updateValue();
};

// AM/PM değiştirme
const togglePeriod = () => {
  period.value = period.value === 'AM' ? 'PM' : 'AM';
  updateValue();
};

// Değeri güncelle
const updateValue = () => {
  let finalHours = hours.value;
  if (props.format === '12h' && period.value === 'PM') {
    finalHours = (finalHours % 12) + 12;
  }
  emit('update:modelValue', `${String(finalHours).padStart(2, '0')}:${String(minutes.value).padStart(2, '0')}`);
};

// Blur işlemi
const handleBlur = (event: FocusEvent) => {
  // Dropdown içindeki tıklamalarda kapanmasını engelle
  const relatedTarget = event.relatedTarget as HTMLElement;
  if (!relatedTarget || !event.currentTarget.contains(relatedTarget)) {
    showDropdown.value = false;
  }
};
</script> 