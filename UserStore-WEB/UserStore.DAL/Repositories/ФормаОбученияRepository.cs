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
   public class ФормаОбученияRepository :IRepository<ФормаОбучения>
    {
        private ApplicationContext db;

        public ФормаОбученияRepository(ApplicationContext context)
        {
            this.db = context;
        }


        public IEnumerable<ФормаОбучения> GetAll()
        {
            return db.Formofstudy;
        }

        public ФормаОбучения Get(int id)
        {
            return db.Formofstudy.Find(id);
        }

        public void Create(ФормаОбучения formofstudy)
        {
            db.Formofstudy.Add(formofstudy);
        }

        public void Update(ФормаОбучения formofstudy)
        {
            db.Entry(formofstudy).State = EntityState.Modified;
        }
        public IEnumerable<ФормаОбучения> Find(Func<ФормаОбучения, Boolean> predicate)
        {
            return db.Formofstudy.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            ФормаОбучения formofstudy = db.Formofstudy.Find(id);
            if (formofstudy != null)
                db.Formofstudy.Remove(formofstudy);
        }


    }
}
