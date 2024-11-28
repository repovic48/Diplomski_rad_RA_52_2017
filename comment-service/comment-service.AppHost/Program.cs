var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.comment_service>("comment-service");

builder.Build().Run();
