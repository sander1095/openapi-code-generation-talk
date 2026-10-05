#!/usr/bin/env bash
set -euo pipefail
cd "$(dirname "${BASH_SOURCE[0]}")"

scripts_dir="$(pwd)"
prebuild="$(cd .. && pwd)/Prebuild"

# The apps are interactive (they wait for a key press), so each one gets its own terminal window.
launch() {
	local command="$1"

	if [ "$(uname -s)" = "Darwin" ]; then
		osascript -e "tell application \"Terminal\" to do script \"${command//\"/\\\"}\"" >/dev/null
	elif command -v gnome-terminal >/dev/null 2>&1; then
		gnome-terminal -- bash -c "$command; exec bash"
	elif command -v x-terminal-emulator >/dev/null 2>&1; then
		x-terminal-emulator -e bash -c "$command; exec bash"
	else
		echo "No terminal emulator found, running in the background instead: $command" >&2
		bash -c "$command" &
	fi
}

launch "cd '$prebuild/minimal-api' && ./ConferenceServerMinimalAPI"
launch "cd '$prebuild/controllers' && ./ConferenceServerControllers"
launch "cd '$prebuild/client-app' && ./ConferenceApp"
launch "cd '$scripts_dir' && npm --prefix ../ConferenceAppJs start"
