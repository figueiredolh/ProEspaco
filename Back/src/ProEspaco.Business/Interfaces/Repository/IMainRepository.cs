using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Business.Interfaces.Repository
{
    public interface IMainRepository<T> : IDisposable where T : class
    {
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        void ExcluirVarios(IEnumerable<T> entidades);
        Task<bool> SalvarAlteracoes();
    }
}
