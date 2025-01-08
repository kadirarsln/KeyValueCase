using KeyValueCase.Models;
using KeyValueCase.Services;
using Marten;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMarten(options =>
{
    // Baðlantý dizesini appsettings.json'dan okuyarak ayarla
    var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
    options.Connection(connectionString);
    options.Schema.For<KeyValueModel>().Identity(x => x.Id);
});

builder.Services.AddScoped<IDataService, DataService>();

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
