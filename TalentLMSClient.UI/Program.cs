using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TalentLMSClient.Domain.Entities.Common;
using TalentLMSClient.UI.Configuration;
using TalentLMSClient.Infrastructure;
using TalentLMSClient.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//Add local services of type IServiceInstaller
builder.Services.InstallServices(builder.Configuration, typeof(IServiceInstaller).Assembly);


//read configuration from appsettings.json
//Add Environment Variables to the builder
var apiSettings = builder.Configuration.GetSection("TalentLMSApiSettings");
builder.Services.Configure<TalentLMSApiSettings>(apiSettings);
builder.Configuration.AddEnvironmentVariables();



var app = builder.Build();

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
