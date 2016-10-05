using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.State
{
    public abstract class EstadoOrcamento
    {
        public abstract void CalcularDescontoExtra(Orcamento orcamento);
        public abstract void Aprova(Orcamento orcamento);
        public abstract void Reprova(Orcamento orcamento);
        public abstract void Finaliza(Orcamento orcamento);
    }
}
