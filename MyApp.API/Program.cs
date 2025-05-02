using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MyApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region �۩w�q�A��
builder.Services.ConfigureCors();
builder.Services.ConfigureContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
#endregion

var app = builder.Build();

#region �۩w�q�B��
app.UseCors("AllowOrigin");
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
