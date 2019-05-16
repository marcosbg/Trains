namespace TW.Trains.Domain.Services
{
    public interface ICalculadoraQuantidadeRotas
    {
        string CalcularQuantidadeRotas(string cidadeOrigem, string cidadeDestino, double numeroReferencia);
    }
}