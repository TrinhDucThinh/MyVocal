using AutoMapper;
using MyVocal.Model.Models;
using MyVocal.Service;
using MyVocal.Web.Infrastructure.Core;
using MyVocal.Web.Infrastructure.Extensions;
using MyVocal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyVocal.Web.Api
{
    [RoutePrefix("api/question")]
    public class QuestionController : ApiControllerBase
    {
        #region Initialize

        private IQuestionService _questionService;

        public QuestionController(IErrorService errorService, IQuestionService questionService) :
            base(errorService)
        {
            this._questionService = questionService;
        }

        #endregion Initialize

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _questionService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.QuestionId).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(query);

                var paginationSet = new PaginationSet<QuestionViewModel>()
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
                var model = _questionService.GetById(id);
                var responseData = Mapper.Map<Question, QuestionViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, QuestionViewModel questionVm)
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
                    var newQuestion = new Question();

                    newQuestion.UpdateQuestion(questionVm);

                    var category = _questionService.Add(newQuestion);

                    _questionService.Save();
                    //generate Id for Question and send to client
                    var responseData = Mapper.Map<Question, QuestionViewModel>(newQuestion);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, QuestionViewModel questionVm)
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
                    var questionDb = _questionService.GetById(questionVm.QuestionId);
                    questionDb.UpdateQuestion(questionVm);
                    _questionService.Update(questionDb);
                    _questionService.Save();

                    var responseData = Mapper.Map<Question, QuestionViewModel>(questionDb);
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
                    var oldQuestion = _questionService.Delete(id);
                    _questionService.Save();

                    var responseData = Mapper.Map<Question, QuestionViewModel>(oldQuestion);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}