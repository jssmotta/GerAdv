@echo off
REM Simplified script to run tests in RELEASE mode
echo ================================================
echo      RUNNING TESTS IN RELEASE MODE
echo ================================================
echo.

cd /d "%~dp0"
powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0RunCodeCoverage.ps1" > "%~dp0RunTestsRelease.log" 2>&1

REM If you want to see the output in the console instead of a log file, comment out the line above and uncomment the line below.
REM using Release
REM powershell -NoProfile -ExecutionPolicy Bypass -File "%~dp0RunCodeCoverage.ps1" -Configuration Release > "%~dp0RunTestsRelease.log" 2>&1

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ================================================
    echo SUCCESS! Check the report in your browser.
    echo ================================================
) else (
    echo.
    echo ================================================
    echo ERROR! Check the logs above.
    echo ================================================
    pause
)
