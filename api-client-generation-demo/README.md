# Introduction
This demo shows off Kiota and NSwag

## Setup
```
winget install RicoSuter.NSwagStudio
dotnet tool restore
```

Also install the kiota extension in vscode

## Demo content
- Demo the Servers (both Minimal API and controllers, run Controllers with HTTPs!)
  - Talk about ProducesResponseType, OpenAPIAnalyzers, Visual Studio API client generation

- Demo NSwagStudio with the openapi_conference.yml
  - Also talk about being able to generate client based on the api explorer
- Demo correct C# (minimal API + controllers + the analyzers)
- Demo the client,at least in code.
- Demo kiota with CLI options with openapi_conference.yml
- Demo kiota with visual studio code extension (demo github searching)
- demo setting up call (opinionated)