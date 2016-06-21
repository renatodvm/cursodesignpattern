using CursoAluraDesignPatterns.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.TemplateMethod
{
    public abstract class TemplateCalculoImposto : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            if (DeveCalcularJurosMaximo(orcamento))
                return ObterTaxacaoMaxima(orcamento);

            return ObterTaxacaoMinima(orcamento);
        }

        public abstract bool DeveCalcularJurosMaximo(Orcamento orcamento);
        public abstract double ObterTaxacaoMaxima(Orcamento orcamento);
        public abstract double ObterTaxacaoMinima(Orcamento orcamento);
    }
}
