var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.restaurant_service>("restaurant-service");

builder.Build().Run();
