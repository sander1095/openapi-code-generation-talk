// See https://aka.ms/new-console-template for more information
using ConferenceApp.Clients.Kiota;
using ConferenceApp.Clients.NSwag;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

// Set up shared code between Kiota and NSwag
var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7135") // Talk with the Controllers API
};

Console.WriteLine("Press any key to start the demo app");
_ = Console.ReadKey();

Console.WriteLine("------NSWAG------");
{
    INSwagTalksClient nswagTalksClient = new NSwagTalksClient(httpClient);

    var nswagTalks = await nswagTalksClient.GetTalksAsync();
    Console.WriteLine($"NSwag API client returned {nswagTalks.Count} talks");
    var nswagTalk = await nswagTalksClient.GetTalkAsync(1);
    Console.WriteLine($"NSwag API client returned a talk with title: {nswagTalk.Title} for Id: 1");

    Console.WriteLine("Creating new talk with NSwag API Client");
    var newNSwagTalk = await nswagTalksClient.CreateTalkAsync(new CreateTalk { Title = "NSwag is awesome!" });
    Console.WriteLine($"NSwag's API client returned a new talk with ID {newNSwagTalk.Id}");
}
Console.WriteLine("-----------------");
Console.WriteLine("------KIOTA------");
{
    var authenticationProvider = new AnonymousAuthenticationProvider();
    var adapter = new HttpClientRequestAdapter(authenticationProvider, httpClient: httpClient);
    var kiotaConferenceClient = new KiotaConferenceClient(adapter);

    // https://github.com/microsoft/kiota/issues/4004
    var kiotaTalks = await kiotaConferenceClient.Api.Talks.GetAsync();
    Console.WriteLine($"Kiota API client returned {kiotaTalks?.Count} talks");
    var kiotaTalk = await kiotaConferenceClient.Api.Talks[1].GetAsync();
    Console.WriteLine($"Kiota API client returned a talk with title: {kiotaTalk?.Title} for Id: 1");

    Console.WriteLine("Creating new talk with NSwag API Client");
    var newKiotaTalk = await kiotaConferenceClient.Api.Talks.PostAsync(new ConferenceApp.Clients.Kiota.Models.CreateTalk { Title = "Kiota is awesome!" });
    Console.WriteLine($"Kiota's API client returned a new talk with ID {newKiotaTalk?.Id}");
}

Console.WriteLine("-----------------");
Console.ReadKey();
