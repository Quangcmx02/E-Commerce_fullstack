<template>
  <div class="space-y-2">
    <label v-if="label" class="text-sm font-medium text-zinc-300">{{ label }}</label>
    <div class="flex items-center gap-2">
      <div
        class="relative h-10 w-10 overflow-hidden rounded-lg border border-zinc-700"
        :class="{ 'opacity-50': disabled }"
      >
        <input
          type="color"
          :value="modelValue"
          :disabled="disabled"
          class="absolute inset-0 h-full w-full cursor-pointer border-0 opacity-0"
          @input="$emit('update:modelValue', $event.target.value)"
        />
        <div
          class="h-full w-full"
          :style="{ backgroundColor: modelValue }"
        ></div>
      </div>
      <input
        type="text"
        :value="modelValue"
        :disabled="disabled"
        class="h-10 rounded-lg border border-zinc-700 bg-zinc-800 px-3 text-sm text-zinc-300 placeholder:text-zinc-500 focus:border-primary focus:outline-none focus:ring-2 focus:ring-primary/20 disabled:cursor-not-allowed disabled:opacity-50"
        placeholder="#000000"
        pattern="^#[0-9A-Fa-f]{6}$"
        @input="handleInput"
      />
    </div>
    <div v-if="presetColors?.length" class="flex flex-wrap gap-2">
      <button
        v-for="color in presetColors"
        :key="color"
        type="button"
        class="h-6 w-6 rounded-md border border-zinc-700 focus:outline-none focus:ring-2 focus:ring-primary/20"
        :style="{ backgroundColor: color }"
        :disabled="disabled"
        @click="$emit('update:modelValue', color)"
      ></button>
    </div>
  </div>
</template>

<script setup lang="ts">
defineProps({
  modelValue: {
    type: String,
    required: true,
  },
  label: {
    type: String,
    default: '',
  },
  disabled: {
    type: Boolean,
    default: false,
  },
  presetColors: {
    type: Array as PropType<string[]>,
    default: () => [],
  },
});

const emit = defineEmits(['update:modelValue']);

const handleInput = (event: Event) => {
  const input = event.target as HTMLInputElement;
  const value = input.value;
  
  if (value.match(/^#[0-9A-Fa-f]{6}$/)) {
    emit('update:modelValue', value);
  }
};
</script> 