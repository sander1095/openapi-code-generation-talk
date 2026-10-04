# Introduction
This demo shows off NSwag and Kiota for .NET, and openapi-typescript (+ openapi-fetch), Hey API and Orval for JavaScript/TypeScript.

## Setup
```
winget install RicoSuter.NSwagStudio
dotnet tool restore
dotnet dev-certs https --trust
cd ConferenceAppJs
npm install
```

Also install the kiota extension in vscode

- See the `Prebuild` folder for win64 published apps.
- Run `start-prebuild-projects.ps1` in the `Scripts` folder to start all the projects.
- Open the Controllers project Scalar page: https://localhost:7135/scalar
- Open the Minimal API project Scalar page: https://localhost:7202/scalar
- The OpenAPI 3.1 documents are available at `/openapi/v1.json` on both servers.

## Demo content

### Servers
- Before demoing the API client generation, let's take a look at what kind of API client we'll be generating
- Demo the Servers (both Minimal API and controllers, run Controllers with HTTPs!)
  - Talk about ProducesResponseType, OpenAPIAnalyzers, Visual Studio API client generation
  - Talk about Minimal API extension methods, TypedResults
  - Talk about Microsoft.AspNetCore.OpenApi, OpenAPI 3.1 and Scalar
  - Talk about operationIds: `[EndpointName]` (controllers) and `.WithName()` (Minimal API) set them (`Talks_GetTalks`). Code generators turn them into method names.

### NSwag
- Have the controllers running on HTTPS
- Demo nswagcli (thanks to .NET tool, but also other options available)
- Demo NSwagStudio and use the OpenAPI document URL (https://localhost:7135/openapi/v1.json)
  - Talk about .nswag file, also other ways to generate with NSwag
- Show off client usage.

### Kiota
- Have the controllers running on HTTPS
- Show off vscode kiota (github)
- Show off CLI (tree, generation)

- Demo the client,at least in code.

### JavaScript / TypeScript
- Have the controllers running on HTTPS
- Run `npm run generate` in `ConferenceAppJs` (or `Scripts/generate-js-clients.ps1`) to generate all clients
  - `openapi-typescript`: generates only types, used by the tiny `openapi-fetch` runtime
  - Hey API (`openapi-ts.config.ts`): generates an SDK with a function per operation
  - Orval (`orval.config.ts`): generates fetch functions, and can also generate TanStack Query/SWR hooks, Zod schemas and MSW mocks
- Run `npm start` in `ConferenceAppJs` to demo the clients
- Node.js doesn't trust the ASP.NET Core development certificate by default. `npm install` exports it to `.certs/aspnet-dev.pem` and the npm scripts pass it to Node.js with `NODE_EXTRA_CA_CERTS`.
