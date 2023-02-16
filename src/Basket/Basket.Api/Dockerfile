#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Basket/Basket.Api/Basket.Api.csproj", "Basket/Basket.Api/"]
COPY ["DataBase/Data/Data.csproj", "DataBase/Data/"]
COPY ["DataModel/Dto/Dto.csproj", "DataModel/Dto/"]
COPY ["RepositeryLayer/Repositery/Repositery.csproj", "RepositeryLayer/Repositery/"]
COPY ["ShardCore/Core/Core.csproj", "ShardCore/Core/"]
RUN dotnet restore "Basket/Basket.Api/Basket.Api.csproj"
COPY . .
WORKDIR "/src/Basket/Basket.Api"
RUN dotnet build "Basket.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Basket.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Basket.Api.dll"]