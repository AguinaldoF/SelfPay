using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfPay.Models
{
    public class Pedido
    {
        public Int64 pedido_id { get; set; }
        public decimal pedido_valor { get; set; }
        public DateTime pedido_dataCadastro { get; set; }
        public Int64 carrinhoItens_id { get; set; }        
    }
}