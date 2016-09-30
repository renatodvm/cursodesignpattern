using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.Decorator
{
    public class Icpp2 : Imposto
    {
        public Icpp2() : base() { }

        public Icpp2(Imposto outroImposto) : base(outroImposto)
        {
        }

        public override double CalculaImposto(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.1) + CalculaOutroImposto(orcamento);
        }
    }
}
