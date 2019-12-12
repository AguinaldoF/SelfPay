using SelfPay.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SelfPay.Infra
{
    public class ProdutoRepository
    {
        public void AddProduto(Produto produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "AddProduto";

                cmd.Parameters.AddWithValue("@produto_nome", produto.produto_nome);
                cmd.Parameters.AddWithValue("@produto_desc", produto.produto_desc);
                cmd.Parameters.AddWithValue("@produto_ativo", produto.produto_ativo);
                cmd.Parameters.AddWithValue("@produto_preco", produto.produto_preco);
                cmd.Parameters.AddWithValue("@produto_precoPromo", produto.produto_precoPromo);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlRepository.ExecuteNonQuery(cmd, ConnectionString.SELFPAY);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Produto> GetAllProduto()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "GetAllProduto";

                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = SqlRepository.ExecuteReader(cmd, ConnectionString.SELFPAY);

                List<Produto> listaProdutos = (from rw in dt.AsEnumerable()
                                               select new Produto()
                                               {
                                                   produto_id = Convert.ToInt64(rw["produto_id"]),
                                                   produto_nome = Convert.ToString(rw["produto_nome"]),
                                                   produto_desc = Convert.ToDecimal(rw["produto_desc"]),
                                                   produto_ativo = Convert.ToBoolean(rw["produto_ativo"]),
                                                   produto_preco = Convert.ToDecimal(rw["produto_preco"]),
                                                   produto_precoPromo = Convert.ToDecimal(rw["produto_precoPromo"])
                                               }).ToList();

                return listaProdutos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Produto GetProdutoById(Int64 produto_id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "GetProdutoById";

                cmd.Parameters.AddWithValue("@produto_id", produto_id);

                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = SqlRepository.ExecuteReader(cmd, ConnectionString.SELFPAY);

                Produto produto = new Produto
                {
                    produto_id = Convert.ToInt64(dt.Rows[0]["produto_id"]),
                    produto_nome = Convert.ToString(dt.Rows[0]["produto_nome"]),
                    produto_desc = Convert.ToDecimal(dt.Rows[0]["produto_desc"]),
                    produto_ativo = Convert.ToBoolean(dt.Rows[0]["produto_ativo"]),
                    produto_preco = Convert.ToDecimal(dt.Rows[0]["produto_preco"]),
                    produto_precoPromo = Convert.ToDecimal(dt.Rows[0]["produto_precoPromo"])
                };                             

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}