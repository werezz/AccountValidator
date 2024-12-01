using AccountValidator.Services;
using AccountValidator.Services.Interfaces;
using AccountValidator.Services.validations;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();
builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{ 
    c.SwaggerDoc("v1", new OpenApiInfo {Title = "My Api", Version = "v1" });
});

builder.Services.AddScoped<ICustomerAccountHandler, CustomerAccountHandler>();
builder.Services.AddScoped<ICustomerAccountUploadHandler, CustomerAccountUploadHandler>();
builder.Services.AddScoped<IAccountNameValidator, AccountNameValidator>();
builder.Services.AddScoped<IAccountNumberValidator, AccountNumberValidator>();
builder.Services.AddScoped<IsAlphaBetic>();
builder.Services.AddScoped<IsNumerical>();
builder.Services.AddScoped<StartsUpperCase>();
builder.Services.AddScoped<EndsWithSpecifiedCharacter>();
builder.Services.AddScoped<StartsWithSpecifiedCharacter>();
builder.Services.AddScoped<IsSpecifiedLength>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
