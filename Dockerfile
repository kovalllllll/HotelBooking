FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["src/HotelBooking.Web/HotelBooking.Web.csproj", "src/HotelBooking.Web/"]
COPY ["src/HotelBooking.Application/HotelBooking.Application.csproj", "src/HotelBooking.Application/"]
COPY ["src/HotelBooking.Domain/HotelBooking.Domain.csproj", "src/HotelBooking.Domain/"]
COPY ["src/HotelBooking.Infrastructure/HotelBooking.Infrastructure.csproj", "src/HotelBooking.Infrastructure/"]
RUN dotnet restore "src/HotelBooking.Web/HotelBooking.Web.csproj"
COPY . .
WORKDIR "/src/src/HotelBooking.Web"
RUN dotnet build "HotelBooking.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HotelBooking.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HotelBooking.Web.dll"]
