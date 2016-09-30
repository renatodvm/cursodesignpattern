using CursoAluraDesignPatterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.Decorator
{
    public class Ikcv2 : Imposto
    {
        public Ikcv2() : base() { }

        public Ikcv2(Imposto outroImposto) : base(outroImposto)
        {
        }

        public override double CalculaImposto(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.09) + CalculaOutroImposto(orcamento);
        }
    }
}
