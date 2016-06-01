using CursoAluraDesignPatterns.Strategy;
using CursoAluraDesignPatterns.StrategyInvestimentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //StrategyAula();
            StrategyInvestimentos();

            Console.ReadKey();
        }

        
        static void StrategyAula()
        {
            Imposto iss = new Iss();
            Imposto icms = new Icms();
            Imposto iccc = new Iccc();
            Orcamento orcamento = new Orcamento(500.0);
            CalculadorDeImposto calculador = new CalculadorDeImposto();

            // Calculando o ISS
            calculador.RealizaCalculo(orcamento, iss);

            // Calculando o ICMS        
            calculador.RealizaCalculo(orcamento, icms);

            Console.Write("Iccc < 1000 (5%): ");
            calculador.RealizaCalculo(orcamento, iccc);

            Orcamento orcamento2 = new Orcamento(1001);
            Console.Write("Iccc < 3000 (7%): ");
            calculador.RealizaCalculo(orcamento2, iccc);

            Orcamento orcamento3 = new Orcamento(3001);
            Console.Write("Iccc > 3000 (8%): ");
            calculador.RealizaCalculo(orcamento3, iccc);
        }

        static void StrategyInvestimentos()
        {
            var conta = new Conta();
            var conservador = new Conservador();
            var moderado = new Moderado();
            var agressivo = new Agressivo();
            var realizador = new RealizadorDeInvestimentos();

            conta.Saldo = 100;
            realizador.AplicarSaldo(conservador, conta);
            Console.WriteLine(string.Concat("Conservador novo saldo R$ ", conta.Saldo.ToString("###,##0.00")));

            conta.Saldo = 100;
            realizador.AplicarSaldo(moderado, conta);
            Console.WriteLine(string.Concat("Moderado novo saldo R$ ", conta.Saldo.ToString("###,##0.00")));

            conta.Saldo = 100;
            realizador.AplicarSaldo(agressivo, conta);
            Console.WriteLine(string.Concat("Agressivo novo saldo R$ ", conta.Saldo.ToString("###,##0.00")));
        }

    }
}
