# Introduction
This demo shows off the basics of OpenAPI and tooling.

## Setup
```
# To run the HTTP server and Prism Mock API
npm install
npm start
```

Swagger UI will run on http://localhost:8080/swagger/.  
Scalar will run on http://localhost:8080/scalar/.  
The Prism mock API will run on http://localhost:4010.

You can also open `swagger/index.html` and `scalar/index.html` straight from disk. Browsers block pages on `file://` from fetching other files, so both pages load the definition from `conference_openapi.js`, which `npm start` generates from `conference_openapi.yml`. Run `npm run build-spec` after changing the YAML file without restarting.

## Demo content
Demo the `conference_openapi.yml` which contains a simple demo definition + some security schemes.

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