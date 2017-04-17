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
    public class TopicController : Controller
    {
        ISubjectService _subjectService;

        public TopicController(ISubjectService subjectService)
        {
            this._subjectService = subjectService;
        }

        public JsonResult LoadAllTopic(int groupId,int page, int pageSize = 3)
        {
            int totalRow = 0;
            IEnumerable<Subject> listTopic=null;
            try
            {
                listTopic = _subjectService.GetByGroupId(groupId, page, pageSize, out totalRow);
               
            }catch(Exception ex)
            {
                string ex2 = ex.ToString();
            }

            var listSubjectViewModel = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(listTopic);
            return Json(new {
                 data= listSubjectViewModel,
                 total=totalRow,
                 status=true
            },JsonRequestBehavior.AllowGet);
        }


        // GET: Topic
        public ActionResult Index()
        {
            return View();
        }


    }
}