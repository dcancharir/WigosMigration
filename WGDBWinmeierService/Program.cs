using Microsoft.EntityFrameworkCore;
using Quartz;
using Serilog;
using WGDBWinmeierService.Jobs;
using WGDBWinmeierService.Context;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.Extensions.Logging.EventLog;

var options = new WebApplicationOptions
{
    Args = args,
    ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default
};

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseWindowsService();
builder.Services.Configure<EventLogSettings>(config =>
{
    config.LogName = string.Empty;
    config.SourceName = "WinmeierService";


});
var cronjobMigracionDataWarehouse = builder.Configuration.GetValue<string>("Crons:HoraMigracionDatawareHouse");
var baseUri = builder.Configuration.GetValue<string>("Variables:BaseUri");

builder.WebHost.UseUrls($"{baseUri}");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<wgdb_000Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection"));
});
//quartz
builder.Services.AddQuartz(q =>
{
    //base Quartz scheduler, job and trigger configurations
    JobKey key = new JobKey("DataWareHouseMigrationJob");
    q.AddJob<MigrationDatawareHouseJob>(jobConfig => jobConfig.WithIdentity(key));
    q.AddTrigger(opts => opts
            .ForJob(key)
            .WithIdentity("DataWareHouseMigrationJob-trigger")
           //.WithCronSchedule(cronjobMigracionDataWarehouse)
           .StartNow()
    );

}).AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
//logs
builder.Host.ConfigureLogging(logging =>
{
    var logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
    if(!Directory.Exists(logFolder))
    {
        Directory.CreateDirectory(logFolder);
    }

    var logFile = Path.Combine(logFolder, "winmeiermigrator-.log");
    logging.AddSerilog();
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Information()
        .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Error)
        .WriteTo.File(logFile, rollingInterval: RollingInterval.Day)
        .CreateLogger();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.ConfigObject.AdditionalItems.Add("syntaxHighlight", false);
    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
