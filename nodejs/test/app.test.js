const request = require('supertest')
const fc = require('fast-check')

const app = require('../src/app')

describe('app', () => {
  it('what property should I test?', done => {
    // this is how you can hit the server endpoints
    request(app)
      .get('/users')
      .then(result => {
        const users = result.body
        // do some stuff?
        done()
      })
      .catch(done)
  })

  // here's an idea for a property
  // the /users/:id endpoint should always return either a 200 or a 404
  // try and set up that test using fast-check and supertest and see if it's true :)
})
