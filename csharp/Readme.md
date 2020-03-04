# Users API, C# Version

Users are stored in `resources\users.json`

## Get all users

```
curl --request GET \
  --url http://localhost:51967/user
```

## Get a single user

```
curl --request GET \
  --url http://localhost:51967/user/1
```

## Update a user
```
curl --request POST \
  --url http://localhost:51967/user/1 \
  --header 'content-type: application/json' \
  --data '{"Name":"R.J. MacReady","Age":30,"Occupation":"Helicopter Pilot"}'
```