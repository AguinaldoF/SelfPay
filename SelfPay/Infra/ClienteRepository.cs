using SelfPay.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SelfPay.Infra
{
    public class ClienteRepository
    {
        public void AddCliente(Cliente cliente)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "AddCliente";
                
                cmd.Parameters.AddWithValue("@nome", cliente.nome);
                cmd.Parameters.AddWithValue("@email", cliente.email);
                cmd.Parameters.AddWithValue("@dataCadastro", cliente.dataCadastro);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlRepository.ExecuteNonQuery(cmd, ConnectionString.SELFPAY);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cliente> GetAllCliente()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "GetAllCliente";

                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = SqlRepository.ExecuteReader(cmd, ConnectionString.SELFPAY);

                List<Cliente> listaClientes = (from rw in dt.AsEnumerable()
                                                select new Cliente()
                                                {
                                                    cliente_id = Convert.ToInt64(rw["cliente_id"]),
                                                    nome = Convert.ToString(rw["nome"]),
                                                    email = Convert.ToString(rw["email"]),
                                                    dataCadastro = Convert.ToDateTime(rw["dataCadastro"])
                                                }).ToList();

                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cliente GetClienteById(Int64 cliente_id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "GetClienteById";

                cmd.Parameters.AddWithValue("@cliente_id", cliente_id);

                cmd.CommandType = CommandType.StoredProcedure;

                DataTable dt = SqlRepository.ExecuteReader(cmd, ConnectionString.SELFPAY);

                Cliente cliente = new Cliente
                {
                    cliente_id = Convert.ToInt64(dt.Rows[0]["cliente_id"]),
                    nome = Convert.ToString(dt.Rows[0]["nome"]),
                    email = Convert.ToString(dt.Rows[0]["email"]),
                    dataCadastro = Convert.ToDateTime(dt.Rows[0]["dataCadastro"])
                };

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}