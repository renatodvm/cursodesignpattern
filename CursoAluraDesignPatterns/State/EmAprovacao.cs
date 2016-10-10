using System;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.State
{
    public class EmAprovacao : EstadoOrcamento
    {
        public override void Aprova(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Aprovado());
        }

        protected override void RealizarCalculoDescontoExtra(Orcamento orcamento)
        {
            orcamento.AtribuirValor(orcamento.Valor - (orcamento.Valor * 0.05));
        }

        public override void Finaliza(Orcamento orcamento)
        {
            throw new Exception("Orçamento em aprovação não pode ser finalizado.");
        }

        public override void Reprova(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Reprovado());
        }
    }
}
