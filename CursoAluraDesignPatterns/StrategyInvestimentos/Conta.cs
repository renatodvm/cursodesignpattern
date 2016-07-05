using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.StrategyInvestimentos
{
    public class Conta
    {
        public double Saldo { get; set; }

        public string Titular { get; set; }

        public string Agencia { get; set; }

        public string NumeroConta { get; set; }

        public Conta(double saldo, string titular)
        {
            Saldo = saldo;
            Titular = titular;
        }

        public Conta(double saldo, string titular, string agencia, string numeroConta)
            : this(saldo, titular)
        {
            Agencia = agencia;
            NumeroConta = numeroConta;
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
