using System;
using System.Collections.Generic;
using System.Linq;
namespace CursoAluraDesignPatterns.DecoratorFiltros
{
    public class ContaAbertaMesCorrente : FiltroConta
    {
        public ContaAbertaMesCorrente()
        {
        }

        public ContaAbertaMesCorrente(FiltroConta proximoFiltro) : base(proximoFiltro)
        {
        }

        protected override List<Conta> AplicaFiltro(IList<Conta> contas)
        {
            return contas.Where(c => c.DataAbertura.Month == DateTime.Now.Month).ToList();
        }
    }
}
