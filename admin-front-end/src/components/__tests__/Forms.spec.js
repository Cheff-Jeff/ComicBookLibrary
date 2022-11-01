import { describe, it, expect } from 'vitest'
import { mount } from '@vue/test-utils'

/* Test name forms component */
import ArtistsForm from '../forms/ArtistsForm.vue'
describe('Artist form', ()=>{
  it('renders properly', ()=>{
    const value   = 'Test'
    const id      = 1
    const api     = 'post'
    const wrapper = mount(ArtistsForm, {
      props: {
        Value: value,
        Id: id,
        apiType: api
      }
    })

    expect(wrapper.find('input[type="hidden"]').element.value).toBe(`${id}`)
    expect(wrapper.find('input[type="text"]').element.value).toBe(value)
  })
})

describe('title validation', ()=>{
  it('validates title', ()=>{
    const wrapper = mount(ArtistsForm, {
      props: {
        apiType: 'post'
      }
    })
    const title = 'Kuifje'
    const badTitle = 'Kuifje2'

    wrapper.find('input[type="text"]').setValue(title)
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe('')

    wrapper.find('input[type="text"]').setValue(badTitle)
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe(`${badTitle} is not a name.`)
    
    wrapper.find('input[type="text"]').setValue('')
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe('Name can not be empty.')
  })
})

import WriterForm from '../forms/WriterForm.vue'
describe('Writer form', ()=>{
  it('renders properly', ()=>{
    const value   = 'Test'
    const id      = 1
    const api     = 'post'
    const wrapper = mount(WriterForm, {
      props: {
        Value: value,
        Id: id,
        apiType: api
      }
    })

    expect(wrapper.find('input[type="hidden"]').element.value).toBe(`${id}`)
    expect(wrapper.find('input[type="text"]').element.value).toBe(value)
  })
})

describe('title validation', ()=>{
  it('validates title', ()=>{
    const wrapper = mount(WriterForm, {
      props: {
        apiType: 'post'
      }
    })
    const title = 'Kuifje'
    const badTitle = 'Kuifje2'

    wrapper.find('input[type="text"]').setValue(title)
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe('')

    wrapper.find('input[type="text"]').setValue(badTitle)
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe(`${badTitle} is not a name.`)
    
    wrapper.find('input[type="text"]').setValue('')
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe('Name can not be empty.')
  })
})

import PublicherForm from '../forms/PublicherForm.vue'
describe('Publicher form', ()=>{
  it('renders properly', ()=>{
    const value   = 'Test'
    const id      = 1
    const api     = 'post'
    const wrapper = mount(PublicherForm, {
      props: {
        Value: value,
        Id: id,
        apiType: api
      }
    })

    expect(wrapper.find('input[type="hidden"]').element.value).toBe(`${id}`)
    expect(wrapper.find('input[type="text"]').element.value).toBe(value)
  })
})

describe('title validation', ()=>{
  it('validates title', ()=>{
    const wrapper = mount(PublicherForm, {
      props: {
        apiType: 'post'
      }
    })
    const title = 'Kuifje'
    const badTitle = 'Kuifje2'

    wrapper.find('input[type="text"]').setValue(title)
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe('')

    wrapper.find('input[type="text"]').setValue(badTitle)
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe(`${badTitle} is not a name.`)
    
    wrapper.find('input[type="text"]').setValue('')
    wrapper.vm.validate()
    expect(wrapper.vm.nameError).toBe('Name can not be empty.')
  })
})

/*
end name forms
test login form
*/

import LoginForm from '../forms/LoginForm.vue'
describe('form rendes properly', ()=>{
  it('renders email', ()=>{
    const wrapper = mount(LoginForm)
    const email = '1999jeffreynijkamp@gmail.com'
    wrapper.find('input[type="email"]').setValue(email)

    expect(wrapper.find('input[type="email"]').element.value).toBe(email)
  })
})

describe('email validation', ()=>{
  it('validates email properly', ()=>{
    const wrapper = mount(LoginForm)
    const email = '1999jeffreynijkamp@gmail.com'
    const badEmail = '1999jeffreynijkamp'
    
    wrapper.find('input[type="email"]').setValue(email)
    wrapper.vm.checkEmail()
    expect(wrapper.vm.emailError).toBe('')

    wrapper.find('input[type="email"]').setValue(badEmail)
    wrapper.vm.checkEmail()
    expect(wrapper.vm.emailError).toBe(`${badEmail} is not an email.`)

    wrapper.find('input[type="email"]').setValue('')
    wrapper.vm.checkEmail()
    expect(wrapper.vm.emailError).toBe(`Email can not be empty.`)
  })
})

describe('input type switch', ()=>{
  it('switches input type properly', ()=>{
    const wrapper = mount(LoginForm)

    wrapper.vm.switchInputType()
    expect(wrapper.vm.passwordType).toBe('text')

    wrapper.vm.switchInputType()
    expect(wrapper.vm.passwordType).toBe('password')
  })
})

describe('password validation', ()=>{
  it('validates password properly', ()=>{
    const wrapper = mount(LoginForm)
    const passowrd = 'adminadmin'
    const badPassowrd = 'admin'

    wrapper.find('input[name="password"]').setValue(passowrd)
    wrapper.vm.validatePassword()
    expect(wrapper.vm.passwordError).toBe('')

    wrapper.find('input[name="password"]').setValue(badPassowrd)
    wrapper.vm.validatePassword()
    expect(wrapper.vm.passwordError).toBe('Password must be at least 10 characters long.')
    
    wrapper.find('input[name="password"]').setValue('')
    wrapper.vm.validatePassword()
    expect(wrapper.vm.passwordError).toBe('Password can not be empty.')
  })
})