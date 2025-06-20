# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80
EXPOSE 443


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CarStore.WebApi/CarStore.Clean.WebApi.csproj", "CarStore.WebApi/"]
COPY ["CarStore.Infrastructure/CarStore.Clean.Infrastructure.csproj", "CarStore.Infrastructure/"]
COPY ["CarStore.Application/CarStore.Clean.Application.csproj", "CarStore.Application/"]
COPY ["CarStore.Domain/CarStore.Clean.Domain.csproj", "CarStore.Domain/"]
RUN dotnet restore "./CarStore.WebApi/CarStore.Clean.WebApi.csproj"
COPY . .
WORKDIR "/src/CarStore.WebApi"
RUN dotnet build "./CarStore.Clean.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CarStore.Clean.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarStore.Clean.WebApi.dll"]