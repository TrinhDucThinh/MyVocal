using AutoMapper;
using MyVocal.Data.Infrastructure;
using MyVocal.Model.Models;
using MyVocal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using static MyVocal.Service.SubjectGroupService;

namespace MyVocal.Web.Controllers
{
    public class LibraryController : Controller
    {
        ISubjectGroupService _subjectGroupService;

        public LibraryController(ISubjectGroupService subjectGroupService)
        {
            this._subjectGroupService = subjectGroupService;
        }
        // GET: Library
        public ActionResult Index()
        {
            ViewBag.pathServer = WebConfigurationManager.AppSettings["location"];
            var listSubjectGroup=_subjectGroupService.GetAll();
            var listSubjectGroupViewModel = Mapper.Map<IEnumerable<SubjectGroup>, IEnumerable<SubjectGroupViewModel>>(listSubjectGroup);
            
            return View(listSubjectGroupViewModel);
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}