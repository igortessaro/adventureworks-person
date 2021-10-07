#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.sln .
COPY AdventureWorks.Person.Api/*.csproj ./AdventureWorks.Person.Api/
COPY AdventureWorks.Person.Domain/*.csproj ./AdventureWorks.Person.Domain/
COPY AdventureWorks.Person.Domain.Tests/*.csproj ./AdventureWorks.Person.Domain.Tests/
COPY AdventureWorks.Person.Infrastructure/*.csproj ./AdventureWorks.Person.Infrastructure/
RUN dotnet restore
COPY . .
RUN dotnet build "AdventureWorks.Person.Api/AdventureWorks.Person.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdventureWorks.Person.Api/AdventureWorks.Person.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdventureWorks.Person.Api.dll"]
