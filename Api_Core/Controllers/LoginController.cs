using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController
    {
        public readonly ILoginService _iLoginService;

        public LoginController(ILoginService iLoginService)
        {
            _iLoginService = iLoginService;
        }

        //public IHttpActionResult Post(Login login)
        [HttpPost]
        public ActionResult Post(string login, string senha)
        {
            try
            {
                return new OkObjectResult(_iLoginService.verificaLogin(login, senha));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Erro ao tentar efetuar o login: " + ex.Message);
            }
        }
    }
}