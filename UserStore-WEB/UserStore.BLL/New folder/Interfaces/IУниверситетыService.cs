using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.BLL.DTO;

namespace Distance.BLL.Interfaces
{
   public interface IУниверситетыService
    {
        IEnumerable<УниверситетыDTO> GetAll();
        УниверситетыDTO Get(int? id);
        //  IEnumerable<УниверситетыDTO> Find(Func<УниверситетыDTO, Boolean> predicate);
        void Create(УниверситетыDTO item);
        void Update(УниверситетыDTO item);
        void Delete(int id);
        void Dispose();
    }
}
