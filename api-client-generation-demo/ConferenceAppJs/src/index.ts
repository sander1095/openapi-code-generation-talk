import { createInterface } from 'node:readline/promises';
import createClient from 'openapi-fetch';
import type { paths } from './clients/openapi-typescript/schema.js';
import * as heyApi from './clients/hey-api/index.js';
import * as orval from './clients/orval/conference.js';

const baseUrl = 'https://localhost:7135'; // Talk with the Controllers API

const readline = createInterface({ input: process.stdin, output: process.stdout });
await readline.question('Press enter to start the demo app');
readline.close();

console.log('------OPENAPI-TYPESCRIPT + OPENAPI-FETCH------');
{
  // openapi-typescript only generates types. openapi-fetch is a tiny fetch wrapper that uses them,
  // so URLs, path parameters, request bodies and responses are all checked by the compiler.
  const client = createClient<paths>({ baseUrl });

  const { data: talks } = await client.GET('/api/talks');
  console.log(`openapi-fetch returned ${talks?.length} talks`);

  const { data: talk } = await client.GET('/api/talks/{id}', { params: { path: { id: 1 } } });
  console.log(`openapi-fetch returned a talk with title: ${talk?.title} for Id: 1`);

  // Errors are typed too: `error` is the ProblemDetails schema of the 404 response.
  const { error, response } = await client.GET('/api/talks/{id}', { params: { path: { id: 999 } } });
  console.log(`openapi-fetch returned ${response.status} with ProblemDetails status ${error?.status} for Id: 999`);

  console.log('Creating new talk with openapi-fetch');
  const { data: newTalk } = await client.POST('/api/talks', { body: { title: 'openapi-fetch is awesome!' } });
  console.log(`openapi-fetch returned a new talk with ID ${newTalk?.id}`);
}
console.log('----------------------------------------------');
console.log('------HEY API------');
{
  // Hey API generates an SDK function per operationId. The client's baseUrl comes from the
  // `servers` in the OpenAPI document, and can be changed with `client.setConfig()`.
  const { data: talks } = await heyApi.talksGetTalks();
  console.log(`Hey API returned ${talks?.length} talks`);

  const { data: talk } = await heyApi.talksGetTalk({ path: { id: 1 } });
  console.log(`Hey API returned a talk with title: ${talk?.title} for Id: 1`);

  console.log('Creating new talk with Hey API');
  // `throwOnError` turns error responses into exceptions, which narrows `data` to `Talk`.
  const { data: newTalk } = await heyApi.talksCreateTalk({ body: { title: 'Hey API is awesome!' }, throwOnError: true });
  console.log(`Hey API returned a new talk with ID ${newTalk.id}`);
}
console.log('-------------------');
console.log('------ORVAL------');
{
  // Orval generates a fetch function per operationId that returns `{ data, status, headers }`.
  // It can also generate TanStack Query / SWR hooks, Zod schemas and MSW mocks from the same document.
  const talks = await orval.talksGetTalks();
  console.log(`Orval returned ${talks.data.length} talks`);

  const talk = await orval.talksGetTalk(1);
  if (talk.status === 200) {
    // Checking the status narrows `data` from `Talk | ProblemDetails` to `Talk`.
    console.log(`Orval returned a talk with title: ${talk.data.title} for Id: 1`);
  }

  console.log('Creating new talk with Orval');
  const newTalk = await orval.talksCreateTalk({ title: 'Orval is awesome!' });
  if (newTalk.status === 200) {
    console.log(`Orval returned a new talk with ID ${newTalk.data.id}`);
  }
}
console.log('-----------------');
