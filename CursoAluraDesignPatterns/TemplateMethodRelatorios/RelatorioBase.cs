using CursoAluraDesignPatterns.StrategyInvestimentos;
using System;
using System.Collections.Generic;

namespace CursoAluraDesignPatterns.TemplateMethodRelatorios
{
    public abstract class RelatorioBase
    {
        public abstract string ObterCabecalho(Banco banco);
        public abstract string ObterCorpo(Conta conta);
        public abstract string ObterRodape(Banco banco);

        public void ExibirRelatorio(IList<Conta> contas, Banco banco)
        {
            Console.WriteLine(ObterCabecalho(banco));
            foreach (var conta in contas)
            {
                Console.WriteLine(ObterCorpo(conta));
            }
            Console.WriteLine(ObterRodape(banco));
        }
    }
}
