using FastEndpoints;
using SuperNote.Application;
using SuperNote.DataAccess;
using SuperNote.Infrastructure;
using SuperNote.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());
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