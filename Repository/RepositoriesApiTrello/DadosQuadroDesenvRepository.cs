﻿using Domain.DadosTrello;
using Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Repository.RepositoriesApiTrello
{
    public class DadosQuadroDesenvRepository : IDadosQuadroDesenvRepository
    {
        //Conta SMN com o quadro de desenv
        //string key = "67a7b156c076bdb0c32ef0c7fac3e4e3";
        //string tokken = "ba50b1de587070a955ebd7dc02bdc292acee46f4460e77ea9c4b78620029c86e";
        //string quadro = "LNLrC30H";

        public List<DadosCardCs> Get()
        {
            string key = "62c66f984189c61a289abd38ec4794e1";
            string tokken = "2d7a693ed4467904ff0335b87929580f50f434f9a94ed683e709c3273a1821fa";
            string quadro = "LNLrC30H";

            var requisicaoWeb = WebRequest.CreateHttp("https://api.trello.com/1/boards/" + quadro + "/cards/?fields=desc,idMembers,name,id,due,dueComplete,badges,url&key=" + key + "&token=" + tokken);
            requisicaoWeb.Method = "GET";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                streamDados.Close();
                resposta.Close();
                return JsonConvert.DeserializeObject<List<DadosCardCs>>(objResponse.ToString());
            }
        }
    }
}
