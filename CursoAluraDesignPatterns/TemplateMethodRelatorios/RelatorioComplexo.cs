using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoAluraDesignPatterns.StrategyInvestimentos;

namespace CursoAluraDesignPatterns.TemplateMethodRelatorios
{
    public class RelatorioComplexo : RelatorioBase
    {
        public override string ObterCabecalho(Banco banco)
        {
            return string.Format("{0} - {1} - {2}", banco.Nome, banco.Endereco, banco.Telefone);
        }

        public override string ObterCorpo(Conta conta)
        {
            return string.Format("Titular: {0} - Agência: {1} - Nº conta: {2} - Saldo: {3}", conta.Titular, conta.Agencia, conta.NumeroConta, conta.Saldo.ToString("###,###,##0.00"));
        }

        public override string ObterRodape(Banco banco)
        {
            return string.Format("{0} - {1}", banco.Email, DateTime.Now.ToShortDateString());
        }
    }
}
