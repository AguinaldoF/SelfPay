using SelfPay.Infra;
using SelfPay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SelfPay.Controllers
{
    public class ClienteController : ApiController
    {
        ClienteRepository _cliente = new ClienteRepository();

        private ApiResponse response;

        [System.Web.Http.Route("api/Cliente/AddCliente")]
        [System.Web.Http.HttpPost]
        public ApiResponse AddCliente([FromBody] Cliente cliente)
        {
            response = new ApiResponse();

            try
            {
                if (!string.IsNullOrEmpty(cliente.Token))
                {
                    if (cliente.Token == "teste")
                    {
                        _cliente.AddCliente(cliente);

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

        [System.Web.Http.Route("api/Cliente/GetAllCliente")]
        [System.Web.Http.HttpGet]
        public ApiResponse GetAllCliente([FromBody] Cliente cliente)
        {
            response = new ApiResponse();

            try
            {
                if (!string.IsNullOrEmpty(cliente.Token))
                {
                    if (cliente.Token == "teste")
                    {
                        List<Cliente> listaClientes = _cliente.GetAllCliente();

                        response.StatusCode = Convert.ToInt32(HttpStatusCode.OK);
                        response.Message = "Solicitação executada com sucesso!";
                        response.Result = listaClientes;
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
