using AutoMapper;
using MyVocal.Model.Models;
using MyVocal.Service;
using MyVocal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyVocal.Web.Controllers
{
    public class WordController : Controller
    {
        IWordService _wordService;

        public WordController(IWordService workService)
        {
            this._wordService = workService;
        }

        public ActionResult Test()
        {
            return View();
        }
        // GET: Word
        public ActionResult LearnTopic()
        {
            return View();
        }
        
        

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
    }
}