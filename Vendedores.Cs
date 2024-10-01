using System;

namespace EmpresaComercial
{
    internal class Vendedores
    {
        private Vendedor[] osVendedores;
        private int max;
        private int qtde;

        public Vendedores(int max)
        {
            this.max = max;
            this.qtde = 0;
            osVendedores = new Vendedor[max];
        }

        public bool AddVendedor(Vendedor v)
        {
            if (qtde < max)
            {
                osVendedores[qtde] = v;
                qtde++;
                return true;
            }
            Console.WriteLine("Número máximo de vendedores atingido.");
            return false;
        }

        public bool DelVendedor(Vendedor v)
        {
            int index = Array.IndexOf(osVendedores, v);
            if (index != -1)
            {
                // Verifica se há vendas associadas
                if (osVendedores[index].ValorVendas() == 0)
                {
                    osVendedores[index] = null;
                    qtde--;
                    return true;
                }
                Console.WriteLine("Não é possível excluir o vendedor, pois ele possui vendas associadas.");
            }
            return false;
        }

        public Vendedor SearchVendedor(int id)
        {
            foreach (var vendedor in osVendedores)
            {
                if (vendedor != null && vendedor.Id == id)
                {
                    return vendedor;
                }
            }
            return null;
        }

        public void ListarVendedores()
        {
            double totalVendas = 0;
            double totalComissao = 0;

            foreach (var vendedor in osVendedores)
            {
                if (vendedor != null)
                {
                    Console.WriteLine(vendedor);
                    totalVendas += vendedor.ValorVendas();
                    totalComissao += vendedor.ValorComissao();
                }
            }

            Console.WriteLine($"Total de Vendas: {totalVendas:C}, Total de Comissões: {totalComissao:C}");
        }
    }
}
