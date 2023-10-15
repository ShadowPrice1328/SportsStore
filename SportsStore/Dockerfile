FROM mcr.microsoft.com/dotnet/aspnet:latest
COPY /bin/Release/net7.0/publish/ SportsStore
ENV ASPNETCORE_ENVIRONMENT Production
ENV Logging__Console__FormatterName=Simple
EXPOSE 5000
WORKDIR /SportsStore
ENTRYPOINT ["dotnet", "SportsStore.dll", "--urls=http://0.0.0.0:5000"]