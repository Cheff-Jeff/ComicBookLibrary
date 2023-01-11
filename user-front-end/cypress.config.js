const { defineConfig } = require('cypress')

module.exports = defineConfig({
  projectId: "x6y8x3",
  e2e: {
    specPattern: 'cypress/e2e/**/*.{cy,spec}.{js,jsx,ts,tsx}',
    baseUrl: 'http://localhost:8082'
  }
})
