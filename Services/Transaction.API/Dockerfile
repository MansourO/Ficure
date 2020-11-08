FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /Services/Transaction.API

COPY ["Services/Transaction.API/Transaction.API.csproj", "Services/Transaction.API/"]

# Copy csproj and restore as distinct layers
COPY Services/Transaction.API/Transaction.API.csproj ./
RUN dotnet restore Services/Transaction.API/Transaction.API.csproj
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Transaction.API.dll"]

