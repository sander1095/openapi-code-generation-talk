# Introduction
This demo shows off the basics of OpenAPI and tooling.

## Setup
```
winget install Python.Python.3.12 # To run the python http server
npm install # to run the OpenAPI Mock API
```

## Demo content
`conference_openapi.yaml` contains a simple demo definition + some security schemes.

Call `run-demo.ps1` to run the `prism` mock server and and HTTP server.

Take a look at the swagger UI and then demonstrate the security features, including (not working) microsoft login.