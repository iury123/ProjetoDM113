﻿using EstoqueEntityModel;
using Estoques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace Estoques
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServicoEstoque : IServicoEstoque
    {
        public bool AdicionarEstoque(string NumeroProduto, int Quantidade)
        {
            throw new NotImplementedException();
        }

        public int ConsultarEstoque(string NumeroProduto)
        {
            try
            {
                using(ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> result = database.ProdutoEstoques
                        .Where(p => p.NumeroProduto == NumeroProduto).ToList();
                    return result.First().EstoqueProduto;
                }
            }
            catch {}
            return -1;
        }

        public bool IncluirProduto(Produto produto)
        {
            try
            {
                using (ProvedorEstoque database = new ProvedorEstoque())
                {
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
                using(ProvedorEstoque database = new ProvedorEstoque())
                {
                    List<ProdutoEstoque> produtoEstoques = database.ProdutoEstoques.ToList();
                    foreach(ProdutoEstoque estoque in produtoEstoques)
                    {
                        produtos.Add(estoque.NomeProduto);
                    }
                }
            } catch {}
            return produtos;
        }

        public bool RemoverEstoque(string NumeroProduto, string Quantidade)
        {
            throw new NotImplementedException();
        }

        public bool RemoverProduto(string NumeroProduto)
        {
            throw new NotImplementedException();
        }

        public Produto VerProduto(string NumeroProduto)
        {
            throw new NotImplementedException();
        }
    }
}
