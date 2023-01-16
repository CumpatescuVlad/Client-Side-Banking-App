using DataApi.Config;
using DataApi.Services;
using DataApi.src;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ConfigModel>(builder.Configuration.GetSection("Config"));
builder.Services.AddScoped<ICredentials, Credentials>();
builder.Services.AddScoped<IAuthentificationService, AuthentificationService>();
builder.Services.AddScoped<ICommunicationService, CommunicationService>();  
builder.Services.AddScoped<IActivationService, ActivationService>();
builder.Services.AddScoped<ICredentialsUpdateService, CredentialsUpdateService>();
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
