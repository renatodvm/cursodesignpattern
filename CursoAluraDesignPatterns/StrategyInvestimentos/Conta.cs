using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.StrategyInvestimentos
{
    public class Conta
    {
        public double Saldo { get; internal set; }

        public string Titular { get; set; }

        public string Agencia { get; set; }

        public string NumeroConta { get; set; }

        public EstadoConta Estado { get; private set; }

        public Conta(double saldo, string titular)
        {
            Saldo = saldo;
            Titular = titular;

            if (saldo >= 0)
                Estado = new Positivo(this);
            else
                Estado = new Negativo(this);
        }

        public Conta(double saldo, string titular, string agencia, string numeroConta)
            : this(saldo, titular)
        {
            Agencia = agencia;
            NumeroConta = numeroConta;
        }

        public void Sacar(double valor)
        {
            Estado.Sacar(valor);

            if (Saldo >= 0 && Estado is Negativo)
                Estado = new Positivo(this);
            else if (Saldo < 0 && Estado is Positivo)
                Estado = new Negativo(this);
        }

        public abstract class EstadoConta
        {
            protected Conta Conta { get; set; }

            public EstadoConta(Conta conta)
            {
                Conta = conta;
            }

            public void Sacar(double valor)
            {
                if (!PodeSacar(valor))
                    throw new Exception("Saque permitido apenas para contas com saldo positivo.");

                Conta.Saldo -= valor;
            }

            protected abstract bool PodeSacar(double valor);
            public abstract string Descricao();
        }

        private class Positivo : EstadoConta
        {
            public Positivo(Conta conta) : base(conta)
            {
            }

            protected override bool PodeSacar(double valor)
            {
                return base.Conta.Saldo - valor >= 0;
            }

            public override string Descricao()
            {
                return "Positivo";
            }
        }

        private class Negativo : EstadoConta
        {
            public Negativo(Conta conta) : base(conta)
            {
            }

            protected override bool PodeSacar(double valor)
            {
                return false;
            }

            public override string Descricao()
            {
                return "Negativo";
            }
        }
    }

    public class Banco
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string Email { get; set; }

        public Banco(string nome, string telefone, string endereco, string email)
        {
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
            Email = email;
        }
    }
}
