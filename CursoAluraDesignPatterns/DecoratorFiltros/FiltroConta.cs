using System.Collections.Generic;

namespace CursoAluraDesignPatterns.DecoratorFiltros
{
    public abstract class FiltroConta
    {
        protected FiltroConta ProximoFiltro;

        public FiltroConta()
        {
        }

        public FiltroConta(FiltroConta proximoFiltro)
        {
            ProximoFiltro = proximoFiltro;
        }

        public virtual IList<Conta> Filtra(IList<Conta> contas)
        {
            if (contas == null)
                return new List<Conta>();

            var contasRetorno = AplicaFiltro(contas);

            if (ProximoFiltro != null)
                contasRetorno.AddRange(ProximoFiltro.Filtra(contas));

            return contasRetorno;
        }

        protected abstract List<Conta> AplicaFiltro(IList<Conta> contas);
    }
}
