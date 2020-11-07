FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

COPY Transaction.API.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Transaction.API.dll"]

