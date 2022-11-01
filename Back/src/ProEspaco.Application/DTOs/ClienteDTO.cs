using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEspaco.Application.DTOs
{
    public class ClienteDTO
    {
        public int Id { get; protected set; } //somente leitura
        
        [Required]
        [MaxLength(30, ErrorMessage = "O campo {0} aceita no máximo {1} caracteres")]
        public string Nome { get; set; }

        [Required]
        [Phone(ErrorMessage = "O campo {0} precisa estar em um formato válido")]
        //validar tbm com regex!
        public string Telefone { get; set; }
        public string Cep { get; set; } //regex
        
        [MaxLength(150, ErrorMessage = "O campo {0} aceita no máximo {1} caracteres")]
        public string Endereco { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} aceita no máximo {1} caracteres")]
        public string Bairro { get; set; }

        [MaxLength(50, ErrorMessage = "O campo {0} aceita no máximo {1} caracteres")]
        public string Cidade { get; set; }     
        public string DataCriacao { get; private set; } //somente leitura

        //public IEnumerable<Agendamento>? Agendamentos { get; set; }
    }
}
