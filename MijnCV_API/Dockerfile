#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MijnCV_API/MijnCV_API.csproj", "MijnCV_API/"]
RUN dotnet restore "MijnCV_API/MijnCV_API.csproj"
COPY . .
WORKDIR "/src/MijnCV_API"
RUN dotnet build "MijnCV_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MijnCV_API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MijnCV_API.dll"]