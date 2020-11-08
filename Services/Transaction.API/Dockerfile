FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /Services/Transaction.API

#Copy Files
COPY ["Services/Transaction.API/Transaction.API.csproj", "Services/Transaction.API/"]
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

#Dotnet Restore
COPY Services/Transaction.API/Transaction.API.csproj ./
RUN dotnet restore Services/Transaction.API/Transaction.API.csproj
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Services/Transaction.API/Transaction.API.csproj", "Transaction.API/"]
RUN dotnet restore "Transaction.API/Transaction.API.csproj"
COPY . .
WORKDIR "/src/Transaction.API"
RUN dotnet build "Transaction.API.csproj" -c Release -o /app/build

#Dotnet Publish
COPY Services/Transaction.API/Transaction.API.csproj ./
RUN dotnet publish -c Release -o out
FROM build AS publish
RUN dotnet publish "Transaction.API.csproj" -c Release -o /app/publish

#Build Image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
FROM base AS final
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transaction.API.dll"]