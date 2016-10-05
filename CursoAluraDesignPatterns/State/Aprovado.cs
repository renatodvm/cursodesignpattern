using System;
using CursoAluraDesignPatterns.Strategy;

namespace CursoAluraDesignPatterns.State
{
    public class Aprovado : EstadoOrcamento
    {
        public override void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está aprovado.");
        }

        public override void CalcularDescontoExtra(Orcamento orcamento)
        {
            orcamento.AtribuirValor(orcamento.Valor - (orcamento.Valor * 0.02));
        }

        public override void Finaliza(Orcamento orcamento)
        {
            orcamento.AlterarEstado(new Finalizado());
        }

        public override void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento aprovado não pode ser reprovado.");
        }
    }
}
