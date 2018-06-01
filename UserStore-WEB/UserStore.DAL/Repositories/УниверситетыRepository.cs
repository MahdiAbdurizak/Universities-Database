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
   public class УниверситетыRepository : IRepository<Университеты>
    {
        private ApplicationContext db;

        public УниверситетыRepository(ApplicationContext context)
        {
            this.db = context;
        }


        public IEnumerable<Университеты> GetAll()
        {
            return db.Universities.Include(o => o.специальности);
        }

        public Университеты Get(int id)
        {
            return db.Universities.Find(id);
        }

        public void Create(Университеты University)
        {
            db.Universities.Add(University);
        }

        public void Update(Университеты University)
        {
            db.Entry(University).State = EntityState.Modified;
        }
        public IEnumerable<Университеты> Find(Func<Университеты, Boolean> predicate)
        {
            return db.Universities.Include(o => o.специальности).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Университеты University = db.Universities.Find(id);
            if (University != null)
                db.Universities.Remove(University);
        }

    }
}
