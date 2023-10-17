// Namespace responsável pelas configurações da API
namespace API.Config;

// Classe que implementa a interface IMongoDBSettings
public class MongoDBSettings : IMongoDBSettings
{
    // Propriedade para armazenar a string de conexão com o MongoDB
    public string ConnectionString { get; set; }

    // Propriedade para armazenar o nome do banco de dados no MongoDB
    public string DatabaseName { get; set; }
}