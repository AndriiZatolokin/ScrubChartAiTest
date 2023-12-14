using Microsoft.EntityFrameworkCore;
using ScrubChartAiTest.Repositories;
using AppDBContext = ScrubChartAiTest.DataBase.AppDBContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
var connectionString = builder.Configuration.GetConnectionString("AppContext");
builder.Services.AddDbContext<AppDBContext>(options =>
           options.UseNpgsql(connectionString));

builder.Services.AddScoped<IVisitRepository, VistiRepository>();

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
