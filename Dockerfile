# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore CompanySystem.MVC/CompanySystem.MVC.csproj
RUN dotnet publish CompanySystem.MVC/CompanySystem.MVC.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "CompanySystem.MVC.dll"]