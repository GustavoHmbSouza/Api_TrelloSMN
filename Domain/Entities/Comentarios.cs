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
    }
    public class actions
    {
        public string id { get; set; }

        public Data data { get; set;}
    }

    public class Data
    {
        public string text { get; set; }
    }
}
