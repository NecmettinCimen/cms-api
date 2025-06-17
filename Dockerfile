FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App
ARG BUILD_NUMBER

# Copy everything
COPY ./API/ ./API/

# Build and publish a release
RUN dotnet publish ./API/cms-api.csproj -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App
COPY --from=build-env /App/out .

ENTRYPOINT ["dotnet", "cms-api.dll"]

