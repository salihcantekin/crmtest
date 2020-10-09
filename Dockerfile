FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

WORKDIR /app

COPY ./Crm.API/Crm.API.csproj ./

RUN dotnet restore

ENV ASPNETCORE_ENVIRONMENT=Production

COPY . ./

RUN dotnet publish ./Crm.API -c Release -o /out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as build-env
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "Crm.API.dll"]