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
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash - && apt-get install -y nodejs
RUN npm install
WORKDIR /src
# Build the app and make the app ready to be published
RUN dotnet publish "Angular.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
# Copy the binaries and static Javascript over to final docker
COPY --from=publish /app .
# Copy manifest.json over to the dist folder for PWA to work
COPY ./ClientApp/src/manifest.json /app/ClientApp/dist
ENTRYPOINT ["dotnet", "Angular.dll"]
