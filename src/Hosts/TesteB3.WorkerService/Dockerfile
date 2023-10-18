#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Hosts/TesteB3.WorkerService/TesteB3.WorkerService.csproj", "Hosts/TesteB3.WorkerService/"]
COPY ["TesteB3.Application/TesteB3.Application.csproj", "TesteB3.Application/"]
COPY ["TesteB3.Infrasctructure/TesteB3.Infrasctructure.csproj", "TesteB3.Infrasctructure/"]
COPY ["Shared/TesteB3.Domain/TesteB3.Domain.csproj", "Shared/TesteB3.Domain/"]
COPY ["Shared/TesteB3.Domain.Shared/TesteB3.Domain.Shared.csproj", "Shared/TesteB3.Domain.Shared/"]
RUN dotnet restore "Hosts/TesteB3.WorkerService/TesteB3.WorkerService.csproj"
COPY . .
WORKDIR "/src/Hosts/TesteB3.WorkerService"
RUN dotnet build "TesteB3.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TesteB3.WorkerService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TesteB3.WorkerService.dll"]