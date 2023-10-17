using Domain.Models; // Importa o namespace para acessar os modelos de domínio

namespace Application.Interface; // Define o namespace para as interfaces de aplicação

public interface IClienteService // Define a interface IClienteService
{
    Task<List<Cliente>> ObterTodosClientes(); // Método para obter todos os clientes
    Task<Cliente> ObterClientePorId(Guid id); // Método para obter um cliente por ID
    Task AdicionarNovoCliente(Cliente cliente); // Método para adicionar um novo cliente
    Task AtualizarClienteExistente(Guid id, Cliente cliente); // Método para atualizar um cliente existente
    Task ExcluirClientePorId(Guid id); // Método para excluir um cliente por ID
}