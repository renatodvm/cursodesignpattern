using CursoAluraDesignPatterns.ChainOfResponsibility;
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
            //StrategyInvestimentos();

            CalculadoraDeDescontoAula();

            Console.ReadKey();
        }

        private static void CalculadoraDeDescontoAula()
        {
            // Teste 1: orçamento sem desconto
            var orcamento = new Orcamento(500.0);
            var calculadoraDeDesconto = new CalculadoraDeDesconto();

            Console.WriteLine(string.Format("Orçamento de R$ 500,00, sem desconto. Valor do desconto: {0}.", calculadoraDeDesconto.Calcular(orcamento)));

            // Teste 2: orçamento com desconto de mais de 5 itens
            var orcamento2 = new Orcamento(500);
            orcamento2.Itens.Add(new OrcamentoItem());
            orcamento2.Itens.Add(new OrcamentoItem());
            orcamento2.Itens.Add(new OrcamentoItem());
            orcamento2.Itens.Add(new OrcamentoItem());
            orcamento2.Itens.Add(new OrcamentoItem());
            orcamento2.Itens.Add(new OrcamentoItem());

            Console.WriteLine(string.Format("Orçamento de R$ 500,00, com desconto de 10% para mais de 5 itens. Valor do desconto: {0}.", calculadoraDeDesconto.Calcular(orcamento2)));

            // Teste 3: orçamento com desconto de mais de R$ 500,00
            var orcamento3 = new Orcamento(501);
            Console.WriteLine(string.Format("Orçamento de R$ 501,00, com desconto de 7%. Valor do desconto: {0}.", calculadoraDeDesconto.Calcular(orcamento3)));

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
