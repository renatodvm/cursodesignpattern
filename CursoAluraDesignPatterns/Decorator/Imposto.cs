using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.Decorator
{
    public abstract class Imposto
    {
        public Imposto OutroImposto { get; set; }

        public Imposto(Imposto outroImposto)
        {
            this.OutroImposto = outroImposto;
        }

        public Imposto()
        {
            OutroImposto = null;
        }

        protected double CalculaOutroImposto(Orcamento orcamento)
        {
            return (OutroImposto == null ? 0 : OutroImposto.CalculaImposto(orcamento));
        }

        public abstract double CalculaImposto(Orcamento orcamento);

    }
}
