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
    [RoutePrefix("api/questionCategory")]
    public class QuestionCategoryController : ApiControllerBase
    {
        private IQuestionCategoryService _questionCategoryService;

        public QuestionCategoryController(IErrorService errorService, IQuestionCategoryService questionCategoryService) :
            base(errorService)
        {
            this._questionCategoryService = questionCategoryService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _questionCategoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.QuestionCategoryName).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<QuestionCategory>, IEnumerable<QuestionCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<QuestionCategoryViewModel>()
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

        [Route("getAllQuestion")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _questionCategoryService.GetAll();

                var responseData = Mapper.Map<IEnumerable<QuestionCategory>, IEnumerable<QuestionCategoryViewModel>>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _questionCategoryService.GetById(id);
                var responseData = Mapper.Map<QuestionCategory, QuestionCategoryViewModel>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, QuestionCategoryViewModel questionCategoryVm)
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
                    var newQuestionCategory = new QuestionCategory();


                    newQuestionCategory.UpdateQuestionCategory(questionCategoryVm);

                    var questionCategory = _questionCategoryService.Add(newQuestionCategory);

                    _questionCategoryService.Save();
                   
                    var responseData = Mapper.Map<QuestionCategory, QuestionCategoryViewModel>(questionCategory);

                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }
                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, QuestionCategoryViewModel questionCategoryVm)
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
                    var questionCategoryDb = _questionCategoryService.GetById(questionCategoryVm.QuestionCategoryId);
                    questionCategoryDb.UpdateQuestionCategory(questionCategoryVm);
                    _questionCategoryService.Update(questionCategoryDb);
                    _questionCategoryService.Save();

                    var responseData = Mapper.Map<QuestionCategory, QuestionCategoryViewModel>(questionCategoryDb);
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
                    var questionCategoryOld = _questionCategoryService.Delete(id);
                    _questionCategoryService.Save();

                    var responseData = Mapper.Map<QuestionCategory, QuestionCategoryViewModel>(questionCategoryOld);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}
