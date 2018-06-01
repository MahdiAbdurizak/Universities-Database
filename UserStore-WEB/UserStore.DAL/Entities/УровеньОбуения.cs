using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.DAL.Entities
{
   public class УровеньОбучения
    {
        [Key]
        public int Код_УровеньОбуения { get; set; }
        public string Уровень_Обучения { get; set; }
        public virtual ICollection<Специальности> специальности { get; set; }
    }
}
