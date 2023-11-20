using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Otus.HomeWork.DelegateAndEvents;
using Otus.HomeWork.DelegateAndEvents.Abstractions;
using Otus.HomeWork.DelegateAndEvents.Extensions;
using Otus.HomeWork.DelegateAndEvents.Services;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<StartUp>();
builder.Services.AddScoped<IPeopleService, PeopleService>();
builder.Services.AddScoped<IFolderReaderService, FolderReaderService>();
builder.Services.AddLogging(loggerBuilder =>
{
    loggerBuilder.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
});


using IHost host = builder.Build();

await host.RunAsync();