using Domain.Comentario;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository.RepositoriesApiTrello
{
    public class ComentarioRepository : IComentarioRepository
    {
        public Comentarios Get(string idCard)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            string key = "67a7b156c076bdb0c32ef0c7fac3e4e3";
            string tokken = "ba50b1de587070a955ebd7dc02bdc292acee46f4460e77ea9c4b78620029c86e";

            var requisicaoWeb = WebRequest.CreateHttp("https://api.trello.com/1/card/" + idCard + "/?&fields=id&actions=commentCard&action_fields=data&actions_limit=1000&key=" + key + "&token=" + tokken);
            requisicaoWeb.Method = "GET";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                streamDados.Close();
                resposta.Close();
                return JsonConvert.DeserializeObject<Comentarios>(objResponse.ToString());
            }
        }
    }
}
