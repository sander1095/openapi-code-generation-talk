# Define a script block to stop all jobs
$stopJobs = {
    Get-Job | Stop-Job
    Get-Job | Remove-Job
}

# Set the trap
trap {
    & $stopJobs
    break
}

# Start the Python script as a background job
Start-Job -ScriptBlock {
    python -m http.server
}

# Start the Prism server in the same window
Start-Process -NoNewWindow "npm" -ArgumentList "run prism"

# Call the stopJobs script block when the script exits
& $stopJobs