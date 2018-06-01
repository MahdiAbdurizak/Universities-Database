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
   public class ФормаОбученияService : IФормаОбученияService
    {

        IUnitOfWork Database { get; set; }
        public ФормаОбученияService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<ФормаОбученияDTO> GetAll()
        {

            return Mapper.Map<IEnumerable<ФормаОбучения>, List<ФормаОбученияDTO>>(Database.Formofstudy.GetAll());
        }



        public ФормаОбученияDTO Get(int? id)
        {
            if (id == null)
                throw new Infrastructure.ValidationException("Не установлено id телефона", "");
            var formofstudy = Database.Formofstudy.Get(id.Value);
            if (formofstudy == null)
                throw new Infrastructure.ValidationException("Телефон не найден", "");
            // применяем автомаппер для проекции Phone на PhoneDTO
            //    Mapper.Initialize(cfg => cfg.CreateMap<Phone, PhoneDTO>());
            return Mapper.Map<ФормаОбучения, ФормаОбученияDTO>(formofstudy);
        }

        //public IEnumerable<ClientCommentDTO> Find(Func<ClientCommentDTO, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //    //var repository = new MyRepository<Person>();
        //    // var personsOlderThan50 = repository.FindAll(p => p.Age > 50);
        //    //examp of ("https://stackoverflow.com/questions/11143602/possible-ways-to-use-func-t-bool-while-using-a-linq-repository ")
        //}

        public void Create(ФормаОбученияDTO item)
        {
            ФормаОбучения formofstudy = new ФормаОбучения
            {
                Форма_Обучения = item.Форма_Обучения,
               

            };
            Database.Formofstudy.Create(formofstudy);
            Database.Save();
        }

        public void Update(ФормаОбученияDTO item)
        {
            ФормаОбучения formofstudy = new ФормаОбучения
            {
                Код_ФормаОбуения=item.Код_ФормаОбуения,
                Форма_Обучения = item.Форма_Обучения


            };
            Database.Formofstudy.Update(formofstudy);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Formofstudy.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
