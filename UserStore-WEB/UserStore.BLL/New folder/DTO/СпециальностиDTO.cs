using Distance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.BLL.DTO
{
   public class СпециальностиDTO
    {
        public int Код_Специальности { get; set; }
        public string Специальность { get; set; }
        public string Сокр_название { get; set; }
        public string Код_Направление { get; set; }
        public string Направление { get; set; }
        public string Профиль { get; set; }
        public string Язык_Обуения { get; set; }
        public int Код_УровеньОбуения { get; set; }
        public int Код_ФормаОбуения { get; set; }
        public ICollection<Университеты> университеты { get; set; }
    }
}
