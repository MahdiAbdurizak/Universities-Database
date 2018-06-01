using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.DAL.EF;
using Distance.DAL.Entities;
using Distance.DAL.Interfaces;

namespace Distance.DAL.Repositories
{
   public class СпециальностиRepository :IRepository<Специальности>
    {
        private ApplicationContext db;

        public СпециальностиRepository(ApplicationContext context)
        {
            this.db = context;
        }


        public IEnumerable<Специальности> GetAll()
        {
            return db.Specialties.Include(o => o.Уровень_обуения)
                .Include(o => o.Форма_обуения);
        }

        public Специальности Get(int id)
        {
            return db.Specialties.Find(id);
        }

        public void Create(Специальности Specialty)
        {
            db.Specialties.Add(Specialty);
        }

        public void Update(Специальности Specialty)
        {
            db.Entry(Specialty).State = EntityState.Modified;
        }
        public IEnumerable<Специальности> Find(Func<Специальности, Boolean> predicate)
        {
            return db.Specialties.Include(o => o.Уровень_обуения)
            .Include(o => o.Форма_обуения).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Специальности Specialty = db.Specialties.Find(id);
            if (Specialty != null)
                db.Specialties.Remove(Specialty);
        }


    }
}
