using SelecionarParaCasaPopular.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelecionarParaCasaPopular.Data.Models.Dtos
{
    public class CreateFamiliaDto
    {
        public ICollection<CreateMebrosDto> Membros { get; set; }
        public int Pontos { get; set; }
    }
}
