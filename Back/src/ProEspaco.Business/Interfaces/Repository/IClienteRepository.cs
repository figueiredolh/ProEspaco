using ProEspaco.Business.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Business.Interfaces.Repository
{
    public interface IClienteRepository : IMainRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> ObterTodos(bool incluirAgendamentos = false);
        Task<Cliente> ObterPorId(int id, bool incluirAgendamentos = false);
        Task<IEnumerable<Cliente>> ObterPorNome(string nome);
    }
}
