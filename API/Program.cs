// Configura��o inicial da aplica��o

using API.Config; // Importa o namespace para acessar as configura��es da aplica��o
using Application.Interface; // Importa o namespace para acessar as interfaces da aplica��o
using Application.Services; // Importa o namespace para acessar os servi�os da aplica��o
using Infrastructure.Interfaces; // Importa o namespace para acessar as interfaces da infraestrutura
using Infrastructure.Repositories; // Importa o namespace para acessar os reposit�rios da infraestrutura
using MongoDB.Driver; // Importa o namespace para acessar as classes relacionadas ao MongoDB

var builder = WebApplication.CreateBuilder(args); // Cria um novo WebApplicationBuilder

// Adiciona servi�os ao container
var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>(); // Obt�m as configura��es do MongoDB do arquivo de configura��o
var mongoClient = new MongoClient(mongoDbSettings.ConnectionString); // Inicializa um novo cliente do MongoDB com base na string de conex�o
var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.DatabaseName); // Obt�m o banco de dados do MongoDB com base no nome do banco de dados

builder.Services.AddSingleton(mongoDatabase); // Adiciona o banco de dados como um servi�o singleton ao cont�iner de servi�os

builder.Services.AddScoped<IClienteRepository, ClienteRepository>(); // Adiciona o reposit�rio do cliente como um servi�o de escopo ao cont�iner de servi�os
builder.Services.AddScoped<IClienteService, ClienteService>(); // Adiciona o servi�o do cliente como um servi�o de escopo ao cont�iner de servi�os

builder.Services.AddControllers(); // Adiciona os controladores ao cont�iner de servi�os

// Configura o Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer(); // Adiciona o explorador de API de endpoints ao cont�iner de servi�os
builder.Services.AddSwaggerGen(); // Adiciona a gera��o de Swagger ao cont�iner de servi�os

var app = builder.Build(); // Constr�i a aplica��o

// Configura o pipeline de solicita��o HTTP
if (app.Environment.IsDevelopment()) // Verifica se o ambiente � de desenvolvimento
{
    app.UseSwagger(); // Usa o Swagger
    app.UseSwaggerUI(); // Usa o Swagger UI
}

app.UseAuthorization(); // Adiciona autoriza��o ao pipeline de solicita��o HTTP

app.MapControllers(); // Mapeia os controladores

app.Run(); // Executa a aplica��o