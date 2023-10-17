using Domain.Models; // Importa o namespace para acessar os modelos de domínio

namespace Infrastructure.Interfaces;

// Definição da interface IClienteRepository
public interface IClienteRepository
{
    Task<List<Cliente>> ObterTodosClientes(); // Método para obter todos os clientes
    Task<Cliente> ObterClientePorId(Guid id); // Método para obter um cliente por ID
    Task AdicionarCliente(Cliente cliente); // Método para adicionar um cliente
    Task AtualizarCliente(Guid id, Cliente cliente); // Método para atualizar um cliente
    Task ExcluirCliente(Guid id); // Método para excluir um cliente
}
