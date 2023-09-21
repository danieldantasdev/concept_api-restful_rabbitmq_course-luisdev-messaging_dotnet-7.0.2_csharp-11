FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Messaging.RabbitMqClient.Customers.Api/Messaging.RabbitMqClient.Customers.Api.csproj", "Messaging.RabbitMqClient.Customers.Api/"]
RUN dotnet restore "Messaging.RabbitMqClient.Customers.Api/Messaging.RabbitMqClient.Customers.Api.csproj"
COPY . .
WORKDIR "/src/Messaging.RabbitMqClient.Customers.Api"
RUN dotnet build "Messaging.RabbitMqClient.Customers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messaging.RabbitMqClient.Customers.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messaging.RabbitMqClient.Customers.Api.dll"]
