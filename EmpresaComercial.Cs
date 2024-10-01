using System;

namespace EmpresaComercial
{
    internal class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double PercComissao { get; set; }
        private Venda[] asVendas;

        public Vendedor(int id, string nome, double percComissao)
        {
            Id = id;
            Nome = nome;
            PercComissao = percComissao;
            asVendas = new Venda[31]; // 31 dias no mês
        }

        public void RegistrarVenda(int dia, Venda venda)
        {
            if (dia < 1 || dia > 31)
            {
                Console.WriteLine("Dia inválido. Use um dia entre 1 e 31.");
                return;
            }

            asVendas[dia - 1] = venda;
        }

        public double ValorVendas()
        {
            double total = 0;
            foreach (var venda in asVendas)
            {
                if (venda != null)
                {
                    total += venda.Valor;
                }
            }
            return total;
        }

        public double ValorComissao()
        {
            return ValorVendas() * (PercComissao / 100);
        }

        public double ValorMedioVendasDiarias()
        {
            int diasComVenda = 0;
            double totalVendas = 0;

            foreach (var venda in asVendas)
            {
                if (venda != null)
                {
                    diasComVenda++;
                    totalVendas += venda.Valor;
                }
            }

            return diasComVenda > 0 ? totalVendas / diasComVenda : 0;
        }

        public override string ToString()
        {
            return $"Vendedor {Id}: {Nome}, Total Vendas: {ValorVendas():C}, Comissão: {ValorComissao():C}, Média Vendas Diárias: {ValorMedioVendasDiarias():C}";
        }
    }
}
