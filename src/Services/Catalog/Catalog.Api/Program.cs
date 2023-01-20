using Core.extension.Catalog;
using Data.Entities.Connection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Repositery.Implemint.Generic;
using Repositery.Interface.Generic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region connection with mango Db


builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection("MongoDbSettings")
);
builder.Services.AddSingleton<IMongoDatabase>(options => {
    var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();

    var client = new MongoClient(settings.ConnectionString);
    return client.GetDatabase(settings.DatabaseName);
});

builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);


builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
#endregion

// dependence injection

builder.Services.AddinjectDbServices(builder.Configuration);

// Auto Mapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
