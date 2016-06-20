using CursoAluraDesignPatterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.ChainOfResponsibility
{
    public class DescontoCompraMaior500Reais : IDesconto
    {
        public IDesconto ProximoDesconto { get; set; }

        public double CalcularDesconto(Orcamento orcamento)
        {
            double desconto = 0;

            if (orcamento.Valor > 500)
                desconto = orcamento.Valor * .07;

            if (ProximoDesconto != null)
                desconto += ProximoDesconto.CalcularDesconto(orcamento);

            return desconto;
        }
    }
}
