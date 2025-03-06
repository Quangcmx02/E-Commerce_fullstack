<template>
    <!-- Başlık Bölümü -->
    <div class="container mx-auto px-4 py-8">
        <div class="text-center mb-12">
            <h1 class="text-4xl font-bold text-zinc-100 mb-4">Aktif Kampanyalar</h1>
            <p class="text-zinc-400">Özel indirimler ve fırsatlardan yararlanın!</p>
        </div>

        <!-- Kampanya Kategorileri -->
        <div class="flex flex-wrap gap-4 justify-center mb-8">
            <button v-for="category in categories" :key="category.id" class="px-6 py-2 rounded-full border border-zinc-800 text-zinc-100 hover:bg-zinc-800/50 transition-colors" :class="{ 'bg-zinc-800': selectedCategory === category.id }" @click="selectedCategory = category.id">
                {{ category.name }}
            </button>
        </div>

        <!-- Kampanyalar Grid -->
        <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
            <div v-for="campaign in filteredCampaigns" :key="campaign.id" class="bg-[#111111] rounded-2xl overflow-hidden border border-zinc-800/50 hover:border-zinc-700 transition-all duration-300">
                <!-- Kampanya Görseli -->
                <div class="relative">
                    <img :src="campaign.image" :alt="campaign.title" class="w-full h-48 object-cover" />
                    <div class="absolute top-4 right-4 bg-[#B91C1C] text-zinc-100 px-3 py-1 rounded-full text-sm font-medium">{{ campaign.discount }} İndirim</div>
                </div>

                <!-- Kampanya Detayları -->
                <div class="p-5">
                    <h3 class="text-lg font-semibold text-zinc-100 mb-2">
                        {{ campaign.title }}
                    </h3>
                    <p class="text-zinc-400 text-sm mb-4">{{ campaign.description }}</p>

                    <!-- Kampanya Bilgileri -->
                    <div class="flex items-center justify-between text-sm text-zinc-500 mb-4">
                        <div class="flex items-center">
                            <span class="mr-2">
                                <CalendarIcon class="w-4 h-4" />
                            </span>
                            <span>{{ campaign.validUntil }}</span>
                        </div>
                        <div class="flex items-center">
                            <span class="mr-2">
                                <UsersIcon class="w-4 h-4" />
                            </span>
                            <span>{{ campaign.usageCount }} kişi kullandı</span>
                        </div>
                    </div>

                    <!-- Kampanya Kupon Kodu -->
                    <div v-if="campaign.couponCode" class="bg-zinc-900 p-3 rounded-xl flex items-center justify-between border border-zinc-800">
                        <span class="font-mono text-base text-zinc-100">{{ campaign.couponCode }}</span>
                        <button @click="copyCode(campaign.couponCode)" class="text-zinc-400 hover:text-zinc-100 transition-colors">
                            <CopyIcon class="w-5 h-5" />
                        </button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Kampanya Bilgilendirme -->
        <div class="mt-12 bg-[#111111] rounded-2xl p-8 border border-zinc-800/50">
            <h2 class="text-2xl font-bold text-zinc-100 mb-4">Kampanya Kullanım Koşulları</h2>
            <ul class="space-y-3 text-zinc-400">
                <li class="flex items-start">
                    <CheckIcon class="w-5 h-5 text-emerald-500 mr-2 mt-1 flex-shrink-0" />
                    <span>Kampanyalar belirtilen son kullanım tarihine kadar geçerlidir.</span>
                </li>
                <li class="flex items-start">
                    <CheckIcon class="w-5 h-5 text-emerald-500 mr-2 mt-1 flex-shrink-0" />
                    <span>Bir siparişte yalnızca bir kampanya kodu kullanılabilir.</span>
                </li>
                <li class="flex items-start">
                    <CheckIcon class="w-5 h-5 text-emerald-500 mr-2 mt-1 flex-shrink-0" />
                    <span>Kampanyalar diğer indirimlerle birleştirilemez.</span>
                </li>
                <li class="flex items-start">
                    <CheckIcon class="w-5 h-5 text-emerald-500 mr-2 mt-1 flex-shrink-0" />
                    <span>Kampanya koşulları mağaza tarafından değiştirilebilir.</span>
                </li>
            </ul>
        </div>
    </div>
</template>

<script setup>
import { ref, computed } from "vue";
import { CalendarIcon, UsersIcon, CopyIcon, CheckIcon } from "lucide-vue-next";
import { useToast } from "vue-toastification";

const toast = useToast();

// Kampanya Kategorileri
const categories = [
    { id: "all", name: "Tüm Kampanyalar" },
    { id: "seasonal", name: "Sezonsal" },
    { id: "special", name: "Özel" },
    { id: "flash", name: "Flaş" },
    { id: "new-user", name: "Yeni Üye" },
];

const selectedCategory = ref("all");

// Örnek Kampanya Verileri
const campaigns = [
    {
        id: 1,
        title: "Hoş Geldin İndirimi",
        description: "Yeni üyelere özel ilk alışverişlerinde %20 indirim fırsatı!",
        image: "https://picsum.photos/800/400?random=1",
        discount: "%20",
        category: "new-user",
        validUntil: "28.02.2024",
        usageCount: 1250,
        couponCode: "WELCOME20",
        originalPrice: "1299.99",
        discountedPrice: "999.99",
    },
    {
        id: 2,
        title: "Kış Sezonu İndirimi",
        description: "Kış ürünlerinde net %30 indirim fırsatını kaçırmayın!",
        image: "https://picsum.photos/800/400?random=2",
        discount: "%30",
        category: "seasonal",
        validUntil: "15.03.2024",
        usageCount: 3420,
        couponCode: "WINTER30",
        originalPrice: "899.99",
        discountedPrice: "629.99",
    },
    {
        id: 3,
        title: "Flaş Saatler",
        description: "Sadece 2 saat geçerli süper indirimler!",
        image: "https://picsum.photos/800/400?random=3",
        discount: "%40",
        category: "flash",
        validUntil: "24 saat içinde",
        usageCount: 892,
        couponCode: "FLASH40",
        originalPrice: "1499.99",
        discountedPrice: "899.99",
    },
    {
        id: 4,
        title: "Özel Üyelik İndirimi",
        description: "Premium üyelere özel ekstra indirim avantajı",
        image: "https://picsum.photos/800/400?random=4",
        discount: "%25",
        category: "special",
        validUntil: "31.03.2024",
        usageCount: 567,
        couponCode: "PREMIUM25",
        originalPrice: "2499.99",
        discountedPrice: "1874.99",
    },
    {
        id: 5,
        title: "Hafta Sonu Fırsatı",
        description: "Hafta sonuna özel tüm ürünlerde geçerli indirim",
        image: "https://picsum.photos/800/400?random=5",
        discount: "%15",
        category: "special",
        validUntil: "25.02.2024",
        usageCount: 2341,
        couponCode: "WEEKEND15",
        originalPrice: "799.99",
        discountedPrice: "679.99",
    },
    {
        id: 6,
        title: "Bahar Kampanyası",
        description: "Bahar koleksiyonunda erken rezervasyon indirimi",
        image: "https://picsum.photos/800/400?random=6",
        discount: "%35",
        category: "seasonal",
        validUntil: "01.04.2024",
        usageCount: 1123,
        couponCode: "SPRING35",
        originalPrice: "1999.99",
        discountedPrice: "1299.99",
    },
];

// Filtrelenmiş Kampanyalar
const filteredCampaigns = computed(() => {
    if (selectedCategory.value === "all") {
        return campaigns;
    }
    return campaigns.filter((campaign) => campaign.category === selectedCategory.value);
});

// Kupon Kodu Kopyalama
const copyCode = (code) => {
    navigator.clipboard.writeText(code);
    toast.success("Kupon kodu kopyalandı!");
};
</script>
