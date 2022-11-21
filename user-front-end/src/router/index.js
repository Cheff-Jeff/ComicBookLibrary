import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import { routGaurd, CheckLogin } from '../assets/javascript/Gaurd';
import { ref } from 'vue';

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
      name: 'comcis',
      component: () => import('../views/ComicsView.vue')
    },
    {
      path: '/comics/:slug',
      name: 'comicDetail',
      beforeEnter: async (to, from, next) => {
        const response = await routGaurd(`${import.meta.env.VITE_API_COMICS_URL}/${to.params.slug}`)
        if(!response)
        {
          next({ name: 'NotFount' })
          return false
        }
        else
        {
          next();
          return true
        }
      },
      component: () => import('../views/ComicView.vue')
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('../views/LoginView.vue')
    },
    {
      path: '/registration',
      name: 'register',
      component: () => import('../views/RegisterView.vue')
    },
    {
      path: '/account',
      name: 'account',
      beforeEnter: (to,from,next) => {
        console.log(CheckLogin());
        if(!CheckLogin()){
          next({ name: 'login' })
          console.log("No user");
          return false
        }
        else{
          console.log("In");
          next();
          return true
        }
      },
      component: () => import('../views/AccountView.vue')
    },
    {
      //error 404 page
      path: '/:pathMatch(.*)*',
      name: 'NotFount',
      component: () => import('../views/NotFount.vue')
    }
  ]
})

export default router
