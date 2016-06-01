using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.StrategyInvestimentos
{
    public class Agressivo : EstrategiaInvestimento
    {
        public double AplicarSaldo(Conta conta)
        {
            var chance = new Random().Next(101);
            if (chance <= 20) return conta.Saldo * .05;
            if (chance <= 50) return conta.Saldo * .03;
            return conta.Saldo * .006;
        }
    }
}
