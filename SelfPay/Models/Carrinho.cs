using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfPay.Models
{
    public class Carrinho
    {
        public Int64 carrinho_id { get; set; }
        public DateTime carrinho_dataCadastro { get; set; }
        public decimal carrinho_total { get; set; }
        public Int64 cliente_id { get; set; }
        public string Token { get; set; }
        public Boolean fechado { get; set; }
    }
}