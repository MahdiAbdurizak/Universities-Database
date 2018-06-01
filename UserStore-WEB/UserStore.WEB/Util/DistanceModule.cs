using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distance.BLL.Interfaces;
using Distance.BLL.Services;

namespace Distance.WEB.Util
{
    public class DistanceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IСпециальностиService>().To<СпециальностиService>();
            Bind<IУниверситетыService>().To<УниверситетыService>();
            Bind<IУровеньОбученияService>().To<УровеньОбученияService>();
            Bind<IФормаОбученияService>().To<ФормаОбученияService>();
            

        }
    }
}