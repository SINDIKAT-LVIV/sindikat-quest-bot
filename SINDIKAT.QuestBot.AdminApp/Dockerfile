FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SINDIKAT.QuestBot.AdminClient/SINDIKAT.QuestBot.AdminClient.csproj", "SINDIKAT.QuestBot.AdminClient/"]
RUN dotnet restore "SINDIKAT.QuestBot.AdminClient/SINDIKAT.QuestBot.AdminClient.csproj"
COPY . .
WORKDIR "/src/SINDIKAT.QuestBot.AdminClient"
RUN dotnet build "SINDIKAT.QuestBot.AdminClient.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SINDIKAT.QuestBot.AdminClient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SINDIKAT.QuestBot.AdminClient.dll"]
