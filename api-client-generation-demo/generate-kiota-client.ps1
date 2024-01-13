dotnet kiota generate --clean-output `
					  --language csharp `
					  --openapi "https://localhost:7135/swagger/v1/swagger.json" `
					  -o ConferenceApp/Clients/Kiota `
					  -n ConferenceApp.Clients.Kiota `
					  -c KiotaConferenceClient