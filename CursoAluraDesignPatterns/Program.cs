using CursoAluraDesignPatterns.ChainOfResponsibility;
using CursoAluraDesignPatterns.ChainOfResponsibilityRequisicaoWeb;
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

            //ChainOfResponsibilityAula();
            ChainOfResponsibilityRequisicao();

            Console.ReadKey();
        }

        private static void ChainOfResponsibilityRequisicao()
        {
            var requisicao = new Requisicao(FormatoRequisicao.Xml);
            Console.WriteLine(requisicao.Requisitar(new Conta(100, "João da Silva")));

            var requisicao2 = new Requisicao(FormatoRequisicao.Csv);
            Console.WriteLine(requisicao2.Requisitar(new Conta(1000, "José da Silva")));

            var requisicao3 = new Requisicao(FormatoRequisicao.Porcento);
            Console.WriteLine(requisicao3.Requisitar(new Conta(50000, "Maria da Silva")));
        }

        private static void ChainOfResponsibilityAula()
        {
            // Teste 1: orçamento sem desconto
            var orcamento = new Orcamento(500.0);
            var calculadoraDeDesconto = new CalculadoraDeDesconto();

            Console.WriteLine(string.Format("Orçamento 1. Desconto esperado: R$ 0,00. Desconto obtido: {0}.", calculadoraDeDesconto.Calcular(orcamento)));

            // Teste 2: orçamento com desconto de mais de 5 itens
            var orcamento2 = new Orcamento(500);
            orcamento2.Itens.Add(new OrcamentoItem("Lápis"));
            orcamento2.Itens.Add(new OrcamentoItem("Borracha"));
            orcamento2.Itens.Add(new OrcamentoItem("Caneca"));
            orcamento2.Itens.Add(new OrcamentoItem("Lapiseira"));
            orcamento2.Itens.Add(new OrcamentoItem("Cola"));
            orcamento2.Itens.Add(new OrcamentoItem("Fita adesiva"));

            Console.WriteLine(string.Format("Orçamento 2. Desconto esperado > 5 itens: R$ 50,00. Desconto obtido: {0}.", calculadoraDeDesconto.Calcular(orcamento2)));

            // Teste 3: orçamento com desconto de mais de R$ 500,00
            var orcamento3 = new Orcamento(501);
            Console.WriteLine(string.Format("Orçamento 3. Desconto esperado 7%: R$ 35,07. Desconto obtido: {0}.", calculadoraDeDesconto.Calcular(orcamento3)));

            // Teste 4: orçamento com desconto de mais de 5 itens, mais de R$ 500,00 e lápis e caneta
            var orcamento4 = new Orcamento(501);
            orcamento4.Itens.Add(new OrcamentoItem("Lápis"));
            orcamento4.Itens.Add(new OrcamentoItem("Caneta"));
            orcamento4.Itens.Add(new OrcamentoItem("Caneca"));
            orcamento4.Itens.Add(new OrcamentoItem("Lapiseira"));
            orcamento4.Itens.Add(new OrcamentoItem("Cola"));
            orcamento4.Itens.Add(new OrcamentoItem("Fita adesiva"));

            Console.WriteLine(string.Format("Orçamento 4. Desconto esperado 10% + 7% + 5%: R$ 110,22. Valor do desconto: {0}.", calculadoraDeDesconto.Calcular(orcamento4)));
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
            var conta = new Conta(0, "João da Silva");
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
