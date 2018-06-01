using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Distance.BLL.Interfaces;
using Distance.BLL.DTO;
using Distance.WEB.Models;
using AutoMapper;
using Distance.BLL.Infrastructure;
using Distance.BLL.Services;

namespace Distance.WEB.Controllers
{
    public class HomeController : Controller
    {
        //IOrderService orderService;
        //IServicesService _servicesService;
        //IRecentWorkService _recentWorkService;
        IУниверситетыService _УниверситетыService;
        IСпециальностиService _СпециальностиService;
        //public HomeController(IУниверситетыService serv)
        //{
        //    _УниверситетыService = serv;
        //}

        public HomeController(IУниверситетыService univserv, IСпециальностиService spserv)
        {
            _УниверситетыService = univserv;
            _СпециальностиService = spserv;
        }
        public ActionResult Index()
        {
            IEnumerable<УниверситетыDTO> UnivDtos = _УниверситетыService.GetAll();
            //Mapper.Initialize(cfg => cfg.CreateMap<PhoneDTO, PhoneViewModel>());
            var Universities = Mapper.Map<IEnumerable<УниверситетыDTO>, List<УниверситетыViewModel>>(UnivDtos);
            return View(Universities);
            //var vm = new HomeVm()
            //{
            //    Universities = _УниверситетыService.GetAll(),
            //    Specialties = _СпециальностиService.GetAll(),


            //};
            //var vm2 = new HomeVm()
            //{
            //    Universities2 = Mapper.Map<IEnumerable<УниверситетыDTO>, List<УниверситетыViewModel>>(vm.Universities),
            //    Specialties2 = Mapper.Map<IEnumerable<СпециальностиDTO>, List<СпециальностиViewModel>>(vm.Specialties)

            //};
            // IEnumerable<ServiceDTO> OurServices = _servicesService.GetAll();
            //var Services = Mapper.Map<IEnumerable<ServiceDTO>, List<ServiceViewModel>>(OurServices);

            //return View(vm2);
        }

        public ActionResult Specialties(int? id)
        {
            try
            {
                 СпециальностиDTO Special = _СпециальностиService.Get(id);

                var Specialties2 = Mapper.Map<СпециальностиDTO,СпециальностиViewModel>(Special);
                return View(Specialties2);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }

        }
        public ActionResult AllSpecialties()
        {
            try
            {
                IEnumerable<СпециальностиDTO> Specialties = _СпециальностиService.GetAll();

                var Specialties2 = Mapper.Map<IEnumerable<СпециальностиDTO>, List<СпециальностиViewModel>>(Specialties);
                return View(Specialties2);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }

        }



        //public ActionResult MakeOrder(int? id)
        //{
        //    try
        //    {
        //        PhoneDTO phone = orderService.GetPhone(id);

        //        var order = Mapper.Map<PhoneDTO, OrderViewModel>(phone);
        //        return View(order);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return Content(ex.Message);
        //    }
        //}
        //[HttpPost]
        //public ActionResult MakeOrder(OrderViewModel order)
        //{
        //    try
        //    {
        //        //Mapper.Initialize(cfg => cfg.CreateMap<OrderViewModel, OrderDTO>());
        //        var orderDto = Mapper.Map<OrderViewModel, OrderDTO>(order);
        //        orderService.MakeOrder(orderDto);
        //        return Content("<h2>Ваш заказ успешно оформлен</h2>");
        //    }
        //    catch (ValidationException ex)
        //    {
        //        ModelState.AddModelError(ex.Property, ex.Message);
        //    }
        //    return View(order);
        //}
        protected override void Dispose(bool disposing)
        {
            // orderService.Dispose();
            //_servicesService.Dispose();
            //_recentWorkService.Dispose();
            _УниверситетыService.Dispose();
            _СпециальностиService.Dispose();
            base.Dispose(disposing);
        }
    }
}