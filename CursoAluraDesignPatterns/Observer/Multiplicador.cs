using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoAluraDesignPatterns.Builder;

namespace CursoAluraDesignPatterns.Observer
{
    public class Multiplicador : AcaoAposGerarNota
    {
        public double Fator { get; private set; }

        public Multiplicador(double fator)
        {
            this.Fator = fator;
        }

        public void Executa(NotaFiscal notaFiscal)
        {
            var valor = notaFiscal.ValorBruto;
            var valorFinal = notaFiscal.ValorBruto * Fator;
            Console.WriteLine(String.Format("Multiplicando... Valor original NF: {0} - Valor com o fator de multiplicação: {1}", valor, valorFinal));
        }
    }
}
