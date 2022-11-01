using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEspaco.Application.DTOs;
using ProEspaco.Application.Interfaces;
using ProEspaco.Business.Entities;
using System;
using System.Threading.Tasks;

namespace ProEspaco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;
        public ClientesController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            try
            {
                var cliente = await _clienteAppService.ObterTodosAppService();

                if (cliente == null)
                {
                    return NoContent();
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao retornar dados. Erro: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            try
            {
                var cliente = await _clienteAppService.ObterPorIdAppService(id);

                if (cliente == null)
                {
                    return NoContent();
                }

                return Ok(cliente);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Erro ao retornar dados. Erro: {ex.Message}");
            }        
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(ClienteDTO modelCliente)
        {
            try
            {
                var cliente = await _clienteAppService.AdicionarAppService(modelCliente);

                if (cliente == null)
                {
                    return NoContent();
                }

                return Ok(cliente);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar dados. Erro: {ex.Message}");
            }   
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Atualizar(int id, ClienteDTO modelCliente)
        {
            try
            {
                var cliente = await _clienteAppService.AtualizarAppService(id, modelCliente);

                if (cliente == null)
                {
                    return NoContent();
                }

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar dados. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Excluir(int id)
        {
            try
            {
                var cliente = await _clienteAppService.ExcluirAppService(id);

                if (cliente == null)
                {
                    return NoContent();
                }

                return Ok("Cliente deletado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir dados. {ex.Message}");
            }
        }
    }
}
