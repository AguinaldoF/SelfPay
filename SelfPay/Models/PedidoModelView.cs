using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfPay.Models
{
    public class PedidoModelView
    {
        public string Token { get; set; }
        public Int64 cliente_id { get; set; }
        public Int64 produto_id { get; set; }
        public int carrinhoItens_quantidade { get; set; }
    }
}