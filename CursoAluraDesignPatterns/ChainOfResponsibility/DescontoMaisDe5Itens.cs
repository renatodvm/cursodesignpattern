using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.ChainOfResponsibility
{
    public class DescontoMaisDe5Itens : IDesconto
    {
        public IDesconto ProximoDesconto { get; set; }

        public double CalcularDesconto(Orcamento orcamento)
        {
            if (orcamento.Itens.Count > 5)
                return orcamento.Valor * .1;

            if (ProximoDesconto != null)
                return ProximoDesconto.CalcularDesconto(orcamento);

            return 0;
        }
    }
}
