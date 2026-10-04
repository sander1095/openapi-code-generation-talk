// Browsers block fetching files from file:// pages, so the Swagger UI and Scalar pages load the
// OpenAPI definition through a <script> tag. This script embeds conference_openapi.yml in that file.
import { readFile, writeFile } from 'node:fs/promises';
import { parse } from 'yaml';

const definition = parse(await readFile(new URL('../conference_openapi.yml', import.meta.url), 'utf8'));

await writeFile(
  new URL('../conference_openapi.js', import.meta.url),
  `// Generated from conference_openapi.yml by \`npm run build-spec\`. Do not edit.\n` +
    `window.conferenceOpenApi = ${JSON.stringify(definition, null, 2)};\n`,
);
