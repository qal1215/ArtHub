#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ArtHub.API/ArtHub.API.csproj", "ArtHub.API/"]
COPY ["ArtHub.Service/ArtHub.Service.csproj", "ArtHub.Service/"]
COPY ["ArtHub.BusinessObject/ArtHub.BusinessObject.csproj", "ArtHub.BusinessObject/"]
COPY ["ArtHub.Repository/ArtHub.Repository.csproj", "ArtHub.Repository/"]
COPY ["ArtHub.DAO/ArtHub.DAO.csproj", "ArtHub.DAO/"]
RUN dotnet restore "./ArtHub.API/./ArtHub.API.csproj"
COPY . .
WORKDIR "/src/ArtHub.API"
RUN dotnet build "./ArtHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ArtHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtHub.API.dll"]