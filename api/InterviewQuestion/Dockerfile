#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InterviewQuestion/InterviewQuestion.csproj", "InterviewQuestion/"]
RUN dotnet restore "InterviewQuestion/InterviewQuestion.csproj"
COPY . .
WORKDIR "/src/InterviewQuestion"
RUN dotnet build "InterviewQuestion.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterviewQuestion.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "InterviewQuestion.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet InterviewQuestion.dll