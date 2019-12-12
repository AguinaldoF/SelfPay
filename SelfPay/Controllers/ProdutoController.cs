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
    public class ProdutoController : ApiController
    {
        ProdutoRepository _produto = new ProdutoRepository();

        private ApiResponse response;

        [System.Web.Http.Route("api/Produto/AddProduto")]
        [System.Web.Http.HttpPost]
        public ApiResponse AddProduto([FromBody] Produto produto)
        {
            response = new ApiResponse();

            try
            {
                if (!string.IsNullOrEmpty(produto.Token))
                {
                    if (produto.Token == "teste")
                    {
                        _produto.AddProduto(produto);

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

        [System.Web.Http.Route("api/Produto/GetAllProduto")]
        [System.Web.Http.HttpGet]
        public ApiResponse GetAllProduto([FromBody] Produto produto)
        {
            response = new ApiResponse();

            try
            {
                if (!string.IsNullOrEmpty(produto.Token))
                {
                    if (produto.Token == "teste")
                    {
                        List<Produto> listaProdutos = _produto.GetAllProduto();

                        response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                        response.Message = "Solicitação executada com sucesso!";
                        response.Result = listaProdutos;
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
