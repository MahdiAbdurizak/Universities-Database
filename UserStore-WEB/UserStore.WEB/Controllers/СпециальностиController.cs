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
    public class СпециальностиController : Controller
    {
        IСпециальностиService _СпециальностиService;
        IУровеньОбученияService _УровеньОбученияService;
        IФормаОбученияService _ФормаОбученияService;
        IУниверситетыService _УниверситетыService;

        public СпециальностиController(IСпециальностиService spserv, IУровеньОбученияService levserv, IФормаОбученияService Formserv , IУниверситетыService univserv)
        {

            _СпециальностиService = spserv;
            _УровеньОбученияService = levserv;
            _ФормаОбученияService = Formserv;
            _УниверситетыService = univserv;
        }

        // GET: Специальности
        public ActionResult Index()
        {
            IEnumerable<СпециальностиDTO> SpicalDtos = _СпециальностиService.GetAll();
            var Specialties = Mapper.Map<IEnumerable<СпециальностиDTO>, List<СпециальностиViewModel>>(SpicalDtos);

            return View(Specialties);
        }

        public ActionResult Create()
        {
            ViewBag.Код_Уровень_Обуения = new SelectList(_УровеньОбученияService.GetAll(), "Код_УровеньОбуения", "Уровень_Обучения");
            ViewBag.Код_Форма_Обуения = new SelectList(_ФормаОбученияService.GetAll(), "Код_ФормаОбуения", "Форма_Обучения");
            ViewBag.Код_Университета = new SelectList(_УниверситетыService.GetAll(), "Код_Университета", "Университет");

            return View();
        }
        [HttpPost]
        public ActionResult Create(СпециальностиViewModel Special)
        {
            try
            {


                var SpicalDto = Mapper.Map<СпециальностиViewModel, СпециальностиDTO>(Special);
                
                _СпециальностиService.Create(SpicalDto);

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            ViewBag.Код_Уровень_Обуения = new SelectList(_УровеньОбученияService.GetAll(), "Код_УровеньОбуения", "Уровень_Обучения", Special.Код_Уровень_Обуения);
            ViewBag.Код_Форма_Обуения = new SelectList(_ФормаОбученияService.GetAll(), "Код_ФормаОбуения", "Форма_Обучения", Special.Код_Форма_Обуения);
            ViewBag.Код_Университета = new SelectList(_УниверситетыService.GetAll(), "Код_Университета", "Университет");


            return View(Special);
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                СпециальностиDTO SpicalDto = _СпециальностиService.Get(id);
                var Specialty = Mapper.Map<СпециальностиDTO, СпециальностиViewModel>(SpicalDto);
                ViewBag.Код_Уровень_Обуения = new SelectList(_УровеньОбученияService.GetAll(), "Код_УровеньОбуения", "Уровень_Обучения");
                ViewBag.Код_Форма_Обуения = new SelectList(_ФормаОбученияService.GetAll(), "Код_ФормаОбуения", "Форма_Обучения");
                return View(Specialty);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Edit(СпециальностиViewModel Special)
        {
            try
            {


                var SpicalDto = Mapper.Map<СпециальностиViewModel, СпециальностиDTO>(Special);
                _СпециальностиService.Update(SpicalDto);

                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            ViewBag.Код_Уровень_Обуения = new SelectList(_УровеньОбученияService.GetAll(), "Код_УровеньОбуения", "Уровень_Обучения", Special.Код_Уровень_Обуения);
            ViewBag.Код_Форма_Обуения = new SelectList(_ФормаОбученияService.GetAll(), "Код_ФормаОбуения", "Форма_Обучения", Special.Код_Форма_Обуения);


            return View(Special);

        }

        public ActionResult Delete(int? id)
        {
            try
            {
                СпециальностиDTO SpicalDto = _СпециальностиService.Get(id);

                var Specialty = Mapper.Map<СпециальностиDTO, СпециальностиViewModel>(SpicalDto);
                return View(Specialty);
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

                _СпециальностиService.Delete(id);
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
            _СпециальностиService.Dispose();
            _УровеньОбученияService.Dispose();
            _ФормаОбученияService.Dispose();
            _УниверситетыService.Dispose();

            base.Dispose(disposing);
        }

    }
}