using EntityTask.Application;
using EntityTask.Domain.Contracts;
using EntityTask.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RegisterDependencies(builder.Services);

builder.Services.AddControllers();
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

void RegisterDependencies(IServiceCollection services)
{
    services.AddSingleton<IEntityStorage, EntityStorage>();
    services.AddTransient<IEntityService, EntityService>();
}