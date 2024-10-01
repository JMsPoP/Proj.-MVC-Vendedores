using System;

namespace EmpresaComercial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vendedores vendedores = new Vendedores(10);
            int opcao;

            do
            {
                Console.WriteLine("0. Sair\n1. Cadastrar vendedor\n2. Consultar vendedor\n3. Excluir vendedor\n4. Registrar venda\n5. Listar vendedores");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: // Cadastrar vendedor
                        Console.Write("Digite o ID do vendedor: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Digite o nome do vendedor: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite a porcentagem de comissão: ");
                        double percComissao = double.Parse(Console.ReadLine());

                        Vendedor novoVendedor = new Vendedor(id, nome, percComissao);
                        vendedores.AddVendedor(novoVendedor);
                        break;

                    case 2: // Consultar vendedor
                        Console.Write("Digite o ID do vendedor a consultar: ");
                        id = int.Parse(Console.ReadLine());
                        Vendedor vendedorEncontrado = vendedores.SearchVendedor(id);
                        if (vendedorEncontrado != null)
                        {
                            Console.WriteLine(vendedorEncontrado);
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                        }
                        break;

                    case 3: // Excluir vendedor
                        Console.Write("Digite o ID do vendedor a excluir: ");
                        id = int.Parse(Console.ReadLine());
                        vendedorEncontrado = vendedores.SearchVendedor(id);
                        if (vendedores.DelVendedor(vendedorEncontrado))
                        {
                            Console.WriteLine("Vendedor excluído com sucesso.");
                        }
                        break;

                    case 4: // Registrar venda
                        Console.Write("Digite o ID do vendedor: ");
                        id = int.Parse(Console.ReadLine());
                        vendedorEncontrado = vendedores.SearchVendedor(id);
                        if (vendedorEncontrado != null)
                        {
                            Console.Write("Digite o dia da venda (1-31): ");
                            int dia = int.Parse(Console.ReadLine());
                            Console.Write("Digite a quantidade de vendas: ");
                            int qtde = int.Parse(Console.ReadLine());
                            Console.Write("Digite o valor total da venda: ");
                            double valor = double.Parse(Console.ReadLine());

                            Venda novaVenda = new Venda(qtde, valor);
                            vendedorEncontrado.RegistrarVenda(dia, novaVenda);
                            Console.WriteLine("Venda registrada com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Vendedor não encontrado.");
                        }
                        break;

                    case 5: // Listar vendedores
                        vendedores.ListarVendedores();
                        break;

                    case 0:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
x'