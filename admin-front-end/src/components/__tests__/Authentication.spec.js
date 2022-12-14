import { describe, expect, test } from 'vitest'
import { Logout } from '../../assets/javascript/authentication'
describe('logout', () => {
  test('Deletes the localStorage item.', () => {
    sessionStorage.setItem('userIsAdmin', true)
    expect(Logout()).toBe(true)
  })
})
describe('logout', ()=> {
  test('can not find user', () => {
    expect(Logout()).toBe(false)
  })
})

import { checkRoute } from '../../assets/javascript/authentication'
describe('routeGard', ()=>{
  test('route available to user', ()=>{
    sessionStorage.setItem('userIsAdmin', true)
    expect(checkRoute()).toBe(true)
    
    sessionStorage.removeItem('userIsAdmin')
  })
})

describe('routeGard', ()=>{
  test('route not available to user', ()=>{
    expect(checkRoute()).toBe(false)
  })
})