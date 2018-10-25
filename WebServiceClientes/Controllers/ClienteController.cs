using BusinessLogic.Helpers;
using CommonSolution.Clases;
using CommonSolution.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace WebService.Controllers
{

    public class ClienteController : ApiController
    {


        [HttpPost]
        public string addCliente([FromBody] DTOCliente nuevoCliente)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ClienteHelper ch = new ClienteHelper();
            ch.addCliente(nuevoCliente);
            Response respuesta = new Response() { estado = ESTADO.OK, msg = "FUE AGREGADO CON EXITO" };
            return js.Serialize(respuesta);

        }

        [HttpGet]
        public string getCliente(string ci)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            ClienteHelper ch = new ClienteHelper();
            

            return js.Serialize(ch.getCliente(ci));

        }

      
    }
}