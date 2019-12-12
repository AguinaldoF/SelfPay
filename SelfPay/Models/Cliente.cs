using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfPay.Models
{
    public class Cliente
    {
        public Int64 cliente_id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime dataCadastro { get; set; }
        public string Token { get; set; }
    }
}