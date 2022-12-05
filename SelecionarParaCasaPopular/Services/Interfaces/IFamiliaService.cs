using SelecionarParaCasaPopular.Data.Models;

namespace SelecionarParaCasaPopular.Services.Interfaces
{
    public interface IFamiliaService
    {
        public bool AdicionaFamilia(Familia familia);
        public List<Familia> BuscarFamiliaOrdenadoPorPonto();

    }
}
