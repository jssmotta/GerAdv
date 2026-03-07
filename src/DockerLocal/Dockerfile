FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy everything from the service folder (context is set to the project folder by compose)
COPY . ./

# Copy only SHARED from SG (not the entire SG repo)
# `sgshared` is supplied by docker-compose additional build contexts
COPY --from=sgshared . /SG/SHARED

# Restore and publish only the API project
RUN dotnet restore API/API.csproj
RUN dotnet publish API/API.csproj -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app .

ENV ASPNETCORE_URLS=https://+:7179
EXPOSE 7179

# Start API
ENTRYPOINT ["dotnet", "API.dll"]