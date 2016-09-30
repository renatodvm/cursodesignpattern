using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.Strategy
{
    public class Iccc : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            if (orcamento.Valor < 1000)
                return orcamento.Valor * .05;

            if (orcamento.Valor < 3000)
                return orcamento.Valor * .07;

            return orcamento.Valor * .08 + 30;
        }
    }
}
