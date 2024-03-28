using System.Text;
using Bookshelf.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RoommateBackend.Data;
using RoommateBackend.Extensions;
using RoommateBackend.Models;
using RoommateBackend.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.ConfigureSwaggerGen();
builder.Services.ConfigureControllers();
builder.Services.ConfigureServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.Run();
