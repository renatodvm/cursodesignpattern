using CursoAluraDesignPatterns.StrategyInvestimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.ChainOfResponsibilityRequisicaoWeb
{
    public class RequisicaoCsv : RequisicaoBase, IRequisicao
    {
        public RequisicaoCsv(IRequisicao proximaRequisicao) : base(proximaRequisicao)
        { }

        public string Requisitar(Conta conta, FormatoRequisicao formato)
        {
            if (formato != FormatoRequisicao.Csv)
                return ProximaRequisicao == null ? string.Empty : ProximaRequisicao.Requisitar(conta, formato);

            return string.Format("{0};{1}", conta.Titular, conta.Saldo);
        }
    }
}
