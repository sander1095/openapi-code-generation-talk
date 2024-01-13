// See https://aka.ms/new-console-template for more information
using ConferenceApp.Clients.NSwag;

// Set up shared code between Kiota and NSwag
var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7135")
};

Console.WriteLine("Press any key to start the demo app");
_ = Console.ReadKey();

Console.WriteLine("------NSWAG------");
ITalksClient nswagTalksClient = new TalksClient(httpClient);

var nswagTalks = await nswagTalksClient.GetTalksAsync();
Console.WriteLine($"NSwag API client returned {nswagTalks.Count} talks");
var nswagTalk = await nswagTalksClient.GetTalkAsync(1);
Console.WriteLine($"NSwag API client returned a talk with title: {nswagTalk.Title} for Id: 1");

Console.WriteLine("Creating new talk with NSwag API Client");
var newNSwagTalk = await nswagTalksClient.CreateTalkAsync(new CreateTalk { Title = "NSwag is awesome!" });
Console.WriteLine($"NSwag's API client returned a new talk with ID {newNSwagTalk.Id}");

Console.WriteLine("-----------------");
Console.WriteLine("------KIOTA------");
Console.WriteLine("-----------------");
Console.ReadKey();
