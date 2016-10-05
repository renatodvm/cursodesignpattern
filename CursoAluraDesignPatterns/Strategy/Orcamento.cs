using CursoAluraDesignPatterns.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.Strategy
{
    public class Orcamento
    {
        public double Valor { get; private set; }

        public EstadoOrcamento Estado { get; private set; }

        public IList<OrcamentoItem> Itens { get; private set; }

        private Orcamento()
        {
            Itens = new List<OrcamentoItem>();
            Estado = new EmAprovacao();
        }

        public Orcamento(double valor) : this()
        {
            this.Valor = valor;
        }

        public void CalcularDescontoExtra()
        {
            Estado.CalcularDescontoExtra(this);
        }

        public void Aprova()
        {
            Estado.Aprova(this);
        }

        public void Reprova()
        {
            Estado.Reprova(this);
        }

        public void Finaliza()
        {
            Estado.Finaliza(this);
        }

        internal void AtribuirValor(double valor)
        {
            Valor = valor;
        }

        internal void AlterarEstado(EstadoOrcamento novoEstado)
        {
            Estado = novoEstado;
        }
    }

    public class OrcamentoItem
    {
        public string Produto { get; set; }
        public double Valor { get; set; }

        public OrcamentoItem(string produto, double valor)
        {
            Produto = produto;
            Valor = valor;
        }
    }
}
