using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distance.BLL.Interfaces;
using Distance.BLL.Services;

[assembly: OwinStartup(typeof(UserStore.WEB.App_Start.Startup))]
namespace UserStore.WEB.App_Start
{
    public class Startup
    {
        
        public void Configuration(IAppBuilder app)
        {
           
        }

      

    }

}
