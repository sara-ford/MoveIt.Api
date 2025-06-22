using MoveIt.Data.DataRepository;
using MoveIt.Core.Repository;
using MoveIt.Core.Services;
using MoveIt.Service;
using Microsoft.EntityFrameworkCore;
using MoveIt.Data;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// הוסיפי את ה-DbContext עם ה-ConnectionString שלך
builder.Services.AddDbContext<MoveItContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// הוסיפי את ה-services שלך
builder.Services.AddScoped<IMemberService, MembersService>();
builder.Services.AddScoped<IDataRepository, DataRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
