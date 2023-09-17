#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VPO_1.3/VPO_1.3.csproj", "VPO_1.3/"]
RUN dotnet restore "VPO_1.3/VPO_1.3.csproj"
COPY . .
WORKDIR "/src/VPO_1.3"
RUN dotnet build "VPO_1.3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VPO_1.3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VPO_1.3.dll"]