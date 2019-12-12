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
    public class CarrinhoController : ApiController
    {
        CarrinhoRepository _carrinho = new CarrinhoRepository();

        private ApiResponse response;

        [System.Web.Http.Route("api/Carrinho/AddCarrinho")]
        [System.Web.Http.HttpPost]
        public ApiResponse AddCarrinho([FromBody] Carrinho carrinho)
        {
            response = new ApiResponse();

            try
            {
                if (!string.IsNullOrEmpty(carrinho.Token))
                {
                    if (carrinho.Token == "teste")
                    {
                        Int64 carrinho_id = _carrinho.AddCarrinho(carrinho);

                        response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                        response.Message = "Solicitação executada com sucesso!";                        
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
