<template>
    <div class="space-y-6">
        <!-- Başlık ve Açıklama -->
        <div class="flex items-center justify-between">
            <div>
                <h1 class="text-3xl font-bold tracking-tight">Kullanıcı Yönetimi</h1>
                <p class="text-muted-foreground">Platformdaki tüm kullanıcıları buradan yönetebilirsiniz.</p>
            </div>
            <button class="inline-flex items-center justify-center rounded-md bg-primary px-4 py-2 text-sm font-medium text-primary-foreground shadow hover:bg-primary/90">
                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                    <path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2" />
                    <circle cx="9" cy="7" r="4" />
                    <line x1="19" x2="19" y1="8" y2="14" />
                    <line x1="22" x2="16" y1="11" y2="11" />
                </svg>
                Yeni Kullanıcı Ekle
            </button>
        </div>

        <!-- Filtreler ve Arama -->
        <div class="flex flex-col gap-4 rounded-lg border bg-card p-4 md:flex-row md:items-center md:justify-between">
            <div class="flex flex-1 flex-col gap-4 md:flex-row md:items-center">
                <!-- Arama -->
                <div class="relative flex-1">
                    <input
                        type="text"
                        placeholder="Kullanıcı ara..."
                        v-model="searchQuery"
                        class="h-9 w-full rounded-md border bg-background px-3 pl-9 text-sm placeholder:text-muted-foreground focus:outline-none focus:ring-2 focus:ring-primary"
                    />
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="absolute left-3 top-1/2 -translate-y-1/2 text-muted-foreground">
                        <circle cx="11" cy="11" r="8" />
                        <path d="m21 21-4.3-4.3" />
                    </svg>
                </div>

                <!-- Rol Filtresi -->
                <select v-model="selectedRole" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="">Tüm Roller</option>
                    <option value="admin">Admin</option>
                    <option value="user">Kullanıcı</option>
                    <option value="seller">Satıcı</option>
                </select>

                <!-- Durum Filtresi -->
                <select v-model="selectedStatus" class="h-9 rounded-md border bg-background px-3 text-sm focus:outline-none focus:ring-2 focus:ring-primary">
                    <option value="">Tüm Durumlar</option>
                    <option value="active">Aktif</option>
                    <option value="inactive">Pasif</option>
                    <option value="banned">Yasaklı</option>
                </select>
            </div>

            <!-- Dışa Aktar -->
            <div class="flex items-center gap-2">
                <button class="inline-flex items-center justify-center rounded-md border bg-background px-3 py-2 text-sm font-medium shadow-sm hover:bg-accent">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" />
                        <polyline points="7 10 12 15 17 10" />
                        <line x1="12" x2="12" y1="15" y2="3" />
                    </svg>
                    Excel'e Aktar
                </button>
                <button class="inline-flex items-center justify-center rounded-md border bg-background px-3 py-2 text-sm font-medium shadow-sm hover:bg-accent">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="mr-2">
                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4" />
                        <polyline points="7 10 12 15 17 10" />
                        <line x1="12" x2="12" y1="15" y2="3" />
                    </svg>
                    PDF'e Aktar
                </button>
            </div>
        </div>

        <!-- Kullanıcı Tablosu -->
        <div class="rounded-lg border bg-card">
            <div class="relative overflow-x-auto">
                <table class="w-full text-left text-sm">
                    <thead class="bg-muted/50 text-xs uppercase">
                        <tr>
                            <th class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </th>
                            <th class="px-6 py-4">Kullanıcı</th>
                            <th class="px-6 py-4">E-posta</th>
                            <th class="px-6 py-4">Rol</th>
                            <th class="px-6 py-4">Durum</th>
                            <th class="px-6 py-4">Kayıt Tarihi</th>
                            <th class="px-6 py-4">Son Giriş</th>
                            <th class="px-6 py-4">İşlemler</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr v-for="user in filteredUsers" :key="user.id" class="border-b">
                            <td class="px-6 py-4">
                                <input type="checkbox" class="rounded border-muted" />
                            </td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-3">
                                    <img :src="user.avatar" :alt="user.name" class="h-8 w-8 rounded-full object-cover" />
                                    <div>
                                        <p class="font-medium">{{ user.name }}</p>
                                        <p class="text-xs text-muted-foreground">ID: {{ user.id }}</p>
                                    </div>
                                </div>
                            </td>
                            <td class="px-6 py-4">{{ user.email }}</td>
                            <td class="px-6 py-4">
                                <span :class="[
                                    'rounded-full px-2 py-1 text-xs font-medium',
                                    user.role === 'admin' ? 'bg-purple-100 text-purple-700' :
                                    user.role === 'seller' ? 'bg-blue-100 text-blue-700' :
                                    'bg-gray-100 text-gray-700'
                                ]">
                                    {{ user.role }}
                                </span>
                            </td>
                            <td class="px-6 py-4">
                                <span :class="[
                                    'rounded-full px-2 py-1 text-xs font-medium',
                                    user.status === 'active' ? 'bg-green-100 text-green-700' :
                                    user.status === 'inactive' ? 'bg-yellow-100 text-yellow-700' :
                                    'bg-red-100 text-red-700'
                                ]">
                                    {{ user.status }}
                                </span>
                            </td>
                            <td class="px-6 py-4">{{ user.registeredAt }}</td>
                            <td class="px-6 py-4">{{ user.lastLogin }}</td>
                            <td class="px-6 py-4">
                                <div class="flex items-center gap-2">
                                    <button class="rounded-md p-2 hover:bg-accent" title="Düzenle">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M17 3a2.85 2.83 0 1 1 4 4L7.5 20.5 2 22l1.5-5.5Z" />
                                            <path d="m15 5 4 4" />
                                        </svg>
                                    </button>
                                    <button class="rounded-md p-2 hover:bg-accent" title="Şifre Sıfırla">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M2 12A10 10 0 1 0 12 2v10Z" />
                                        </svg>
                                    </button>
                                    <button class="rounded-md p-2 text-red-500 hover:bg-accent" title="Sil">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round">
                                            <path d="M3 6h18" />
                                            <path d="M19 6v14c0 1-1 2-2 2H7c-1 0-2-1-2-2V6" />
                                            <path d="M8 6V4c0-1 1-2 2-2h4c1 0 2 1 2 2v2" />
                                        </svg>
                                    </button>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <!-- Pagination -->
            <div class="flex items-center justify-between border-t px-6 py-4">
                <div class="text-sm text-muted-foreground">
                    Toplam <span class="font-medium">{{ totalUsers }}</span> kullanıcıdan <span class="font-medium">1-10</span> arası gösteriliyor
                </div>
                <div class="flex items-center gap-2">
                    <button class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent disabled:opacity-50" :disabled="currentPage === 1">
                        Önceki
                    </button>
                    <div class="flex items-center gap-1">
                        <button v-for="page in totalPages" :key="page" class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent" :class="{ 'bg-primary text-primary-foreground': currentPage === page }">
                            {{ page }}
                        </button>
                    </div>
                    <button class="rounded-md px-3 py-2 text-sm font-medium hover:bg-accent disabled:opacity-50" :disabled="currentPage === totalPages">
                        Sonraki
                    </button>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'

// Durum değişkenleri
const searchQuery = ref('')
const selectedRole = ref('')
const selectedStatus = ref('')
const currentPage = ref(1)

// Örnek kullanıcı verileri
const users = [
    {
        id: "USR001",
        name: "Ahmet Yılmaz",
        email: "ahmet@example.com",
        role: "admin",
        status: "active",
        registeredAt: "2024-01-15",
        lastLogin: "2024-02-15 14:30",
        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=1"
    },
    {
        id: "USR002",
        name: "Mehmet Demir",
        email: "mehmet@example.com",
        role: "seller",
        status: "active",
        registeredAt: "2024-01-20",
        lastLogin: "2024-02-15 12:45",
        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=2"
    },
    {
        id: "USR003",
        name: "Ayşe Kaya",
        email: "ayse@example.com",
        role: "user",
        status: "inactive",
        registeredAt: "2024-01-25",
        lastLogin: "2024-02-14 16:20",
        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=3"
    },
    {
        id: "USR004",
        name: "Fatma Şahin",
        email: "fatma@example.com",
        role: "seller",
        status: "banned",
        registeredAt: "2024-01-30",
        lastLogin: "2024-02-13 09:15",
        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=4"
    },
    {
        id: "USR005",
        name: "Ali Öztürk",
        email: "ali@example.com",
        role: "user",
        status: "active",
        registeredAt: "2024-02-01",
        lastLogin: "2024-02-15 11:30",
        avatar: "https://api.dicebear.com/7.x/avataaars/svg?seed=5"
    }
]

// Hesaplanan özellikler
const filteredUsers = computed(() => {
    let result = [...users]

    // Arama filtresi
    if (searchQuery.value) {
        const query = searchQuery.value.toLowerCase()
        result = result.filter(user =>
            user.name.toLowerCase().includes(query) ||
            user.email.toLowerCase().includes(query) ||
            user.id.toLowerCase().includes(query)
        )
    }

    // Rol filtresi
    if (selectedRole.value) {
        result = result.filter(user => user.role === selectedRole.value)
    }

    // Durum filtresi
    if (selectedStatus.value) {
        result = result.filter(user => user.status === selectedStatus.value)
    }

    return result
})

const totalUsers = computed(() => filteredUsers.value.length)
const totalPages = computed(() => Math.ceil(totalUsers.value / 10))
</script> 