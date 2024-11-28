# Step 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the project file and restore the dependencies (via dotnet restore)
COPY ["user-service/user-service.csproj", "user-service/"]

# Run restore to install the required dependencies
RUN dotnet restore "user-service/user-service.csproj"

# Copy the rest of the source code into the container
COPY . .

# Publish the application in release mode
RUN dotnet publish "user-service/user-service.csproj" -c Release -o /app/publish

# Step 2: Set up the runtime environment for the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory for the final container
WORKDIR /app

# Expose the port that the application will listen on
EXPOSE 8081

# Copy the published application from the build stage to the final image
COPY --from=build /app/publish /app

# Set the entry point to the application
ENTRYPOINT ["dotnet", "user-service.dll"]
