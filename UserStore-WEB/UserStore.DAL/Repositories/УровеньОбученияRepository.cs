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
   public class УровеньОбученияRepository :IRepository<УровеньОбучения>
    {
        private ApplicationContext db;

        public УровеньОбученияRepository(ApplicationContext context)
        {
            this.db = context;
        }


        public IEnumerable<УровеньОбучения> GetAll()
        {
            return db.Levelofstudy;
        }

        public УровеньОбучения Get(int id)
        {
            return db.Levelofstudy.Find(id);
        }

        public void Create(УровеньОбучения levelofstudy)
        {
            db.Levelofstudy.Add(levelofstudy);
        }

        public void Update(УровеньОбучения levelofstudy)
        {
            db.Entry(levelofstudy).State = EntityState.Modified;
        }
        public IEnumerable<УровеньОбучения> Find(Func<УровеньОбучения, Boolean> predicate)
        {
            return db.Levelofstudy.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            УровеньОбучения levelofstudy = db.Levelofstudy.Find(id);
            if (levelofstudy != null)
                db.Levelofstudy.Remove(levelofstudy);
        }


    }
}
