# Use the SDK image to build and run tests
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /src/CandidateApp.Tests

# Copy the test project and other necessary files
COPY ["CandidateApp.Tests/CandidateApp.Tests.csproj", "CandidateApp.Tests/"]

# Restore dependencies
RUN dotnet restore "./CandidateApp.Tests/CandidateApp.Tests.csproj" --no-cache

# Copy the rest of the code
COPY . .

# Build the test project
RUN dotnet build "./CandidateApp.Tests/CandidateApp.Tests.csproj" -c Release -o /app/build

# Run the tests
FROM build AS test
WORKDIR /app/build
RUN dotnet test "CandidateApp.Tests.dll" --logger "trx;LogFileName=test_results.xml"

# For running tests as part of the build process
FROM test AS final
ENTRYPOINT ["dotnet", "test", "CandidateApp.Tests.dll"]
