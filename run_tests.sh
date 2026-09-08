#!/bin/bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
TEST_PROJECT="$SCRIPT_DIR/Pliance.SDK.Tests/Pliance.SDK.Tests.csproj"
RESULTS_DIR="$SCRIPT_DIR/test-results"
RESULTS_FILE="results.xml"

mkdir -p "$RESULTS_DIR"

dotnet test "$TEST_PROJECT" \
  --logger "junit;LogFilePath=$RESULTS_FILE" \
  --results-directory "$RESULTS_DIR"

echo "JUnit test results written to $RESULTS_DIR/$RESULTS_FILE"
