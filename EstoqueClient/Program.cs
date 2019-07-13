using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using EstoqueClient.Estoques;

namespace EstoqueClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("BasicHttpBinding_IServicoEstoque");
            // Test the operations in the service
            // Obtain a list of all products
            Console.WriteLine("Test 1: List all products");
            List<string> products = proxy.ListarProdutos().ToList();
            foreach (string p in products)
            {
                Console.WriteLine("Name: {0}", p);
                Console.WriteLine();
            }
            Console.WriteLine();
            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
