using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.StrategyInvestimentos
{
    public class Moderado : EstrategiaInvestimento
    {
        public double AplicarSaldo(Conta conta)
        {
            return new Random().Next(101) <= 50 ? conta.Saldo * .025 : conta.Saldo * .007;
        }
    }
}
