using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.SRP
{
    public class CalculadoraDeSalarioSemCoesao
    {
        public double calcula(FuncionarioSemCoesao funcionario)
        {
            if (funcionario.Cargo is DesenvolvedorSemCoesao)
            {
                return dezOuVintePorcento(funcionario);
            }

            if (funcionario.Cargo is DbaSemCoesao || funcionario.Cargo is TesterSemCoesao)
            {
                return quinzeOuVinteCincoPorcento(funcionario);
            }

            throw new Exception("funcionario invalido");
        }

        private double dezOuVintePorcento(FuncionarioSemCoesao funcionario)
        {
            if (funcionario.SalarioBase > 3000.0)
            {
                return funcionario.SalarioBase * 0.8;
            }
            else
            {
                return funcionario.SalarioBase * 0.9;
            }
        }

        private double quinzeOuVinteCincoPorcento(FuncionarioSemCoesao funcionario)
        {
            if (funcionario.SalarioBase > 2000.0)
            {
                return funcionario.SalarioBase * 0.75;
            }
            else
            {
                return funcionario.SalarioBase * 0.85;
            }
        }
    }

    public class TesterSemCoesao : CargoSemCoesao
    {
    }

    public class DbaSemCoesao : CargoSemCoesao
    {
    }

    public class DesenvolvedorSemCoesao : CargoSemCoesao
    {
    }

    public abstract class CargoSemCoesao
    {
    }

    public class FuncionarioSemCoesao
    {

        public CargoSemCoesao Cargo { get; private set; }

        public double SalarioBase { get; private set; }

        public FuncionarioSemCoesao(CargoSemCoesao cargo, double salarioBase)
        {
            this.Cargo = cargo;
            this.SalarioBase = salarioBase;
        }

    }
}
