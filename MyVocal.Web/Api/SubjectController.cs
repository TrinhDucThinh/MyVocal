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
    }
}
