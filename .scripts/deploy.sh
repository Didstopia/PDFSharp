#!/bin/bash

set -e
set -o pipefail

BUILD_CONFIG=$1
NUGET_API_KEY=$2

if [[ "$BUILD_CONFIG" == "Release" ]]; then
	dotnet restore
	dotnet build --configuration ${BUILD_CONFIG}
	dotnet pack --configuration ${BUILD_CONFIG}
	dotnet nuget push Didstopia.PDFSharp/bin/$BUILD_CONFIG/*.nupkg --api-key $NUGET_API_KEY --source https://www.nuget.org/api/v2/package
fi
