# nodejs example for property based testing

## Running the server

(make sure you have node installed)

* cd into `nodejs` directory
* `npm install`
* `npm start`

## Testing

* `npm test`
* to run tests on file save - `npm test -- --watch`

## Endpoints

### GET /users

Gets all users

`curl --request GET --url http://localhost:3000/users`

### GET /users/:id

Gets a single user matching that ID

`curl --request GET --url http://localhost:3000/users/1`

### POST /users/:id

Updates a user with the given request body (must have content type JSON)

```
curl --request POST \
  --url http://localhost:3000/users/1 \
  --header 'content-type: application/json' \
  --data '{"Name":"Jimmy Bondies","Age":40,"Occupation":"classified"}'
```
