using SelfPay.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SelfPay.Infra
{
    public class PedidoRepository
    {
        public Int64 AddPedido(Pedido pedido)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "AddPedido";

                cmd.Parameters.AddWithValue("@pedido_valor", pedido.pedido_valor);
                cmd.Parameters.AddWithValue("@carrinhoItens_id", pedido.carrinhoItens_id);
                cmd.Parameters.AddWithValue("@pedido_dataCadastro", pedido.pedido_dataCadastro);

                cmd.CommandType = CommandType.StoredProcedure;

                Int64 pedido_id = SqlRepository.ExecuteScalar(cmd, ConnectionString.SELFPAY);

                return pedido_id;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}