using Media_Api.MyDbContext;
using Media_Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MediaDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DbConnection"));
});
builder.Services.AddControllers();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo(){Title = "Media Api", Version = "v1"});
});

var app = builder.Build();

app.UseStatusCodePages();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();