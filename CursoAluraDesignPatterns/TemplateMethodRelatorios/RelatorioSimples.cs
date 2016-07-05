using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoAluraDesignPatterns.StrategyInvestimentos;

namespace CursoAluraDesignPatterns.TemplateMethodRelatorios
{
    public class RelatorioSimples : RelatorioBase
    {
        public override string ObterCabecalho(Banco banco)
        {
            return banco.Nome;
        }

        public override string ObterCorpo(Conta conta)
        {
            return string.Format("Titular: {0} - Saldo: {1} ", conta.Titular, conta.Saldo.ToString("###,###,##0.00"));
        }

        public override string ObterRodape(Banco banco)
        {
            return banco.Telefone;
        }
    }
}
