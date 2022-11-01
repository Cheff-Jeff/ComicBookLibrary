import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'

import 'bootstrap/dist/css/bootstrap.min.css'
import './assets/styles/main.scss'
import 'bootstrap'
import { autoAnimatePlugin } from '@formkit/auto-animate/vue'

const app = createApp(App)
app.use(autoAnimatePlugin)
app.use(createPinia())
app.use(router)

app.mount('#app')
