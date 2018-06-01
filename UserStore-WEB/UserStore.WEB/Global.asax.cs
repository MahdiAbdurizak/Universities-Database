using AutoMapper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Distance.BLL.DTO;
using Distance.BLL.Infrastructure;
using Distance.WEB.Models;
using Distance.WEB.Util;

namespace Distance.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);


            //AutoMapperConfig.Initialize();
            AutoMapperConfig2.Initialize();
            // внедрение зависимостей
            NinjectModule distanceModule = new DistanceModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(distanceModule, serviceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }


        public class AutoMapperConfig2
        {
            public static void Initialize()
            {
                Mapper.Initialize(cfg =>
                {
                    //cfg.CreateMap<УниверситетыDTO, УниверситетыViewModel>()
                    //.ForMember("Код_Специальности", opt => opt.MapFrom(src => src.специальности));
                    cfg.CreateMap<СпециальностиDTO, СпециальностиViewModel>()
                    .ForMember("Код_Форма_Обуения", opt => opt.MapFrom(src => src.Код_ФормаОбуения))
                      .ForMember("Код_Уровень_Обуения", opt => opt.MapFrom(src => src.Код_УровеньОбуения)); 
                    cfg.CreateMap<СпециальностиViewModel, СпециальностиDTO>()
                    .ForMember("Код_ФормаОбуения", opt => opt.MapFrom(src => src.Код_Форма_Обуения))
                    .ForMember("Код_УровеньОбуения", opt => opt.MapFrom(src => src.Код_Уровень_Обуения));
                   
                   // cfg.CreateMap<УниверситетыViewModel, УниверситетыDTO>()
                   //.ForMember("специальности", opt => opt.MapFrom(src => src.Код_Специальности));
                });

            }
        }


    }
}


