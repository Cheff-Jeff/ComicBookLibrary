FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
EXPOSE 80
EXPOSE 443

ENV DATABASE_CONECTION="Server=mssqlstud.fhict.local;Database=dbi483908_comics;User Id=dbi483908_comics;Password=data;"

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["ComicsBackend/ComicsBackend.csproj", "ComicsBackend/"]
RUN dotnet restore "ComicsBackend/ComicsBackend.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ComicsBackend/ComicsBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ComicsBackend/ComicsBackend.csproj" -c Release -o /app/publish \
   -r alpine-x64 \
   --self-contained true \
   -p:PublishTrimmed=true \
   -p:PublishSingleFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["./ComicsBackend"]

# van af parend folder
# docker build -f UserBackend\Dockerfile --force-rm -t naam .
# docker run -it -p 8000:80 --rm -e ASPNETCORE_ENVIRONMENT=Development --name container-naam image-naam

# naar swagger ui met: http://localhost:8000/swagger/index.html