using Microsoft.EntityFrameworkCore;
using UserApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDb>(options => options.UseInMemoryDatabase("UserList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument(config =>
{
    config.DocumentName = "UserAPI";
    config.Title = "UserAPI v1";
    config.Version = "v1";
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "UserAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapGet("/users", async (UserDb db) => await db.Users.ToListAsync());

app.Run();