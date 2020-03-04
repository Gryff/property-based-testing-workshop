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

module.exports = app
