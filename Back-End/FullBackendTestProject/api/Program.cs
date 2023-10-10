using api.Middleware;
using infrastructure;
using service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddNpgsqlDataSource(Utilities.ProperlyFormattedConnectionString,
    dataSourceBuilder => dataSourceBuilder.EnableParameterLogging());
builder.Services.AddSingleton<Repository>();
builder.Services.AddSingleton<Service>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSpaStaticFiles(conf => conf.RootPath = "../path to www directory");

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.UseMiddleware<GlobalExceptionHandler>();
app.UseSpaStaticFiles();
app.UseSpa(conf => conf.Options.SourcePath = "../path to www directory");
app.Run();