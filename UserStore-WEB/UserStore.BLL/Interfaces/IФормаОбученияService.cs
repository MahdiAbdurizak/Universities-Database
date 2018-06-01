using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.BLL.DTO;

namespace Distance.BLL.Interfaces
{
   public interface IФормаОбученияService
    {
        IEnumerable<ФормаОбученияDTO> GetAll();
        ФормаОбученияDTO Get(int? id);
        //  IEnumerable<ФормаОбученияDTO> Find(Func<ФормаОбученияDTO, Boolean> predicate);
        void Create(ФормаОбученияDTO item);
        void Update(ФормаОбученияDTO item);
        void Delete(int id);
        void Dispose();
    }
}
