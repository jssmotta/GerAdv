<#

Generates a PFX named `appsgcert.pfx` for `localhost` and saves it to DockerLocal/certs.



Usage examples:

  powershell -ExecutionPolicy Bypass -File .\DockerLocal\generate-pfx.ps1 -PfxPassword "MyPass123"

  .\DockerLocal\generate-pfx.ps1 -OutputDir .\DockerLocal\certs -PfxFileName appsgcert.pfx -PfxPassword "MyPass123"



This script uses mkcert (recommended) or PowerShell's New-SelfSignedCertificate as fallback.

#>



param(

    [string]$OutputDir = "$PSScriptRoot\certs",

    [string]$PfxFileName = "appsgcert.pfx",

    [string]$PfxPassword = "password1",

    [string]$DnsName = "localhost",

    [int]$ValidYears = 10,

    [switch]$UseMkcert

)



if (-not (Test-Path $OutputDir)) {

    New-Item -ItemType Directory -Path $OutputDir | Out-Null

}



$pfxPath = Join-Path $OutputDir $PfxFileName



# --- Unique temp names per project (prevents conflicts between projects) ---

$baseName = [System.IO.Path]::GetFileNameWithoutExtension($PfxFileName)



if ($UseMkcert) {

    # --- mkcert + openssl flow ---

    $mkcert = Get-Command mkcert -ErrorAction SilentlyContinue

    if (-not $mkcert) {

        Write-Error "mkcert not found in PATH. Install it with: choco install mkcert -y"

        exit 2

    }



    Write-Output "mkcert found, generating PEM files..."

    & mkcert -install 2>&1 | Out-Null



    $tmpKey  = Join-Path $env:TEMP "$baseName-key.pem"

    $tmpCert = Join-Path $env:TEMP "$baseName.pem"



    # Clean up previous PEM files to avoid accidental reuse

    Remove-Item -Force $tmpKey, $tmpCert -ErrorAction SilentlyContinue



    & mkcert -key-file $tmpKey -cert-file $tmpCert $DnsName 127.0.0.1 ::1 2>&1 | Out-Null



    if (-not (Test-Path $tmpKey) -or -not (Test-Path $tmpCert)) {

        Write-Error "ERROR: mkcert did not generate the expected PEM files."

        Write-Error "  Expected key : $tmpKey"

        Write-Error "  Expected cert: $tmpCert"

        Write-Error "Check if mkcert is working: mkcert -CAROOT"

        exit 3

    }



    # Locate openssl

    $opensslCmd = (Get-Command openssl -ErrorAction SilentlyContinue | Select-Object -First 1).Source

    if (-not $opensslCmd) {

        $candidates = @(

            "$env:ProgramFiles\Git\usr\bin\openssl.exe",

            "$env:ProgramFiles(x86)\Git\usr\bin\openssl.exe",

            "$env:ProgramFiles\Git\mingw64\bin\openssl.exe",

            "$env:ProgramFiles\OpenSSL-Win64\bin\openssl.exe",

            "$env:ProgramFiles\OpenSSL-Win32\bin\openssl.exe"

        )

        $opensslCmd = $candidates | Where-Object { Test-Path $_ } | Select-Object -First 1

    }

    if (-not $opensslCmd) {

        Write-Error "ERROR: OpenSSL not found. Install it with: choco install openssl.light -y"

        Remove-Item -Force $tmpKey, $tmpCert -ErrorAction SilentlyContinue

        exit 4

    }



    # Verify CA root

    $caroot = (& mkcert -CAROOT).Trim()

    $rootCA = Join-Path $caroot 'rootCA.pem'

    if (-not (Test-Path $rootCA)) {

        Write-Error "ERROR: rootCA.pem not found at $caroot"

        Write-Error "Run 'mkcert -install' as administrator and try again."

        Remove-Item -Force $tmpKey, $tmpCert -ErrorAction SilentlyContinue

        exit 5

    }



    # Generate PFX

    $argList = @('pkcs12','-export','-out',$pfxPath,'-inkey',$tmpKey,'-in',$tmpCert,'-certfile',$rootCA,'-password',"pass:$PfxPassword")

    $proc = Start-Process -FilePath $opensslCmd -ArgumentList $argList -PassThru -Wait -WindowStyle Hidden

    if ($proc.ExitCode -ne 0) {

        Write-Error "ERROR: OpenSSL failed to create PFX (exit code $($proc.ExitCode))."

        Remove-Item -Force $tmpKey, $tmpCert -ErrorAction SilentlyContinue

        exit 6

    }



    # Clean up temp PEM files

    Remove-Item -Force $tmpKey, $tmpCert -ErrorAction SilentlyContinue



    # --- POST-GENERATION VALIDATION ---

    if (-not (Test-Path $pfxPath)) {

        Write-Error "CRITICAL ERROR: PFX was not created at: $pfxPath"

        exit 7

    }



    $pfxSize = (Get-Item $pfxPath).Length

    if ($pfxSize -lt 3000) {

        Write-Error "ERROR: Generated PFX is too small ($pfxSize bytes). Likely mkcert failure."

        Write-Error "  A valid mkcert PFX should be ~4000+ bytes (includes CA chain)."

        Write-Error "  Delete the file and try again: del `"$pfxPath`""

        Remove-Item -Force $pfxPath -ErrorAction SilentlyContinue

        exit 8

    }



    Write-Output ""

    Write-Output "PFX created at: $pfxPath (via mkcert + openssl)"

    Write-Output "  Size: $pfxSize bytes"

    Write-Output "  CA root: $rootCA"

    Write-Output "  Valid for: $DnsName, 127.0.0.1, ::1"

    exit 0



} else {

    # --- Fallback: New-SelfSignedCertificate ---

    Write-Warning "Generating self-signed certificate (without mkcert)."

    Write-Warning "The browser will show a security warning. Use -UseMkcert to avoid this."



    $securePass = ConvertTo-SecureString -String $PfxPassword -Force -AsPlainText

    $cert = New-SelfSignedCertificate -DnsName $DnsName -CertStoreLocation "Cert:\CurrentUser\My" -KeyExportPolicy Exportable -KeySpec KeyExchange -NotAfter (Get-Date).AddYears($ValidYears)



    if (-not $cert) {

        Write-Error "ERROR: Failed to create self-signed certificate."

        exit 1

    }



    try {

        Export-PfxCertificate -Cert $cert -FilePath $pfxPath -Password $securePass -Force | Out-Null

        Write-Output ""

        Write-Warning "PFX created at: $pfxPath (self-signed -- browser will complain!)"

        Write-Warning "  For a trusted certificate, run: .\generate-pfx.ps1 -UseMkcert"

    } catch {

        Write-Error "ERROR: Failed to export PFX: $_"

        exit 1

    } finally {

        try { Remove-Item -Path "Cert:\CurrentUser\My\$($cert.Thumbprint)" -Force -ErrorAction SilentlyContinue } catch {}

    }



    exit 0

}

