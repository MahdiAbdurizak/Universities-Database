using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

   // Для увеличения гибкости подключения к БД используются репозитории.
   //Поэтому вначале определим в проекте еще одну папку Interfaces.
   //И в нее добавим интерфейс репозиториев IRepository
}
