using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Business.Entities
{
    public class ServicoSubtipo
    {
        public int Id { get; set; }
        public int ServicoId { get; set; }
        public string Nome { get; set; }
        public double ValorAtual { get; set; }

        public Servico Servico { get; set; }
        public IEnumerable<Agendamento>? Agendamentos { get; set; }
    }
}
