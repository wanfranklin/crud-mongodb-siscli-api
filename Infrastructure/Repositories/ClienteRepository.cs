using Domain.Models;
using Infrastructure.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories;

// Classe ClienteRepository responsável por implementar a interface IClienteRepository
public class ClienteRepository : IClienteRepository
{
    // Uma coleção do MongoDB para armazenar clientes
    private readonly IMongoCollection<Cliente> _clientes;

    // Construtor que recebe um objeto IMongoDatabase para interagir com o banco de dados
    public ClienteRepository(IMongoDatabase database)
    {
        // Inicializa a coleção de clientes com base no banco de dados fornecido
        _clientes = database.GetCollection<Cliente>("clientes");
    }

    // Método para adicionar um novo cliente à coleção do MongoDB
    public async Task AdicionarCliente(Cliente cliente)
    {
        await _clientes.InsertOneAsync(cliente);
    }

    // Método para atualizar um cliente existente com base em seu ID
    public async Task AtualizarCliente(Guid id, Cliente cliente)
    {
        await _clientes.ReplaceOneAsync(c => c.Id == id, cliente);
    }

    // Método para excluir um cliente com base em seu ID
    public async Task ExcluirCliente(Guid id)
    {
        await _clientes.DeleteOneAsync(c => c.Id == id);
    }

    // Método para obter todos os clientes na coleção do MongoDB
    public async Task<List<Cliente>> ObterTodosClientes()
    {
        return await _clientes.Find(c => true).ToListAsync();
    }

    // Método para obter um cliente com base em seu ID
    public async Task<Cliente> ObterClientePorId(Guid id)
    {
        return await _clientes.Find(c => c.Id == id).FirstOrDefaultAsync();
    }
}