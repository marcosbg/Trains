using System;
using TW.Trains.Domain.Models;

namespace TW.Trains.Tests.DomainTests
{
    public class TestsBase
    {
        public Ferrovia CriarFerrovia()
        {
            Ferrovia ferrovia = new Ferrovia();

            //AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7

            ferrovia.AdicionarRota("A", "B", 5);
            ferrovia.AdicionarRota("B", "C", 4);
            ferrovia.AdicionarRota("C", "D", 8);
            ferrovia.AdicionarRota("D", "C", 8);
            ferrovia.AdicionarRota("D", "E", 6);
            ferrovia.AdicionarRota("A", "D", 5);
            ferrovia.AdicionarRota("C", "E", 2);
            ferrovia.AdicionarRota("E", "B", 3);
            ferrovia.AdicionarRota("A", "E", 7);

            return ferrovia;
        }
    }
}
