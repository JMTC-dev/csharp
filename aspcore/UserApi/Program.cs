using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UserApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UserDb>(options => options.UseInMemoryDatabase("UserList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSingleton<PasswordHasher<User>>();
var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrWhiteSpace(jwtKey))
{
    throw new ArgumentException("JWT signing keyt is not configured. Set the Jwt__Key environment variable.");
}
builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ValidAudience = "UserApi",
        ValidIssuer = "UserApi"
    };
});
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

var users = app.MapGroup("/users");

users.MapGet("/", async Task<Ok<List<UserDTO>>> (UserDb db) =>
{
    var listOfUsers = await db.Users.Select((user) => new UserDTO(user)).ToListAsync();
    return TypedResults.Ok(listOfUsers);
});

users.MapGet("/{id}", async Task<Results<Ok<UserDTO>, NotFound>> (int id, UserDb db) =>
{

    return await db.Users.FindAsync(id)
        is User user
        ? TypedResults.Ok(new UserDTO(user))
        : TypedResults.NotFound();
});

users.MapPost("/", async Task<Created<UserDTO>> (UserCreateRequest newUser, UserDb db, PasswordHasher<User> ph) =>
{
    var hashedPassword = ph.HashPassword(null, newUser.Password);
    var user = new User(newUser.Username, newUser.Email, hashedPassword);

    db.Users.Add(user);
    await db.SaveChangesAsync();

    return TypedResults.Created($"/users/{user.Id}", new UserDTO(user));
});

users.MapPatch("/{id}", async Task<Results<Ok, NotFound>> (int id, UserDb db, UserUpdateRequest updateUser, PasswordHasher<User> ph) =>
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

users.MapDelete("/{id}", async Task<Results<NoContent, NotFound>> (int id, UserDb db) =>
{
    var userToDelete = await db.Users.FindAsync(id);
    if (userToDelete == null)
    {
        return TypedResults.NotFound();
    }

    db.Users.Remove(userToDelete);

    await db.SaveChangesAsync();

    return TypedResults.NoContent();

});

app.Run();