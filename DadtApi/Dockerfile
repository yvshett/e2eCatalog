#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
ENV http_proxy=http://proxy-chain.intel.com:911
ENV build-arg https_proxy=http://proxy-chain.intel.com:911
COPY ["DadtApi.csproj", ""]
RUN dotnet restore "./DadtApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DadtApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DadtApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DadtApi.dll"]

## docker build -f Dockerfile -t DadtApi:1 .
## docker run -d -p 3002:80 DadtApi:1 .