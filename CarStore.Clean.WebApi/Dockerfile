FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["CarStore.Clean.WebApi/CarStore.Clean.WebApi.csproj", "CarStore.Clean.WebApi/"]
COPY ["CarStore.Clean.Application/CarStore.Clean.Application.csproj", "CarStore.Clean.Application/"]
COPY ["CarStore.Clean.Domain/CarStore.Clean.Domain.csproj", "CarStore.Clean.Domain/"]
COPY ["CarStore.Clean.Infrastructure/CarStore.Clean.Infrastructure.csproj", "CarStore.Clean.Infrastructure/"]
RUN dotnet restore "CarStore.Clean.WebApi/CarStore.Clean.WebApi.csproj"

COPY . .
WORKDIR "/src/CarStore.Clean.WebApi"
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish ./
COPY --from=build /src /src

ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef

CMD dotnet ef database update \
    --project /src/CarStore.Clean.Infrastructure \
    --startup-project /src/CarStore.Clean.WebApi \
    --context CarShopDBContext && \
    dotnet CarStore.Clean.WebApi.dll
