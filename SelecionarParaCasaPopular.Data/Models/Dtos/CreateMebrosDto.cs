using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelecionarParaCasaPopular.Data.Models.Dtos
{
    public class CreateMebrosDto
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public bool TitularDoCadastro { get; set; }
        public DateTime DataNascimento { get; set; }
        public double RendaIndividual { get; set; }
        public bool Dependente { get; set; }
    }
}
