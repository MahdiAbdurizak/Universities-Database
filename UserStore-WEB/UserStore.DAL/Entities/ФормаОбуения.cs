using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.DAL.Entities
{
    public class ФормаОбучения
    {
        [Key]
        public int Код_ФормаОбуения { get; set; }
        public string Форма_Обучения { get; set; }
        public virtual ICollection<Специальности> специальности { get; set; }
    }
}
