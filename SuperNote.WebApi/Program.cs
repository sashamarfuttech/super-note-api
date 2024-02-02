using FastEndpoints;
using SuperNote.Application;
using SuperNote.DataAccess;
using SuperNote.Domain;
using static SuperNote.WebApi.AssemblyReferences;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(WebApi, Application));

builder.Services.AddFastEndpoints();

builder.Services
    .AddDomainServices()
    .AddApplicationServices()
    .AddDataAccessServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFastEndpoints();
app.Run();