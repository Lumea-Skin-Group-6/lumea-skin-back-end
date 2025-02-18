# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy solution and projects
COPY ["SkincareBookingApp/SkincareBookingApp.csproj", "SkincareBookingApp/"]
COPY ["BusinessObject/BusinessObject.csproj", "BusinessObject/"]
COPY ["Service/Service.csproj", "Service/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["Repository/Repository.csproj", "Repository/"]

# Restore dependencies
WORKDIR "/src/SkincareBookingApp"
RUN dotnet restore

# Copy the full source code
COPY . .

# Build the project
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkincareBookingApp.dll"]
