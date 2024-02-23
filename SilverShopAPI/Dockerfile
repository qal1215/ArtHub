#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SilverShopAPI/ArtHub.API.csproj", "SilverShopAPI/"]
COPY ["ArtHub.Service/ArtHub.Service.csproj", "ArtHub.Service/"]
COPY ["SilverShopBusinessObject/ArtHub.BusinessObject.csproj", "SilverShopBusinessObject/"]
COPY ["SilverShopRepository/ArtHub.Repository.csproj", "SilverShopRepository/"]
COPY ["SilverShopDAO/ArtHub.DAO.csproj", "SilverShopDAO/"]
RUN dotnet restore "./SilverShopAPI/./ArtHub.API.csproj"
COPY . .
WORKDIR "/src/SilverShopAPI"
RUN dotnet build "./ArtHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ArtHub.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtHub.API.dll"]