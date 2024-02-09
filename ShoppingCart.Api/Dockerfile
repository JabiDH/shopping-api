# Use the .NET SDK image to generate the certificate
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
USER root

# Install OpenSSL for certificate generation
RUN apt-get update \
    && apt-get install -y openssl \
    && rm -rf /var/lib/apt/lists/*

# Generate a self-signed certificate using OpenSSL
RUN openssl req -newkey rsa:2048 -nodes -keyout /etc/ssl/certs/certificate.key -x509 -days 365 -out /etc/ssl/certs/certificate.crt \
    -subj "/CN=localhost"

# Convert the certificate to .pfx format
RUN openssl pkcs12 -export -out /etc/ssl/certs/certificate.pfx -inkey /etc/ssl/certs/certificate.key -in /etc/ssl/certs/certificate.crt -passout pass:Certificate$2024

ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShoppingCart.Api/ShoppingCart.Api.csproj", "ShoppingCart.Api/"]
RUN dotnet restore "./ShoppingCart.Api/ShoppingCart.Api.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.Api"
RUN dotnet build "./ShoppingCart.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShoppingCart.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=base /etc/ssl/certs/certificate.pfx .
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS=https://+:8081;http://+:8080
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/etc/ssl/certs/certificate.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=Certificate$2024
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "ShoppingCart.Api.dll"]
