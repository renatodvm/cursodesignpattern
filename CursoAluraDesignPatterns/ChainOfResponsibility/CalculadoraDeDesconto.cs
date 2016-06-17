using CursoAluraDesignPatterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.ChainOfResponsibility
{
    public class CalculadoraDeDesconto
    {
        public double Calcular(Orcamento orcamento)
        {
            var desconto1 = new DescontoMaisDe5Itens();
            var desconto2 = new DescontoCompraMaior500Reais();

            desconto1.ProximoDesconto = desconto2;

            return desconto1.CalcularDesconto(orcamento);
        }
    }
}
