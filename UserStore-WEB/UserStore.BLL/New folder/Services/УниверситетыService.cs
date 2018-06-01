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
   public class УниверситетыService : IУниверситетыService
    {
        IUnitOfWork Database { get; set; }
        public УниверситетыService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<УниверситетыDTO> GetAll()
        {
            return Mapper.Map<IEnumerable<Университеты>, List<УниверситетыDTO>>(Database.Universities.GetAll());
        }



        public УниверситетыDTO Get(int? id)
        {
            if (id == null)
                throw new Infrastructure.ValidationException("Не установлено id телефона", "");
            var University = Database.Universities.Get(id.Value);
            if (University == null)
                throw new Infrastructure.ValidationException("Телефон не найден", "");
            // применяем автомаппер для проекции Phone на PhoneDTO
            //    Mapper.Initialize(cfg => cfg.CreateMap<Phone, PhoneDTO>());
            return Mapper.Map<Университеты, УниверситетыDTO>(University);
        }

        //public IEnumerable<ClientCommentDTO> Find(Func<ClientCommentDTO, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //    //var repository = new MyRepository<Person>();
        //    // var personsOlderThan50 = repository.FindAll(p => p.Age > 50);
        //    //examp of ("https://stackoverflow.com/questions/11143602/possible-ways-to-use-func-t-bool-while-using-a-linq-repository ")
        //}

        public void Create(УниверситетыDTO item)
        {
            Специальности специальности = Database.Specialties.Get(item.специальности);
            List<Специальности> _специальности = new List<Специальности>();
             _специальности.Add(специальности);

            {
                Университеты University = new Университеты
                {
                  
                    Университет = item.Университет,
                    URLизображения = item.URLизображения,
                    город = item.город,
                    специальности = _специальности,


                };

                Database.Universities.Create(University);
                Database.Save();
            }
        }

        public void Update(УниверситетыDTO item)
        {
            Специальности специальности = Database.Specialties.Get(item.специальности);
            List<Специальности> _специальности = new List<Специальности>();
            _специальности.Add(специальности);
            Университеты University = new Университеты
            {
                Код_Университета=item.Код_Университета,
                специальности = _специальности,
                Университет = item.Университет ,
                URLизображения = item.URLизображения,
                город =item.город
                

            };
            Database.Universities.Update(University);
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Universities.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
