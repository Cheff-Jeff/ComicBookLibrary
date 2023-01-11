import Chance from 'chance';
const chance = new Chance();

describe('My First Test', () => {
  it('visits the app root url', () => {
    cy.visit('/')
    cy.contains('What’s new this week?')
    cy.contains('Popular comis this month.')
  })
})

describe('Test routing gourd', () => {
  it('Blocks protected account route', () => {
    cy.visit('/account')
    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/login`)
  })
})

describe('Test comic detail', () => {
  it('Blocks protected comic detail route', () => {
    cy.visit('/comics/10101010')
    cy.contains('p','You broke something!')
  })
  it('Visits comic detail page', () => {
    cy.visit('/')
    cy.get('section.new .inner').first().click()
    cy.contains('button', 'Add to library')
  })
})

describe('Test register', () => {
  const fName = chance.first();
  const lName = chance.last();
  const email = chance.email({domain: "example.com"})
  const password = 'jeffreynijkamp'
  const Rpassword = 'jeffreynijkamp'
  it('register user properly', () => {
    cy.visit('/registration')

    cy.get('input[name="firstName"]').type(fName)
    cy.get('input[name="lastname"]').type(lName)
    cy.get('input[name="email"]').type(email)
    cy.get('input[name="password"]').type(password)
    cy.get('input[name="repeatPassword"]').type(Rpassword)

    cy.get('button[type="submit"]').click();
    cy.wait(500)
    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/account`)
  })

  it('signs off', () => {
    cy.visit('/account')

    cy.get('button').contains('Logout').click()

    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/`)
  })

  it('login user properly', () => {
    cy.visit('/login')

    cy.get('input[name="email"]').type(email)
    cy.get('input[name="password"]').type(password)

    cy.get('button[type="submit"]').click();
    // cy.wait(500)
    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/account`)

    cy.get('button').contains('Logout').click()
    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/`)
  })
})

describe('Library', () => {
  const fName = chance.first();
  const lName = chance.last();
  const email = chance.email({domain: "example.com"})
  const password = 'jeffreynijkamp'
  const Rpassword = 'jeffreynijkamp'
  it('signing up', () => {
    cy.visit('/')
    cy.get('nav span').contains('Sign up').click()
    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/registration`)

    cy.get('input[name="firstName"]').type(fName)
    cy.get('input[name="lastname"]').type(lName)
    cy.get('input[name="email"]').type(email)
    cy.get('input[name="password"]').type(password)
    cy.get('input[name="repeatPassword"]').type(Rpassword)

    cy.get('button[type="submit"]').click();
    cy.wait(500)
    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/account`)
  })
  it('can add item to library', () => {
    cy.get('button').contains('My library').click()
    cy.contains('p', "You haven't got any comics in your collection yet.")

    cy.get('a').contains('Browse comics').click()
    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/comics`)

    cy.get('section.comics .comic').first().children('a').click({force: true})
    cy.get('button').contains('Add to library').click()
    cy.wait(300)
    cy.get('nav span').contains('Account').click()
    cy.contains('button', 'remove comic')
  })
  it('can remove item from library', () => {
    cy.get('button').contains('My library').click()
    cy.get('button').contains('remove comic').click()
    cy.contains('p', "You haven't got any comics in your collection yet.")
  })
  it('signs off', () => {
    cy.visit('/account')

    cy.get('button').contains('Logout').click()

    cy.url().should('be.equal', `${Cypress.config("baseUrl")}/`)
  })
})