#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "${BASH_SOURCE[0]}")"

dotnet kiota generate --clean-output \
                      --language csharp \
                      --openapi "https://localhost:7135/openapi/v1.json" \
                      -o ../ConferenceApp/Clients/Kiota \
                      -n ConferenceApp.Clients.Kiota \
                      -c KiotaConferenceClient
