using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEspaco.Business.Interfaces.Repository;
using ProEspaco.Data.Context;

namespace ProEspaco.Data.Repository
{
    public abstract class MainRepository<T> : IMainRepository<T> where T : class
    {
        protected readonly ProEspacoContext context;
        protected readonly DbSet<T> dbSetGeneric;
        
        public MainRepository(ProEspacoContext _context)
        {
            context = _context;
            dbSetGeneric = _context.Set<T>();
        }
        public virtual void Adicionar(T entidade)
        {
            dbSetGeneric.Add(entidade);
        }

        public virtual void Atualizar(T entidade)
        {
            dbSetGeneric.Update(entidade);
        }

        public virtual void Excluir(T entidade)
        {
            dbSetGeneric.Remove(entidade);
        }

        public virtual void ExcluirVarios(IEnumerable<T> entidades)
        {
            dbSetGeneric.RemoveRange(entidades);
        }

        public virtual async Task<bool> SalvarAlteracoes()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
