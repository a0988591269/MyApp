using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MyApp.API.Extensions;
using MyApp.Application.Mappings;

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
// AutoMapper �|�G
// �ھ� MappingProfile �����O����Ҧb���ե�]�Ҧp MyApp.Application�^�C
// �۰ʱ��y�õ��U�Ӳե󤤩Ҧ��~�Ӧ� AutoMapper.Profile �����O�C
// �ҥH�A�u�n�D�@�� Profile ��N��N�n�C
// �p�G�A�N Profile �����b�h�ӱM�ס]�Ҧp�@�Ӧb MyApp.Application�A�@�Ӧb MyApp.Infrastructure�^
// ����A�i�H�ϥ� typeof(InfrastructureProfile).Assembly �������e�ե� Assembly�C
// �u���b�n���U �h�Өӷ��]���P�M�ס^Profile �ɡA�~�ݭn .Assembly
builder.Services.AddAutoMapper(typeof(MappingProfile));
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
