using Microsoft.EntityFrameworkCore;
using ProEspaco.Business.Entities;
using ProEspaco.Business.Interfaces.Repository;
using ProEspaco.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Data.Repository
{
    public class ClienteRepository : MainRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ProEspacoContext context) : base(context)
        {

        }
        
        public async Task<Cliente> ObterPorId(int id, bool incluirAgendamentos = false) //Obter uma consulta simples ou completa
        {
            var query = context.Clientes.AsNoTracking().Where(c => c.Id == id);

            if (incluirAgendamentos)
            {
                query = query.Include(c => c.Agendamentos);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> ObterPorNome(string nome)
        {
            var nomeFormatado = nome.ToLower().Trim();
            var query = context.Clientes.Where(c => c.Nome.ToLower().Trim().Contains(nomeFormatado) || nomeFormatado.Contains(c.Nome.ToLower().Trim()));
            
            return await query.OrderBy(c => c.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ObterTodos(bool incluirAgendamentos = false)
        {
            var query = context.Clientes.AsNoTracking();

            if (incluirAgendamentos)
            {
                query = query.Include(c => c.Agendamentos);
            }

            return await query.OrderBy(c => c.Nome).ToListAsync();
        }
    }
}
