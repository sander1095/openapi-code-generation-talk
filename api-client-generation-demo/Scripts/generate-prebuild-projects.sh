#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "${BASH_SOURCE[0]}")"

# Publish for the machine we're running on; override with e.g. ./generate-prebuild-projects.sh linux-x64
rid="${1:-}"
if [ -z "$rid" ]; then
	case "$(uname -s)-$(uname -m)" in
		Darwin-arm64)   rid="osx-arm64" ;;
		Darwin-x86_64)  rid="osx-x64" ;;
		Linux-aarch64)  rid="linux-arm64" ;;
		Linux-x86_64)   rid="linux-x64" ;;
		*) echo "Unknown platform $(uname -s)-$(uname -m), pass a runtime identifier as the first argument" >&2; exit 1 ;;
	esac
fi

echo "Publishing for $rid"

rm -rf ../Prebuild
dotnet publish ../ConferenceApp/ -r "$rid" -o ../Prebuild/client-app
dotnet publish ../ConferenceServerControllers/ -r "$rid" -o ../Prebuild/controllers
dotnet publish ../ConferenceServerMinimalAPI -r "$rid" -o ../Prebuild/minimal-api
