#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Protel.API/Protel.API.csproj", "Protel.API/"]
COPY ["Protel.Business/Protel.Business.csproj", "Protel.Business/"]
COPY ["Protel.DataAccess/Protel.DataAccess.csproj", "Protel.DataAccess/"]
COPY ["Protel.Core/Protel.Core.csproj", "Protel.Core/"]
COPY ["Protel.Service/Protel.Service.csproj", "Protel.Service/"]
RUN dotnet restore "Protel.API/Protel.API.csproj"
COPY . .
WORKDIR "/src/Protel.API"
RUN dotnet build "Protel.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Protel.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Protel.API.dll
#ENTRYPOINT ["dotnet", "Protel.API.dll"]