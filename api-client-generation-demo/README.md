# Introduction
This demo shows off Kiota and NSwag

## Setup
```
winget install RicoSuter.NSwagStudio
dotnet tool restore
```

Also install the kiota extension in vscode

- See the `Prebuild` folder for win64 published apps.
- Run `start-prebuild-projects.ps1` in the `Scripts` folder to start all the projects.
- Open the Controllers project Swagger page: https://localhost:7135/swagger
- Open the Controllers project Swagger page: https://localhost:7202/swagger

## Demo content

### Servers
- Before demoing the API client generation, let's take a look at what kind of API client we'll be generating
- Demo the Servers (both Minimal API and controllers, run Controllers with HTTPs!)
  - Talk about ProducesResponseType, OpenAPIAnalyzers, Visual Studio API client generation
  - Talk about Minimal API extension methods, TypedResults

### NSwag
- Have the controllers running on HTTPS
- Demo nswagcli (thanks to .NET tool, but also other options available)
- Demo NSwagStudio and use the Swagger URL (https://localhost:7135/swagger/v1/swagger.json)
  - Talk about .nswag file, also other ways to generate with NSwag
- Show off client usage.
- 
### Kiota
- Have the controllers running on HTTPS
- Show off vscode kiota (github)
- Show off CLI (tree, generation)

- Demo the client,at least in code.