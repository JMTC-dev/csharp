using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UserApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDb>(options => options.UseInMemoryDatabase("UserList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSingleton<PasswordHasher<User>>();
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
    app.UseDeveloperExceptionPage();
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "UserAPI";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapGet("/users", async Task<Ok<List<UserDTO>>> (UserDb db) =>
{
    var listOfUsers = await db.Users.Select((user) => new UserDTO(user)).ToListAsync();
    return TypedResults.Ok(listOfUsers);
});

app.MapGet("/users/{id}", async Task<Results<Ok<UserDTO>, NotFound>> (int id, UserDb db) =>
{

    return await db.Users.FindAsync(id)
        is User user
        ? TypedResults.Ok(new UserDTO(user))
        : TypedResults.NotFound();
});

app.MapPost("/users", async Task<Created<UserDTO>> (UserCreateRequest newUser, UserDb db, PasswordHasher<User> ph) =>
{
    var hashedPassword = ph.HashPassword(null, newUser.Password);
    var user = new User(newUser.Username, newUser.Email, hashedPassword);

    db.Users.Add(user);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/users/{user.Id}", new UserDTO(user));
});

app.MapPatch("/users/{id}", async Task<Results<Ok, NotFound>> (int id, UserDb db, UserUpdateRequest updateUser, PasswordHasher<User> ph) =>
{
    var userToUpdate = await db.Users.FindAsync(id);
    if (userToUpdate == null)
    {
        return TypedResults.NotFound();
    }

    if (updateUser.Email != null)
    {
        userToUpdate.Email = updateUser.Email;
    }

    if (updateUser.Password != null)
    {
        var hashedPassword = ph.HashPassword(null, updateUser.Password);
        userToUpdate.Password = hashedPassword;
    }

    await db.SaveChangesAsync();

    return TypedResults.Ok();

});

app.Run();