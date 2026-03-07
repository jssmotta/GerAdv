# Stop and remove the containers created by the local compose
$compose = Join-Path $PSScriptRoot 'docker-compose.yml'
$projectName = 'geradv-dockerlocal'
if (-not (Get-Command docker -ErrorAction SilentlyContinue)) {
    Write-Error "Docker not found. Ensure Docker Desktop is installed and running."
    exit 1
}

docker info | Out-Null
if ($LASTEXITCODE -ne 0) {
    Write-Error "Docker Desktop engine is not available. Start Docker Desktop and wait until it is running, then retry."
    exit 1
}

Write-Output "Stopping and removing containers defined in: $compose"
docker compose -p $projectName -f $compose down -v

# Remove staged external dependencies from build context
$gerSharedSrcDest = Join-Path $PSScriptRoot '..\SG\SHARED'

if (Test-Path $gerSharedSrcDest) {
    Write-Output "Removing staged SHARED folder: $gerSharedSrcDest"
    Remove-Item -Recurse -Force -ErrorAction SilentlyContinue $gerSharedSrcDest
}
