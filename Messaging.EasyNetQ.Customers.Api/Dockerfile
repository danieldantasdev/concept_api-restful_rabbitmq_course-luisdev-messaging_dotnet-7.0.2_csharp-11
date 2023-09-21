FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Messaging.EasyNetQ.Customers.Api/Messaging.EasyNetQ.Customers.Api.csproj", "Messaging.EasyNetQ.Customers.Api/"]
RUN dotnet restore "Messaging.EasyNetQ.Customers.Api/Messaging.EasyNetQ.Customers.Api.csproj"
COPY . .
WORKDIR "/src/Messaging.EasyNetQ.Customers.Api"
RUN dotnet build "Messaging.EasyNetQ.Customers.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messaging.EasyNetQ.Customers.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messaging.EasyNetQ.Customers.Api.dll"]
