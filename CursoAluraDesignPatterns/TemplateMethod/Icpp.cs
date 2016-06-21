using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.TemplateMethod
{
    public class Icpp : TemplateCalculoImposto
    {
        public override double ObterTaxacaoMaxima(Orcamento orcamento)
        {
            return orcamento.Valor * .07;
        }

        public override double ObterTaxacaoMinima(Orcamento orcamento)
        {
            return orcamento.Valor * .05;
        }
        

        public override bool DeveCalcularJurosMaximo(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }
    }
}
