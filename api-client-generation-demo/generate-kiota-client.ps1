dotnet kiota generate -l csharp `
					  --openapi "kiota\conference_openapi.yaml" `
					  -o .\kiota\KiotaApiClient `
					  -n ConferenceApp.Clients.Kiota `
					  -c KiotaConferenceClient