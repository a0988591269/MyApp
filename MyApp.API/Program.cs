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

#region 自定義服務
builder.Services.ConfigureCors();
builder.Services.ConfigureContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();
// AutoMapper 會：
// 根據 MappingProfile 的型別找到其所在的組件（例如 MyApp.Application）。
// 自動掃描並註冊該組件中所有繼承自 AutoMapper.Profile 的類別。
// 所以你只要挑一個 Profile 當代表就好。
// 如果你將 Profile 分散在多個專案（例如一個在 MyApp.Application，一個在 MyApp.Infrastructure）
// 那麼你可以使用 typeof(InfrastructureProfile).Assembly 來獲取當前組件的 Assembly。
// 只有在要註冊 多個來源（不同專案）Profile 時，才需要 .Assembly
builder.Services.AddAutoMapper(typeof(MappingProfile));
#endregion

var app = builder.Build();

#region 自定義運行
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
