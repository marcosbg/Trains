namespace TW.Trains.Domain.Services
{
    public interface ICalculadoraMenoresDistancias
    {
        string CalcularDistanciaDaMenorRotaParaViajar(string cidadeOrigem, string cidadeDestino);
    }
}