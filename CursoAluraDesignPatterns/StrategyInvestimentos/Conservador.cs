using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.StrategyInvestimentos
{
    public class Conservador : EstrategiaInvestimento
    {
        public double AplicarSaldo(Conta conta)
        {
            return conta.Saldo * .008;
        }
    }
}
