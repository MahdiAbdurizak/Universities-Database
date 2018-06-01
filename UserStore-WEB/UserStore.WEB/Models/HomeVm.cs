using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Distance.BLL.DTO;
using Distance.WEB.Models;

namespace Distance.WEB.Models
{
    public class HomeVm
    {
        public IEnumerable<СпециальностиDTO> Specialties { get; set; }
        public IEnumerable<УниверситетыDTO> Universities { get; set; }
        public IEnumerable<СпециальностиViewModel> Specialties2 { get; set; }
        public IEnumerable<УниверситетыViewModel> Universities2 { get; set; }


    }
}