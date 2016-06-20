using System.Linq;
using CursoAluraDesignPatterns.Strategy;
using System.Collections.Generic;

namespace CursoAluraDesignPatterns.ChainOfResponsibility
{
    public class DescontoPorVendaCasada : IDesconto
    {
        public IDesconto ProximoDesconto { get; set; }

        public double CalcularDesconto(Orcamento orcamento)
        {
            double desconto = 0;

            var temLapisECaneta = ExisteItem(orcamento, "Lápis") && ExisteItem(orcamento, "Caneta");
            if (temLapisECaneta)
                desconto = orcamento.Valor * 0.05;

            return desconto;
        }

        private bool ExisteItem(Orcamento orcamento, string produto)
        {
            if (string.IsNullOrWhiteSpace(produto))
                return false;

            return orcamento.Itens.Any(i => i.Produto != null && produto.ToUpper().Equals(i.Produto.ToUpper()));
        }
    }
}
