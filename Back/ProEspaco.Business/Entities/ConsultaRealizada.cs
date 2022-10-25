using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Business.Entities
{
    public class ConsultaRealizada
    {
        public int Id { get; set; }
        public int AgendamentoId { get; set; }

        public Agendamento Agendamento { get; set; }
    }
}
