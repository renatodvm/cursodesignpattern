using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.ChainOfResponsibility
{
    public class DescontoMaisDe5Itens : IDesconto
    {
        public IDesconto ProximoDesconto { get; set; }

        public double CalcularDesconto(Orcamento orcamento)
        {
            double desconto = 0;

            if (orcamento.Itens.Count > 5)
                desconto = orcamento.Valor * .1;

            if (ProximoDesconto != null)
                desconto += ProximoDesconto.CalcularDesconto(orcamento);

            return desconto;
        }
    }
}
