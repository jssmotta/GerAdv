# Start the API locally using Docker Desktop
param(
    [switch]$Detach = $true
)

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

Write-Output "Bringing up containers using compose file: $compose (project: $projectName)"
function Get-ResolvedPathFromCandidates {
    param([string[]]$candidates)
    foreach ($p in $candidates) {
        if ([string]::IsNullOrWhiteSpace($p)) { continue }
        $full = Resolve-Path -LiteralPath $p -ErrorAction SilentlyContinue
        if ($full) { return $full.Path }
    }
    return $null
}

function Test-IsUnderPath {
    param(
        [string]$path,
        [string]$rootPath
    )

    $fullPath = [System.IO.Path]::GetFullPath($path).TrimEnd('\\')
    $fullRoot = [System.IO.Path]::GetFullPath($rootPath).TrimEnd('\\')

    return $fullPath.Equals($fullRoot, [System.StringComparison]::OrdinalIgnoreCase) -or
           $fullPath.StartsWith($fullRoot + '\\', [System.StringComparison]::OrdinalIgnoreCase)
}

function Stage-ExternalDependency {
    param(
        [string]$name,
        [string[]]$sourceCandidates,
        [string]$destinationPath,
        [string]$allowedRoot,
        [switch]$required
    )

    $source = Get-ResolvedPathFromCandidates -candidates $sourceCandidates
    if (-not $source) {
        if ($required) {
            Write-Error "Required dependency '$name' not found. Set environment variable ${name}_PATH or ensure SG/SHARED exists."
            exit 1
        }
        Write-Output "Optional dependency '$name' not found."
        return
    }

    if (-not [string]::IsNullOrWhiteSpace($allowedRoot) -and -not (Test-IsUnderPath -path $source -rootPath $allowedRoot)) {
        Write-Error "Dependency '$name' resolved to '$source', which is outside allowed root '$allowedRoot'."
        exit 1
    }

    if (Test-Path $destinationPath) {
        Remove-Item -Recurse -Force -ErrorAction SilentlyContinue $destinationPath
    }
    $parent = Split-Path -Parent $destinationPath
    New-Item -ItemType Directory -Path $parent -Force | Out-Null

    Write-Output "Staging dependency '$name': $source -> $destinationPath"
    Copy-Item -Path $source -Destination $destinationPath -Recurse -Force
}

$gerSharedSrcCandidates = @(
    Join-Path $PSScriptRoot '..\..\..\SG\SHARED'
    Join-Path $PSScriptRoot '..\..\..\..\SG\SHARED'
    'C:\\github\\SG\\SHARED'
    $(if ($env:SHARED_SRC_PATH) { $env:SHARED_SRC_PATH } else { $null })
)

$gerSharedSrcDest = Join-Path $PSScriptRoot '..\SG\SHARED'
Stage-ExternalDependency -name 'SHARED_SRC' -sourceCandidates $gerSharedSrcCandidates -destinationPath $gerSharedSrcDest -allowedRoot 'C:\github\SG\SHARED' -required

# Ensure PFX exists for local HTTPS (create if missing)
$certsDir = Join-Path $PSScriptRoot 'certs'
$pfxName = 'appsgcert.pfx'
$pfxPath = Join-Path $certsDir $pfxName
if (-not (Test-Path $pfxPath)) {
    Write-Output "PFX não encontrado em: $pfxPath - gerando..."
    $generator = Join-Path $PSScriptRoot 'generate-pfx.ps1'
    if (Test-Path $generator) {
        try {
            & powershell -NoProfile -NonInteractive -ExecutionPolicy Bypass -File $generator -OutputDir $certsDir -PfxFileName $pfxName -UseMkcert
            if (Test-Path $pfxPath) {
                Write-Output "PFX gerado com sucesso: $pfxPath"
            } else {
                Write-Warning "O script de geração executou, mas o PFX não foi encontrado em: $pfxPath"
            }
        } catch {
            Write-Warning "Falha ao executar o gerador de PFX: $_"
        }
        } else {
        Write-Warning "Gerador de PFX não encontrado: $generator - pulei geração automática."
    }
} else {
    Write-Output "PFX já existe: $pfxPath"
}

if ($Detach) {
    docker compose -p $projectName -f $compose up -d --build
} else {
    docker compose -p $projectName -f $compose up --build
}
