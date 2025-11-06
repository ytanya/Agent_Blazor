# Step 1: Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore dependencies
COPY . .
RUN dotnet restore "BlazorHero.CleanArchitecture.Server.csproj"

# Build and publish
RUN dotnet publish "BlazorHero.CleanArchitecture.Server.csproj" -c Release -o /app/publish

# Step 2: Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "BlazorHero.CleanArchitecture.Server.dll"]
