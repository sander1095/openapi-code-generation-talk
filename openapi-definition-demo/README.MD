# Introduction
This demo shows off the basics of OpenAPI and tooling.

## Setup
```
# To run the HTTP server and Prism Mock API
npm install
npm start
```

Swagger will run on http://localhost:8080.  
Redocly will run on http://localhost:8090.

If you want to regenerate redocly, call `npx @redocly/cli build-docs ../swagger/conference_openapi.yml` in the `redocly` folder.

## Demo content
Demo the `conference_openapi.yaml` which contains a simple demo definition + some security schemes.

Then demonstrate Swagger:

- Example request/response
- Multiple status code options
- Showcase schema's on the button
- Try out request (doesn't work -> 401)
- Security
  - Microsoft login (not working)
  - API key
- Try out requests
- , including (not working) microsoft login.

Then demonstrate redocly with their 3 lane view.