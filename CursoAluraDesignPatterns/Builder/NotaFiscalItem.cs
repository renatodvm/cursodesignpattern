namespace CursoAluraDesignPatterns.Builder
{
    public class NotaFiscalItem
    {
        public string Produto { get; private set; }
        public double Valor { get; private set; }

        public NotaFiscalItem(string produto, double valor)
        {
            this.Produto = produto;
            this.Valor = valor;
        }
    }
}
