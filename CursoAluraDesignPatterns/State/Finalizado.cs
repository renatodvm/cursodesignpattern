using System;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.State
{
    public class Finalizado : EstadoOrcamento
    {
        public override void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ser aprovado.");
        }

        protected override void RealizarCalculoDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ter desconto extra calculado.");
        }

        public override void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está finalizado.");
        }

        public override void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento finalizado não pode ser reprovado.");
        }
    }
}
