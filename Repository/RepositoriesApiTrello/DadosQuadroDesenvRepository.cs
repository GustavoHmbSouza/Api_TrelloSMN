using Domain.DadosTrello;
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

        public IEnumerable<DadosCard> Get()
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            string key = "67a7b156c076bdb0c32ef0c7fac3e4e3";
            string tokken = "ba50b1de587070a955ebd7dc02bdc292acee46f4460e77ea9c4b78620029c86e";
            string quadro = "yy3ztFA5";

            var requisicaoWeb = WebRequest.CreateHttp("https://api.trello.com/1/boards/" + quadro + "/cards/?fields=desc,idMembers,name,id,due,url&key=" + key + "&token=" + tokken);
            requisicaoWeb.Method = "GET";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                streamDados.Close();
                resposta.Close();
                return JsonConvert.DeserializeObject<IEnumerable<DadosCard>>(objResponse.ToString());
            }
        }
    }
}
