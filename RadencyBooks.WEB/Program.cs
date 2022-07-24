using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RadencyBooks.Application;
using RadencyBooks.Application.Interfaces;
using RadencyBooks.Application.Models;
using RadencyBooks.Infrastructure;
using RadencyBooks.WEB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Books"));
builder.Services
    .AddApplication()
    .AddInfrastructure();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddTransient(ser => ser.GetRequiredService<IOptions<AppSettings>>().Value);
builder.Services.AddTransient<IRepository<Book>, Repository<Book>>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IRepository<Book>, Repository<Book>>();

var app = builder.Build();
app.AddSeedData();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<ErrorHandlerMiddleware>();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();