#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["godguest.gateways.services/godguest.gateways.services.csproj", "godguest.gateways.services/"]
RUN dotnet restore "godguest.gateways.services/godguest.gateways.services.csproj"
COPY . .
WORKDIR "/src/godguest.gateways.services"
RUN dotnet build "godguest.gateways.services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "godguest.gateways.services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "godguest.gateways.services.dll"]