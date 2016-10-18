using CursoAluraDesignPatterns.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.Builder
{
    public class NotaFiscalBuilder
    {
        private NotaFiscalItemBuilder _builderItem;
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public double ValorBruto { get; private set; }
        public double Impostos { get; private set; }
        public DateTime DataEmissao { get; private set; }
        public string Observacao { get; private set; }
        public IList<NotaFiscalItem> Itens { get; private set; }

        private IList<AcaoAposGerarNota> _acoesAposGerarNota = new List<AcaoAposGerarNota>();

        public NotaFiscalBuilder()
        {
            Itens = new List<NotaFiscalItem>();
            NaDataDeEmissao(DateTime.Now);
            _builderItem = new NotaFiscalItemBuilder();
        }

        public NotaFiscalBuilder ComRazaoSocial(string razaoSocial)
        {
            this.RazaoSocial = razaoSocial;
            return this;
        }

        public NotaFiscalBuilder ComCnpj(string cnpj)
        {
            this.Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder NaDataDeEmissao(DateTime dataEmissao)
        {
            this.DataEmissao = dataEmissao;
            return this;
        }

        public NotaFiscalBuilder ComObservacao(string observacao)
        {
            this.Observacao = observacao;
            return this;
        }

        public NotaFiscalBuilder ComItem(string produto, double valor)
        {
            this.Itens.Add(_builderItem.ComProduto(produto).ComValor(valor).Criar());
            this.ValorBruto += valor;
            this.Impostos += valor * 0.05;
            return this;
        }

        public NotaFiscalBuilder AdicionarAcao(AcaoAposGerarNota novaAcao)
        {
            _acoesAposGerarNota.Add(novaAcao);
            return this;
        }

        public NotaFiscal Criar()
        {
            var nf = new NotaFiscal(RazaoSocial, Cnpj, ValorBruto, Impostos, DataEmissao, Observacao, Itens);

            foreach (var acao in _acoesAposGerarNota)
            {
                acao.Executa(nf);
            }

            return nf;
        }
    }
}
