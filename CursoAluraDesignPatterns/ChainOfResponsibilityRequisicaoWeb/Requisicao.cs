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
            var requisicaoXml = new RequisicaoXml();
            var requisicaoCsv = new RequisicaoCsv();
            var requisicaoPorcento = new RequisicaoPorcento();

            requisicaoXml.ProximaRequisicao = requisicaoCsv;
            requisicaoCsv.ProximaRequisicao = requisicaoPorcento;

            return requisicaoXml.Requisitar(conta, Formato);
        }
    }
}
