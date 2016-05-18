using CursoAluraDesignPatterns.Strategy;
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

            Console.ReadKey();
        }
    }
}
