using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.ChainOfResponsibility
{
    public interface IDesconto
    {
        double CalcularDesconto(Orcamento orcamento);
        IDesconto ProximoDesconto { get; set; }
    }
}
