import { createApp } from 'vue'
import { inject } from '@vercel/analytics'
import App from './App.vue'
import router from './router'
import './assets/main.css'

// Vercel Analytics'i başlat
inject()

const app = createApp(App)
app.use(router)
app.mount('#app') 