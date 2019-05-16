﻿using System;
using System.Collections;
using TW.Trains.Domain.Models;

namespace TW.Trains.Domain.Services
{
    public class CalculadoraQuantidadeRotasComDistanciaMaxima : CalculadoraQuantidadeRotasBase
    {
        public CalculadoraQuantidadeRotasComDistanciaMaxima(Ferrovia ferrovia) : base(ferrovia)
        {
        }

        protected override void QuantidadeParadasComReferencia(string cidadeOrigem, string cidadeDestino, double numeroAtual, double numeroReferencia)
        {
            // Busca nas cidades proximas a atual e verifica se chegou nos destino e a distancia nao ultrapassou o limite
            foreach (string cidadeBusca in (Ferrovia.Rotas[cidadeOrigem] as Hashtable).Keys)
            {
                if (numeroAtual > numeroReferencia)
                    return;

                var distancia = (double)(Ferrovia.Rotas[cidadeOrigem] as Hashtable)[cidadeBusca];
                var distanciaPercorrida = numeroAtual + distancia;

                if (cidadeBusca == cidadeDestino && distanciaPercorrida < numeroReferencia)
                {
                    QuantidadeRotas += 1;
                }

                QuantidadeParadasComReferencia(cidadeBusca, cidadeDestino, distanciaPercorrida, numeroReferencia);
            }
        }
    }
}
