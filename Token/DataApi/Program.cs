using DataApi.Config;
using DataApi.Filters;
using DataApi.Services;
using DataApi.src;
using Microsoft.AspNetCore.Mvc;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ConfigModel>(builder.Configuration.GetSection("Config"));
builder.Services.AddScoped<ICredentialsProvider, CredentialsProvider>();
builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();
builder.Services.AddScoped<ICommunicationProvider, CommunicationProvider>();
builder.Services.AddScoped<IActivationService, ActivationService>();
builder.Services.AddScoped<ICredentialsUpdateService, CredentialsUpdateService>();
builder.Host.UseSerilog((ctx, lc) =>
lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));
builder.Services.Configure<ApiBehaviorOptions>(options=>
options.SuppressModelStateInvalidFilter=true);
builder.Services.AddScoped<ValidateImput>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
