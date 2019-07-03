FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Angular.csproj", "./"]
RUN dotnet restore "Angular.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "Angular.csproj" -c Release -o /app

FROM build AS publish
WORKDIR /src/ClientApp
RUN curl -sL https://deb.nodesource.com/setup_8.x | bash - && apt-get install -yq nodejs build-essential
RUN npm install
WORKDIR /src
RUN dotnet publish "Angular.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Angular.dll"]
