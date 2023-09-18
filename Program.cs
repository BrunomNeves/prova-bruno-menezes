using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using prova_bruno_menezes.Interfaces;
using prova_bruno_menezes.Model;
using prova_bruno_menezes.Repository;
using prova_bruno_menezes.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new  Microsoft.OpenApi.Models.OpenApiInfo 
        {
            Title = "Consulta Clima",
            Version = "v1" 
        });
});


//builder.Services.AddScoped<IRestClientService, RestClientService>();
builder.Services.AddScoped<IConsultaClimaService, ConsultaClima>();
builder.Services.AddScoped<IGravaDados, GravaDadosRepository>();
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Consulta Clima Bruno Menezes v1");
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
