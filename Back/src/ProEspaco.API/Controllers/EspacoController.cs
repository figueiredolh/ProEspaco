using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProEspaco.Business.Interfaces.Repository;
using System.Threading.Tasks;

namespace ProEspaco.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspacoController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public EspacoController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Route("eventos")]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.ObterTodos();

            return Ok(clientes);
        }
    }
}
