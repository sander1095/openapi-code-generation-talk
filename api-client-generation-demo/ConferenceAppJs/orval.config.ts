import { defineConfig } from 'orval';

// https://orval.dev/reference/configuration/overview
export default defineConfig({
  conference: {
    input: {
      target: 'https://localhost:7135/openapi/v1.json',
    },
    output: {
      target: 'src/clients/orval/conference.ts',
      client: 'fetch',
      baseUrl: 'https://localhost:7135',
      clean: true,
      override: {
        // NSwag builds operation ids as `Talks_GetTalks`, which would generate `talksGetTalks()`.
        // `operationName` is Orval's equivalent of an NSwag operation name generator. Returning a
        // tuple sets the function name and the base name used for the generated types separately.
        // https://orval.dev/reference/configuration/output#operationname
        operationName: (operation, route, verb) => {
          const operationId = operation.operationId ?? `${verb}-${route}`;
          const typeName = operationId.split('_').pop()!;
          const functionName = typeName.charAt(0).toLowerCase() + typeName.slice(1);
          return [functionName, typeName];
        },
      },
    },
  },
});
