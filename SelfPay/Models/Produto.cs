using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfPay.Models
{
    public class Produto
    {
        public Int64 produto_id { get; set; }
        public string produto_nome { get; set; }
        public decimal produto_desc { get; set; }
        public Boolean produto_ativo { get; set; }
        public decimal produto_preco { get; set; }
        public decimal produto_precoPromo { get; set; }
        public string Token { get; set; }
    }
}