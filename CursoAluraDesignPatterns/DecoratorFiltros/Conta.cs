using System;
using System.Collections.Generic;

namespace CursoAluraDesignPatterns.DecoratorFiltros
{
    public class Conta
    {
        public Conta() : base()
        {
        }

        public Conta(decimal saldo, DateTime dataAbertura)
        {
            Saldo = saldo;
            DataAbertura = dataAbertura;
        }

        public decimal Saldo { get; set; }

        public DateTime DataAbertura { get; set; }
    }
}
