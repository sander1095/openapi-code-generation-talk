start ../Prebuild/minimal-api/ConferenceServerMinimalAPI.exe
start ../Prebuild/controllers/ConferenceServerControllers.exe
start ../Prebuild/client-app/ConferenceApp.exe
start pwsh -ArgumentList "-NoExit", "-Command", "npm --prefix ../ConferenceAppJs start"
