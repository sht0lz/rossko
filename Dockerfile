FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_URLS http://*:5000
ENV redisConnectionString=redis:6379
EXPOSE 5000

FROM microsoft/aspnetcore-build:2.0 AS builder
ARG Configuration=Release
WORKDIR /src
COPY *.sln ./
COPY Domain/Domain.csproj Domain/
COPY AppServices/AppServices.csproj AppServices/
COPY Api/Api.csproj Api/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
RUN dotnet restore
COPY . .
WORKDIR /src/Api
RUN dotnet build -c $Configuration -o /app

FROM builder AS publish
ARG Configuration=Release
RUN dotnet publish -c $Configuration -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]