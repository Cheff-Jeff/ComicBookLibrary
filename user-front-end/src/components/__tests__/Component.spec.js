import { describe, expect, it } from 'vitest'
import { mount } from '@vue/test-utils'

import BannerLeft from '../BannerLeft.vue'
import BannerRight from '../BannerRight.vue'
describe('banner render', ()=>{
  it('renders properly', ()=>{
    const wrapper = mount(BannerLeft, {
      props: {
        Title: 'Test',
        Heading: true,
      }
    })

    expect(wrapper.text()).toContain('Test')
  })
})

describe('banner render', ()=>{
  it('renders properly', ()=>{
    const wrapper = mount(BannerRight, {
      props: {
        Title: 'Test',
        Heading: true,
      }
    })

    expect(wrapper.text()).toContain('Test')
  })
})

import ComicDetail from '../ComicDetail.vue'
describe('banner render', ()=>{
  it('renders properly', ()=>{
    const wrapper = mount(ComicDetail, {
      props: {
        Title: 'Test',
        Descriptin: 'Description',
        Image: 'defaultComic.jpg',
        Publisher: 'Marvel',
        Writer: 'Stan Lee',
        Artist: 'Dan Man',
        CoverArtist: 'Jeffrey'
      }
    })

    expect(wrapper.text()).toContain('Test')
    expect(wrapper.text()).toContain('Description')
    expect(wrapper.text()).toContain('Marvel')
    expect(wrapper.text()).toContain('Stan Lee')
    expect(wrapper.text()).toContain('Dan Man')
    expect(wrapper.text()).toContain('Jeffrey')
  })
})

import ComicMaster from '../ComicMaster.vue'
describe('banner render', ()=>{
  it('renders properly', ()=>{
    const wrapper = mount(ComicMaster, {
      props: {
        Title: 'Test',
        Image: 'defaultComic.jpg',
      }
    })

    expect(wrapper.text()).toContain('Test')
  })
})

import LoginForm from '../LoginForm.vue'
// describe('input switch', ()=>{
//   it('swtiches properly', ()=>{
//     const wrapper = mount(LoginForm)
//     wrapper.vm.switchInputType()
//     expect(wrapper.vm.passwordType).toBe('text')

//     wrapper.vm.switchInputType()
//     expect(wrapper.vm.passwordType).toBe('password')
//   })
// })

// describe('password validation', ()=>{
//   it('validates password properly', ()=>{
//     const wrapper = mount(LoginForm)
//     const password = 'adminadmin'
//     const badpassword = 'admin'

//     wrapper.find('input[name="password"]').setValue(password)
//     wrapper.vm.validatePassword()
//     expect(wrapper.vm.passwordError).toBe('')

//     wrapper.find('input[name="password"]').setValue(badpassword)
//     wrapper.vm.validatePassword()
//     expect(wrapper.vm.passwordError).toBe('Password must be at least 10 characters long.')

//     wrapper.find('input[name="password"]').setValue('')
//     wrapper.vm.validatePassword()
//     expect(wrapper.vm.passwordError).toBe('Password can not be empty.')
//   })
// })

// describe('email validation', ()=>{
//   it('validates email properly', ()=>{
//     const wrapper = mount(LoginForm)
//     const email = 'admin@adminmail.com'
//     const badEmail = 'admin'

//     wrapper.find('input[name="email"]').setValue(email)
//     wrapper.vm.checkEmail()
//     expect(wrapper.vm.emailError).toBe('')

//     wrapper.find('input[name="email"]').setValue(badEmail)
//     wrapper.vm.checkEmail()
//     expect(wrapper.vm.emailError).toBe(`${badEmail} is not an email.`)

//     wrapper.find('input[name="email"]').setValue('')
//     wrapper.vm.checkEmail()
//     expect(wrapper.vm.emailError).toBe('Email can not be empty.')
//   })
// })

import RegisterForm from '../RegisterForm.vue'
// describe('input switch', ()=>{
//   it('swtiches properly', ()=>{
//     const wrapper = mount(RegisterForm)
//     wrapper.vm.switchInputType()
//     expect(wrapper.vm.passwordType).toBe('text')

//     wrapper.vm.switchInputType()
//     expect(wrapper.vm.passwordType).toBe('password')

//     wrapper.vm.switchInputTypeRepeat()
//     expect(wrapper.vm.rePasswordType).toBe('text')

//     wrapper.vm.switchInputTypeRepeat()
//     expect(wrapper.vm.rePasswordType).toBe('password')
//   })
// })

// describe('password validation', ()=>{
//   it('validates password properly', ()=>{
//     const wrapper = mount(RegisterForm)
//     const password = 'adminadmin'
//     const badpassword = 'admin'

//     wrapper.find('input[name="password"]').setValue(password)
//     wrapper.vm.validatePassword()
//     expect(wrapper.vm.passwordError).toBe('')

//     wrapper.find('input[name="password"]').setValue(badpassword)
//     wrapper.vm.validatePassword()
//     expect(wrapper.vm.passwordError).toBe('Password must be at least 10 characters long.')

//     wrapper.find('input[name="password"]').setValue('')
//     wrapper.vm.validatePassword()
//     expect(wrapper.vm.passwordError).toBe('Password can not be empty.')
//   })
// })

// describe('password validation', ()=>{
//   it('validates rePassword properly', ()=>{
//     const wrapper = mount(RegisterForm)
//     const password = 'adminadmin'
//     const rePassword = 'adminadmin'
//     const badrePassword = 'adminadmin2'
//     const badpassword = 'admin'

//     wrapper.find('input[name="password"]').setValue(password)
//     wrapper.find('input[name="repeatPassword"]').setValue(rePassword)
//     wrapper.vm.validatePasswordRepeat()
//     expect(wrapper.vm.rePasswordError).toBe('')

//     wrapper.find('input[name="repeatPassword"]').setValue(badpassword)
//     wrapper.vm.validatePasswordRepeat()
//     expect(wrapper.vm.rePasswordError).toBe('Password must be at least 10 characters long.')

//     wrapper.find('input[name="repeatPassword"]').setValue('')
//     wrapper.vm.validatePasswordRepeat()
//     expect(wrapper.vm.rePasswordError).toBe('Password can not be empty.')

//     wrapper.find('input[name="repeatPassword"]').setValue(badrePassword)
//     wrapper.vm.validatePasswordRepeat()
//     expect(wrapper.vm.rePasswordError).toBe('Confirm password must match.')
//   })
// })

// describe('email validation', ()=>{
//   it('validates email properly', ()=>{
//     const wrapper = mount(RegisterForm)
//     const email = 'admin@adminmail.com'
//     const badEmail = 'admin'

//     wrapper.find('input[name="email"]').setValue(email)
//     wrapper.vm.checkEmail()
//     expect(wrapper.vm.emailError).toBe('')

//     wrapper.find('input[name="email"]').setValue(badEmail)
//     wrapper.vm.checkEmail()
//     expect(wrapper.vm.emailError).toBe(`${badEmail} is not an email.`)

//     wrapper.find('input[name="email"]').setValue('')
//     wrapper.vm.checkEmail()
//     expect(wrapper.vm.emailError).toBe('Email can not be empty.')
//   })
// })

// describe('validate name', ()=>{
//   it('validate first name', ()=>{
//     const wrapper = mount(RegisterForm)
//     const name = 'Jeffrey'
//     const badName = 'Jeff24'

//     wrapper.find('input[name="firstName"]').setValue(name)
//     wrapper.vm.validateFirstName()
//     expect(wrapper.vm.firstNameError).toBe('')
    
//     wrapper.find('input[name="firstName"]').setValue(badName)
//     wrapper.vm.validateFirstName()
//     expect(wrapper.vm.firstNameError).toBe(`${badName} is not a name.`)

//     wrapper.find('input[name="firstName"]').setValue('')
//     wrapper.vm.validateFirstName()
//     expect(wrapper.vm.firstNameError).toBe(`Name can not be empty.`)
//   })
// })

// describe('validate name', ()=>{
//   it('validate last name', ()=>{
//     const wrapper = mount(RegisterForm)
//     const name = 'Nijkamp'
//     const badName = 'Jeff24'

//     wrapper.find('input[name="lastname"]').setValue(name)
//     wrapper.vm.validateLastName()
//     expect(wrapper.vm.lastNameError).toBe('')
    
//     wrapper.find('input[name="lastname"]').setValue(badName)
//     wrapper.vm.validateLastName()
//     expect(wrapper.vm.lastNameError).toBe(`${badName} is not a name.`)

//     wrapper.find('input[name="lastname"]').setValue('')
//     wrapper.vm.validateLastName()
//     expect(wrapper.vm.lastNameError).toBe(`Name can not be empty.`)
//   })
// })