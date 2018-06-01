using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.DAL.Entities;


namespace Distance.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       
        Task SaveAsync();  
        IRepository<Специальности> Specialties { get; }
        IRepository<Университеты> Universities { get; }
        IRepository<УровеньОбучения> Levelofstudy { get; }
        IRepository<ФормаОбучения> Formofstudy { get; }  
        void Save();
    }
}
