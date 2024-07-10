// Entry point of the whole application

// Get the builder container of the web app
using Microsoft.EntityFrameworkCore;
using SocialMediaAPI.AppDataContext;
using SocialMediaAPI.Interfaces;
using SocialMediaAPI.Models;
using SocialMediaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the application
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("DBSettings"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddLogging();
builder.Services.AddProblemDetails();

// Register the DbContext with scoped lifetime
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbSettings:ConnectionString")));

// Register the IUserServices with its implementation
builder.Services.AddScoped<IUserServices, UserService>();

var app = builder.Build();

{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    // Perform any database initialization here if needed
}

if (app.Environment.IsDevelopment())
{
    // If app is run in development, use swagger for API documentation
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run the app
app.Run();
