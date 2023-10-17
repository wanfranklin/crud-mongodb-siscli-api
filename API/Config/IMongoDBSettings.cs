// Namespace responsável pelas configurações da API
namespace API.Config;

// Interface responsável por definir as configurações do MongoDB
public interface IMongoDBSettings
{
    // Propriedade para armazenar a string de conexão com o MongoDB
    string ConnectionString { get; set; }

    // Propriedade para armazenar o nome do banco de dados no MongoDB
    string DatabaseName { get; set; }
}
