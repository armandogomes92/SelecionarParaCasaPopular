
using Microsoft.EntityFrameworkCore;
using SelecionarParaCasaPopular.Data.DataContext;
using SelecionarParaCasaPopular.Data.Models;
using SelecionarParaCasaPopular.Services.Interfaces;
using System.Collections;

namespace SelecionarParaCasaPopular.Services
{
    public class FamiliaService: IFamiliaService
    {
        private readonly FamiliasContext _context;
        private readonly ICalculadorService _calculador;

        public FamiliaService(FamiliasContext context, ICalculadorService calculador)
        {
            _context = context;
            _calculador = calculador;
        }

        public bool AdicionaFamilia(Familia familia)
        {
            familia.Pontos = _calculador.CalcularPontuacaoTotal(familia);
            _context.Add(familia);
            _context.SaveChanges();
            var result = _context.Familia.Where(f => f.Membros == familia.Membros);
            if (result != null) return true;
            return false;
        }

        public List<Familia> BuscarFamiliaOrdenadoPorPonto() 
        {
            return _context.Familia.Include(f => f.Membros).OrderByDescending(f => f.Pontos).ToList();
        }
    }
}
