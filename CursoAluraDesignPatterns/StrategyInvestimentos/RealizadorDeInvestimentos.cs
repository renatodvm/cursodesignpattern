using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.StrategyInvestimentos
{
    public class RealizadorDeInvestimentos
    {
        public void AplicarSaldo(EstrategiaInvestimento estrategia, Conta conta)
        {
            var valorInvestido = estrategia.AplicarSaldo(conta);
            conta.Saldo += valorInvestido;
        }
    }
}
