using Kiota.KiotaApiClient;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

var authProvider = new ApiKeyAuthenticationProvider("APIKEY", "X-API-KEY", ApiKeyAuthenticationProvider.KeyLocation.Header);
// Create request adapter using the HttpClient-based implementation
var adapter = new HttpClientRequestAdapter(authProvider, httpClient: new HttpClient() { BaseAddress = new("http://localhost:4010") });
// Create the API client
var client = new ConferenceApiClient(adapter);

try
{
    // GET /talks
    var allTalks = await client.Talks.GetAsync();
    Console.WriteLine($"Retrieved {allTalks?.Count} talks.");

    // GET /talks/{id}
    var specificTalkId = 3;
    var specificTalk = await client.Talks[specificTalkId].GetAsync();
    Console.WriteLine($"Retrieved Talk - ID: {specificTalk?.Id}, Title: {specificTalk?.Title}");
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
    Console.WriteLine(ex.StackTrace);
}