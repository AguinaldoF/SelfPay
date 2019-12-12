using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SelfPay.Infra
{
    public enum ConnectionString
    {
        SELFPAY = 0
    }

    public class SqlRepository
    {
        private static string[] Connection =
            {
                @"Server=.\SQLEXPRESS; Initial Catalog=AvaliacaoSelfPay; Persist Security Info=true; User ID=avaliacao; Password=1234"
            };

        public static void ExecuteNonQuery(SqlCommand sqlCommand, ConnectionString cs = ConnectionString.SELFPAY)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Connection[(int)cs]))
                {
                    cn.Open();

                    sqlCommand.Connection = cn;

                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable ExecuteReader(SqlCommand sqlCommand, ConnectionString cs = ConnectionString.SELFPAY)
        {
            try
            {
                DataTable dt = new DataTable();

                using (SqlConnection cn = new SqlConnection(Connection[(int)cs]))
                {
                    cn.Open();

                    sqlCommand.Connection = cn;

                    dt.Load(sqlCommand.ExecuteReader());

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static int ExecuteScalar(SqlCommand sqlCommand, ConnectionString cs = ConnectionString.SELFPAY)
        {
            int id = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(Connection[(int)cs]))
                {
                    cn.Open();

                    sqlCommand.Connection = cn;

                    id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return id;
        }
    }
}