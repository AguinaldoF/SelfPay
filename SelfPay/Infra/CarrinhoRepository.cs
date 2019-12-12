using SelfPay.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SelfPay.Infra
{
    public class CarrinhoRepository
    {
        public Int64 AddCarrinho(Carrinho carrinho)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "AddCarrinho";

                cmd.Parameters.AddWithValue("@carrinho_dataCadastro", carrinho.carrinho_dataCadastro);
                cmd.Parameters.AddWithValue("@carrinho_total", carrinho.carrinho_total);
                cmd.Parameters.AddWithValue("@cliente_id", carrinho.cliente_id);

                cmd.CommandType = CommandType.StoredProcedure;

                Int64 carrinho_id = SqlRepository.ExecuteScalar(cmd, ConnectionString.SELFPAY);

                return carrinho_id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int64 AddCarrinhoItens(CarrinhoItens carrinhoItens)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "AddCarrinhoItens";

                cmd.Parameters.AddWithValue("@carrinhoItens_carrinho_id", carrinhoItens.carrinhoItens_carrinho_id);
                cmd.Parameters.AddWithValue("@carrinhoItens_produto_id", carrinhoItens.carrinhoItens_produto_id);
                cmd.Parameters.AddWithValue("@carrinhoItens_valorUnitario", carrinhoItens.carrinhoItens_valorUnitario);
                cmd.Parameters.AddWithValue("@carrinhoItens_valorTotalItem", carrinhoItens.carrinhoItens_valorTotalItem);
                cmd.Parameters.AddWithValue("@carrinhoItens_quantidade", carrinhoItens.carrinhoItens_quantidade);
                cmd.Parameters.AddWithValue("@carrinhoItens_dataCadastro", carrinhoItens.carrinhoItens_dataCadastro);

                cmd.CommandType = CommandType.StoredProcedure;

                Int64 carrinhoItens_id = SqlRepository.ExecuteScalar(cmd, ConnectionString.SELFPAY);

                return carrinhoItens_id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Carrinho GetCarrinhoByClienteId(Int64 cliente_id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "GetCarrinhoByClienteId";

                cmd.Parameters.AddWithValue("@cliente_id", cliente_id);

                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = SqlRepository.ExecuteReader(cmd, ConnectionString.SELFPAY);

                Carrinho carrinho = new Carrinho
                {
                    carrinho_id = Convert.ToInt64(dt.Rows[0]["carrinho_id"]),
                    carrinho_dataCadastro = Convert.ToDateTime(dt.Rows[0]["carrinho_dataCadastro"]),
                    carrinho_total = Convert.ToDecimal(dt.Rows[0]["carrinho_total"]),
                    cliente_id = Convert.ToInt64(dt.Rows[0]["cliente_id"]),
                    fechado = Convert.ToBoolean(dt.Rows[0]["fechado"])
                };

                return carrinho;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}