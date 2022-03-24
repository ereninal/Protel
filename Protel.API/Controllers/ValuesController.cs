using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Protel.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("GetEncrypt")]
        public string GetEncrypt(string param)
        {
            return param.Encrypt();
        }
        [HttpPost("GetDecrypt")]
        public string GetDecrypt(string param)
        {
            return param.Decrypt();
        }
    }
}
