import { describe, expect, test } from 'vitest'
import { validateEmail, validateName, validateTitle } from '../../assets/javascript/validation'
describe('ValidateEmailHappyFlow', () => {
  test('Validates email', () => {
    expect(validateEmail('admin@adminmail.com')).toBe(true)
  })
})

describe('ValidateEmailBadFlow', () => {
  test('Validates bad email', () => {
    expect(validateEmail('test')).toBe(false)
  })
})

describe('ValidateNameHappyFlow', () => {
  test('Validates name', () => {
    expect(validateName('Sir Ian McKellen')).toBe(true)
  })
})

describe('ValidateNameBadFlow', () => {
  test('Validates bad name', () => {
    expect(validateName('Sir Ian McKellen㋡')).toBe(false)
  })
})

describe('ValidateTitleBadFlow', () => {
  test('Validates bad title', () => {
    expect(validateTitle('Amazing Spider-man #2㋡')).toBe(false)
  })
})

describe('ValidateTitleHappyFlow', () => {
  test('Validates title', () => {
    expect(validateTitle('Amazing Spider-man #2')).toBe(true)
  })
})