using SelecionarParaCasaPopular.Data.Models;

namespace SelecionarParaCasaPopular.Services.Interfaces
{
    public interface ICalculadorService
    {
        public int CalcularPontuacaoTotal(Familia familia);
    }
}
