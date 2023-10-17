// Configuração inicial da aplicação

using API.Config; // Importa o namespace para acessar as configurações da aplicação
using Application.Interface; // Importa o namespace para acessar as interfaces da aplicação
using Application.Services; // Importa o namespace para acessar os serviços da aplicação
using Infrastructure.Interfaces; // Importa o namespace para acessar as interfaces da infraestrutura
using Infrastructure.Repositories; // Importa o namespace para acessar os repositórios da infraestrutura
using MongoDB.Driver; // Importa o namespace para acessar as classes relacionadas ao MongoDB

var builder = WebApplication.CreateBuilder(args); // Cria um novo WebApplicationBuilder

// Adiciona serviços ao container
var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDBSettings)).Get<MongoDBSettings>(); // Obtém as configurações do MongoDB do arquivo de configuração
var mongoClient = new MongoClient(mongoDbSettings.ConnectionString); // Inicializa um novo cliente do MongoDB com base na string de conexão
var mongoDatabase = mongoClient.GetDatabase(mongoDbSettings.DatabaseName); // Obtém o banco de dados do MongoDB com base no nome do banco de dados

builder.Services.AddSingleton(mongoDatabase); // Adiciona o banco de dados como um serviço singleton ao contêiner de serviços

builder.Services.AddScoped<IClienteRepository, ClienteRepository>(); // Adiciona o repositório do cliente como um serviço de escopo ao contêiner de serviços
builder.Services.AddScoped<IClienteService, ClienteService>(); // Adiciona o serviço do cliente como um serviço de escopo ao contêiner de serviços

builder.Services.AddControllers(); // Adiciona os controladores ao contêiner de serviços

// Configura o Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer(); // Adiciona o explorador de API de endpoints ao contêiner de serviços
builder.Services.AddSwaggerGen(); // Adiciona a geração de Swagger ao contêiner de serviços

var app = builder.Build(); // Constrói a aplicação

// Configura o pipeline de solicitação HTTP
if (app.Environment.IsDevelopment()) // Verifica se o ambiente é de desenvolvimento
{
    app.UseSwagger(); // Usa o Swagger
    app.UseSwaggerUI(); // Usa o Swagger UI
}

app.UseAuthorization(); // Adiciona autorização ao pipeline de solicitação HTTP

app.MapControllers(); // Mapeia os controladores

app.Run(); // Executa a aplicação