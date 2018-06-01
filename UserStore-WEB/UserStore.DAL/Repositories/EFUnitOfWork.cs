using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.DAL.EF;
using Distance.DAL.Entities;

using Distance.DAL.Interfaces;

namespace Distance.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private СпециальностиRepository SpecialtiesRepository;
        private УниверситетыRepository UniversitiesRepository;
        private УровеньОбученияRepository LevelofstudyRepository;
        private ФормаОбученияRepository FormofstudyRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationContext(connectionString);
           
        }


        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

      

        public IRepository<Специальности> Specialties
        {
            get
            {
                if (SpecialtiesRepository == null)
                    SpecialtiesRepository = new СпециальностиRepository(db);
                return SpecialtiesRepository;
            }
        }

        public IRepository<Университеты> Universities
        {
            get
            {
                if (UniversitiesRepository == null)
                    UniversitiesRepository = new УниверситетыRepository(db);
                return UniversitiesRepository;
            }
        }

        public IRepository<УровеньОбучения> Levelofstudy
        {
            get
            {
                if (LevelofstudyRepository == null)
                    LevelofstudyRepository = new УровеньОбученияRepository(db);
                return LevelofstudyRepository;
            }
        }


        public IRepository<ФормаОбучения> Formofstudy
        {
            get
            {
                if (FormofstudyRepository == null)
                    FormofstudyRepository = new ФормаОбученияRepository(db);
                return FormofstudyRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }



        


       
    }

    //Класс EFUnitOfWork в конструкторе принимает строку - названия подключения,
    // которая потом будет передаваться в конструктор контекста данных.
    // Собственно через EFUnitOfWork мы и будем взаимодействовать с базой данных.
}
