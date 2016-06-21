using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.TemplateMethod
{
    public class Ihit : TemplateCalculoImposto
    {
        public override double ObterTaxacaoMaxima(Orcamento orcamento)
        {
            return (orcamento.Valor * .13) + 100;
        }

        public override double ObterTaxacaoMinima(Orcamento orcamento)
        {
            return orcamento.Valor * .01 * orcamento.Itens.Count;
        }

        public override bool DeveCalcularJurosMaximo(Orcamento orcamento)
        {
            return (from n in orcamento.Itens
                    where orcamento.Itens.Count(n1 => n1.Produto == n.Produto) >= 2
                    select n).Distinct().Count() > 0;
        }
    }
}
