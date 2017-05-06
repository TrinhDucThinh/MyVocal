using MyVocal.Model.Models;
using MyVocal.Service;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyVocal.Web.Controllers
{
    public class WordController : Controller
    {
        private IWordService _wordService;
        //Contructor
        public WordController(IWordService workService)
        {
            this._wordService = workService;
        }
        //Learn and practise word in a subject
        public ActionResult LearnTopic(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        //Get all word in a subject and return result is json array
        public JsonResult ListAllBySubjectId(int SubjectId)
        {
            bool status = false;
            IEnumerable<Word> listWord = null;
            try
            {
                listWord = _wordService.GetAllBySubjectId(SubjectId);
                status = true;
            }
            catch (Exception ex)
            {
                string ex2 = ex.ToString();
                status = false;
            }

            //var listWordViewModel = Mapper.Map<IEnumerable<Word>, IEnumerable<WordViewModel>>(listWord);
            return Json(new
            {
                data = listWord,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }
        //Test word in a Subject(Topic)
        public ActionResult TestTopic(int id)
        {
            ViewBag.Id = id;
            return View();
        }

    }
}