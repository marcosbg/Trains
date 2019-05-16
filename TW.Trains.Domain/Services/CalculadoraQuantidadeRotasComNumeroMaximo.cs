﻿using System;
using System.Collections;
using TW.Trains.Domain.Models;

namespace TW.Trains.Domain.Services
{
    public class CalculadoraQuantidadeRotasComNumeroMaximo : CalculadoraQuantidadeRotasBase
    {
        public CalculadoraQuantidadeRotasComNumeroMaximo(Ferrovia ferrovia) : base(ferrovia)
        {
        }

        protected override void QuantidadeParadasComReferencia(string cidadeOrigem, string cidadeDestino, double numeroAtual, double numeroReferencia)
        {
            // Busca nas cidades proximas a atual e verifica se chegou nos destino e a quantidade de paradas nao ultrapassou o limite
            foreach (string cidadeBusca in (Ferrovia.Rotas[cidadeOrigem] as Hashtable).Keys)
            {
                var qtdParadas = numeroAtual + 1;
                if (qtdParadas > numeroReferencia)
                    return;

                if (cidadeBusca == cidadeDestino)
                {
                    QuantidadeRotas += 1;
                }
                else
                {
                    QuantidadeParadasComReferencia(cidadeBusca, cidadeDestino, qtdParadas, numeroReferencia);
                }
            }
        }
    }
}
