using ProEspaco.Business.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Business.Entities
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int ServicoId { get; set; }
        public int? ServicoSubtipoId { get; set; }
        public DateTime DataAgendamento { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFim { get; set; }
        public double ValorCobrado { get; set; }
        public EnumSituacao Situacao { get; set; }

        public Cliente Cliente { get; set; }
        public Servico Servico { get; set; }
        public ServicoSubtipo ServicoSubtipo { get; set; }
        public ConsultaRealizada? ConsultaRealizada { get; set; }
    }
}
