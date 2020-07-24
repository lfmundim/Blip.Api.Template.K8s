FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["Blip.Api.Template.Facades/Blip.Api.Template.Facades.csproj", "Blip.Api.Template.Facades/"]
COPY ["Blip.Api.Template.Models/Blip.Api.Template.Models.csproj", "Blip.Api.Template.Models/"]
COPY ["Blip.Api.Template.Services/Blip.Api.Template.Services.csproj", "Blip.Api.Template.Services/"]
COPY ["Blip.Api.Template/Blip.Api.Template.csproj", "Blip.Api.Template/"]

RUN dotnet restore "Blip.Api.Template/Blip.Api.Template.csproj"
COPY . .
WORKDIR "/src/Blip.Api.Template"
RUN dotnet build "Blip.Api.Template.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Blip.Api.Template.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blip.Api.Template.dll"]