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
            if (orcamento.Valor > 500)
                return orcamento.Valor * .07;

            if (ProximoDesconto != null)
                return ProximoDesconto.CalcularDesconto(orcamento);

            return 0;
        }
    }
}
