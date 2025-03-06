<template>
  <div
    class="rounded-lg border bg-white shadow-sm dark:border-zinc-700 dark:bg-zinc-800"
    :class="className"
  >
    <!-- Profil Kapak Fotoğrafı -->
    <div
      v-if="coverImage"
      class="relative h-32 w-full rounded-t-lg bg-gray-200 dark:bg-zinc-700"
    >
      <img
        :src="coverImage"
        alt="Kapak Fotoğrafı"
        class="h-full w-full rounded-t-lg object-cover"
        @error="handleCoverImageError"
      />
    </div>

    <div class="p-4">
      <!-- Profil Fotoğrafı ve Temel Bilgiler -->
      <div class="flex items-start gap-4">
        <div class="relative">
          <img
            :src="avatar"
            :alt="name"
            class="h-16 w-16 rounded-full object-cover ring-4 ring-white dark:ring-zinc-800"
            @error="handleAvatarError"
          />
          <div
            v-if="status"
            class="absolute bottom-0 right-0 h-4 w-4 rounded-full border-2 border-white dark:border-zinc-800"
            :class="{
              'bg-green-500': status === 'online',
              'bg-yellow-500': status === 'away',
              'bg-red-500': status === 'offline',
              'bg-gray-500': status === 'busy',
            }"
          ></div>
        </div>

        <div class="flex-1">
          <div class="flex items-center justify-between">
            <div>
              <h3 class="text-lg font-semibold text-gray-900 dark:text-white">
                {{ name }}
              </h3>
              <p class="text-sm text-gray-600 dark:text-zinc-300">
                {{ title }}
              </p>
            </div>
            <slot name="actions"></slot>
          </div>

          <!-- Biyografi -->
          <p
            v-if="bio"
            class="mt-3 text-sm text-gray-600 dark:text-zinc-300"
            v-html="bio"
          ></p>
        </div>
      </div>

      <!-- İstatistikler -->
      <div
        v-if="stats && stats.length > 0"
        class="mt-4 grid grid-cols-3 divide-x divide-gray-200 border-t pt-4 text-center dark:divide-zinc-700 dark:border-zinc-700"
      >
        <div
          v-for="(stat, index) in stats"
          :key="index"
          class="px-2"
        >
          <div class="text-lg font-semibold text-gray-900 dark:text-white">
            {{ formatNumber(stat.value) }}
          </div>
          <div class="text-xs text-gray-600 dark:text-zinc-300">
            {{ stat.label }}
          </div>
        </div>
      </div>

      <!-- İletişim Bilgileri -->
      <div
        v-if="contact"
        class="mt-4 space-y-2 border-t pt-4 dark:border-zinc-700"
      >
        <div
          v-if="contact.email"
          class="flex items-center gap-2 text-sm text-gray-600 dark:text-zinc-300"
        >
          <svg
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
              d="M3 8l7.89 5.26a2 2 0 002.22 0L21 8M5 19h14a2 2 0 002-2V7a2 2 0 00-2-2H5a2 2 0 00-2 2v10a2 2 0 002 2z"
            />
          </svg>
          {{ contact.email }}
        </div>
        <div
          v-if="contact.phone"
          class="flex items-center gap-2 text-sm text-gray-600 dark:text-zinc-300"
        >
          <svg
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
              d="M3 5a2 2 0 012-2h3.28a1 1 0 01.948.684l1.498 4.493a1 1 0 01-.502 1.21l-2.257 1.13a11.042 11.042 0 005.516 5.516l1.13-2.257a1 1 0 011.21-.502l4.493 1.498a1 1 0 01.684.949V19a2 2 0 01-2 2h-1C9.716 21 3 14.284 3 6V5z"
            />
          </svg>
          {{ contact.phone }}
        </div>
        <div
          v-if="contact.location"
          class="flex items-center gap-2 text-sm text-gray-600 dark:text-zinc-300"
        >
          <svg
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
              d="M17.657 16.657L13.414 20.9a1.998 1.998 0 01-2.827 0l-4.244-4.243a8 8 0 1111.314 0z"
            />
            <path
              stroke-linecap="round"
              stroke-linejoin="round"
              stroke-width="2"
              d="M15 11a3 3 0 11-6 0 3 3 0 016 0z"
            />
          </svg>
          {{ contact.location }}
        </div>
      </div>

      <!-- Özel İçerik -->
      <slot></slot>
    </div>
  </div>
</template>

<script setup lang="ts">
interface Stat {
  label: string;
  value: number;
}

interface Contact {
  email?: string;
  phone?: string;
  location?: string;
}

interface Props {
  name: string;
  title: string;
  avatar: string;
  coverImage?: string;
  bio?: string;
  status?: 'online' | 'offline' | 'away' | 'busy';
  stats?: Stat[];
  contact?: Contact;
  className?: string;
}

const props = withDefaults(defineProps<Props>(), {
  className: '',
});

const handleAvatarError = (e: Event) => {
  const target = e.target as HTMLImageElement;
  target.src = '/placeholder-avatar.png';
};

const handleCoverImageError = (e: Event) => {
  const target = e.target as HTMLImageElement;
  target.src = '/placeholder-cover.png';
};

const formatNumber = (value: number) => {
  return new Intl.NumberFormat('tr-TR').format(value);
};
</script> 