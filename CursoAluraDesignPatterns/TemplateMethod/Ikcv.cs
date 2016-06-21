using CursoAluraDesignPatterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.TemplateMethod
{
    public class Ikcv : TemplateCalculoImposto
    {
        public override double ObterTaxacaoMaxima(Orcamento orcamento)
        {
            return orcamento.Valor * .1;
        }

        public override double ObterTaxacaoMinima(Orcamento orcamento)
        {
            return orcamento.Valor * .06;
        }        

        public override bool DeveCalcularJurosMaximo(Orcamento orcamento)
        {
            return orcamento.Valor >= 500 && orcamento.Itens.Any(v => v.Valor > 100);
        }
    }
}
