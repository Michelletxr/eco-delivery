# Usando a imagem base do SDK do .NET para build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar os arquivos do projeto e restaurar as dependências
COPY *.csproj ./
RUN dotnet restore

# Copiar o restante dos arquivos do projeto e compilar a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Usar a imagem base do runtime do .NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Expor a porta que será usada
EXPOSE 80

# Comando para rodar a aplicação
ENTRYPOINT ["dotnet", "EcoDeliveryApi.dll"]
