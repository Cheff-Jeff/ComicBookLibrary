import { createApp } from 'vue'
import { createPinia } from 'pinia'

import App from './App.vue'
import router from './router'
import { autoAnimatePlugin } from '@formkit/auto-animate/vue'

import 'bootstrap/dist/css/bootstrap.min.css'
import './assets/styles/main.scss'
import 'bootstrap'

const app = createApp(App)

app.use(autoAnimatePlugin)
app.use(createPinia())
app.use(router)

app.config.performance = true
app.mount('#app')
