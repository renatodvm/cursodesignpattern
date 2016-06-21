using CursoAluraDesignPatterns.StrategyInvestimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.ChainOfResponsibilityRequisicaoWeb
{
    public enum FormatoRequisicao { Xml, Csv, Porcento }

    public class Requisicao
    {
        public FormatoRequisicao Formato { get; private set; }

        public Requisicao(FormatoRequisicao formato)
        {
            Formato = formato;
        }

        public string Requisitar(Conta conta)
        {
            var requisicaoPorcento = new RequisicaoPorcento(null);
            var requisicaoCsv = new RequisicaoCsv(requisicaoPorcento);
            var requisicaoXml = new RequisicaoXml(requisicaoCsv);

            return requisicaoXml.Requisitar(conta, Formato);
        }
    }
}
