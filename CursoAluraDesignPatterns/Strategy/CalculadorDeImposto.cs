using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.Strategy
{
    public class CalculadorDeImposto
    {
        public void RealizaCalculo(Orcamento orcamento, IImposto imposto)
        {
            double valor = imposto.Calcula(orcamento);
            Console.WriteLine(valor);
        }
    }
}
