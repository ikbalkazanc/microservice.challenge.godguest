using System.Reflection;
using checkout.application.Handlers;
using checkout.application.Settings;
using checkout.infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(opt => opt.UseNpgsql(ConnectionStrings.GetPostgreSqlDatabaseConnecitonString));
builder.Services.AddScoped(typeof(DatabaseContext));
builder.Services.AddMediatR(typeof(GetPaymentHistoryHandler));
builder.Services.AddTransient<GetPaymentHistoryHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
