# 1. Uygulama için bir temel görüntü seç
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# 2. SDK içeren bir görüntüden derleme işlemleri
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "KeyValueCase.csproj"
RUN dotnet build "KeyValueCase.csproj" -c Release -o /app/build

# 3. Yayın (publish) aşaması
FROM build AS publish
RUN dotnet publish "KeyValueCase.csproj" -c Release -o /app/publish

# 4. Final kapsayıcı
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KeyValueCase.dll"]
