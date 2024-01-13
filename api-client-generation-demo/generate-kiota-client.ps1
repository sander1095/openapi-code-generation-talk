dotnet kiota generate -l csharp `
					  --openapi "kiota\conference_openapi.yaml" `
					  -o .\kiota\KiotaApiClient `
					  -n Kiota.KiotaApiClient `
					  -c ConferenceApiClient