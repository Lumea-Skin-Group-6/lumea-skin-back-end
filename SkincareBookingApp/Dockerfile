# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
ENV BUILD_CONFIGURATION=Release

# Copy solution and project files
COPY SkincareBookingApp/*.csproj SkincareBookingApp/
COPY BusinessObject/*.csproj BusinessObject/
COPY Service/*.csproj Service/
COPY DAL/*.csproj DAL/
COPY Repository/*.csproj Repository/

# Restore dependencies
WORKDIR /src/SkincareBookingApp
RUN dotnet restore

# Copy the full source code
COPY . .

# Build the project (No custom output directory)
RUN dotnet build --no-restore -c $BUILD_CONFIGURATION

# Publish the application
RUN dotnet publish --no-restore -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "SkincareBookingApp.dll"]
