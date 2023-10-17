using Application.Interface; // Importa o namespace para acessar as interfaces de aplicação
using Domain.Models; // Importa o namespace para acessar os modelos de domínio
using Microsoft.AspNetCore.Mvc; // Importa o namespace para acessar as classes de controle do ASP.NET Core

namespace API.Controllers; // Define o namespace para os controladores da API

[ApiController] // Atributo que indica que a classe é um controlador da API
[Route("api/clientes")] // Rota base para o controlador de clientes
public class ClienteController : ControllerBase // Define a classe ClienteController como um controlador de base
{
    private readonly IClienteService _clienteService; // Declara uma variável para armazenar o serviço de cliente

    public ClienteController(IClienteService clienteService) // Construtor que recebe o serviço de cliente como parâmetro
    {
        _clienteService = clienteService; // Inicializa o serviço de cliente
    }

    [HttpPost("adicionar")] // Rota personalizada para adicionar um cliente
    public async Task<IActionResult> AdicionarCliente([FromBody] Cliente cliente) // Método para adicionar um cliente
    {
        await _clienteService.AdicionarNovoCliente(cliente); // Chama o método AdicionarNovoCliente do serviço de cliente
        return Ok("Novo cliente adicionado com sucesso ao MongoDB"); // Retorna uma resposta de sucesso
    }

    [HttpGet("listar")] // Rota personalizada para listar todos os clientes
    public async Task<IActionResult> ListarClientes() // Método para listar todos os clientes
    {
        var clientes = await _clienteService.ObterTodosClientes(); // Chama o método ObterTodosClientes do serviço de cliente
        return Ok(clientes); // Retorna uma resposta com os clientes obtidos
    }
}
