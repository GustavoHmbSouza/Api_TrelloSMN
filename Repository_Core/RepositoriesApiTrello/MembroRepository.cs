using Domain.Entities;
using Domain.Membro;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace Repository.RepositoriesApiTrello
{
    public class MembroRepository : IMembroRepository
    {
        public MembroCs Get(string idMembro)
        {
            string key = "62c66f984189c61a289abd38ec4794e1";
            string tokken = "2d7a693ed4467904ff0335b87929580f50f434f9a94ed683e709c3273a1821fa";

            var requisicaoWeb = WebRequest.CreateHttp("https://api.trello.com/1/members/" + idMembro + "/?fields=initials,fullName,avatarHash,id?&key=" + key + "&token=" + tokken);
            requisicaoWeb.Method = "GET";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                streamDados.Close();
                resposta.Close();
                return JsonConvert.DeserializeObject<MembroCs>(objResponse.ToString());
            }
        }
    }
}
