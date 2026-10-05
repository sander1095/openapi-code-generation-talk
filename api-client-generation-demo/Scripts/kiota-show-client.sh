#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "${BASH_SOURCE[0]}")"

dotnet kiota show --openapi "https://localhost:7135/openapi/v1.json"
