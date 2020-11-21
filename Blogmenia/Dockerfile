#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Blogmenia.csproj", "./"]
COPY ["../Blogmenia.Data/Blogmenia.Data.csproj", "../Blogmenia.Data/"]
COPY ["../Blogmenia.Core/Blogmenia.Core.csproj", "../Blogmenia.Core/"]
RUN dotnet restore "Blogmenia.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "Blogmenia.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blogmenia.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blogmenia.dll"]
