using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.DecoratorFiltros
{
    public class ContaMais500MilReais : FiltroConta
    {
        public ContaMais500MilReais()
        {
        }

        public ContaMais500MilReais(FiltroConta proximoFiltro) : base(proximoFiltro)
        {
        }
        protected override List<Conta> AplicaFiltro(IList<Conta> contas)
        {
            return contas.Where(c => c.Saldo > 500000).ToList();
        }
    }
}
