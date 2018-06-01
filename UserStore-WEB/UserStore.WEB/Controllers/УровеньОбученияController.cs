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
    public class УровеньОбученияController : Controller
    {
        IУровеньОбученияService _УровеньОбученияService;

        public УровеньОбученияController(IУровеньОбученияService levserv)
        {

            _УровеньОбученияService = levserv;
        }
        // GET: УровеньОбучения
        public ActionResult Index()
        {
            IEnumerable<УровеньОбученияDTO> LevelofstudyDtos = _УровеньОбученияService.GetAll();
            var Levelofstudy = Mapper.Map<IEnumerable<УровеньОбученияDTO>, List<УровеньОбученияViewModel>>(LevelofstudyDtos);

            return View(Levelofstudy.ToList());
        }

        public ActionResult Details(int? id)
        {
            try
            {
                УровеньОбученияDTO LevelofstudyDto = _УровеньОбученияService.Get(id);

                var Levelofstudy = Mapper.Map<УровеньОбученияDTO, УровеньОбученияViewModel>(LevelofstudyDto);
                return View(Levelofstudy);
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
        public ActionResult Create(УровеньОбученияViewModel Levelofstudy)
        {
            try
            {
                var LevelofstudyDto = Mapper.Map<УровеньОбученияViewModel, УровеньОбученияDTO>(Levelofstudy);
                _УровеньОбученияService.Create(LevelofstudyDto);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(Levelofstudy);
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                УровеньОбученияDTO LevelofstudyDto = _УровеньОбученияService.Get(id);

                var Levelofstudy = Mapper.Map<УровеньОбученияDTO, УровеньОбученияViewModel>(LevelofstudyDto);
                return View(Levelofstudy);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }


        [HttpPost]
        public ActionResult Edit(УровеньОбученияViewModel Levelofstudy)
        {
            try
            {
                var LevelofstudyDto = Mapper.Map<УровеньОбученияViewModel, УровеньОбученияDTO>(Levelofstudy);
                _УровеньОбученияService.Update(LevelofstudyDto);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            return View(Levelofstudy);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                УровеньОбученияDTO LevelofstudyDto = _УровеньОбученияService.Get(id);

                var Levelofstudy = Mapper.Map<УровеньОбученияDTO, УровеньОбученияViewModel>(LevelofstudyDto);
                return View(Levelofstudy);
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
               
                _УровеньОбученияService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            //return View(LevelofstudyDto);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            
            _УровеньОбученияService.Dispose();
            
            base.Dispose(disposing);
        }


    }

}
