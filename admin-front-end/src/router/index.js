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
      path: '/publichers',
      name: 'Publichers',
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
      component: () => import('../views/PublichersView.vue')
    },
    {
      path: '/add-publichers',
      name: 'addPublichers',
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
      component: () => import('../views/create/AddPublicherView.vue')
    },
    {
      path: '/update-publicher/:id',
      name: 'updatePublichers',
      beforeEnter: async (to, from, next) => {
        const responce = await checkRouteItem(`${import.meta.env.VITE_API_PUBLICHERS_URL}/${to.params.id}`)
        if(!responce)
        {
          next({ name: 'Publichers' })
          return false
        }
        else{
          next()
        }
      },
      component: () => import('../views/update/UpdatePublicher.vue')
    },
    {
      path: '/artists',
      name: 'Artists',
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
      component: () => import('../views/ArtistsView.vue')
    },
    {
      path: '/add-artist',
      name: 'addArtist',
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
      component: () => import('../views/create/AddArtist.vue')
    },
    {
      path: '/update-artist/:id',
      name: 'updateArtist',
      beforeEnter: async (to, from, next) => {
        const responce = await checkRouteItem(`${import.meta.env.VITE_API_ARTISTS_URL}/${to.params.id}`)
        if(!responce)
        {
          next({ name: 'Artists' })
          return false
        }
        else{
          next()
        }
      },
      component: () => import('../views/update/UpdateArtist.vue')
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
