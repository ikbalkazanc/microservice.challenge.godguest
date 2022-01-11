#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["godguest.gateways.application/godguest.gateways.application.csproj", "godguest.gateways.application/"]
RUN dotnet restore "godguest.gateways.application/godguest.gateways.application.csproj"
COPY . .
WORKDIR "/src/godguest.gateways.application"
RUN dotnet build "godguest.gateways.application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "godguest.gateways.application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "godguest.gateways.application.dll"]