using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.Builder
{
    public class NotaFiscalItemBuilder
    {
        public string Produto { get; private set; }
        public double Valor { get; private set; }

        public NotaFiscalItemBuilder ComProduto(string produto)
        {
            this.Produto = produto;
            return this;
        }

        public NotaFiscalItemBuilder ComValor(double valor)
        {
            this.Valor = valor;
            return this;
        }

        public NotaFiscalItem Criar()
        {
            return new NotaFiscalItem(Produto, Valor);
        }
    }
}
