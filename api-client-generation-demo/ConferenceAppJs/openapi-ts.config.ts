import { defineConfig } from '@hey-api/openapi-ts';

// https://heyapi.dev/openapi-ts/configuration
export default defineConfig({
  input: 'https://localhost:7135/openapi/v1.json',
  output: 'src/clients/hey-api',
  plugins: ['@hey-api/client-fetch', '@hey-api/typescript', '@hey-api/sdk'],
});
