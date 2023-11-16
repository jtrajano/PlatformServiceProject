FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY *.sln .

COPY ./PlatformService/PlatformService.csproj ./PlatformService/
COPY ./PlatformService.Core/PlatformService.Core.csproj ./PlatformService.Core/
COPY ./PlatformService.Infrastructure/PlatformService.Infrastructure.csproj ./PlatformService.Infrastructure/


WORKDIR /App/PlatformService
RUN dotnet restore

WORKDIR /App
COPY PlatformService/. ./PlatformService/
COPY PlatformService.Core/. ./PlatformService.Core/
COPY PlatformService.Infrastructure/. ./PlatformService.Infrastructure/

WORKDIR /App/PlatformService
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App


COPY --from=build-env /App/PlatformService/out .
ENTRYPOINT ["dotnet", "PlatformService.dll"]