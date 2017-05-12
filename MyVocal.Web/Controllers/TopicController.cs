using AutoMapper;
using MyVocal.Model.Models;
using MyVocal.Service;
using MyVocal.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyVocal.Web.Controllers
{
    public class TopicController : Controller
    {
        private ISubjectService _subjectService;
        private IWordService _wordService;
        //Contructor
        public TopicController(ISubjectService subjectService, IWordService wordService)
        {
            this._subjectService = subjectService;
            this._wordService = wordService;
        }
        //Return all Subject in a subjectGroup as json
        public JsonResult LoadAllTopic(int groupId, int pageIndex = 1, int pageSize = 8)
        {
            int totalRow = 0;
            IEnumerable<Subject> listTopic = null;
            try
            {
                listTopic = _subjectService.GetByGroupId(groupId, pageIndex, pageSize, out totalRow);
            }
            catch (Exception ex)
            {
                string ex2 = ex.ToString();
            }

            var listSubjectViewModel = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(listTopic);
            return Json(new
            {
                data = listSubjectViewModel,
                total = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        // GET: Topic
        public ActionResult Index(int groupId)
        {
            ViewBag.GroupId = groupId;
            return View();
        }

        ///

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