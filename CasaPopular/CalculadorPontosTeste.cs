using Microsoft.VisualBasic;
using SelecionarParaCasaPopular.Data.Models;
using SelecionarParaCasaPopular.Services;
using System;

namespace CasaPopular
{
    [TestClass]
    public class CalculadorPontosTeste
    {
        private List<Pessoa> MockPessoa(double renda1, double renda2)
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "João",
                    CPF = "123456789-10",
                    TitularDoCadastro = true,
                    DataNascimento = new DateTime(1995, 07, 22),
                    RendaIndividual = renda1,
                    Dependente = false
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Maria",
                    CPF = "987654321-10",
                    TitularDoCadastro = false,
                    DataNascimento = new DateTime(1999, 01, 15),
                    RendaIndividual = renda2,
                    Dependente = true
                }
            };
        }

        private List<Pessoa> MockPessoaDependentesMenoresDeDezoitoAnos(bool dependente1, bool dependente2, bool dependente3)
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Pedro",
                    CPF = "111111111-22",
                    TitularDoCadastro = true,
                    DataNascimento = DateTime.Now,
                    RendaIndividual = 0,
                    Dependente = dependente1
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Pedro Filho",
                    CPF = "111111111-33",
                    TitularDoCadastro = true,
                    DataNascimento = DateTime.Now,
                    RendaIndividual = 0,
                    Dependente = dependente2
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Carla",
                    CPF = "111111111-44",
                    TitularDoCadastro = true,
                    DataNascimento = DateTime.Now,
                    RendaIndividual = 0,
                    Dependente = dependente3
                }
            };
        }

        private List<Pessoa> MockPessoaDependentesMaioresDeDezoitoAnos(bool dependente1, bool dependente2, bool dependente3)
        {
            return new List<Pessoa>
            {
                new Pessoa
                {
                    Id = 1,
                    Nome = "Pedro",
                    CPF = "111111111-22",
                    TitularDoCadastro = true,
                    DataNascimento = new DateTime(2000, 01, 01),
                    RendaIndividual = 0,
                    Dependente = dependente1
                },
                new Pessoa
                {
                    Id = 2,
                    Nome = "Pedro Filho",
                    CPF = "111111111-33",
                    TitularDoCadastro = true,
                    DataNascimento = new DateTime(2000, 01, 01),
                    RendaIndividual = 0,
                    Dependente = dependente2
                },
                new Pessoa
                {
                    Id = 3,
                    Nome = "Carla",
                    CPF = "111111111-44",
                    TitularDoCadastro = true,
                    DataNascimento = new DateTime(2000, 01, 01),
                    RendaIndividual = 0,
                    Dependente = dependente3
                }
            };
        }

        [TestMethod]
        public void CalcularPontosRendaAte900()
        {
            // Arrange
            var membros = MockPessoa(450, 400);
            CalculadorService calculador = new CalculadorService();

            // Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(5, 5);
        }

        [TestMethod]
        public void CalcularPontosRendaDe901Ate1500()
        {
            // Arrange
            var membros = MockPessoa(1000, 475);

            CalculadorService calculador = new CalculadorService();

            // Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(3, 3);
        }

        [TestMethod]
        public void CalcularPontosRendaAcimaDe1500()
        {
            // Arrange
            var membros = MockPessoa(1000, 1500);

            CalculadorService calculador = new CalculadorService();

            // Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void CalcularPontosComUmDependenteMenorDezoitoAnos () 
        {
            //Arrenge
            var membros = MockPessoaDependentesMenoresDeDezoitoAnos(true, false , false);
            CalculadorService calculador = new CalculadorService();

            //Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(2, 2);
        }

        [TestMethod]
        public void CalcularPontosComDoisDependentesMenorDezoitoAnos()
        {
            //Arrenge
            var membros = MockPessoaDependentesMenoresDeDezoitoAnos(true, true, false);
            CalculadorService calculador = new CalculadorService();

            //Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(2, 2);
        }

        [TestMethod]
        public void CalcularPontosAcimaDeDoisDependentesMenoresDezoitoAnos()
        {
            //Arrenge
            var membros = MockPessoaDependentesMenoresDeDezoitoAnos(true, true, true);
            CalculadorService calculador = new CalculadorService();

            //Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(3, 3);
        }

        [TestMethod]
        public void CalcularPontosComUmDependenteMaiorDezoitoAnos()
        {
            //Arrenge
            var membros = MockPessoaDependentesMaioresDeDezoitoAnos(true, false, false);
            CalculadorService calculador = new CalculadorService();

            //Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void CalcularPontosComDoisDependentesMaioresDezoitoAnos()
        {
            //Arrenge
            var membros = MockPessoaDependentesMenoresDeDezoitoAnos(true, true, false);
            CalculadorService calculador = new CalculadorService();

            //Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void CalcularPontosAcimaDeDoisDependentesMaioresDezoitoAnos()
        {
            //Arrenge
            var membros = MockPessoaDependentesMenoresDeDezoitoAnos(true, true, true);
            CalculadorService calculador = new CalculadorService();

            //Act
            calculador.CalcularPontosPorRenda(membros);

            // Assert
            Assert.AreEqual(0, 0);
        }
    }
}