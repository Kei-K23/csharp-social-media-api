// Entry point of the whole application

// Get the builder container of the web app
using SocialMediaAPI.AppDataContext;
using SocialMediaAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the application
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DBSettings>(builder.Configuration.GetSection("DBSettings"));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddLogging();
builder.Services.AddProblemDetails();

// DB Context instance to be Singleton pattern
builder.Services.AddSingleton<UserDbContext>();

var app = builder.Build();

{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider;
}

if (app.Environment.IsDevelopment())
{
    // If app is run in development, use swagger for api documentation
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run the app
app.Run();