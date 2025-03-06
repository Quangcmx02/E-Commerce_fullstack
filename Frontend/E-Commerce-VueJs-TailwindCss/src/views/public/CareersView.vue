<template>
    <div class="container mx-auto px-4 py-8">
        <div class="max-w-4xl mx-auto">
            <!-- Başlık Bölümü -->
            <div class="text-center mb-12">
                <h1 class="text-3xl font-bold tracking-tighter sm:text-4xl md:text-5xl mb-4">
                    Kariyer Fırsatları
                </h1>
                <p class="text-muted-foreground">
                    Yenilikçi ve dinamik ekibimizin bir parçası olun
                </p>
            </div>

            <!-- Departman Filtreleri -->
            <div class="mb-8">
                <div class="flex flex-wrap gap-2">
                    <button
                        v-for="department in departments"
                        :key="department.id"
                        @click="selectedDepartment = department.id"
                        :class="[
                            'px-4 py-2 rounded-md text-sm font-medium transition-colors duration-200',
                            selectedDepartment === department.id
                                ? 'bg-primary text-primary-foreground'
                                : 'bg-background border hover:bg-muted',
                        ]"
                    >
                        {{ department.name }}
                    </button>
                </div>
            </div>

            <!-- Pozisyonlar Listesi -->
            <div class="space-y-4">
                <div
                    v-for="position in filteredPositions"
                    :key="position.id"
                    class="group rounded-lg border bg-background p-6 transition-all duration-200 hover:border-primary"
                >
                    <div class="flex items-start justify-between">
                        <div>
                            <h3 class="text-lg font-semibold group-hover:text-primary">
                                {{ position.title }}
                            </h3>
                            <p class="mt-1 text-muted-foreground">{{ position.department }}</p>
                            <div class="mt-2 flex flex-wrap gap-2">
                                <span
                                    v-for="(tag, index) in position.tags"
                                    :key="index"
                                    class="inline-flex items-center rounded-full bg-muted px-2.5 py-0.5 text-xs font-medium"
                                >
                                    {{ tag }}
                                </span>
                            </div>
                        </div>
                        <div class="flex items-center space-x-4">
                            <span class="text-sm text-muted-foreground">{{
                                position.location
                            }}</span>
                            <router-link
                                :to="{ name: 'career-detail', params: { id: position.id } }"
                                class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground hover:bg-primary/90 transition-colors"
                            >
                                Detayları Gör
                            </router-link>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Boş Durum -->
            <div
                v-if="filteredPositions.length === 0"
                class="flex flex-col items-center justify-center rounded-lg border bg-background p-12 text-center"
            >
                <div class="text-muted-foreground">
                    <svg
                        xmlns="http://www.w3.org/2000/svg"
                        class="mx-auto h-12 w-12"
                        fill="none"
                        viewBox="0 0 24 24"
                        stroke="currentColor"
                    >
                        <path
                            stroke-linecap="round"
                            stroke-linejoin="round"
                            stroke-width="2"
                            d="M19 11H5m14 0a2 2 0 012 2v6a2 2 0 01-2 2H5a2 2 0 01-2-2v-6a2 2 0 012-2m14 0V9a2 2 0 00-2-2M5 11V9a2 2 0 012-2m0 0V5a2 2 0 012-2h6a2 2 0 012 2v2M7 7h10"
                        />
                    </svg>
                </div>
                <h3 class="mt-4 text-lg font-medium">Açık Pozisyon Bulunamadı</h3>
                <p class="mt-2 text-sm text-muted-foreground">
                    Seçili departmanda şu anda açık pozisyon bulunmuyor.
                </p>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

// Örnek departman verileri
const departments = [
    { id: 'all', name: 'Tüm Departmanlar' },
    { id: 'software', name: 'Yazılım Geliştirme' },
    { id: 'design', name: 'Tasarım' },
    { id: 'marketing', name: 'Pazarlama' },
    { id: 'sales', name: 'Satış' },
]

// Örnek pozisyon verileri
const positions = [
    {
        id: 1,
        title: 'Senior Frontend Developer',
        department: 'Yazılım Geliştirme',
        departmentId: 'software',
        location: 'İstanbul',
        tags: ['Vue.js', 'TypeScript', 'Tailwind CSS'],
    },
    {
        id: 2,
        title: 'UI/UX Designer',
        department: 'Tasarım',
        departmentId: 'design',
        location: 'Remote',
        tags: ['Figma', 'Adobe XD', 'User Research'],
    },
    {
        id: 3,
        title: 'Digital Marketing Specialist',
        department: 'Pazarlama',
        departmentId: 'marketing',
        location: 'İstanbul',
        tags: ['SEO', 'Social Media', 'Content Marketing'],
    },
    {
        id: 4,
        title: 'Sales Representative',
        department: 'Satış',
        departmentId: 'sales',
        location: 'Ankara',
        tags: ['B2B Sales', 'CRM', 'Negotiation'],
    },
]

const selectedDepartment = ref('all')

// Filtrelenmiş pozisyonlar
const filteredPositions = computed(() => {
    if (selectedDepartment.value === 'all') {
        return positions
    }
    return positions.filter((position) => position.departmentId === selectedDepartment.value)
})
</script>
