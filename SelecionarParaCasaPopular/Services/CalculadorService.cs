using SelecionarParaCasaPopular.Data.Models;
using SelecionarParaCasaPopular.Services.Interfaces;

namespace SelecionarParaCasaPopular.Services
{
    public class CalculadorService: ICalculadorService
    {

        public CalculadorService()
        {
        }

        public int CalcularPontosPorRenda(ICollection<Pessoa> membros)
        {
            int pontos = 0;
            double renda = membros.Sum(r => r.RendaIndividual);
            
            if (renda <= 900) pontos = 5;

            if (renda > 900 && renda <= 1500) pontos = 3;

            if (renda > 1500 || renda <= 0) pontos = 0;

            return pontos;
        }

        public int CalcularPontosPorDependentes(ICollection<Pessoa> membros)
        {
            int pontos = 0;
            int dependentes = membros.Count(d => d.Dependente == true);
            DateTime anoVigente = DateTime.Now;

            foreach (var membro in membros)
            {
                if (anoVigente.Year - membro.DataNascimento.Year  > 18)
                {
                    dependentes--;
                }
            }
            if (dependentes >= 3) pontos = 3;
                
            if (dependentes > 0 && dependentes < 3 ) pontos = 2;
            
            return pontos;
        }

        public int CalcularPontuacaoTotal(Familia familia)
        {
            int totalDePontos = CalcularPontosPorRenda(familia.Membros) + CalcularPontosPorDependentes(familia.Membros);
            return totalDePontos;
        }
    }
}
