global using LayoutBuilder.Models;
global using LayoutBuilder.Services.ProjectServices;
global using LayoutBuilder.Models.Response;
global using LayoutBuilder.Data;

using Microsoft.EntityFrameworkCore;
using LayoutBuilder.Controllers;    

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers();
builder.Services.AddScoped<IProjectService, ProjectService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

