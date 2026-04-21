# Etapa 1

# Construcción
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Establecemos el directorio de trabajo
WORKDIR /app

# Copiamos todo el contenido de Blazor
COPY Agenda.Blazor ./Blazor/Agenda.Blazor/
COPY Agenda.UI.Common ./Blazor/Agenda.UI.Common/
COPY Agenda.Common ./Blazor/Agenda.Common/
COPY Agenda.Domain ./Blazor/Agenda.Domain/

# Copiamos todo el contenido de Api
COPY Agenda.Api ./Api/Agenda.Api/
COPY Agenda.DB.Local ./Api/Agenda.DB.Local/
COPY Agenda.Common ./Api/Agenda.Common/
COPY Agenda.Domain ./Api/Agenda.Domain/

# Copiamos todo el contenido de User gRPC
COPY Agenda.User.Grpc ./User/Agenda.User.Grpc/
COPY Agenda.UserDb.Local ./User/Agenda.UserDb.Local/
COPY Agenda.Common ./User/Agenda.Common/
COPY Agenda.Domain ./User/Agenda.Domain/

# Copiamos todo el contenido de Login gRPC
COPY Agenda.Login.Grpc ./Login/Agenda.Login.Grpc/
COPY Agenda.UserDb.Local ./Login/Agenda.UserDb.Local/
COPY Agenda.Common ./Login/Agenda.Common/
COPY Agenda.Domain ./Login/Agenda.Domain/

# Opcional
# Configuramos el repositorio de NuGet con los nugets privados

# Restauramos las dependencias de Blazor
RUN dotnet restore /app/Blazor/Agenda.Blazor/Agenda.Blazor.csproj

# Publicamos Blazor en modo Release
RUN dotnet publish /app/Blazor/Agenda.Blazor/Agenda.Blazor.csproj -c Release -o /out/Blazor

# Restauramos las dependencias de Api
RUN dotnet restore /app/Api/Agenda.Api/Agenda.Api.csproj

# Publicamos Api en modo Release
RUN dotnet publish /app/Api/Agenda.Api/Agenda.Api.csproj -c Release -o /out/Api

# Restauramos las dependencias de Login gRPC
RUN dotnet restore /app/Login/Agenda.Login.Grpc/Agenda.Login.Grpc.csproj

# Publicamos Login gRPC en modo Release
RUN dotnet publish /app/Login/Agenda.Login.Grpc/Agenda.Login.Grpc.csproj -c Release -o /out/Login

# Restauramos las dependencias de User gRPC
RUN dotnet restore /app/User/Agenda.User.Grpc/Agenda.User.Grpc.csproj

# Publicamos User gRPC en modo Release
RUN dotnet publish /app/User/Agenda.User.Grpc/Agenda.User.Grpc.csproj -c Release -o /out/User



# Etapa 2 - Blazor

# Imagen de producción
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS blazor

# Establecemos el directorio de trabajo
WORKDIR /app

# Copiamos los archivos publicados desde la etapa de build
COPY --from=build /out/Blazor ./

# Establecemos la variable de entorno ASPNETCORE_URLS
ENV ASPNETCORE_URLS=http://0.0.0.0:10000

# Ejecutamos la aplicación
ENTRYPOINT ["dotnet", "Agenda.Blazor.dll"]



# Etapa 3 - Api

# Imagen de producción
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS api

# Establecemos el directorio de trabajo
WORKDIR /app

# Copiamos los archivos publicados desde la etapa de build
COPY --from=build /out/Api ./

# Establecemos la variable de entorno ASPNETCORE_URLS
ENV ASPNETCORE_URLS=http://0.0.0.0:11000

# Ejecutamos la aplicación
ENTRYPOINT ["dotnet", "Agenda.Api.dll"]



# Etapa 4 - Login

# Imagen de producción
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS login

# Establecemos el directorio de trabajo
WORKDIR /app

# Copiamos los archivos publicados desde la etapa de build
COPY --from=build /out/Login ./

# Establecemos la variable de entorno ASPNETCORE_URLS
ENV ASPNETCORE_URLS=http://0.0.0.0:12000

# Ejecutamos la aplicación
ENTRYPOINT ["dotnet", "Agenda.Login.Grpc.dll"]



# Etapa 5 - User

# Imagen de producción
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS user

# Establecemos el directorio de trabajo
WORKDIR /app

# Copiamos los archivos publicados desde la etapa de build
COPY --from=build /out/User ./

# Establecemos la variable de entorno ASPNETCORE_URLS
ENV ASPNETCORE_URLS=http://0.0.0.0:13000

# Ejecutamos la aplicación
ENTRYPOINT ["dotnet", "Agenda.User.Grpc.dll"]
