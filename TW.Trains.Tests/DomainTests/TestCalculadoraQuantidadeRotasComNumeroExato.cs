using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TW.Trains.Domain.Frabrics;
using TW.Trains.Domain.Services;
using TW.Trains.Domain.Utils;

namespace TW.Trains.Tests.DomainTests
{
    [TestClass]
    public class TestCalculadoraQuantidadeRotasComNumeroExato : TestsBase
    {
        [TestMethod]
        public void CalcularQuantidadeRotasComNumeroExato_CidadeOrigemNaoExiste_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComNumeroExato(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("F", "A", 1);

            Assert.IsTrue(resultado == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularQuantidadeRotasComNumeroExato_CidadeDestinoNaoExiste_NaoDeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComNumeroExato(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("A", "F", 1);

            Assert.IsTrue(resultado == MensagensUtil.MensagemRotaNaoExiste);
        }

        [TestMethod]
        public void CalcularQuantidadeRotasComNumeroExato_CidadeExistem_DeveCalcular()
        {
            var ferrovia = CriarFerrovia();
            var servico = FabricaCalculadoraQuantidadeRotas.CriarCalculadoraQuantidadeRotasComNumeroExato(ferrovia);

            var resultado = servico.CalcularQuantidadeRotas("A", "C", 4);

            Assert.IsTrue(resultado == "3");
        }
    }
}
