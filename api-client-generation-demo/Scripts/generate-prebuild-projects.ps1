Remove-Item ../Prebuild -Recurse -Force -ErrorAction SilentlyContinue
dotnet publish ../ConferenceApp/ -r win-x64 -o ../Prebuild/client-app
dotnet publish ../ConferenceServerControllers/ -r win-x64 -o ../Prebuild/controllers
dotnet publish ../ConferenceServerMinimalAPI -r win-x64 -o ../Prebuild/minimal-api
