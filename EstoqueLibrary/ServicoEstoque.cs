using EstoqueEntityModel;
using Estoques;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace Estoques
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque, IServicoEstoqueV2
    {
        public bool AdicionarEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> result = database.ProdutoEstoques
                        .Where(p => p.NumeroProduto == NumeroProduto).ToList();

                    if (result.Count() == 0)
                    {
                        return false;
                    }

                    ProdutoEstoque produtoEstoque = result.First();
                    produtoEstoque.EstoqueProduto += Quantidade;
                    database.Entry(produtoEstoque).State = EntityState.Modified;
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int ConsultarEstoque(string NumeroProduto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> result = database.ProdutoEstoques
                        .Where(p => p.NumeroProduto == NumeroProduto).ToList();

                    if (result.Count() == 0)
                    {
                        return -1;
                    }

                    return result.First().EstoqueProduto;
                }
            }
            catch { }
            return -1;
        }

        public bool IncluirProduto(Produto produto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {

                    List<ProdutoEstoque> result = database.ProdutoEstoques
                        .Where(p => p.NumeroProduto == produto.NumeroProduto).ToList();

                    if (result.Count() > 0)
                    {
                        return false;
                    }

                    ProdutoEstoque produtoEstoque = new ProdutoEstoque()
                    {
                        NomeProduto = produto.NomeProduto,
                        NumeroProduto = produto.NumeroProduto,
                        DescricaoProduto = produto.DescricaoProduto,
                        EstoqueProduto = produto.EstoqueProduto
                    };
                    database.ProdutoEstoques.Add(produtoEstoque);
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<string> ListarProdutos()
        {
            List<string> produtos = new List<string>();
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> produtoEstoques = database.ProdutoEstoques.ToList();
                    produtoEstoques.ForEach((estoque) => produtos.Add(estoque.NomeProduto));
                }
            }
            catch { }
            return produtos;
        }

        public bool RemoverEstoque(string NumeroProduto, int Quantidade)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> result = database.ProdutoEstoques
                        .Where(p => p.NumeroProduto == NumeroProduto).ToList();

                    if (result.Count() == 0)
                    {
                        return false;
                    }

                    ProdutoEstoque produtoEstoque = result.First();
                    if (produtoEstoque.EstoqueProduto >= Quantidade)
                    {
                        produtoEstoque.EstoqueProduto -= Quantidade;
                        database.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> result = database.ProdutoEstoques
                        .Where(p => p.NumeroProduto == NumeroProduto).ToList();

                    if (result.Count() == 0)
                    {
                        return false;
                    }

                    database.ProdutoEstoques.Remove(result.First());
                    database.SaveChanges();
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Produto VerProduto(string NumeroProduto)
        {
            Produto produto = null;
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> result = database.ProdutoEstoques
                        .Where(p => p.NumeroProduto == NumeroProduto).ToList();

                    if (result.Count() == 0)
                    {
                        return null;
                    }

                    ProdutoEstoque produtoEstoque = result.First();

                    produto = new Produto()
                    {
                        NomeProduto = produtoEstoque.NomeProduto,
                        NumeroProduto = produtoEstoque.NumeroProduto,
                        DescricaoProduto = produtoEstoque.DescricaoProduto,
                        EstoqueProduto = produtoEstoque.EstoqueProduto
                    };
                }
            }
            catch
            {
                return null;
            }
            return produto;
        }
    }
}
