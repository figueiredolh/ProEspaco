using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Business.Entities
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool TemSubtipo { get; set; }
        public string ValorAtual { get; set; }

        public IEnumerable<ServicoSubtipo>? Subtipos { get; set; }
        public IEnumerable<Agendamento>? Agendamentos { get; set; }
    }
}
