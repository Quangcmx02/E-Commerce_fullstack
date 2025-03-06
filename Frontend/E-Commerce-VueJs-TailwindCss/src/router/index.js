import { createRouter, createWebHistory } from 'vue-router'
import publicRoutes from './publicRoutes';
import customerRoutes from './customerRoutes';
import sellerRoutes from './sellerRoutes';
import authRoutes from './authRoutes';
import adminRoutes from './adminRoutes';

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        ...publicRoutes,
        ...customerRoutes,
        ...sellerRoutes,
        ...authRoutes,
        ...adminRoutes
    ],
    scrollBehavior(to, from, savedPosition) {
        if (to.hash) {
            // Eğer URL'de hash varsa (örn: /sayfa#section), o konuma kaydır
            return {
                el: to.hash,
                behavior: 'smooth',
            }
        } else {
            // Sayfa yüklendiğinde çalışmasını garantilemek için setTimeout kullanıyoruz
            return new Promise((resolve) => {
                setTimeout(() => {
                    resolve({ top: 0, left: 0, behavior: 'smooth' })
                }, 1)
            })
        }
    }
})

// Global navigation guard ekleyerek her route değişiminde scroll'u sıfırlıyoruz
router.beforeEach((to, from, next) => {
    // Mevcut scroll pozisyonunu sıfırla
    if (document.documentElement) {
        document.documentElement.scrollTop = 0
    }
    if (document.body) {
        document.body.scrollTop = 0
    }
    next()
})

export default router
