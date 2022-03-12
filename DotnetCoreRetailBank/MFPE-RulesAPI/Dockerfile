#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["RulesAPI/RulesAPI.csproj", "RulesAPI/"]
RUN dotnet restore "RulesAPI/RulesAPI.csproj"
COPY . .
WORKDIR "/src/RulesAPI"
RUN dotnet build "RulesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RulesAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RulesAPI.dll"]