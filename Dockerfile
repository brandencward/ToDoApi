# Application Build should be done in a seperate script
# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY app/ /app
WORKDIR /app
ENTRYPOINT ["dotnet", "aspnetapp.dll"]