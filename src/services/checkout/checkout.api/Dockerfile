#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 6002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["checkout.api/checkout.api.csproj", "checkout.api/"]
RUN dotnet restore "checkout.api/checkout.api.csproj"
COPY . .
WORKDIR "/src/checkout.api"
RUN dotnet build "checkout.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "checkout.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "checkout.api.dll"]