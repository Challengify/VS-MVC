#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Challengify/Challengify.csproj", "Challengify/"]
RUN dotnet restore "Challengify/Challengify.csproj"
COPY . .
WORKDIR "/src/Challengify"
RUN dotnet build "Challengify.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Challengify.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Challengify.dll"]
