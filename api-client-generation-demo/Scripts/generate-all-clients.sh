#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "${BASH_SOURCE[0]}")"

./generate-nswag-client.sh
./generate-kiota-client.sh
./generate-js-clients.sh
