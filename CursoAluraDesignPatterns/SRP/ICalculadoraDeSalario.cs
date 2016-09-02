using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.SRP
{
    public interface ICalculadoraDeSalario
    {
        double Calcular(double salarioBase);
    }

    public class SalarioDezOuVintePorCento : ICalculadoraDeSalario
    {
        public double Calcular(double salarioBase)
        {
            return salarioBase > 3000.0 ? salarioBase * 0.8 : salarioBase * 0.9;
        }
    }

    public class SalarioQuinzeOuVinteCincoPorcento : ICalculadoraDeSalario
    {
        public double Calcular(double salarioBase)
        {
            return salarioBase > 2000.0 ? salarioBase * 0.75 : salarioBase * 0.85;
        }
    }

    
}
