FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/LU.Prase.Web.Host/LU.Prase.Web.Host.csproj", "src/LU.Prase.Web.Host/"]
COPY ["src/LU.Prase.Web.Core/LU.Prase.Web.Core.csproj", "src/LU.Prase.Web.Core/"]
COPY ["src/LU.Prase.Application/LU.Prase.Application.csproj", "src/LU.Prase.Application/"]
COPY ["src/LU.Prase.Core/LU.Prase.Core.csproj", "src/LU.Prase.Core/"]
COPY ["src/LU.Prase.EntityFrameworkCore/LU.Prase.EntityFrameworkCore.csproj", "src/LU.Prase.EntityFrameworkCore/"]
WORKDIR "/src/src/LU.Prase.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/LU.Prase.Web.Host", "src/LU.Prase.Web.Host"]
COPY ["src/LU.Prase.Web.Core", "src/LU.Prase.Web.Core"]
COPY ["src/LU.Prase.Application", "src/LU.Prase.Application"]
COPY ["src/LU.Prase.Core", "src/LU.Prase.Core"]
COPY ["src/LU.Prase.EntityFrameworkCore", "src/LU.Prase.EntityFrameworkCore"]
WORKDIR "/src/src/LU.Prase.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "LU.Prase.Web.Host.dll"]
