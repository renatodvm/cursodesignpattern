using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.Decorator
{
    public class Iss2 : Imposto
    {
        public Iss2(Imposto outroImposto) : base(outroImposto) { }

        public Iss2() : base() { }

        public override double CalculaImposto(Orcamento orcamento)
        {
            return (orcamento.Valor * 0.05) + CalculaOutroImposto(orcamento);
        }
    }
}
