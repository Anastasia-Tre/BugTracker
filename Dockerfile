#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
# COPY ["BugTracker.DataModel/BugTracker.DataModel.csproj", "BugTracker.DataModel/"]
# COPY ["BugTracker.DataAccessLayer/BugTracker.DataAccessLayer.csproj", "BugTracker.DataAccessLayer/"]
# COPY ["BugTracker.Services/BugTracker.Services.csproj", "BugTracker.Services/"]
# COPY ["BugTracker.WebAPI/BugTracker.WebAPI.csproj", "BugTracker.WebAPI/"]

RUN dotnet restore "BugTracker.WebAPI/BugTracker.WebAPI.csproj"
COPY . .
WORKDIR "/src/BugTracker.WebAPI"
RUN dotnet build "BugTracker.WebAPI.csproj" -c Release -o /app/build

#RUN dotnet test

FROM build AS publish
RUN dotnet publish "BugTracker.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BugTracker.WebAPI.dll"]
#ENTRYPOINT ["dotnet", "test"]
