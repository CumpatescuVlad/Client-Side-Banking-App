using BankingApi.Config;
using BankingApi.DataAcces;
using BankingApi.Filters;
using BankingApi.Services;
using Serilog;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Licensing;
using BankingApi.src;

SyncfusionLicenseProvider.RegisterLicense("NzcxNDQ0QDMyMzAyZTMzMmUzMFhjbTNwdnNTNGQ4TmlEV3A3SjZxSHNQaDhlSWlSNDBmRHBtZkJkSisvclk9");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(options =>
options.SuppressModelStateInvalidFilter = true);
builder.Services.AddScoped<ModelValidation>();
builder.Services.Configure<ConfigurationModel>(builder.Configuration.GetSection("Config"));
builder.Services.AddScoped<IInfoService, InfoService>();
builder.Services.AddScoped<IModifyData, ModifyData>();
builder.Services.AddScoped<IReadData, ReadData>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IGenerateStatements, GenerateStatements>();
builder.Services.AddScoped<IDownloadService,DownloadService>();
builder.Host.UseSerilog((ctx,lc)=>
lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));


//configure serilog
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
