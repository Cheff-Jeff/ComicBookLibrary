import { createRouter, createWebHistory } from 'vue-router'
import { checkRoute } from '../assets/javascript/authentication'
import HomeView from '../views/HomeView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/comics',
      name: 'comics',
      beforeEnter(to, from, next){
        if(!checkRoute())
        {
          next({ name: 'home' })
          return false
        }
        else{
          next()
        }
      },
      component: () => import('../views/ComicsView.vue')
    },
    {
      path: '/add-comics',
      name: 'addComics',
      beforeEnter(to, from, next){
        if(!checkRoute())
        {
          next({ name: 'home' })
          return false
        }
        else{
          next()
        }
      },
      component: () => import('../views/AddComicsView.vue')
    },
    {
      path: '/writers',
      name: 'Writers',
      beforeEnter(to, from, next){
        if(!checkRoute())
        {
          next({ name: 'home' })
          return false
        }
        else{
          next()
        }
      },
      component: () => import('../views/WritersView.vue')
    },
    {
      path: '/add-writers',
      name: 'addWriters',
      beforeEnter(to, from, next){
        if(!checkRoute())
        {
          next({ name: 'home' })
          return false
        }
        else{
          next()
        }
      },
      component: () => import('../views/AddWriter.vue')
    },
    {
      path: '/overview',
      name: 'overview',
      beforeEnter(to, from, next){
        if(!checkRoute())
        {
          next({ name: 'home' })
          return false
        }
        else{
          next()
        }
      },
      component: () => import('../views/AdminTabsView.vue')
    }
  ]
})

export default router
