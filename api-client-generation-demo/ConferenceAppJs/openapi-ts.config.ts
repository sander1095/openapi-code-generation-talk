import { defineConfig } from '@hey-api/openapi-ts';

// https://heyapi.dev/openapi-ts/configuration
export default defineConfig({
  input: 'https://localhost:7135/openapi/v1.json',
  output: 'src/clients/hey-api',
  plugins: [
    '@hey-api/client-fetch',
    '@hey-api/typescript',
    {
      name: '@hey-api/sdk',
      operations: {
        // NSwag builds operation ids as `Talks_GetTalks`, which would generate `talksGetTalks()`.
        // `methodName` is Hey API's equivalent of an NSwag operation name generator; the configured
        // casing (camelCase by default) is applied after this transform.
        // https://heyapi.dev/openapi-ts/output/sdk#method-names
        methodName: (name) => name.split('_').pop()!,
      },
    },
  ],
});
