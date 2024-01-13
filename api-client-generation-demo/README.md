# Introduction
This demo shows off Kiota and NSwag

## Setup
```
winget install RicoSuter.NSwagStudio
dotnet tool restore
```

Also install the kiota extension in vscode

## Demo content
**TODO: CREATE SCRIPT TO START UP EVERYTHING**

### Servers
- Before demoing the API client generation, let's take a look at what kind of API client we'll be generating
- Demo the Servers (both Minimal API and controllers, run Controllers with HTTPs!)
  - Talk about ProducesResponseType, OpenAPIAnalyzers, Visual Studio API client generation
  - Talk about Minimal API extension methods, TypedResults

### NSwag
- Have the controllers running on HTTPS
- Demo nswagcli (thanks to .NET tool, but also other options available)
  - TODO: What is the nswag CLI for generating?
- Demo NSwagStudio and use the Swagger URL (https://localhost:7135/swagger/v1/swagger.json)
  - Talk about .nswag file, also other ways to generate with NSwag

- Show off client usage.
### Kiota
- Have the controllers running on HTTPS
- Show off CLI (tree, generation)
- Show off vscode kiota

- Demo correct C# (minimal API + controllers + the analyzers)
- Demo the client,at least in code.
- Demo kiota with CLI options with openapi_conference.yml
- Demo kiota with visual studio code extension (demo github searching)
- demo setting up call (opinionated)