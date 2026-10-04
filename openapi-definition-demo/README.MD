# Introduction
This demo shows off the basics of OpenAPI and tooling.

## Setup
```
# To run the HTTP server and Prism Mock API
npm install
npm start
```

Swagger UI will run on http://localhost:8080.  
Scalar will run on http://localhost:8090.

## Demo content
Demo the `conference_openapi.yaml` which contains a simple demo definition + some security schemes.

Then demonstrate Swagger UI:

- Example request/response
- Multiple status code options
- Showcase schema's on the button
- Try out request (doesn't work -> 401)
- Security
  - Microsoft login (not working)
  - API key
- Try out requests
- , including (not working) microsoft login.

Then demonstrate Scalar with its 3 pane view and built-in API client.

Then demonstrate Postman by importing a collection (URL or content) and it generating an entire collection for you