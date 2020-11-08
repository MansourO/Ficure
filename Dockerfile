FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Transaction.API/Transaction.API.csproj", "Transaction.API/"]
RUN dotnet restore "Transaction.API/Transaction.API.csproj"

WORKDIR "/src/Transaction.API"
COPY . .
RUN dotnet build "Transaction.API.csproj" -c Release -o /app/build

WORKDIR "/src/Transaction.API"
FROM build AS publish
RUN dotnet publish "Transaction.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transaction.API.dll"]

