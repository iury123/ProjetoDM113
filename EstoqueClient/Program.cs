using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueClient.ServicoEstoque;

namespace EstoqueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");
            // Test the operations in the service
            // Obtain a list of all products
            string msg;
            Console.WriteLine("Adicionando Produto 11");
            Produto produto = new Produto()
            {
                NomeProduto = "Produto 11",
                NumeroProduto = "1100",
                DescricaoProduto = "Este e o produto 11",
                EstoqueProduto = 11
            };
            bool success = proxy.IncluirProduto(produto);
            msg = (success) ? "Inserido com sucesso" : "Falha ao inserir";
            Console.WriteLine(msg);
            Console.WriteLine();

            Console.WriteLine("Removendo Produto 10...");
            success = proxy.RemoverProduto("10000");
            msg = (success) ? "Removido com sucesso" : "Falha ao remover";
            Console.WriteLine(msg);
            Console.WriteLine();

            Console.WriteLine("Lista de todos os produtos");
            List<string> products = proxy.ListarProdutos().ToList();
            products.ForEach((p) => Console.WriteLine("NOME: {0}", p));
            Console.WriteLine();

            produto = proxy.VerProduto("2000");

            if (produto != null)
            {
                Console.WriteLine("Produto 2");
                Console.WriteLine("Nome: {0}", produto.NomeProduto);
                Console.WriteLine("Numero: {0}", produto.NumeroProduto);
                Console.WriteLine("Descricao: {0}", produto.DescricaoProduto);
                Console.WriteLine("Estoque Number: {0}", produto.EstoqueProduto);
            }

            Console.WriteLine();
            Console.WriteLine("Adicionando 10 unidades para o Produto 2");
            success = proxy.AdicionarEstoque("2000", 10);
            msg = (success) ? "Adicionado com sucesso" : "Falha ao adicionar";
            Console.WriteLine(msg);
            Console.WriteLine();

            Console.WriteLine("Verificando estoque do Produto 2");
            int estoque = proxy.ConsultarEstoque("2000");
            Console.WriteLine("Estoque: {0}", estoque);
            Console.WriteLine();

            Console.WriteLine("Verificando estoque do Produto 1");
            estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque: {0}", estoque);
            Console.WriteLine();

            Console.WriteLine("Removendo 20 unidades para o Produto 1");
            success = proxy.RemoverEstoque("1000", 20);
            msg = (success) ? "Adicionado com sucesso" : "Falha ao adicionar";
            Console.WriteLine(msg);
            Console.WriteLine();

            Console.WriteLine("Verificando estoque do Produto 1");
            estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque: {0}", estoque);
            Console.WriteLine();

            produto = proxy.VerProduto("1000");
            Console.WriteLine("Produto 1");
            Console.WriteLine("Nome: {0}", produto.NomeProduto);
            Console.WriteLine("Numero: {0}", produto.NumeroProduto);
            Console.WriteLine("Descricao: {0}", produto.DescricaoProduto);
            Console.WriteLine("Estoque Number: {0}", produto.EstoqueProduto);
            Console.WriteLine();

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
