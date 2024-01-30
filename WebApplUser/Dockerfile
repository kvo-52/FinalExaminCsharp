﻿
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WebAppUser/WebAppUser.csproj", "WebAppUser/"]
RUN dotnet restore "WebAppUser/WebAppUser.csproj"
COPY . .
WORKDIR "/src/WebAppUser"
RUN dotnet build "WebAppUser.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UWebAppUser.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAppUser.dll"]
