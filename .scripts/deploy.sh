#!/bin/bash

set -e
set -o pipefail

BUILD_CONFIG=$1
NUGET_API_KEY=$2
NUGET_SOURCE_URL=${3:-https://www.nuget.org/api/v2/package}

if [[ "$BUILD_CONFIG" == "Release" ]]; then
	if [ -n ${3+x} ]; then
		VERSION_SUFFIX="SNAPSHOT-$(git rev-list HEAD | wc -l)-$(git rev-parse --short HEAD)"
	else
		VERSION_SUFFIX=""
	fi

	dotnet restore /p:VersionSuffix=$VERSION_SUFFIX
	dotnet build --configuration ${BUILD_CONFIG} /p:VersionSuffix=$VERSION_SUFFIX
	dotnet pack --configuration ${BUILD_CONFIG} --no-build --version-suffix $VERSION_SUFFIX

	dotnet nuget push Didstopia.PDFSharp/bin/$BUILD_CONFIG/*.nupkg --api-key $NUGET_API_KEY --source $NUGET_SOURCE_URL || true
fi
