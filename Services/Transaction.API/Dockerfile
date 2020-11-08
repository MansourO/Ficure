FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /Services/Transaction.API

#Copy Files
COPY ["Services/Transaction.API/Transaction.API.csproj", "Services/Transaction.API/"]

#Dotnet Restore
COPY Services/Transaction.API/Transaction.API.csproj ./
RUN dotnet restore Services/Transaction.API/Transaction.API.csproj

#Dotnet Publish
COPY Services/Transaction.API/Transaction.API.csproj ./
RUN dotnet publish -c Release -o out

#Build Image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Transaction.API.dll"]