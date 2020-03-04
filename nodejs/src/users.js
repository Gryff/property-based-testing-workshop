const users = [
  { id: 1, name: 'James Bond', age: 40, occupation: 'classified' },
  { id: 2, name: 'Avril Lavigne', age: 30, occupation: 'rock star' },
  { id: 3, name: 'Adam Neumann', age: 40, occupation: 'putting wework on Mars' }
]

module.exports = {
  all: () => users,
  get: id => users.find(user => user.id === id),
  update: (id, data) => {
    const userPosition = users.findIndex(user => user.id === id)
    users[userPosition] = Object.assign({}, users[userPosition], data)
  }
}
