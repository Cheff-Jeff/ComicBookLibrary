import { createRouter, createWebHistory } from 'vue-router'
import { checkRoute, checkRouteItem } from '../assets/javascript/authentication'
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
      component: () => import('../views/create/AddComicsView.vue')
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
      component: () => import('../views/create/AddWriter.vue')
    },
    {
      path: '/update-writer/:id',
      name: 'updateWriter',
      beforeEnter: async (to, from, next) => {
        const responce = await checkRouteItem(`${import.meta.env.VITE_API_WRITHERS_URL}/${to.params.id}`)
        if(!responce)
        {
          next({ name: 'Writers' })
          return false
        }
        else{
          next()
        }
      },
      component: () => import('../views/update/UpdateWriter.vue')
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
