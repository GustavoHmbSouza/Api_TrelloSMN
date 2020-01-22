using System;

namespace Domain.Entities
{
    public class BadgesCs
    {
        public string attachments { get; set; }
        public string checkItems { get; set; }
        public string checkItemsChecked { get; set; }
        public string comments { get; set; }


        public int Num_Anexos { get; set; }
        public int Num_CheckItems { get; set; }
        public int Num_CheckItemsChecked { get; set; }
        public int Num_Comentarios { get; set; }

        public void setDados()
        {
            Num_Anexos = Convert.ToInt32(attachments);
            Num_CheckItems = Convert.ToInt32(checkItems);
            Num_CheckItemsChecked = Convert.ToInt32(checkItemsChecked);
            Num_Comentarios = Convert.ToInt32(comments);
        }
    }
}
