FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Training.RabbitMQ.Api/Training.RabbitMQ.Api.csproj", "Training.RabbitMQ.Api/"]
RUN dotnet restore "Training.RabbitMQ.Api/Training.RabbitMQ.Api.csproj"
COPY . .
WORKDIR "/src/Training.RabbitMQ.Api"
RUN dotnet build "Training.RabbitMQ.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Training.RabbitMQ.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Training.RabbitMQ.Api.dll"]
