using System.Collections.Generic;
using System.Linq;

namespace CursoAluraDesignPatterns.DecoratorFiltros
{
    public class ContaMenos100Reais : FiltroConta
    {
        public ContaMenos100Reais()
        {
        }

        public ContaMenos100Reais(FiltroConta proximoFiltro) : base(proximoFiltro)
        {
        }

        protected override List<Conta> AplicaFiltro(IList<Conta> contas)
        {
            return contas.Where(c => c.Saldo < 100).ToList();
        }
    }
}
