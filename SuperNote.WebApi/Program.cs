using FastEndpoints;
using FastEndpoints.Swagger;
using SuperNote.Application;
using SuperNote.DataAccess;
using SuperNote.Domain;
using static SuperNote.WebApi.AssemblyReferences;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(WebApi, Application));

builder.Services.SwaggerDocument(o =>
{
    o.ShortSchemaNames = true;
});

builder.Services.AddSingleton(TimeProvider.System);

builder.Services
    .AddDomainServices()
    .AddApplicationServices()
    .AddDataAccessServices(builder.Configuration.GetValue<string>("Sql:ConnectionString"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseFastEndpoints(x => x.Errors.UseProblemDetails());

app.UseSwaggerGen();

app.Run();