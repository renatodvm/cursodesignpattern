namespace CursoAluraDesignPatterns.SRP
{
    public class Tester : Cargo
    {
        public Tester() : base(new SalarioQuinzeOuVinteCincoPorcento())
        {
        }
    }

    public class Dba : Cargo
    {
        public Dba() : base(new SalarioQuinzeOuVinteCincoPorcento())
        {
        }
    }

    public class Desenvolvedor : Cargo
    {
        public Desenvolvedor() : base(new SalarioDezOuVintePorCento())
        {
        }
    }

    public abstract class Cargo
    {
        protected readonly ICalculadoraDeSalario CalculadoraSalario;

        public Cargo(ICalculadoraDeSalario calculadoraSalario)
        {
            this.CalculadoraSalario = calculadoraSalario;
        }

        public double CalcularSalario(double salarioBase)
        {
            return this.CalculadoraSalario.Calcular(salarioBase);
        }
    }

    public class Funcionario
    {

        public Cargo Cargo { get; private set; }

        public double SalarioBase { get; private set; }

        public Funcionario(Cargo cargo, double salarioBase)
        {
            this.Cargo = cargo;
            this.SalarioBase = salarioBase;
        }

        public double CalcularSalario()
        {
            return Cargo.CalcularSalario(SalarioBase);
        }

    }
}
