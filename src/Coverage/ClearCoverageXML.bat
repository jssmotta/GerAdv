@echo off
rem ClearCoverage.cobertura.xml.bat
rem Search for and delete all files named coverage.cobertura.xml under a root directory (default C:\github).
rem Usage:
rem   ClearCoverage.cobertura.xml.bat             -> lists and prompts before deleting
rem   ClearCoverage.cobertura.xml.bat -y          -> deletes without confirmation
rem   ClearCoverage.cobertura.xml.bat "C:\my\project" -> uses custom path

setlocal EnableDelayedExpansion

:: Default
set "ROOT=C:\github"

:: If first argument is not empty, use it as root (unless it's a flag)
if not "%~1"=="" (
  if /I "%~1"=="-y" goto :PARSE_FLAGS
  if /I "%~1"=="/y" goto :PARSE_FLAGS
  if /I "%~1"=="--yes" goto :PARSE_FLAGS
  if /I "%~1"=="-h" goto :USAGE
  if /I "%~1"=="/h" goto :USAGE
  set "ROOT=%~1"
)

:PARSE_FLAGS
set "ASSUME_YES=0"
for %%A in (%*) do (
  if /I "%%~A"=="-y" set "ASSUME_YES=1"
  if /I "%%~A"=="/y" set "ASSUME_YES=1"
  if /I "%%~A"=="--yes" set "ASSUME_YES=1"
  if /I "%%~A"=="-h" set "SHOW_HELP=1"
  if /I "%%~A"=="/h" set "SHOW_HELP=1"
)

if defined SHOW_HELP goto :USAGE

echo Searching for "coverage.cobertura.xml" files in "%ROOT%" (recursive)...

rem List found paths to a temp file
powershell -NoProfile -Command "Get-ChildItem -Path '%ROOT%' -Filter 'coverage.cobertura.xml' -Recurse -File -ErrorAction SilentlyContinue | Select-Object -ExpandProperty FullName" > "%TEMP%\coverage_list.txt" 2>nul

if not exist "%TEMP%\coverage_list.txt" (
  echo No files found or error accessing the path.
  goto :CLEANUP
)

set FILECOUNT=0
for /f "usebackq delims=" %%F in ("%TEMP%\coverage_list.txt") do (
  set /A FILECOUNT+=1
)

if %FILECOUNT% EQU 0 (
  echo No files found.
  goto :CLEANUP
)

echo Found %FILECOUNT% file(s):
type "%TEMP%\coverage_list.txt"

if "%ASSUME_YES%"=="1" goto :DELETEFILES

echo.
echo Press Y to delete, N to cancel.
choice /M "Delete these files?"
if errorlevel 2 (
  echo Operation cancelled.
  goto :CLEANUP
)

:DELETEFILES
echo Deleting files...
rem Remove using PowerShell to be robust with long paths
powershell -NoProfile -Command "Get-ChildItem -Path '%ROOT%' -Filter 'coverage.cobertura.xml' -Recurse -File -ErrorAction SilentlyContinue | Remove-Item -Force -ErrorAction SilentlyContinue"
if %ERRORLEVEL% EQU 0 (
  echo Completed.
) else (
  echo Operation finished (some errors may have occurred, e.g. locked files).
)

:CLEANUP
del "%TEMP%\coverage_list.txt" >nul 2>&1
endlocal
goto :eof

:USAGE
echo.
echo Usage: %~nx0 [root_path] [-y]
echo   root_path   Optional. Root directory to search (default C:\github).
echo   -y           Delete without prompting.
echo.
endlocal
goto :eof
