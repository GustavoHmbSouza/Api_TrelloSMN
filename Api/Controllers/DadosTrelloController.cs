using Domain.DadosTrello;
using System;
using System.Web.Http;

namespace Api.Controllers
{
    public class DadosTrelloController : ApiController
    {
        public readonly IDadosTrelloService _iDadosTrelloService;

        public DadosTrelloController(IDadosTrelloService iDadosTrelloService)
        {
            _iDadosTrelloService = iDadosTrelloService;
        }

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(_iDadosTrelloService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao excluir conta: " + ex.Message);
            }
        }
    }
}