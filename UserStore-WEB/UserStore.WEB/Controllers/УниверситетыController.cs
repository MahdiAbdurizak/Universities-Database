using AutoMapper;
using Distance.BLL.DTO;
using Distance.BLL.Infrastructure;
using Distance.BLL.Interfaces;
using Distance.WEB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Distance.WEB.Controllers
{
    public class УниверситетыController : Controller
    {
        IСпециальностиService _СпециальностиService;
        IУниверситетыService _УниверситетыService;


        public УниверситетыController(IСпециальностиService spserv, IУниверситетыService univserv)
        {

            _СпециальностиService = spserv;
            _УниверситетыService = univserv;

        }

        // GET: Университеты
        public ActionResult Index()
        {
            IEnumerable<УниверситетыDTO> UnivDtos = _УниверситетыService.GetAll();
            var Universities = Mapper.Map<IEnumerable<УниверситетыDTO>, List<УниверситетыViewModel>>(UnivDtos);
            return View(Universities);
        }

        public ActionResult Create()
        {
            ViewBag.Код_Специальности = new SelectList(_СпециальностиService.GetAll(), "Код_Специальности", "Специальность");


            return View();
        }

        [HttpPost]
        public ActionResult Create(УниверситетыViewModel Universities, HttpPostedFileBase upload)
        {




            try
            {
                string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                upload.SaveAs(path);
                Universities.URLизображения = "/images/"+ upload.FileName;
                var UnivDtos = Mapper.Map<УниверситетыViewModel, УниверситетыDTO>(Universities);
                _УниверситетыService.Create(UnivDtos);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            //ViewBag.Код_Специальности = new SelectList(_СпециальностиService.GetAll(), "Код_Специальности", "Специальность", Universities.Код_Специальности);



            return View(Universities);
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                УниверситетыDTO UnivDtos = _УниверситетыService.Get(id);
                var University = Mapper.Map<УниверситетыDTO, УниверситетыViewModel>(UnivDtos);
                ViewBag.Код_Специальности = new SelectList(_СпециальностиService.GetAll(), "Код_Специальности", "Специальность");

                return View(University);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(УниверситетыViewModel University, HttpPostedFileBase upload)
        {
            try
            {
                string oldpath = Server.MapPath("~"+ University.URLизображения);
                if (upload != null)
                {
                    System.IO.File.Delete(oldpath); // delete the old file
                    string path = Path.Combine(Server.MapPath("~/images"), upload.FileName);
                    upload.SaveAs(path);
                    University.URLизображения = "/images/" + upload.FileName; //add pic in the data base

                }


                var UnivDtos = Mapper.Map<УниверситетыViewModel, УниверситетыDTO>(University);
                _УниверситетыService.Update(UnivDtos);

                return RedirectToAction("Index");
                
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            ViewBag.Код_Специальности = new SelectList(_СпециальностиService.GetAll(), "Код_Специальности", "Специальность");


            return View(University);

        }
        public ActionResult Delete(int? id)
        {
            try
            {
                УниверситетыDTO UnivDtos = _УниверситетыService.Get(id);

                var University = Mapper.Map<УниверситетыDTO, УниверситетыViewModel>(UnivDtos);
                return View(University);
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

                _УниверситетыService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }

            //return View(LevelofstudyDto);
            return RedirectToAction("Index");
        }
    }
}