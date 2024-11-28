var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.order_service>("order-service");

builder.Build().Run();
