FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Messaging.RabbitMqClient/Messaging.RabbitMqClient.csproj", "Messaging.RabbitMqClient/"]
RUN dotnet restore "Messaging.RabbitMqClient/Messaging.RabbitMqClient.csproj"
COPY . .
WORKDIR "/src/Messaging.RabbitMqClient"
RUN dotnet build "Messaging.RabbitMqClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messaging.RabbitMqClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messaging.RabbitMqClient.dll"]
