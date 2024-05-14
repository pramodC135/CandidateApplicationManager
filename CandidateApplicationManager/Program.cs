using Microsoft.Azure.Cosmos;
using CandidateApplicationManager.Api.Core;
using CandidateApplicationManager.Api.Repository;
using CandidateApplicationManager.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddSingleton((provider) =>
{
    var endPointUri = configuration["CosmosDbSettings:EndpointUri"];
    var primaryKey = configuration["CosmosDbSettings:PrimaryKey"];
    var databaseName = configuration["CosmosDbSettings:DatabaseName"];

    var cosmosClientOption = new CosmosClientOptions
    {
        ApplicationName = databaseName,
        ConnectionMode = ConnectionMode.Direct
    };

    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });

    var cosmosClient = new CosmosClient(endPointUri, primaryKey, cosmosClientOption);

    return cosmosClient;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
