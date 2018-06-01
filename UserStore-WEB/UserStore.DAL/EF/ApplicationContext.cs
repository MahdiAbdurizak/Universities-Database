using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.DAL.Entities;

namespace Distance.DAL.EF
{
    
        public class ApplicationContext : DbContext         
    {
        
        public ApplicationContext(string conectionString) : base(conectionString) {
           
        }
        

       

        public DbSet<Специальности> Specialties { get; set; }
        public DbSet<Университеты> Universities { get; set; }
        public DbSet<УровеньОбучения> Levelofstudy { get; set; }
        public DbSet<ФормаОбучения> Formofstudy { get; set; }





        //static ApplicationContext()
        //{
        //    Database.SetInitializer<ApplicationContext>(new StoreDbInitializer());
           

        //}
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Университеты>().HasMany(x => x.специальности).WithMany();
        //    //modelBuilder.Entity<Специальности>().HasMany(x => x.университеты).WithMany();
        //}





    }
    //    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    //{
       
    //    protected override void Seed(ApplicationContext db)
    //    {
    //        db.Universities.Add(new Университеты
    //        {
    //            Код_Университета=1,
    //            Университет = "Тамбовский государственный университет имени Г. Р. Державина",
    //            URLизображения= "/images/portfolio/recent/item1.png",
    //            город= "Тамбов"


    //        });
           
    //        db.Specialties.Add(new Специальности
    //        {
    //             Код_Специальности= 1,
    //            Специальность = "Прикладная информатика",
    //            Сокр_название = "#",
    //            Код_Направление = "09.04.03",
    //            Направление = "Прикладная информатика",
    //            Профиль = "Прикладная информатика",
    //            Язык_Обуения= "русский",
    //            Код_УровеньОбуения = 1,
    //            Код_ФормаОбуения  = 1
               
                

    //    });
    //        db.Levelofstudy.Add(new УровеньОбучения
    //        {
    //             Код_УровеньОбуения=1,
    //            Уровень_Обучения = "Магистратура"
               
    //    });
    //        db.Formofstudy.Add(new ФормаОбучения
    //        {
    //            Код_ФормаОбуения=1,
    //            Форма_Обучения = "Дистанционная"


    //        });
           
    //        db.SaveChanges();
    //    }


    //}
    
}
