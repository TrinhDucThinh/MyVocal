using AutoMapper;
using MyVocal.Model.Models;
using MyVocal.Service;
using MyVocal.Web.Infrastructure.Core;
using MyVocal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyVocal.Web.Api
{
    [RoutePrefix("api/subject")]
    public class SubjectController : ApiControllerBase
    {
        private ISubjectService _subjectService;

        public SubjectController(IErrorService errorService, ISubjectService subjectService) : base(errorService)
        {
            this._subjectService = subjectService;
        }

        [Route("getallSubject")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _subjectService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getAll")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _subjectService.GetAll(keyword);
                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.SubjectId).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(query);
                var paginationSet = new PaginationSet<SubjectViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        //get word detail by Id
        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _subjectService.GetById(id);
                var responseData = Mapper.Map<Subject, SubjectViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        //get all word in a subject by subject id
        [Route("getAllBySubjectGroupId/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetAllBySubjectGroupId(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _subjectService.GetAllBySubjectId(id);
                var query = model.OrderByDescending(x => x.SubjectName);
                var responseData = Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(query);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
        //Create a word
        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, SubjectViewModel subjectVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newSubject = new Subject();
                    newSubject.SubjectId = subjectVm.SubjectId;
                    newSubject.SubjectName = subjectVm.SubjectName;
                    newSubject.Description = subjectVm.Description;
                    newSubject.SubjectGroupId = subjectVm.SubjectGroupId;
                    var result = _subjectService.Add(newSubject);
                    try
                    {
                        _subjectService.Save();
                    }
                    catch(Exception ex)
                    {
                      
                    }
                  

                    //generate Id for Word and send to client
                    var responseData = Mapper.Map<Subject, SubjectViewModel>(result);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, SubjectViewModel subjectVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newSubject = _subjectService.GetById(subjectVm.SubjectId);
                    newSubject.SubjectId = subjectVm.SubjectId;
                    newSubject.SubjectName = subjectVm.SubjectName;
                    newSubject.Description = subjectVm.Description;
                    var result = _subjectService.Add(newSubject);
                    _subjectService.Save();

                    var responseData = Mapper.Map<Subject, SubjectViewModel>(newSubject);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldSubject= _subjectService.Delete(id);
                    _subjectService.Save();

                    var responseData = Mapper.Map<Subject, SubjectViewModel>(oldSubject);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

    }
}
