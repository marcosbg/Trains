using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.Trains.Domain.Frabrics;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Tests.DomainTests
{
    [TestClass]
    public class TestCalculadoraDistancias : TestsBase
    {
        [TestMethod]
        public void CalcularDistanciaRotaEntreCidades_CidadeNaoExisteNaFerrovia_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraDistancia.CriarCalculadoraDistancias(ferrovia);

            var rotaPrimeiroItemNaoExiste = new string[] { "X", "B", "C" };
            var resultadoPrimeiroItemNaoExiste = servico.CalcularDistanciaRotaEntreCidades(rotaPrimeiroItemNaoExiste);

            var rotaItemNoMeioNaoExiste = new string[] { "A", "X", "C" };
            var resultadoItemNoMeioNaoExiste = servico.CalcularDistanciaRotaEntreCidades(rotaItemNoMeioNaoExiste);

            var rotaUltimoItemNaoExiste = new string[] { "A", "B", "X" };
            var resultadoUltimoItemNaoExiste = servico.CalcularDistanciaRotaEntreCidades(rotaUltimoItemNaoExiste);

            Assert.IsTrue(resultadoPrimeiroItemNaoExiste == MensagensUtil.MensagemRotaNaoExiste);
            Assert.IsTrue(resultadoItemNoMeioNaoExiste == MensagensUtil.MensagemRotaNaoExiste);
            Assert.IsTrue(resultadoUltimoItemNaoExiste == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularDistanciaRotaEntreCidades_CidadesEstaoConectadas_DeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraDistancia.CriarCalculadoraDistancias(ferrovia);

            var rotaComCidadesConectadas = new string[] { "A", "B", "C" };
            var resultado = servico.CalcularDistanciaRotaEntreCidades(rotaComCidadesConectadas);

            Assert.IsTrue(resultado == "9");
        }
    }
}
