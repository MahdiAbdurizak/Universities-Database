using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.BLL.DTO;

namespace Distance.BLL.Interfaces
{
   public interface IУровеньОбученияService
    {
        IEnumerable<УровеньОбученияDTO> GetAll();
        УровеньОбученияDTO Get(int? id);
        //  IEnumerable<УровеньОбученияDTO> Find(Func<УровеньОбученияDTO, Boolean> predicate);
        void Create(УровеньОбученияDTO item);
        void Update(УровеньОбученияDTO item);
        void Delete(int id);
        void Dispose();
    }
}
