using HiQ.Leap.TestExercise.Repository;
using HiQ.Leap.TestExercise.Repository.Contracts;
using HiQ.Leap.TestExercise.Services;
using HiQ.Leap.TestExercise.Services.Contracts;
using HiQ.Leap.TestExercise.APIExample.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IRepository, Repository>();
builder.Services.AddLogging();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();