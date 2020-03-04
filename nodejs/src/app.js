const express = require('express')
const bodyParser = require('body-parser')

const users = require('./users')

const app = express()
app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: false }))

app.get('/users', (req, res) => {
  res.json(users.all())
})

app.get('/users/:id', (req, res) => {
  res.json(users.get(req.params.id))
})

app.post('/users/:id', (req, res) => {
  users.update(parseInt(req.params.id), req.body)
  res.status(200)
  res.send('updated')
})

app.use('*', (req, res, next) => {
  console.error('uh oh, someone hit an endpoint that doesnt exist')
  res.status(404)
  res.send('uh oh, someone hit an endpoint that doesnt exist')
})

app.use((err, req, res, next) => {
  console.error(`uh oh, an error happened! ${err.message} at ${err.stack}`)
  res.status(500)
  res.send()
})

module.exports = app
