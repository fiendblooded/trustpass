using Contracts;
using EFCData;
using MongoDB.Driver;
using MongoFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//BB: add user service
builder.Services.AddScoped<IUserService, UserDao>();
builder.Services.AddScoped<IMatchService, MatchDao>();
builder.Services.AddScoped<ITicketService, TicketDao>();
builder.Services.AddDbContext<PostgresDbContext>();

//BB: setting up MongoDB dependency injection
builder.Services.AddTransient<IMongoDbConnection>(
    _ => MongoDbConnection.FromUrl(new MongoUrl("mongodb+srv://bebar:pufKUcauhGNeEg86@trustpasstestcluster1.ejkw7ke.mongodb.net/trust_pass/?retryWrites=true&w=majority"))
    );
builder.Services.AddTransient<MongoContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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