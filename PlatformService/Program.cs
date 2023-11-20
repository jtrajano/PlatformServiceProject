using Microsoft.EntityFrameworkCore;
using PlatformService.Core.Interfaces;
using PlatformService.Infrastructure.Service;
using PlatformService.Infrastructure.Data;
using PlatformService.Infrastructure.Repository;
using PlatformService.Infrastructure.Repository.Base;
using PlatformService.Middleware;
using PlatformService.SyncDataService.Http;
using PlatformService.SyncDataService;
using Microsoft.Extensions.Options;
using PlatformService.AsyncDataServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IPlatformService, PfService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();
builder.Services.AddSingleton<IMessageBusClient, MessageBusClient>();


if(builder.Environment.IsProduction()){
    builder.Services.AddDbContext<AppDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("PlatformsConn")));
    Console.WriteLine("--> using SQL Server DB");
}
else{
    builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));
        Console.WriteLine("--> using In Memory DB");
}

var app = builder.Build();
Console.WriteLine($"--> CommandService Endpoint {app.Configuration["CommandService"]}");


app.Prepopulation(app.Environment.IsProduction());
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


