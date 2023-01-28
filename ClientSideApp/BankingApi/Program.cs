using BankingApi.Config;
using BankingApi.DataAcces;
using BankingApi.Filters;
using BankingApi.Services;
using BankingApi.src;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Syncfusion.Licensing;
using Quartz;
using Quartz.Core;
using BankingApi.Jobs;

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
builder.Services.AddScoped<IDownloadService, DownloadService>();
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Host.UseSerilog((ctx, lc) =>
lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));
builder.Services.AddQuartz(quartz =>
{
    quartz.UseMicrosoftDependencyInjectionJobFactory();

    var jobKey = new JobKey("BallanceLogJob");
    quartz.AddJob<ResolveOrdersJob>(options => options.WithIdentity(jobKey));

    quartz.AddTrigger(options => options
    .ForJob(jobKey)
    .WithIdentity("StandingAndSweppingOrderJob")
    .WithCronSchedule("15 * * ? * *"));

});
builder.Services.AddQuartzHostedService(quartz => quartz.WaitForJobsToComplete = true);

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
