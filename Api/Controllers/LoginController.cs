using Domain.Login;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    public class LoginController : ApiController
    {
        public readonly ILoginService _iLoginService;

        public LoginController(ILoginService iLoginService)
        {
            _iLoginService = iLoginService;
        }

        //public IHttpActionResult Post(Login login)
        [HttpPost]
        public IHttpActionResult Post(string login, string senha)
        {
            try
            {
                //return Ok();
                return Ok(_iLoginService.verificaLogin(login, senha));
            }
            catch (Exception ex)
            {
                return Ok("Erro ao tentar efetuar o login: " + ex.Message);
            }
        }
    }
}