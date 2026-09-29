#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CA.EShop_SQL.WebAPI/CA.EShop_SQL.WebAPI.csproj", "CA.EShop_SQL.WebAPI/"]
COPY ["CA.EShop_SQL.Application/CA.EShop_SQL.Application.csproj", "CA.EShop_SQL.Application/"]
COPY ["CA.EShop_SQL.Domain/CA.EShop_SQL.Domain.csproj", "CA.EShop_SQL.Domain/"]
COPY ["CA.EShop_SQL.IntegrationEvents/CA.EShop_SQL.IntegrationEvents.csproj", "CA.EShop_SQL.IntegrationEvents/"]
COPY ["CA.EShop_SQL.Presistence/CA.EShop_SQL.Presistence.csproj", "CA.EShop_SQL.Presistence/"]
RUN dotnet restore "CA.EShop_SQL.WebAPI/CA.EShop_SQL.WebAPI.csproj"
COPY . .
WORKDIR "/src/CA.EShop_SQL.WebAPI"
RUN dotnet build "CA.EShop_SQL.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CA.EShop_SQL.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CA.EShop_SQL.WebAPI.dll"]