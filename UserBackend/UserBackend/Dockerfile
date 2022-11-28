#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
# RUN apk add --no-cache icu-libs
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./UserBackend.csproj", "UserBackend/"]
RUN dotnet restore "./UserBackend/UserBackend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "./UserBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./UserBackend.csproj" -c Release -o /app/publish \
   -r alpine-x64 \
   --self-contained true \
   -p:PublishTrimmed=true \
   -p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserBackend.dll"]

# docker build -t naam .
# docker run -it -p 8000:80 --rm -e ASPNETCORE_ENVIRONMENT=Development --name naam naam


# naar swagger ui met: http://localhost:8000/swagger/index.html