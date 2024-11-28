# Step 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the project file and restore the dependencies (via dotnet restore)
COPY ["comment-service/comment-service.csproj", "comment-service/"]

# Run restore to install the required dependencies
RUN dotnet restore "comment-service/comment-service.csproj"

# Copy the rest of the source code into the container
COPY . .

# Publish the application in release mode
RUN dotnet publish "comment-service/comment-service.csproj" -c Release -o /app/publish

# Step 2: Set up the runtime environment for the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory for the final container
WORKDIR /app

# Expose the port that the application will listen on
EXPOSE 8084

# Copy the published application from the build stage to the final image
COPY --from=build /app/publish /app

# Set the entry point to the application
ENTRYPOINT ["dotnet", "comment-service.dll"]
