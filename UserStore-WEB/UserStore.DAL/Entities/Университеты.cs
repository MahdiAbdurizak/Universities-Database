using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.DAL.Entities
{
    public class Университеты
    {
        [Key]
        public int Код_Университета { get; set; }
        public string Университет { get; set; }
        public string О_Университете { get; set; }
        public string URLизображения { get; set; }
        public string город { get; set; }   
        public virtual ICollection<Специальности> специальности { get; set; }

    }
}
