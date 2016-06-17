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

        public IList<OrcamentoItem> Itens { get; private set; }

        private Orcamento()
        {
            Itens = new List<OrcamentoItem>();
        }

        public Orcamento(double valor) : this()
        {
            this.Valor = valor;
        }
    }

    public class OrcamentoItem
    {

    }
}
