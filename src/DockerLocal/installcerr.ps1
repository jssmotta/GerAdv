# Abra PowerShell "Run as Administrator", então execute:
Stop-Process -Name choco -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force 'C:\ProgramData\chocolatey\lib\960379d0c075d4e5840fa9c2c120a75d9b2885b5' -ErrorAction SilentlyContinue
Remove-Item -Recurse -Force 'C:\ProgramData\chocolatey\lib-bad' -ErrorAction SilentlyContinue

choco install mkcert openssl.light -y



mkcert -install

.\generate-pfx.ps1 -PfxPassword "password1" -UseMkcert