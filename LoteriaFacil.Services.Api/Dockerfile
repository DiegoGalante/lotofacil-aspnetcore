FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["LoteriaFacil.Services.Api/LoteriaFacil.Services.Api.csproj", "LoteriaFacil.Services.Api/"]
RUN dotnet restore "LoteriaFacil.Services.Api/LoteriaFacil.Services.Api.csproj"
COPY . .
WORKDIR "/src/LoteriaFacil.Services.Api"
RUN dotnet build "LoteriaFacil.Services.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoteriaFacil.Services.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoteriaFacil.Services.Api.dll"]