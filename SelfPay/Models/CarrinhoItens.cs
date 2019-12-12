using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfPay.Models
{
    public class CarrinhoItens
    {
        public Int64 carrinhoItens_id { get; set; }
        public Int64 carrinhoItens_carrinho_id { get; set; }
        public Int64 carrinhoItens_produto_id { get; set; }
        public decimal carrinhoItens_valorUnitario { get; set; }
        public decimal carrinhoItens_valorTotalItem { get; set; }
        public int carrinhoItens_quantidade { get; set; }
        public DateTime carrinhoItens_dataCadastro { get; set; }
    }
}