using AutoMapper;
using Distance.BLL.DTO;
using Distance.BLL.Infrastructure;
using Distance.BLL.Interfaces;
using Distance.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distance.WEB.Controllers
{
    public class ФормаОбученияController : Controller
    {
        IФормаОбученияService _ФормаОбученияService;

        public ФормаОбученияController(IФормаОбученияService Formserv)
        {

            _ФормаОбученияService = Formserv;
        }
        // GET: ФормаОбучения
        public ActionResult Index()
        {
            IEnumerable<ФормаОбученияDTO> FormofstudyDtos = _ФормаОбученияService.GetAll();
            var Formofstudy = Mapper.Map<IEnumerable<ФормаОбученияDTO>, List<ФормаОбученияViewModel>>(FormofstudyDtos);

            return View(Formofstudy.ToList());
        }

        public ActionResult Details(int? id)
        {
            try
            {
                ФормаОбученияDTO FormofstudyDtos = _ФормаОбученияService.Get(id);

                var Formofstudy = Mapper.Map<ФормаОбученияDTO, ФормаОбученияViewModel>(FormofstudyDtos);
                return View(Formofstudy);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ФормаОбученияViewModel Formofstudy)
        {
            try
            {
                var FormofstudyDtos = Mapper.Map<ФормаОбученияViewModel, ФормаОбученияDTO>(Formofstudy);
                _ФормаОбученияService.Create(FormofstudyDtos);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(Formofstudy);
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                ФормаОбученияDTO FormofstudyDto = _ФормаОбученияService.Get(id);

                var Formofstudy = Mapper.Map<ФормаОбученияDTO, ФормаОбученияViewModel>(FormofstudyDto);
                return View(Formofstudy);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Edit(ФормаОбученияViewModel Formofstudy)
        {
            try
            {
                var FormofstudyDto = Mapper.Map<ФормаОбученияViewModel, ФормаОбученияDTO>(Formofstudy);
                _ФормаОбученияService.Update(FormofstudyDto);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(Formofstudy);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                ФормаОбученияDTO FormofstudyDto = _ФормаОбученияService.Get(id);

                var Formofstudy = Mapper.Map<ФормаОбученияDTO, ФормаОбученияViewModel>(FormofstudyDto);
                return View(Formofstudy);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)

        {
            try
            {

                _ФормаОбученияService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            //return View(FormofstudyDto);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

            _ФормаОбученияService.Dispose();

            base.Dispose(disposing);
        }
    }
}