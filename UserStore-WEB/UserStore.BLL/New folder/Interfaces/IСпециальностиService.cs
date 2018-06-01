using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.BLL.DTO;

namespace Distance.BLL.Interfaces
{
  public interface IСпециальностиService
    {
        IEnumerable<СпециальностиDTO> GetAll();
        СпециальностиDTO Get(int? id);
        //  IEnumerable<СпециальностиDTO> Find(Func<СпециальностиDTO, Boolean> predicate);
        void Create(СпециальностиDTO item);
        void Update(СпециальностиDTO item);
        void Delete(int id);
        void Dispose();
    }
}
