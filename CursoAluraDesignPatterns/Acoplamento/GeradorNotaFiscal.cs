using System.Collections.Generic;

namespace CursoAluraDesignPatterns.Acoplamento
{
    public class GeradorNotaFiscalAcoplado
    {
        private EnviadorDeEmail email;
        private NotaFiscalDao dao;

        public GeradorNotaFiscalAcoplado(EnviadorDeEmail email, NotaFiscalDao dao)
        {
            this.email = email;
            this.dao = dao;
        }

        public NotaFiscal Gera(Fatura fatura)
        {

            double valor = fatura.ValorMensal;

            NotaFiscal nf = new NotaFiscal(valor, ImpostoSimplesSobreO(valor));

            email.EnviaEmail(nf);
            dao.Persiste(nf);

            return nf;
        }

        private double ImpostoSimplesSobreO(double valor)
        {
            return valor * 0.06;
        }
    }

    public class GeradorNotaFiscalDesacoplado
    {
        private IList<IAcaoAposEnviarNota> _acoes;

        public GeradorNotaFiscalDesacoplado(IList<IAcaoAposEnviarNota> acoes)
        {
            _acoes = acoes;
        }

        public NotaFiscal Gera(Fatura fatura)
        {
            double valor = fatura.ValorMensal;

            NotaFiscal nf = new NotaFiscal(valor, ImpostoSimplesSobreO(valor));

            foreach (IAcaoAposEnviarNota acao in _acoes)
                acao.Executa(nf);

            return nf;
        }

        private double ImpostoSimplesSobreO(double valor)
        {
            return valor * 0.06;
        }
    }
}
