using CursoAluraDesignPatterns.StrategyInvestimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.ChainOfResponsibilityRequisicaoWeb
{
    public class RequisicaoXml : RequisicaoBase, IRequisicao
    {
        public RequisicaoXml(IRequisicao proximaRequisicao) : base(proximaRequisicao)
        { }

        public string Requisitar(Conta conta, FormatoRequisicao formato)
        {
            if (formato != FormatoRequisicao.Xml)
                return ProximaRequisicao == null ? string.Empty : ProximaRequisicao.Requisitar(conta, formato);

            return string.Format("<titular>{0}</titular><saldo>{1}</saldo>", conta.Titular, conta.Saldo);
        }
    }
}
