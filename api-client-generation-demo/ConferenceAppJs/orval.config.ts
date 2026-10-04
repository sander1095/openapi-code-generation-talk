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
    },
  },
});
