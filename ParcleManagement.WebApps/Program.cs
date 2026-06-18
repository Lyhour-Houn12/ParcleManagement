<<<<<<< HEAD
using Blazilla;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ParcleManagement.Data.Data;
using ParcleManagement.Data.Models;
using ParcleManagement.WebApps.Components;
using ParcleManagement.WebApps.Validator;
using Microsoft.AspNetCore.Components.Authorization;
using ParcleManagement.WebApps.Auth;

var builder = WebApplication.CreateBuilder(args);

// ── Razor / Blazor ──────────────────────────────────────────────────────────
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ── Database ────────────────────────────────────────────────────────────────
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ── FluentValidation ────────────────────────────────────────────────────────
// Blazilla recommends AddSingleton — validators are stateless and safe to share
builder.Services.AddSingleton<IValidator<LoginModel>, LoginModelValidator>();

// Add these before builder.Build()
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/login";
    });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<CustomAuthStateProvider>();

// ── Build ───────────────────────────────────────────────────────────────────
var app = builder.Build();

// ── Pipeline ────────────────────────────────────────────────────────────────
=======
using Microsoft.EntityFrameworkCore;
using ParcleManagement.Data.db_migration;
using ParcleManagement.WebApps.Components;

var builder = WebApplication.CreateBuilder(args);

// Add parcleDbContext to the container
builder.Services.AddDbContext<ParcleDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
>>>>>>> 5a6549e8f79d4fc59d7a6e713444ce58ecbbc4d7
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
<<<<<<< HEAD

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseAuthentication();  
app.UseAuthorization();
app.UseAntiforgery();   
=======
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();
>>>>>>> 5a6549e8f79d4fc59d7a6e713444ce58ecbbc4d7

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

<<<<<<< HEAD
app.MapPost("/api/auth/register", async (RegisterRequest req, AppDbContext db) =>
{
    if (await db.Users.AnyAsync(u => u.email == req.Email))
        return Results.BadRequest(new { message = "Email already exists." });

    var user = new User
    {
        full_name = req.FullName,
        email = req.Email,
        phone_number = req.PhoneNumber,
        password = BCrypt.Net.BCrypt.HashPassword(req.Password),
        gender = req.Gender,
        address = req.Address,
        status = "active",
        hire_date = DateTime.UtcNow,
        created_at = DateTime.UtcNow,
        updated_at = DateTime.UtcNow,
        manager_id = 0
    };

    db.Users.Add(user);
    await db.SaveChangesAsync();

    return Results.Ok(new { message = "Registered successfully.", userId = user.ID });
});


app.MapPost("/api/auth/login", async (LoginRequest req, AppDbContext db) =>
{
    var user = await db.Users.FirstOrDefaultAsync(u => u.email == req.Email);

    if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.password))
        return Results.Unauthorized();

    return Results.Ok(new
    {
        message = "Login successful.",
        userId = user.ID,
        fullName = user.full_name,
        email = user.email,
        status = user.status
    });
});

app.Run();

record LoginRequest(string Email, string Password);

record RegisterRequest(
    string FullName,
    string Email,
    string PhoneNumber,
    string Password,
    string Address,
    GStatus Gender
);
=======
app.Run();
>>>>>>> 5a6549e8f79d4fc59d7a6e713444ce58ecbbc4d7
