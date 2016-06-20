using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.ChainOfResponsibilityRequisicaoWeb
{
    public abstract class RequisicaoBase
    {
        protected IRequisicao ProximaRequisicao;

        public RequisicaoBase(IRequisicao proximaRequisicao)
        {
            ProximaRequisicao = proximaRequisicao;
        }
    }
}
