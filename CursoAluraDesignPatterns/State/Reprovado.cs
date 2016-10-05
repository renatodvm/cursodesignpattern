using System;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.State
{
    public class Reprovado : EstadoOrcamento
    {
        public override void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento reprovado não pode ser aprovado.");
        }

        public override void CalcularDescontoExtra(Orcamento orcamento)
        {
            throw new Exception("Orçamento reprovado não pode ter desconto extra calculado.");
        }

        public override void Finaliza(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Finalizado());
        }

        public override void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está reprovado.");
        }
    }
}
