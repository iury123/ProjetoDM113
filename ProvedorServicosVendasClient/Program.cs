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

            Console.WriteLine("Verificando estoque do Produto 1");
            int estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque: {0}", estoque);
            Console.WriteLine();

            Console.WriteLine("Adicionando 20 unidades para o Produto 1");
            bool success = proxy.AdicionarEstoque("1000", 20);
            string msg = (success) ? "Adicionado com sucesso" : "Falha ao adicionar";
            Console.WriteLine(msg);
            Console.WriteLine();

            Console.WriteLine("Verificando estoque do Produto 1");
            estoque = proxy.ConsultarEstoque("1000");
            Console.WriteLine("Estoque: {0}", estoque);
            Console.WriteLine();

            Console.WriteLine("Verificando estoque do Produto 5");
            estoque = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Estoque: {0}", estoque);
            Console.WriteLine();

            Console.WriteLine("Remover 10 unidades para o Produto 1");
            success = proxy.RemoverEstoque("5000", 10);
            msg = (success) ? "Adicionado com sucesso" : "Falha ao adicionar";
            Console.WriteLine(msg);
            Console.WriteLine();

            Console.WriteLine("Verificando estoque do Produto 5");
            estoque = proxy.ConsultarEstoque("5000");
            Console.WriteLine("Estoque: {0}", estoque);
            Console.WriteLine();

            // Disconnect from the service
            proxy.Close();
            Console.WriteLine("Press ENTER to finish");
            Console.ReadLine();
        }
    }
}
