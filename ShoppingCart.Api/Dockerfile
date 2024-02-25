FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/aspnetapp.pfx
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="password"

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ShoppingCart.Api/ShoppingCart.Api.csproj", "ShoppingCart.Api/"]
RUN dotnet restore "./ShoppingCart.Api/./ShoppingCart.Api.csproj"
COPY . .
WORKDIR "/src/ShoppingCart.Api"
RUN dotnet build "./ShoppingCart.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ShoppingCart.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingCart.Api.dll"]

#docker run -d -p 32770:8080 -p 32771:8081 -v ./aspnetapp.pfx:/app/aspnetapp.pfx -e ASPNETCORE_Kestrel__Certificates__Default__Password="password" shoppingcartapi:dev