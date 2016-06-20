using CursoAluraDesignPatterns.StrategyInvestimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.ChainOfResponsibilityRequisicaoWeb
{
    public class RequisicaoPorcento : IRequisicao
    {
        private IRequisicao _ProximaRequisicao;

        public IRequisicao ProximaRequisicao { set { _ProximaRequisicao = value; } }

        public string Requisitar(Conta conta, FormatoRequisicao formato)
        {
            if (formato != FormatoRequisicao.Porcento)
                return _ProximaRequisicao == null ? string.Empty : _ProximaRequisicao.Requisitar(conta, formato);

            return string.Format("{0}%{1}", conta.Titular, conta.Saldo);
        }
    }
}
