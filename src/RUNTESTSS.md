
# PowerShell
$env:ASPNETCORE_ENVIRONMENT="Development"; dotnet test --collect:"XPlat Code Coverage" --settings .runsettings


reportgenerator -reports:"Tests\**\TestResults\**\coverage.opencover.xml" -targetdir:"TestResultsFinal\CoverageReport" -reporttypes:Html