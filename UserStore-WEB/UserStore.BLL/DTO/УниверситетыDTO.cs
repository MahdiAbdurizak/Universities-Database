using Distance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.BLL.DTO
{
   public class УниверситетыDTO
    {
        public int Код_Университета { get; set; }
        public string Университет { get; set; }
        public string О_Университете { get; set; }
        public string URLизображения { get; set; }
        public string город { get; set; }
        

    }
}
