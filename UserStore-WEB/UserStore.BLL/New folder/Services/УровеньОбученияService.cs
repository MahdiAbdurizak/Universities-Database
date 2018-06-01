using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Distance.BLL.DTO;
using Distance.BLL.Interfaces;
using Distance.DAL.Entities;
using Distance.DAL.Interfaces;

namespace Distance.BLL.Services
{
   public class УровеньОбученияService : IУровеньОбученияService
    {

        IUnitOfWork Database { get; set; }
        public УровеньОбученияService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<УровеньОбученияDTO> GetAll()
        {

            return Mapper.Map<IEnumerable<УровеньОбучения>, List<УровеньОбученияDTO>>(Database.Levelofstudy.GetAll());
        }



        public УровеньОбученияDTO Get(int? id)
        {
            if (id == null)
                throw new Infrastructure.ValidationException("Не установлено id телефона", "");
            var levelofstudy = Database.Levelofstudy.Get(id.Value);
            if (levelofstudy == null)
                throw new Infrastructure.ValidationException("Телефон не найден", "");
            // применяем автомаппер для проекции Phone на PhoneDTO
            //    Mapper.Initialize(cfg => cfg.CreateMap<Phone, PhoneDTO>());
            return Mapper.Map<УровеньОбучения, УровеньОбученияDTO>(levelofstudy);
        }

        //public IEnumerable<ClientCommentDTO> Find(Func<ClientCommentDTO, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //    //var repository = new MyRepository<Person>();
        //    // var personsOlderThan50 = repository.FindAll(p => p.Age > 50);
        //    //examp of ("https://stackoverflow.com/questions/11143602/possible-ways-to-use-func-t-bool-while-using-a-linq-repository ")
        //}

        public void Create(УровеньОбученияDTO item)
        {
            УровеньОбучения levelofstudy = new УровеньОбучения
            {
                Уровень_Обучения = item.Уровень_Обучения,
                

            };
            Database.Levelofstudy.Create(levelofstudy);
            Database.Save();
        }

        public void Update(УровеньОбученияDTO item)
        {
            УровеньОбучения levelofstudy = new УровеньОбучения
            {
                Код_УровеньОбуения=item.Код_УровеньОбуения,
                Уровень_Обучения = item.Уровень_Обучения


            };
            Database.Levelofstudy.Update(levelofstudy);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Levelofstudy.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
