FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["LoteriaFacil.UI.Web/LoteriaFacil.UI.Web.csproj", "LoteriaFacil.UI.Web/"]
RUN dotnet restore "LoteriaFacil.UI.Web/LoteriaFacil.UI.Web.csproj"
COPY . .
WORKDIR "/src/LoteriaFacil.UI.Web"
RUN dotnet build "LoteriaFacil.UI.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LoteriaFacil.UI.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LoteriaFacil.UI.Web.dll"]
