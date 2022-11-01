import { describe, expect, test } from 'vitest'
import { CheckLogin } from '../../assets/javascript/Gaurd'
describe('routeGard', ()=>{
  test('route available to user', ()=>{
    localStorage.setItem('user', true)
    expect(CheckLogin()).toBe(true)
    
    localStorage.removeItem('user')
  })
})

describe('routeGard', ()=>{
  test('route not available to user', ()=>{
    expect(CheckLogin()).toBe(false)
  })
})

import { Logout } from '../../assets/javascript/authentication'
describe('logout', () => {
  test('Deletes the localStorage item.', () => {
    localStorage.setItem('user', true)
    expect(Logout()).toBe(true)
  })
})
describe('logout', ()=> {
  test('can not find user', () => {
    expect(Logout()).toBe(false)
  })
})