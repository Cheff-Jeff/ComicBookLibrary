FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 80
EXPOSE 443

ENV DATABASE_CONECTION="Server=mssqlstud.fhict.local;Database=dbi483908_users;User Id=dbi483908_users;Password=data;TrustServerCertificate=true;"

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["UserBackend/UserBackend.csproj", "UserBackend/"]
RUN dotnet restore "UserBackend/UserBackend.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "UserBackend/UserBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserBackend/UserBackend.csproj" -c Release -o /app/publish \
   -r alpine-x64 \
   --self-contained true \
   -p:PublishTrimmed=true \
   -p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./UserBackend"]

# van af parend folder
# docker build -f UserBackend\Dockerfile --force-rm -t naam .
# docker run -it -p 8000:80 --rm -e ASPNETCORE_ENVIRONMENT=Development --name container-naam image-naam

# naar swagger ui met: http://localhost:8000/swagger/index.html