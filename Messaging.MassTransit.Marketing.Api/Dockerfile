FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Messaging.MassTransit.Marketing.Api/Messaging.MassTransit.Marketing.Api.csproj", "Messaging.MassTransit.Marketing.Api/"]
RUN dotnet restore "Messaging.MassTransit.Marketing.Api/Messaging.MassTransit.Marketing.Api.csproj"
COPY . .
WORKDIR "/src/Messaging.MassTransit.Marketing.Api"
RUN dotnet build "Messaging.MassTransit.Marketing.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Messaging.MassTransit.Marketing.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Messaging.MassTransit.Marketing.Api.dll"]
