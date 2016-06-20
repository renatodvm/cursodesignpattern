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

        public Conta(double saldo, string titular)
        {
            Saldo = saldo;
            Titular = titular;
        }
    }
}
