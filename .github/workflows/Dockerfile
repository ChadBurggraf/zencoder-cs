FROM mcr.microsoft.com/dotnet/sdk:6.0

ARG NUGET_API_KEY
ARG PUBLISH_ARGS
ARG NUGET_PKG


COPY ./Source/Zencoder/Zencoder.csproj /build//src/Zencoder/Zencoder.csproj

COPY . /build

WORKDIR /build

RUN dotnet restore Zencoder.sln --verbosity minimal

RUN dotnet publish -c Release --no-restore ${PUBLISH_ARGS}

RUN mkdir /output

RUN find /build/src/ -iname ${NUGET_PKG} -exec cp {} /output \;

WORKDIR /output

RUN ls /output

RUN dotnet nuget push ${NUGET_PKG} --skip-duplicate -k ${NUGET_API_KEY} --source https://nuget-push.hudltools.com/
