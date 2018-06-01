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
   public class СпециальностиService : IСпециальностиService
    {
        IUnitOfWork Database { get; set; }
        public СпециальностиService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<СпециальностиDTO> GetAll()
        {

            return Mapper.Map<IEnumerable<Специальности>, List<СпециальностиDTO>>(Database.Specialties.GetAll());
        }



        public СпециальностиDTO Get(int? id)
        {
            if (id == null)
                throw new Infrastructure.ValidationException("Не установлено id телефона", "");
            var Specialty = Database.Specialties.Get(id.Value);
            if (Specialty == null)
                throw new Infrastructure.ValidationException("Телефон не найден", "");
            // применяем автомаппер для проекции Phone на PhoneDTO
            //    Mapper.Initialize(cfg => cfg.CreateMap<Phone, PhoneDTO>());
            return Mapper.Map<Специальности, СпециальностиDTO>(Specialty);
        }

        //public IEnumerable<ClientCommentDTO> Find(Func<ClientCommentDTO, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //    //var repository = new MyRepository<Person>();
        //    // var personsOlderThan50 = repository.FindAll(p => p.Age > 50);
        //    //examp of ("https://stackoverflow.com/questions/11143602/possible-ways-to-use-func-t-bool-while-using-a-linq-repository ")
        //}

        public void Create(СпециальностиDTO item)
        {
            Специальности Specialty = new Специальности
            {

                 Код_Направление=item.Код_Направление,
                 Направление = item.Направление,
                 Профиль = item.Профиль,
                 Сокр_название = item.Сокр_название,
                 Язык_Обуения = item.Язык_Обуения,                
                 Код_УровеньОбуения= item.Код_УровеньОбуения,
                 Код_ФормаОбуения=item.Код_ФормаОбуения ,
                 Код_Университета = item.Код_Университета



            };
            Database.Specialties.Create(Specialty);
            Database.Save();
        }

        public void Update(СпециальностиDTO item)
        {
            Специальности Specialty = new Специальности
            {
                
                Код_Направление = item.Код_Направление,
                Направление = item.Направление,
                Профиль = item.Профиль,
                Сокр_название = item.Сокр_название,
                Язык_Обуения = item.Язык_Обуения,
                Код_УровеньОбуения = item.Код_УровеньОбуения,
                Код_ФормаОбуения = item.Код_ФормаОбуения,
                Код_Университета = item.Код_Университета

            };
            Database.Specialties.Update(Specialty);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Specialties.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
