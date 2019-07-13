using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Estoques
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/01", Name = "IServicoEstoque")]
    public interface IServicoEstoque
    {

        [OperationContract]
        List<string> ListarProdutos();
        [OperationContract]
        bool IncluirProduto(Produto produto);
        [OperationContract]
        bool RemoverProduto(string NumeroProduto);
        [OperationContract]
        int ConsultarEstoque(string NumeroProduto);
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);
        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);
        [OperationContract]
        Produto VerProduto(string NumeroProduto);
    }

    [ServiceContract(Namespace = "http://projetoavaliativo.dm113/02", Name = "IServicoEstoque")]
    public interface IServicoEstoqueV2
    {
        [OperationContract]
        int ConsultarEstoque(string NumeroProduto);
        [OperationContract]
        bool AdicionarEstoque(string NumeroProduto, int Quantidade);
        [OperationContract]
        bool RemoverEstoque(string NumeroProduto, int Quantidade);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Produto
    {
        [DataMember]
        public string NumeroProduto { get; set; }

        [DataMember]
        public string NomeProduto { get; set; }

        [DataMember]
        public string DescricaoProduto { get; set; }

        [DataMember]
        public int EstoqueProduto { get; set; }
    }
}
