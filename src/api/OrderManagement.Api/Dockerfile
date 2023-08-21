#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["api/OrderManagement.Api/OrderManagement.Api.csproj", "api/OrderManagement.Api/"]
COPY ["api/OrderManagement.Domain/OrderManagement.Domain.csproj", "api/OrderManagement.Domain/"]
COPY ["api/OrderManagement.Infra/OrderManagement.Infra.csproj", "api/OrderManagement.Infra/"]
COPY ["api/OrderManagement.UseCases/OrderManagement.UseCases.csproj", "api/OrderManagement.UseCases/"]
RUN dotnet restore "api/OrderManagement.Api/OrderManagement.Api.csproj"
COPY . .
WORKDIR "/src/api/OrderManagement.Api"
RUN dotnet build "OrderManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrderManagement.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrderManagement.Api.dll"]