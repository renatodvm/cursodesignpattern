using System;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.Decorator
{
    public class ImpostoMuitoAlto : Imposto
    {
        public ImpostoMuitoAlto() : base()
        {
        }

        public ImpostoMuitoAlto(Imposto outroImposto) : base(outroImposto)
        {
        }

        public override double CalculaImposto(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.2) + CalculaOutroImposto(orcamento);
        }
    }
}
