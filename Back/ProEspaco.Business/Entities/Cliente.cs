using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Business.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; } //Configurar como Unique
        public string? Cep { get; set; }
        public string? Endereco { get; set; }
        public string? Bairro { get; set; }
        public DateTime DataCadastro { get; set; }

        public IEnumerable<Agendamento>? Agendamentos { get; set; }
    }
}
