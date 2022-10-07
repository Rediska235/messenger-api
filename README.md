# Messenger API
> ASP.NET Core Web API project

## Explanation

In this application you will be able to read and create users, chats between them and messages in these chats.


## Methods
### User
- get all users
- get user by id
- get all users by chat
- create user
- delete user

### Chat
- get all chats
- get all chats by user
- create chat

### Message
- get all messages by chat
- create message


## Examples
<details>
  <summary> <h4> Get all chats by user </h4> </summary>
  
Request URL: 
```
(GET) http://localhost:5215/Chat/pedro
```

Response body:
```
[
  {
    "id": 7,
    "name": "triple P",
    "createdAt": "2022-10-04T23:13:13.6108696"
  },
  {
    "id": 8,
    "name": "alice - pedro",
    "createdAt": "2022-10-04T23:13:54.2015528"
  },
  {
    "id": 10,
    "name": "general",
    "createdAt": "2022-10-05T11:43:37.6211542"
  }
]
```
</details>
<details>
  <summary> <h4> Create message </h4> </summary>
  
Request URL: 
```
(POST) http://localhost:5215/Message
```
Body: 
```
{
  "chat": "general", 
  "author": "bob", 
  "text": "Hello world"
}
```

Response body:
```
{
  "id": 18,
  "chat": {
    "id": 10,
    "name": "general",
    "createdAt": "2022-10-05T11:43:37.6211542"
  },
  "author": {
    "id": 12,
    "username": "bob",
    "createdAt": "2022-10-05T11:09:23.5516488"
  },
  "text": "Hello world",
  "createdAt": "2022-10-05T22:37:57.9222366+03:00"
}
```
</details>
<details>
  <summary> <h4> Get all messages by chat </h4> </summary>
  
Request URL: 
```
(GET) http://localhost:5215/Message/general
```

Response body:
```
[
  {
    "author": "alice",
    "text": "Hi"
  },
  {
    "author": "bob",
    "text": "Hello world"
  }
]
```
</details>

