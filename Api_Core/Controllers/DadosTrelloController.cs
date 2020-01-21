using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.DadosTrello;

namespace Api_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DadosTrelloController
    {
        public readonly IDadosTrelloService _iDadosTrelloService;

        public DadosTrelloController(IDadosTrelloService iDadosTrelloService)
        {
            _iDadosTrelloService = iDadosTrelloService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return new OkObjectResult(_iDadosTrelloService.Get());
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult("Erro ao consultar os dados do trello: " + ex.Message);
            }
        }
    }
}