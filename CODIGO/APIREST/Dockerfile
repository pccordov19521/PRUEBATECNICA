FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /apiapp
EXPOSE 80 
EXPOSE 5001

#COPY PROJECT FILES
COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish APIREST.csproj -o out 

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /apiapp

RUN  ls -al
COPY --from=build /apiapp/out .
ENTRYPOINT ["dotnet","APIREST.dll"]