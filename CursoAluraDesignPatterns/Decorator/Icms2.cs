using System;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.Decorator
{
    public class Icms2 : Imposto
    {
        public Icms2() : base()
        {
        }

        public Icms2(Imposto outroImposto) : base(outroImposto)
        {
        }

        public override double CalculaImposto(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.18) + CalculaOutroImposto(orcamento);
        }
    }
}
