using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Juros.Domain.Intefaces.Business;
using Juros.Domain.Model.DTO;

namespace Juros.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JurosController : ControllerBase
    {
        readonly IJurosServices _service;

        public JurosController(IJurosServices service)
        {
            _service = service;
        }

        [HttpPost("/calculajuros")]
        public ActionResult<string> Calculajuros()
        {
            var valorInicial = String.IsNullOrEmpty(Request.Query["valorinicial"])? 0 : decimal.Parse(Request.Query["valorinicial"]);
            var meses = String.IsNullOrEmpty(Request.Query["meses"]) ? 0 : int.Parse(Request.Query["meses"]);

            try
            {  
                var response = _service.Calculajuros(valorInicial,meses);

                return response.ToString("F");
            }catch(Exception ex) 
            {
                return new BadRequestObjectResult(new
                {
                    ex.Message
                });

            }



        }
    }
}
