using System;

namespace CursoAluraDesignPatterns.Acoplamento
{
    public class EnviadorDeEmail
    {
        public void EnviaEmail(NotaFiscal nf)
        {
            Console.WriteLine("Enviando email");
        }
    }

    public class EnviadorDeEmailDesacoplado : IAcaoAposEnviarNota
    {
        public void Executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("Envio de e-mail desacoplado");
        }
    }
}
