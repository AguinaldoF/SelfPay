using SelfPay.Infra;
using SelfPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SelfPay.Controllers
{
    public class PedidoController : ApiController
    {
        ClienteRepository _cliente = new ClienteRepository();
        ProdutoRepository _produto = new ProdutoRepository();
        CarrinhoRepository _carrinho = new CarrinhoRepository();
        PedidoRepository _pedido = new PedidoRepository();

        private ApiResponse response;

        [System.Web.Http.Route("api/Pedido/FazerPedido")]
        [System.Web.Http.HttpPost]
        public ApiResponse FazerPedido([FromBody]PedidoModelView pedidoModelView)
        {
            response = new ApiResponse();            

            try
            {
                if (!string.IsNullOrEmpty(pedidoModelView.Token))
                {
                    if (pedidoModelView.Token == "teste")
                    {
                        Cliente cliente = _cliente.GetClienteById(pedidoModelView.cliente_id);

                        if (cliente != null)
                        {
                            Carrinho carrinho = _carrinho.GetCarrinhoByClienteId(pedidoModelView.cliente_id);

                            if (carrinho == null)
                            {
                                carrinho = new Carrinho
                                {
                                    carrinho_dataCadastro = DateTime.Now,
                                    carrinho_total = 0,
                                    cliente_id = cliente.cliente_id
                                };

                                carrinho.carrinho_id = _carrinho.AddCarrinho(carrinho);
                            }

                            Produto produto = _produto.GetProdutoById(pedidoModelView.produto_id);

                            if (produto != null)
                            {
                                CarrinhoItens carrinhoItens = new CarrinhoItens
                                {
                                    carrinhoItens_carrinho_id = carrinho.carrinho_id,
                                    carrinhoItens_produto_id = produto.produto_id,
                                    carrinhoItens_valorUnitario = produto.produto_preco - produto.produto_precoPromo,
                                    carrinhoItens_valorTotalItem = (produto.produto_preco - produto.produto_precoPromo) * pedidoModelView.carrinhoItens_quantidade,
                                    carrinhoItens_dataCadastro = DateTime.Now
                                };

                                carrinhoItens.carrinhoItens_id = _carrinho.AddCarrinhoItens(carrinhoItens);

                                Pedido pedido = new Pedido
                                {
                                    pedido_valor = carrinhoItens.carrinhoItens_valorTotalItem,
                                    carrinhoItens_id = carrinhoItens.carrinhoItens_id,
                                    pedido_dataCadastro = DateTime.Now
                                };

                                pedido.pedido_id = _pedido.AddPedido(pedido);

                                response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                                response.Message = "Solicitação executada com sucesso!";
                                response.Result = pedido;
                            }
                        }
                        else
                        {
                            response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            response.Message = "Cliente não existe!";
                        }
                    }
                    else
                    {
                        response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                        response.Message = "Token inválido!";
                    }
                }
                else
                {
                    response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    response.Message = "Token inválido!";
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
