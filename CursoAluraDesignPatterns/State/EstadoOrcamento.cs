using CursoAluraDesignPatterns.Strategy;
using System;

namespace CursoAluraDesignPatterns.State
{
    public abstract class EstadoOrcamento
    {
        protected bool CalculouDescontoExtra { get; set; }

        public virtual void CalcularDescontoExtra(Orcamento orcamento)
        {
            if (CalculouDescontoExtra)
                throw new Exception("Desconto extra já calculado.");

            CalculouDescontoExtra = true;
            RealizarCalculoDescontoExtra(orcamento);
        }

        protected abstract void RealizarCalculoDescontoExtra(Orcamento orcamento);

        public abstract void Aprova(Orcamento orcamento);
        public abstract void Reprova(Orcamento orcamento);
        public abstract void Finaliza(Orcamento orcamento);
    }
}
