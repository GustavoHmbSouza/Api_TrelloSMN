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
            string key = "62c66f984189c61a289abd38ec4794e1";
            string tokken = "2d7a693ed4467904ff0335b87929580f50f434f9a94ed683e709c3273a1821fa";

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
