using comment_service.Services;
using comment_service.Repositories;
using comment_service.DBContext;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(8084);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.AddServiceDefaults();

builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapDefaultEndpoints();

app.UseSwagger();
app.UseSwaggerUI();
app.ApplyMigrations();

app.UseAuthorization();
app.MapControllers();

app.Run();
