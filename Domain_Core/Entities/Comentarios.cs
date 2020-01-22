using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comentarios
    {
        public Comentarios()
        {
            actions = new List<actions>();
        }

        public List<actions> actions { get; set; }
        public int Num_Horas { get; set; }
        public string Dat_DataInicio { get; set; }
        public string Dat_DataFim { get; set; }
        public string Nom_Fase { get; set; }
        public double Num_HorasConcluido { get; set; }

        public bool filtraComentarios()
        {
            int tamListComen = actions.Count;
            bool retorno = false;
            for (int j = 0; j < tamListComen; j++)
            {
                if (!actions[j].data.text.Contains("@Planejamento"))
                {
                    actions.RemoveAt(j);
                    tamListComen--;
                    j--;
                    continue;
                }

                string[] partes = actions[j].data.text.Split('@');

                for (int i = 0; i < partes.Length; i++)
                {
                    if(partes[i].Contains("Horas"))
                    {
                        Num_Horas = Convert.ToInt32(partes[i].Split('=')[1]);
                    }
                    else if (partes[i].Contains("DataInicio"))
                    {
                        Dat_DataInicio = Convert.ToDateTime(partes[i].Split('=')[1]).ToString("g") ;
                    }
                    else if (partes[i].Contains("DataFim"))
                    {
                        Dat_DataFim = Convert.ToDateTime(partes[i].Split('=')[1]).ToString("g");
                    }
                    else if (partes[i].Contains("Fase"))
                    {
                        Nom_Fase = partes[i].Split('=')[1];
                    }
                }

                retorno = true;
            }
            return retorno;
        }
    }
    public class actions
    {
        public string id { get; set; }

        public Data data { get; set;}
    }

    public class Data
    {
        public string text { get; set; }

        public list list { get; set; }
    }

    public class list
    {
        public string name { get; set; }
    }
}
