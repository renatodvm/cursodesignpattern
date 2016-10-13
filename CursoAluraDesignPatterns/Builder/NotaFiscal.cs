using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.Builder
{
    public class NotaFiscal
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public string Observacao { get; private set; }
        public IList<NotaFiscalItem> Itens { get; private set; }

        public NotaFiscal(string razaoSocial, string cnpj, double valorBruto, double impostos, DateTime dataEmissao, string observacao, IList<NotaFiscalItem> itens)
        {
            this.RazaoSocial = razaoSocial;
            this.Cnpj = cnpj;
            this.ValorBruto = valorBruto;
            this.Impostos = impostos;
            this.DataEmissao = dataEmissao;
            this.Observacao = observacao;
            this.Itens = itens;
        }
    }
}
