namespace EmpresaComercial
{
    internal class Venda
    {
        public int Qtde { get; set; }
        public double Valor { get; set; }

        public Venda(int qtde, double valor)
        {
            this.Qtde = qtde;
            this.Valor = valor;
        }

        public double ValorMedio()
        {
            return Qtde > 0 ? Valor / Qtde : 0;
        }

        public override string ToString()
        {
            return $"Quantidade: {Qtde}, Valor Total: {Valor:C}";
        }
    }
}
