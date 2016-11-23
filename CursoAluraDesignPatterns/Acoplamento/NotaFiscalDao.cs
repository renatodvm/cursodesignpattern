using System;

namespace CursoAluraDesignPatterns.Acoplamento
{
    public class NotaFiscalDao
    {
        public void Persiste(NotaFiscal nf)
        {
            Console.WriteLine("Persistindo nota");
        }
    }

    public class NotaFiscalDaoDesacoplado : IAcaoAposEnviarNota
    {
        public void Executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("Persistindo nota desacoplado");
        }
    }
}
