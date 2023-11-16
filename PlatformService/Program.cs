using Microsoft.EntityFrameworkCore;
using PlatformService.Core.Interfaces;
using PlatformService.Infrastructure.Service;
using PlatformService.Infrastructure.Data;
using PlatformService.Infrastructure.Repository;
using PlatformService.Infrastructure.Repository.Base;
using PlatformService.Middleware;
using PlatformService.SyncDataService.Http;
using PlatformService.SyncDataService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();
builder.Services.AddScoped<IPlatformService, PfService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddHttpClient<ICommandDataClient , HttpCommandDataClient>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMem"));


var app = builder.Build();
Console.WriteLine($"--> CommandService Endpoint {app.Configuration["CommandService"]}");

app.Prepopulation();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


