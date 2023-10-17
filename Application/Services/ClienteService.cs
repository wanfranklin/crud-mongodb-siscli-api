using Application.Interface; // Importa o namespace para acessar as interfaces de aplicação
using Domain.Models; // Importa o namespace para acessar os modelos de domínio
using Infrastructure.Interfaces; // Importa o namespace para acessar as interfaces de infraestrutura

namespace Application.Services // Define o namespace do serviço de cliente
{
    public class ClienteService : IClienteService // Define a classe ClienteService implementando a interface IClienteService
    {
        private readonly IClienteRepository _clienteRepository; // Declaração de uma instância de IClienteRepository

        public ClienteService(IClienteRepository clienteRepository) // Construtor que recebe uma instância de IClienteRepository
        {
            _clienteRepository = clienteRepository; // Inicializa a instância de IClienteRepository
        }

        public async Task<List<Cliente>> ObterTodosClientes() // Método para obter todos os clientes
        {
            return await _clienteRepository.ObterTodosClientes(); // Retorna a lista de todos os clientes
        }

        public async Task<Cliente> ObterClientePorId(Guid id) // Método para obter um cliente por ID
        {
            return await _clienteRepository.ObterClientePorId(id); // Retorna o cliente correspondente ao ID fornecido
        }

        public async Task AdicionarNovoCliente(Cliente cliente) // Método para adicionar um novo cliente
        {
            var clienteExistente = await _clienteRepository.ObterClientePorId(cliente.Id); // Verifica se o cliente já existe

            if (clienteExistente != null) // Verifica se o cliente já existe
            {
                Console.WriteLine("Cliente com este ID já existe no banco de dados."); // Exibe uma mensagem de aviso
                return; // Retorna da função
            }

            await _clienteRepository.AdicionarCliente(cliente); // Adiciona o cliente ao repositório
        }

        public async Task AtualizarClienteExistente(Guid id, Cliente cliente) // Método para atualizar um cliente existente
        {
            // Adicione aqui a lógica para atualizar um cliente
            await _clienteRepository.AtualizarCliente(id, cliente); // Atualiza o cliente com o ID especificado
        }

        public async Task ExcluirClientePorId(Guid id) // Método para excluir um cliente por ID
        {
            // Adicione aqui a lógica para excluir um cliente por ID
            await _clienteRepository.ExcluirCliente(id); // Exclui o cliente com o ID especificado
        }
    }
}