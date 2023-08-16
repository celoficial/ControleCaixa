# Imagem base do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
EXPOSE 80 443 5194

WORKDIR /app

# Copiar código-fonte e compilar
COPY . .
RUN dotnet build -c Release -o out

# Publicar a aplicação
FROM build AS publish
RUN dotnet publish -c Release -o out

# Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=publish /app/out .

# Comando para iniciar a aplicação
CMD ["dotnet", "FluxoDeCaixa.Presentation.dll"]
