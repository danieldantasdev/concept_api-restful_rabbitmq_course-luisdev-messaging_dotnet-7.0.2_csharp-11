FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Messaging.EasyNetQ/Messaging.EasyNetQ.csproj", "Messaging.EasyNetQ/"]
RUN dotnet restore "Messaging.EasyNetQ/Messaging.EasyNetQ.csproj"
COPY . .
WORKDIR "/src/Messaging.EasyNetQ"
RUN dotnet build "Messaging.EasyNetQ.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messaging.EasyNetQ.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messaging.EasyNetQ.dll"]
