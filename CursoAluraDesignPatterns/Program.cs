using CursoAluraDesignPatterns.ChainOfResponsibility;
using CursoAluraDesignPatterns.ChainOfResponsibilityRequisicaoWeb;
using CursoAluraDesignPatterns.Decorator;
using CursoAluraDesignPatterns.SRP;
using CursoAluraDesignPatterns.Strategy;
using CursoAluraDesignPatterns.StrategyInvestimentos;
using CursoAluraDesignPatterns.TemplateMethod;
using CursoAluraDesignPatterns.TemplateMethodRelatorios;
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
            //ChainOfResponsibilityRequisicao();

            //TemplateMethodAula();
            //TemplateMethodRelatorios();

            //DecoratorAula();
            //DecoratorFiltroContas();

            StateAula();

            //SrpSemCoesao();
            //SrpComCoesao();

            Console.ReadKey();
        }

        private static void StateAula()
        {
            var orcamento = new Orcamento(500);
            Console.WriteLine(orcamento.Valor);

            orcamento.CalcularDescontoExtra();
            Console.WriteLine(orcamento.Valor);

            orcamento.Aprova();
            orcamento.CalcularDescontoExtra();
            Console.WriteLine(orcamento.Valor);

            orcamento.Finaliza();
            try
            {
                orcamento.CalcularDescontoExtra();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DecoratorFiltroContas()
        {
            var contas = new List<DecoratorFiltros.Conta>();

            var filtroMenos100Reais = new DecoratorFiltros.ContaMenos100Reais();
            var filtroMesCorrenteEFiltroMenos100Reais = new DecoratorFiltros.ContaAbertaMesCorrente(filtroMenos100Reais);
            var todosOsFiltros = new DecoratorFiltros.ContaMais500MilReais(filtroMesCorrenteEFiltroMenos100Reais);

            Console.WriteLine("Apenas 1 conta com menos de 100 reais:");
            contas.Add(new DecoratorFiltros.Conta(90, DateTime.Now));
            var contasFiltro = filtroMenos100Reais.Filtra(contas);
            foreach (var contaFiltro in contasFiltro)
            {
                Console.WriteLine(String.Concat("Data: ", contaFiltro.DataAbertura, " - Saldo R$ ", contaFiltro.Saldo.ToString("###,##0.00")));
            }
            Console.WriteLine("======================");

            Console.WriteLine("Apenas 2 contas com menos de 100 reais e 1 conta no mês corrente ");
            contasFiltro.Clear();
            contas.Clear();
            contas.Add(new DecoratorFiltros.Conta(90, DateTime.Now.AddMonths(-1)));
            contas.Add(new DecoratorFiltros.Conta(95, DateTime.Now.AddMonths(-1)));
            contas.Add(new DecoratorFiltros.Conta(1200, DateTime.Now));
            contas.Add(new DecoratorFiltros.Conta(1500, DateTime.Now.AddMonths(-1))); // Essa conta não entrará no filtro
            contasFiltro = filtroMesCorrenteEFiltroMenos100Reais.Filtra(contas);
            foreach (var contaFiltro in contasFiltro)
            {
                Console.WriteLine(String.Concat("Data: ", contaFiltro.DataAbertura, " - Saldo R$ ", contaFiltro.Saldo.ToString("###,##0.00")));
            }
            Console.WriteLine("======================");


            Console.WriteLine("2 contas com menos de 100 reais, 1 conta no mês corrente e 1 conta acima de 500.000 reais");
            contasFiltro.Clear();
            contas.Clear();
            contas.Add(new DecoratorFiltros.Conta(90, DateTime.Now.AddMonths(-1)));
            contas.Add(new DecoratorFiltros.Conta(95, DateTime.Now.AddMonths(-1)));
            contas.Add(new DecoratorFiltros.Conta(1200, DateTime.Now));
            contas.Add(new DecoratorFiltros.Conta(1500, DateTime.Now.AddMonths(-1))); // Essa conta não entrará no filtro
            contas.Add(new DecoratorFiltros.Conta(500001, DateTime.Now.AddDays(-35)));
            contasFiltro = todosOsFiltros.Filtra(contas);
            foreach (var contaFiltro in contasFiltro)
            {
                Console.WriteLine(String.Concat("Data: ", contaFiltro.DataAbertura, " - Saldo R$ ", contaFiltro.Saldo.ToString("###,##0.00")));
            }
            Console.WriteLine("======================");
        }

        private static void DecoratorAula()
        {
            var orcamento = new Orcamento(500);
            var impostos = new Iss2(new Icms2());
            var issIcmsImpostoMuitoAlto = new ImpostoMuitoAlto(new Iss2(new Icms2()));
            var impostosTotais = new Icms2(new Iss2(new ImpostoMuitoAlto(new Ikcv2(new Icpp2()))));
            var iss = new Iss2();
            var icms = new Icms2();
            var impostoMuitoAlto = new ImpostoMuitoAlto();

            Console.WriteLine(string.Concat("ISS + ICMS = R$ ", impostos.CalculaImposto(orcamento).ToString("###,##0.00")));
            Console.WriteLine(string.Concat("Só ISS = R$ ", iss.CalculaImposto(orcamento).ToString("###,##0.00")));
            Console.WriteLine(string.Concat("Só ICMS = R$ ", icms.CalculaImposto(orcamento).ToString("###,##0.00")));
            Console.WriteLine(string.Concat("Só Imposto muito alto = R$ ", impostoMuitoAlto.CalculaImposto(orcamento).ToString("###,##0.00")));
            Console.WriteLine(string.Concat("Imposto muito alto + ISS + ICMS = R$ ", issIcmsImpostoMuitoAlto.CalculaImposto(orcamento).ToString("###,##0.00")));
            Console.WriteLine(string.Concat("IKCP + ICPP + Imposto muito alto + ISS + ICMS = R$ ", impostosTotais.CalculaImposto(orcamento).ToString("###,##0.00")));
        }

        private static void SrpComCoesao()
        {
            var tester = new Funcionario(new Tester(), 10000);
            var dba = new Funcionario(new Dba(), 12000);
            var dev = new Funcionario(new Desenvolvedor(), 15000);

            var salarioTester = tester.CalcularSalario();
            var salarioDba = dba.CalcularSalario();
            var salarioDev = dev.CalcularSalario();

            Console.WriteLine(string.Concat("Salário Tester: ", salarioTester));
            Console.WriteLine(string.Concat("Salário Dba: ", salarioDba));
            Console.WriteLine(string.Concat("Salário Developer: ", salarioDev));
        }

        private static void SrpSemCoesao()
        {
            var tester = new FuncionarioSemCoesao(new TesterSemCoesao(), 10000);
            var dba = new FuncionarioSemCoesao(new DbaSemCoesao(), 12000);
            var dev = new FuncionarioSemCoesao(new DesenvolvedorSemCoesao(), 15000);

            var calcSalario = new CalculadoraDeSalarioSemCoesao();
            var salarioTester = calcSalario.calcula(tester);
            var salarioDba = calcSalario.calcula(dba);
            var salarioDev = calcSalario.calcula(dev);

            Console.WriteLine(string.Concat("Salário Tester: ", salarioTester));
            Console.WriteLine(string.Concat("Salário Dba: ", salarioDba));
            Console.WriteLine(string.Concat("Salário Developer: ", salarioDev));

        }

        private static void TemplateMethodRelatorios()
        {
            var banco = new Banco("Banco São Paulo", "11-2222-3333", "Rua ABC, 4589 - Vila dos Remédios", "renatodvm@gmail.com");
            var conta1 = new Conta(1100.01, "José 1", "1", "1");
            var conta2 = new Conta(2200.02, "José 2", "2", "2");
            var conta3 = new Conta(3300.03, "José 3", "3", "3");
            var conta4 = new Conta(4400.04, "José 4", "4", "4");
            var contas = new List<Conta>();
            contas.Add(conta1);
            contas.Add(conta2);
            contas.Add(conta3);
            contas.Add(conta4);

            var relatorioSimples = new RelatorioSimples();
            var relatorioComplexo = new RelatorioComplexo();

            relatorioSimples.ExibirRelatorio(contas, banco);
            relatorioComplexo.ExibirRelatorio(contas, banco);
            Console.ReadKey();
        }

        private static void TemplateMethodAula()
        {
            var impostoIcpp = new Icpp();
            var impostoIkcv = new Ikcv();
            var impostoIhit = new Ihit();

            // Teste 1: ICPP mínimo
            var orcamento = new Orcamento(499);
            orcamento.Itens.Add(new OrcamentoItem("Lápis", 100));
            orcamento.Itens.Add(new OrcamentoItem("Caneca", 399));

            var resultado = impostoIcpp.Calcula(orcamento);
            Console.WriteLine(string.Format("ICPP 1 valor mínimo. ICPP esperado: R$ 24,95. ICPP obtido: R$ {0}. ", resultado.ToString("###,##0.00")));


            // Teste 2: ICPP máximo
            var orcamento2 = new Orcamento(500);
            orcamento2.Itens.Add(new OrcamentoItem("Lápis", 100));
            orcamento2.Itens.Add(new OrcamentoItem("Caneca", 400));

            var resultado2 = impostoIcpp.Calcula(orcamento2);
            Console.WriteLine(string.Format("ICPP 2 valor mínimo. ICPP esperado: R$ 35,00. ICPP obtido: R$ {0}. ", resultado2.ToString("###,##0.00")));


            // Teste 3: IKCV mínimo
            var orcamento3 = new Orcamento(495);
            orcamento3.Itens.Add(new OrcamentoItem("Lápis", 99));
            orcamento3.Itens.Add(new OrcamentoItem("Caneca", 99));
            orcamento3.Itens.Add(new OrcamentoItem("Copo", 99));
            orcamento3.Itens.Add(new OrcamentoItem("Taça", 99));
            orcamento3.Itens.Add(new OrcamentoItem("Colher", 99));

            var resultado3 = impostoIkcv.Calcula(orcamento3);
            Console.WriteLine(string.Format("IKCV 1 valor mínimo. IKCV esperado: R$ 29,70. IKCV obtido: R$ {0}. ", resultado3.ToString("###,##0.00")));


            // Teste 4: IKCV máximo
            var orcamento4 = new Orcamento(500);
            orcamento4.Itens.Add(new OrcamentoItem("Lápis", 50));
            orcamento4.Itens.Add(new OrcamentoItem("Caneca", 450));

            var resultado4 = impostoIkcv.Calcula(orcamento4);
            Console.WriteLine(string.Format("IKCV 2 valor máximo. IKCV esperado: R$ 50,00. IKCV obtido: R$ {0}. ", resultado4.ToString("###,##0.00")));


            // Teste 5: IHIT mínimo
            var orcamento5 = new Orcamento(500);
            orcamento5.Itens.Add(new OrcamentoItem("Lápis", 50));
            orcamento5.Itens.Add(new OrcamentoItem("Caneca", 450));

            var resultado5 = impostoIhit.Calcula(orcamento5);
            Console.WriteLine(string.Format("IHIT 1 valor mínimo. IHIT esperado: R$ 10,00. IHIT obtido: R$ {0}. ", resultado5.ToString("###,##0.00")));


            // Teste 6: IHIT máximo
            var orcamento6 = new Orcamento(500);
            orcamento6.Itens.Add(new OrcamentoItem("Lápis", 50));
            orcamento6.Itens.Add(new OrcamentoItem("Caneca", 300));
            orcamento6.Itens.Add(new OrcamentoItem("Lápis", 50));
            orcamento6.Itens.Add(new OrcamentoItem("Colher", 100));

            var resultado6 = impostoIhit.Calcula(orcamento6);
            Console.WriteLine(string.Format("IHIT 2 valor máximo. IHIT esperado: R$ 165,00. IHIT obtido: R$ {0}. ", resultado6.ToString("###,##0.00")));
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
            orcamento2.Itens.Add(new OrcamentoItem("Lápis", 10));
            orcamento2.Itens.Add(new OrcamentoItem("Borracha", 10));
            orcamento2.Itens.Add(new OrcamentoItem("Caneca", 10));
            orcamento2.Itens.Add(new OrcamentoItem("Lapiseira", 10));
            orcamento2.Itens.Add(new OrcamentoItem("Cola", 10));
            orcamento2.Itens.Add(new OrcamentoItem("Fita adesiva", 10));

            Console.WriteLine(string.Format("Orçamento 2. Desconto esperado > 5 itens: R$ 50,00. Desconto obtido: {0}.", calculadoraDeDesconto.Calcular(orcamento2)));

            // Teste 3: orçamento com desconto de mais de R$ 500,00
            var orcamento3 = new Orcamento(501);
            Console.WriteLine(string.Format("Orçamento 3. Desconto esperado 7%: R$ 35,07. Desconto obtido: {0}.", calculadoraDeDesconto.Calcular(orcamento3)));

            // Teste 4: orçamento com desconto de mais de 5 itens, mais de R$ 500,00 e lápis e caneta
            var orcamento4 = new Orcamento(501);
            orcamento4.Itens.Add(new OrcamentoItem("Lápis", 10));
            orcamento4.Itens.Add(new OrcamentoItem("Caneta", 10));
            orcamento4.Itens.Add(new OrcamentoItem("Caneca", 10));
            orcamento4.Itens.Add(new OrcamentoItem("Lapiseira", 10));
            orcamento4.Itens.Add(new OrcamentoItem("Cola", 10));
            orcamento4.Itens.Add(new OrcamentoItem("Fita adesiva", 10));

            Console.WriteLine(string.Format("Orçamento 4. Desconto esperado 10% + 7% + 5%: R$ 110,22. Valor do desconto: {0}.", calculadoraDeDesconto.Calcular(orcamento4)));
        }

        static void StrategyAula()
        {
            IImposto iss = new Iss();
            IImposto icms = new Icms();
            IImposto iccc = new Iccc();
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
