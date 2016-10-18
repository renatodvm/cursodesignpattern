using CursoAluraDesignPatterns.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoAluraDesignPatterns.Observer
{
    public interface AcaoAposGerarNota
    {
        void Executa(NotaFiscal notaFiscal);
    }
}
