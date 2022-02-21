#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 44375

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Juros.Application/Juros.Application.csproj", "Juros.Application/"]
COPY ["Juros.Business/Juros.Business.csproj", "Juros.Business/"]
COPY ["Juros.Domain/Juros.Domain.csproj", "Juros.Domain/"]
RUN dotnet restore "Juros.Application/Juros.Application.csproj"
COPY . .
WORKDIR "/src/Juros.Application"
RUN dotnet build "Juros.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Juros.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Juros.Application.dll"]
