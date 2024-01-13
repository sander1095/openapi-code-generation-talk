dotnet kiota generate -l csharp `
					  --openapi "conference_api.json" `
					  -o .\ConferenceApp\Clients\Kiota `
					  -n ConferenceApp.Clients.Kiota `
					  -c KiotaConferenceClient