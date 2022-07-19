ARG VERSION=3.1-alpine

### Estágio 1 - Obter o source e gerar o Build ###
FROM mcr.microsoft.com/dotnet/core/sdk:$VERSION AS build-env

WORKDIR /app

## Copiar todos projetos e restaurar dependencias
COPY . ./
RUN dotnet restore IFAVALIACAO.API/IFAVALIACAO.API.csproj --interactive
RUN dotnet build   IFAVALIACAO.API/IFAVALIACAO.API.csproj
RUN dotnet publish IFAVALIACAO.API/IFAVALIACAO.API.csproj -c Release -o /app/publish

### Estágio 2 - Subir a aplicação através dos binários ###
## Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:$VERSION

RUN adduser \
  --disabled-password \
  --home /app \
  --gecos '' app \
  && chown -R app /app
USER app

WORKDIR /app
COPY --from=build-env /app/publish .

# ENV ASPNETCORE_ENVIRONMENT Staging
ENV DOTNET_RUNNING_IN_CONTAINER=true \
  ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "IFAVALIACAO.API.dll"]