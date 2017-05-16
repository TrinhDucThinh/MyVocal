using AutoMapper;
using MyVocal.Model.Models;
using MyVocal.Service;
using MyVocal.Web.Api;
using MyVocal.Web.Infrastructure.Core;
using MyVocal.Web.Infrastructure.Extensions;
using MyVocal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static MyVocal.Service.SubjectGroupService;

namespace MyVocal.Web.Api
{
    [RoutePrefix("api/subjectGroup")]
    public class SubjectGroupController : ApiControllerBase
    {
        #region Initialize

        private ISubjectGroupService _subjectGroupService;
   
        public SubjectGroupController(IErrorService errorService, ISubjectGroupService subjectGroupService) :
            base(errorService)
        {
            this._subjectGroupService = subjectGroupService;
        }

        #endregion Initialize

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _subjectGroupService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.SubjectGroupId).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<SubjectGroup>, IEnumerable<SubjectGroupViewModel>>(query);

                var paginationSet = new PaginationSet<SubjectGroupViewModel>()
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

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _subjectGroupService.GetById(id);
                var responseData = Mapper.Map<SubjectGroup, SubjectGroupViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, SubjectGroupViewModel SubjectGroupVm)
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
                    var newSubjectGroup = new SubjectGroup();

                    newSubjectGroup.UpdateSubjectGroup(SubjectGroupVm);

                    var category = _subjectGroupService.Add(newSubjectGroup);

                    _subjectGroupService.Save();
                    //generate Id for SubjectGroup and send to client
                    var responseData = Mapper.Map<SubjectGroup, SubjectGroupViewModel>(newSubjectGroup);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, SubjectGroupViewModel SubjectGroupVm)
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
                    var SubjectGroupDb = _subjectGroupService.GetById(SubjectGroupVm.SubjectGroupId);
                    SubjectGroupDb.UpdateSubjectGroup(SubjectGroupVm);
                    _subjectGroupService.Update(SubjectGroupDb);
                    _subjectGroupService.Save();

                    var responseData = Mapper.Map<SubjectGroup, SubjectGroupViewModel>(SubjectGroupDb);
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
                    var oldSubjectGroup = _subjectGroupService.Delete(id);
                    _subjectGroupService.Save();

                    var responseData = Mapper.Map<SubjectGroup, SubjectGroupViewModel>(oldSubjectGroup);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}
