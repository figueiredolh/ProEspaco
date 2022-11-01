using ProEspaco.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Application.Interfaces
{
    public interface IClienteAppService
    {
        Task<ClienteDTO> AdicionarAppService(ClienteDTO modelCliente);
        Task<ClienteDTO> AtualizarAppService(int id, ClienteDTO modelCliente);
        Task<ClienteDTO> ExcluirAppService(int id);
        Task<ClienteDTO> ExcluirVariosAppService(IEnumerable<ClienteDTO> modelClientes);
        Task<IEnumerable<ClienteDTO>> ObterTodosAppService(bool incluirAgendamentos = false);
        Task<ClienteDTO> ObterPorIdAppService(int id, bool incluirAgendamentos = false);
        Task<IEnumerable<ClienteDTO>> ObterPorNomeAppService(string nome);
    }
}
