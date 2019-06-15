FROM  microsoft/dotnet:2.2-aspnetcore-runtime  AS base
WORKDIR /app
EXPOSE 49684
EXPOSE 44338


FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY . .
RUN dotnet tool install --tool-path ".paket" paket
ENV PATH="/root/.dotnet/tools:${PATH}"

WORKDIR /src/src/WebScanner-api-auth.App
RUN dotnet restore -nowarn:msb3202,nu1503
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY nginx.conf.sigil .
ENTRYPOINT ["dotnet", "WBT.Identity.Api.dll"]

