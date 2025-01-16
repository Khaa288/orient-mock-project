using MockProject.API.Extensions;
using MockProject.Application;
using MockProject.Infrastructure;
using MockProject.Infrastructure.Services.Token;
using MockProject.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services
    .AddApplication()
    .AddInfrastructure(new TokenConfiguration(builder.Configuration["Jwt:Issuer"], builder.Configuration["Jwt:Audience"], builder.Configuration["Jwt:Key"]))
    .AddPersistence(builder.Configuration.GetConnectionString("SQL_CONNECTIONSTRING"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Customized Extensions
app.UseFluentValidationExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCors(options => options
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.Run();
