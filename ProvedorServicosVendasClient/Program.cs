using ProvedorServicosVendasClient.ServicoEstoque;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvedorServicosVendasClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicoEstoqueClient proxy = new ServicoEstoqueClient("WS2007HttpBinding_IServicoEstoque");
            // Test the operations in the service
            // Obtain a list of all products
            Console.WriteLine("Test 1: List all products");
            int value = proxy.ConsultarEstoque("2000");
            Console.WriteLine("VALUE {0}", value);
            Console.WriteLine();
            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
