### Estágio 1 - Obter o source e gerar o Build ###
FROM mcr.microsoft.com/dotnet/core/sdk:2.2.105 AS build-env
WORKDIR /app

## Copiar todos projetos e restaurar dependencias
COPY . ./
RUN dotnet restore IFAVALIACAO.API/IFAVALIACAO.API.csproj
RUN dotnet build   IFAVALIACAO.API/IFAVALIACAO.API.csproj
RUN dotnet publish IFAVALIACAO.API/IFAVALIACAO.API.csproj -c Release -o /app/publish


# Change timezone to local time
# ENV TZ=Brazil/East
# RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

### Estágio 2 - Subir a aplicação através dos binários ###
## Build da imagem
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2.3

WORKDIR /app
COPY --from=build-env /app/publish .

# ENV ASPNETCORE_ENVIRONMENT Staging
ENV ASPNETCORE_URLS http://+:50470
EXPOSE 50470

ENTRYPOINT ["dotnet", "IFAVALIACAO.API.dll"]