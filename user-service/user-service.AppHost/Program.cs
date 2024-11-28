var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.user_service>("user-service");

builder.Build().Run();
