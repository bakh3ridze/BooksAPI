FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY /bin/release/net6.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "{BooksAPI}.dll"]