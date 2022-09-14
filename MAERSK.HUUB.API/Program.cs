using MAERSK.HUUB.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<IApiService, ApiService>();
builder.Services.AddTransient<IHttpService, HttpService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MAERSK.HUUB.API",
        Version = "v1",
        Description = @"<br>API exercise by João Veloso</br>"



    });
});



builder.Services.AddControllers();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MAERSK.HUUB.API");
        c.RoutePrefix = string.Empty;
    });
}


app.UseAuthorization();

app.MapControllers();

app.Run();
