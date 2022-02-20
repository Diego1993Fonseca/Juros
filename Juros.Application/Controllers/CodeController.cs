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
    public class CodeController : ControllerBase
    {

        public CodeController()
        {

        }

        [HttpGet("/showmethecode")]
        public ActionResult<string> Code()
        {

            return "https://github.com/Diego1993Fonseca/";
        }
    }
}
